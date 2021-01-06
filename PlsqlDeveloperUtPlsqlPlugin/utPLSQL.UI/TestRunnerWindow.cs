using Equin.ApplicationFramework;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace utPLSQL
{
    public partial class TestRunnerWindow : Form
    {
        public bool Running { get; private set; }

        private const int IconSize = 24;
        private const int Steps = 1000;

        private readonly RealTimeTestRunner testRunner;
        private readonly object pluginIntegration;
        private readonly string username;
        private readonly string password;
        private readonly string database;
        private readonly string connectAs;

        private readonly List<TestResult> testResults = new List<TestResult>();
        private BindingListView<TestResult> viewTestResults;

        private int totalNumberOfTests;
        private int rowIndexOnRightClick;
        private int completedTests;

        public TestRunnerWindow(object pluginIntegration, string username, string password, string database, string connectAs)
        {
            this.pluginIntegration = pluginIntegration;
            this.username = username;
            this.password = password;
            this.database = database;
            this.connectAs = connectAs;

            testRunner = new RealTimeTestRunner();
            testRunner.Connect(username, password, database);

            InitializeComponent();

            viewTestResults = new BindingListView<TestResult>(testResults);
            gridResults.DataSource = viewTestResults;

            gridResults.Columns[0].HeaderText = "";
            gridResults.Columns[0].MinimumWidth = 30;
            gridResults.Columns[1].MinimumWidth = 235;
            gridResults.Columns[2].MinimumWidth = 600;
            gridResults.Columns[3].MinimumWidth = 100;
            gridResults.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public async Task RunTestsAsync(string type, string owner, string name, string procedure, bool coverage)
        {
            ResetComponents();

            testResults.Clear();

            SetWindowTitle(type, owner, name, procedure);

            try
            {
                testRunner.GetVersion();
            }
            catch
            {
                MessageBox.Show("utPLSQL is not installed", "utPLSQL not installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Running = true;

            if (coverage)
            {
                var codeCoverageReportDialog = new CodeCoverageReportDialog(GetPath(type, owner, name, procedure));
                var dialogResult = codeCoverageReportDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    Show();

                    var schemas = ConvertToList(codeCoverageReportDialog.GetSchemas());
                    var includes = ConvertToList(codeCoverageReportDialog.GetIncludes());
                    var excludes = ConvertToList(codeCoverageReportDialog.GetExcludes());

                    completedTests = 0;

                    txtStatus.Text = "Running tests with coverage...";

                    var htmlReport = await testRunner.RunTestsWithCoverageAsync(GetPath(type, owner, name, procedure), CollectResults(coverage), schemas, includes, excludes);

                    var filePath = $"{Path.GetTempPath()}\\utPLSQL_Coverage_Report_{Guid.NewGuid()}.html";
                    using (var sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine(htmlReport);
                    }

                    txtStatus.BeginInvoke((MethodInvoker)delegate
                    {
                        txtStatus.Text = totalNumberOfTests > 0 ? "Finished" : "No tests found";
                    });

                    Running = false;

                    System.Diagnostics.Process.Start(filePath);
                }
            }
            else
            {
                Show();

                completedTests = 0;

                txtStatus.Text = "Running tests...";

                await testRunner.RunTestsAsync(GetPath(type, owner, name, procedure), CollectResults(coverage));
            }
        }

        private Action<@event> CollectResults(bool coverage)
        {
            return @event =>
            {
                if (@event.type.Equals("pre-run"))
                {
                    gridResults.BeginInvoke((MethodInvoker)delegate
                    {
                        txtStatus.Text = "Running tests...";

                        totalNumberOfTests = @event.totalNumberOfTests;

                        progressBar.Minimum = 0;
                        progressBar.Maximum = totalNumberOfTests * Steps;
                        progressBar.Step = Steps;

                        CreateTestResults(@event);
                        viewTestResults = new BindingListView<TestResult>(testResults);
                        gridResults.DataSource = viewTestResults;

                        if (gridResults.Rows.Count > 0)
                        {
                            gridResults.Rows[0].Selected = false;
                        }
                    });
                }
                else if (@event.type.Equals("post-test"))
                {
                    gridResults.BeginInvoke((MethodInvoker)delegate
                    {
                        completedTests++;

                        txtTests.Text = (completedTests > totalNumberOfTests ? totalNumberOfTests : completedTests) + "/" + totalNumberOfTests;

                        UpdateProgressBar();

                        UpdateTestResult(@event);
                    });
                }
                else if (@event.type.Equals("post-run"))
                {
                    gridResults.BeginInvoke((MethodInvoker)delegate
                    {
                        txtStart.Text = @event.run.startTime.ToString(CultureInfo.CurrentCulture);
                        txtEnd.Text = @event.run.endTime.ToString(CultureInfo.CurrentCulture);
                        txtTime.Text = @event.run.executionTime + " s";

                        txtTests.Text = (completedTests > totalNumberOfTests ? totalNumberOfTests : completedTests) + "/" + totalNumberOfTests;
                        txtSuccess.Text = @event.run.counter.success + "";
                        txtFailures.Text = @event.run.counter.failure + "";
                        txtErrors.Text = @event.run.counter.error + "";
                        txtDisabled.Text = @event.run.counter.disabled + "";

                        if (@event.run.counter.failure > 0 || @event.run.counter.error > 0)
                        {
                            progressBar.ForeColor = Color.DarkRed;
                        }

                        if (!coverage)
                        {
                            txtStatus.Text = totalNumberOfTests > 0 ? "Finished" : "No tests found";
                            Running = false;
                        }
                    });
                }
            };
        }


        private List<string> ConvertToList(string listValue)
        {
            if (string.IsNullOrWhiteSpace(listValue))
            {
                return null;
            }
            else
            {
                if (listValue.Contains(" "))
                {
                    var parts = listValue.Split(' ');
                    return new List<string>(parts);
                }
                else if (listValue.Contains(","))
                {
                    var parts = listValue.Split(',');
                    return new List<string>(parts);
                }
                else if (listValue.Contains("\n"))
                {
                    var parts = listValue.Split('\n');
                    return new List<string>(parts);
                }
                else
                {
                    return new List<string> { listValue };
                }
            }
        }

        /*
        * Workaround for the progressbar animation that produces lagging
        * https://stackoverflow.com/questions/5332616/disabling-net-progressbar-animation-when-changing-value
        */
        private void UpdateProgressBar()
        {
            var newValue = completedTests * Steps + 1;
            if (newValue > progressBar.Maximum)
            {
                progressBar.Value = progressBar.Maximum;
                progressBar.Value--;
                progressBar.Value++;
            }
            else
            {
                progressBar.Value = newValue;
                progressBar.Value--;
            }
        }

        private void SetWindowTitle(string type, string owner, string name, string procedure)
        {
            var startTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            txtStart.Text = startTime;
            var path = GetPath(type, owner, name, procedure);
            txtPath.Text = path[0];
            Text = $"{path[0]} {startTime}";
        }

        private List<string> GetPath(string type, string owner, string name, string procedure)
        {
            switch (type)
            {
                case "USER":
                    return new List<string> { name };
                case "PACKAGE":
                    return new List<string> { $"{owner}.{name}" };
                case "PROCEDURE":
                    return new List<string> { $"{owner}.{name}.{procedure}" };
                default:
                    return new List<string> { owner };
            }
        }

        private void ResetComponents()
        {
            txtPath.Text = "";
            txtStart.Text = "";
            txtTime.Text = "";

            txtEnd.Text = "";
            txtTests.Text = "";
            txtFailures.Text = "";
            txtErrors.Text = "";
            txtDisabled.Text = "";
            txtStatus.Text = "";
            txtStatus.Text = "";

            txtTestOwner.Text = "";
            txtTestPackage.Text = "";
            txtTestProcuedure.Text = "";
            txtTestName.Text = "";
            txtTestDescription.Text = "";
            txtTestSuitePath.Text = "";

            txtTestStart.Text = "";
            txtTestEnd.Text = "";
            txtTestTime.Text = "";

            txtErrorMessage.Text = "";

            var bindingSource = new BindingSource { DataSource = new BindingList<Expectation>() };
            gridTestFailures.DataSource = bindingSource;

            progressBar.ForeColor = Color.Green;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
        }

        private void UpdateTestResult(@event @event)
        {
            if (@event.test != null)
            {
                foreach (var testResult in testResults)
                {
                    if (testResult.Id.Equals(@event.test.id))
                    {
                        testResult.Start = @event.test.startTime;
                        testResult.End = @event.test.endTime;

                        testResult.Time = @event.test.executionTime;

                        var counter = @event.test.counter;
                        if (counter.disabled > 0)
                        {
                            testResult.Icon = IconChar.Ban.ToBitmap(Color.Gray, IconSize);
                            testResult.Status = "Disabled";
                        }
                        else if (counter.success > 0)
                        {
                            testResult.Icon = IconChar.Check.ToBitmap(Color.Green, IconSize);
                            testResult.Status = "Success";
                        }
                        else if (counter.failure > 0)
                        {
                            testResult.Icon = IconChar.TimesCircle.ToBitmap(IconFont.Solid, IconSize, Color.Orange);
                            testResult.Status = "Failure";
                        }
                        else if (counter.error > 0)
                        {
                            testResult.Icon = IconChar.ExclamationCircle.ToBitmap(Color.Red, IconSize);
                            testResult.Status = "Error";
                        }
                        else if (counter.warning > 0)
                        {
                            testResult.Icon = IconChar.ExclamationTriangle.ToBitmap(Color.Orange, IconSize);
                            testResult.Status = "Warning";
                        }

                        if (@event.test.errorStack != null)
                        {
                            testResult.Error = @event.test.errorStack;
                        }

                        if (@event.test.failedExpectations != null)
                        {
                            foreach (var expectation in @event.test.failedExpectations)
                            {
                                testResult.failedExpectations.Add(new Expectation(expectation.message,
                                    expectation.caller));
                            }
                        }

                        gridResults.Refresh();
                        try
                        {
                            var rowIndex = testResults.IndexOf(testResult);
                            gridResults.FirstDisplayedScrollingRowIndex = rowIndex;
                            gridResults.Rows[rowIndex].Selected = true;
                        }
                        catch
                        {
                            // ignore exception that could raise if results are filtered
                        }
                    }
                }
            }
        }

        private void CreateTestResults(@event @event)
        {
            CreateTestResults(@event.items);
            CreateTestResults(@event.suite);
            CreateTestResults(@event.test);
        }

        private void CreateTestResults(items items)
        {
            if (items != null)
            {
                if (items.suite != null)
                {
                    foreach (var itemSuite in items.suite)
                    {
                        CreateTestResults(itemSuite);
                    }
                }

                if (items.test != null)
                {
                    foreach (var test in items.test)
                    {
                        CreateTestResults(test);
                    }
                }
            }
        }

        private void CreateTestResults(suite suite)
        {
            if (suite?.items != null)
            {
                CreateTestResults(suite.items);
            }
        }

        private void CreateTestResults(test test)
        {
            if (test != null)
            {
                testResults.Add(new TestResult
                {
                    Id = test.id,
                    Owner = test.ownerName,
                    Package = test.objectName,
                    Procedure = test.procedureName,
                    Name = test.name,
                    Description = test.description,
                    Icon = IconChar.None.ToBitmap(Color.Black, IconSize)
                });
            }
        }

        private void FilterTestResults()
        {
            if (!cbSuccess.Checked && !cbFailure.Checked && !cbError.Checked && !cbDisabled.Checked)
            {
                viewTestResults.RemoveFilter();
            }
            else
            {
                viewTestResults.ApplyFilter(delegate (TestResult testResult)
                {
                    if (testResult.Status != null)
                    {
                        if (!cbSuccess.Checked && testResult.Status.Equals("Success"))
                        {
                            return false;
                        }
                        if (!cbFailure.Checked && testResult.Status.Equals("Failure"))
                        {
                            return false;
                        }
                        if (!cbError.Checked && testResult.Status.Equals("Error"))
                        {
                            return false;
                        }
                        if (!cbDisabled.Checked && testResult.Status.Equals("Disabled"))
                        {
                            return false;
                        }
                    }
                    return true;
                });
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TestResultWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (Running)
                {
                    var confirmResult =
                        MessageBox.Show("utPLSQL Tests are still running.\r\n\r\nDo you really want to close?",
                            "Running utPLSQL Tests", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        txtStatus.Text = "Aborting...";

                        testRunner.Close();

                        Running = false;
                    }
                }
            }
        }

        private void gridResults_SelectionChanged(object sender, EventArgs e)
        {
            if (gridResults.SelectedRows.Count > 0)
            {
                var row = gridResults.SelectedRows[0];
                var dataBoundItem = (ObjectView<TestResult>)row.DataBoundItem;
                var testResult = dataBoundItem.Object;

                txtTestOwner.Text = testResult.Owner;
                txtTestPackage.Text = testResult.Package;
                txtTestProcuedure.Text = testResult.Procedure;
                txtTestName.Text = testResult.Name;
                txtTestDescription.Text = testResult.Description;
                txtTestSuitePath.Text = testResult.Id;

                txtTestStart.Text = testResult.Start.ToString(CultureInfo.CurrentCulture);
                txtTestEnd.Text = testResult.End.ToString(CultureInfo.CurrentCulture);
                txtTestTime.Text = $"{testResult.Time} s";

                txtErrorMessage.Text = testResult.Error;

                var bindingSource = new BindingSource { DataSource = testResult.failedExpectations };
                gridTestFailures.DataSource = bindingSource;

                gridTestFailures.Columns[0].MinimumWidth = 480;
                gridTestFailures.Columns[1].MinimumWidth = 480;
            }
        }

        private void gridResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pluginIntegration != null)
            {
                invokeOpenPackageBody(e);
            }
        }

        private void gridTestFailures_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pluginIntegration != null)
            {
                invokeOpenPackageBody(e);
            }
        }

        private void invokeOpenPackageBody(DataGridViewCellEventArgs e)
        {
            var testResult = testResults[e.RowIndex];

            var methodInfo = pluginIntegration.GetType().GetMethod("OpenPackageBody");
            methodInfo.Invoke(pluginIntegration, new object[] { testResult.Owner, testResult.Package });
        }

        private void gridResults_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            rowIndexOnRightClick = e.RowIndex;
        }

        private async void menuItemRunTests_ClickAsync(object sender, EventArgs e)
        {
            var testResult = testResults[rowIndexOnRightClick];

            var testResultWindow = new TestRunnerWindow(pluginIntegration, username, password, database, connectAs);
            await testResultWindow.RunTestsAsync("PROCEDURE", testResult.Owner, testResult.Package, testResult.Procedure, false);
        }

        private async void menuItemCoverage_ClickAsync(object sender, EventArgs e)
        {
            var testResult = testResults[rowIndexOnRightClick];

            var testResultWindow = new TestRunnerWindow(pluginIntegration, username, password, database, connectAs);
            await testResultWindow.RunTestsAsync("PROCEDURE", testResult.Owner, testResult.Package, testResult.Procedure, true);
        }

        private void cbSuccess_CheckedChanged(object sender, EventArgs e)
        {
            FilterTestResults();
        }

        private void cbFailures_CheckedChanged(object sender, EventArgs e)
        {
            FilterTestResults();
        }

        private void cbErrors_CheckedChanged(object sender, EventArgs e)
        {
            FilterTestResults();
        }

        private void cbDisabled_CheckedChanged(object sender, EventArgs e)
        {
            FilterTestResults();
        }
    }
}