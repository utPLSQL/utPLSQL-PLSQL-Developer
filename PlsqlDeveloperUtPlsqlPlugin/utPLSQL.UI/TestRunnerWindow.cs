using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Data;
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
        private const string StatusSuccess = "Success";
        private const string StatusFailure = "Failure";
        private const string StatusError = "Error";
        private const string StatusDisabled = "Disabled";
        private const string StatusWarning = "Warning";

        private readonly object pluginIntegration;
        private readonly string username;
        private readonly string password;
        private readonly string database;
        private readonly string connectAs;
        private readonly string oracleHome;

        private RealTimeTestRunner testRunner;

        private int totalNumberOfTests;
        private int rowIndexOnRightClick;
        private int completedTests;

        private ImageConverter imageConverter = new ImageConverter();

        private DataView dataViewTestResults;

        public TestRunnerWindow(object pluginIntegration, string username, string password, string database, string connectAs, string oracleHome)
        {
            this.pluginIntegration = pluginIntegration;
            this.username = username;
            this.password = password;
            this.database = database;
            this.connectAs = connectAs;
            this.oracleHome = oracleHome;

            InitializeComponent();

            dataViewTestResults = new DataView(dataTableTestResults);
        }

        public async Task RunTestsAsync(string type, string owner, string name, string procedure, bool coverage)
        {
            var path = GetPath(type, owner, name, procedure);

            testRunner = new RealTimeTestRunner();

            try
            {
                if (oracleHome != null && Environment.GetEnvironmentVariable("ORACLE_HOME") == null)
                {
                    Environment.SetEnvironmentVariable("ORACLE_HOME", oracleHome);
                }
                testRunner.Connect(username, password, database);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Connect failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                testRunner.GetVersion();
            }
            catch
            {
                MessageBox.Show("utPLSQL is not installed", "utPLSQL not installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await RunTestsAsync(path, coverage);
        }

        private async Task RunTestsAsync(List<string> path, bool coverage)
        {
            ResetComponents();

            dataSet.Clear();

            SetWindowTitle(path);

            Running = true;

            EnableFilter();

            if (coverage)
            {
                var codeCoverageReportDialog = new CodeCoverageReportDialog(path);
                var dialogResult = codeCoverageReportDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    Show();

                    var schemas = ConvertToList(codeCoverageReportDialog.GetSchemas());
                    var includes = ConvertToList(codeCoverageReportDialog.GetIncludes());
                    var excludes = ConvertToList(codeCoverageReportDialog.GetExcludes());

                    completedTests = 0;

                    txtStatus.Text = "Running tests with coverage...";

                    var htmlReport = await testRunner.RunTestsWithCoverageAsync(path, CollectResults(coverage), schemas, includes, excludes);

                    var filePath = $"{Path.GetTempPath()}\\utPLSQL_Coverage_Report_{Guid.NewGuid()}.html";
                    using (var sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine(htmlReport);
                    }

                    txtStatus.BeginInvoke((MethodInvoker)delegate
                    {
                        EnableFilter();

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

                await testRunner.RunTestsAsync(path, CollectResults(coverage));
            }
        }

        private void EnableFilter()
        {
            cbSuccess.Enabled = true;
            cbFailure.Enabled = true;
            cbError.Enabled = true;
            cbDisabled.Enabled = true;
        }

        private Action<@event> CollectResults(bool coverage)
        {
            return @event =>
            {
                if (@event.type.Equals("pre-run"))
                {
                    dataGridViewTestResults.BeginInvoke((MethodInvoker)delegate
                    {
                        txtStatus.Text = "Running tests...";

                        totalNumberOfTests = @event.totalNumberOfTests;

                        progressBar.Minimum = 0;
                        progressBar.Maximum = totalNumberOfTests * Steps;
                        progressBar.Step = Steps;

                        CreateTestResults(@event);


                        dataTableTestResults.AcceptChanges();
                    });
                }
                else if (@event.type.Equals("post-test"))
                {
                    dataGridViewTestResults.BeginInvoke((MethodInvoker)delegate
                    {
                        completedTests++;

                        txtTests.Text = (completedTests > totalNumberOfTests ? totalNumberOfTests : completedTests) + "/" + totalNumberOfTests;

                        UpdateProgressBar();

                        UpdateTestResult(@event);
                    });
                }
                else if (@event.type.Equals("post-run"))
                {
                    dataGridViewTestResults.BeginInvoke((MethodInvoker)delegate
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
                            EnableFilter();

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

        private void SetWindowTitle(IReadOnlyList<string> path)
        {
            var startTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            txtStart.Text = startTime;
            txtPath.Text = path[0];
            Text = $"{path[0]} {startTime}";
        }

        private static List<string> GetPath(string type, string owner, string name, string procedure)
        {
            switch (type)
            {
                case "USER":
                    return new List<string> { name };
                case "PACKAGE":
                    return new List<string> { $"{owner}.{name}" };
                case "PACKAGE BODY":
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

            progressBar.ForeColor = Color.Green;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            cbSuccess.Enabled = false;
            cbFailure.Enabled = false;
            cbError.Enabled = false;
            cbDisabled.Enabled = false;
        }

        private void UpdateTestResult(@event @event)
        {
            if (@event.test != null)
            {
                var rows = dataTableTestResults.Select($"Id = '{ @event.test.id}'");
                var testResult = rows[0];

                testResult.BeginEdit();

                testResult["Start"] = @event.test.startTime;
                testResult["End"] = @event.test.endTime;

                testResult["Time"] = @event.test.executionTime;

                var counter = @event.test.counter;
                if (counter.disabled > 0)
                {
                    testResult["Icon"] = (byte[])imageConverter.ConvertTo(IconChar.Ban.ToBitmap(Color.Gray, IconSize), typeof(byte[]));
                    testResult["Status"] = StatusDisabled;
                }
                else if (counter.success > 0)
                {
                    testResult["Icon"] = (byte[])imageConverter.ConvertTo(IconChar.Check.ToBitmap(Color.Green, IconSize), typeof(byte[]));
                    testResult["Status"] = StatusSuccess;
                }
                else if (counter.failure > 0)
                {
                    testResult["Icon"] = (byte[])imageConverter.ConvertTo(IconChar.TimesCircle.ToBitmap(IconFont.Solid, IconSize, Color.Orange), typeof(byte[]));
                    testResult["Status"] = StatusFailure;
                }
                else if (counter.error > 0)
                {
                    testResult["Icon"] = (byte[])imageConverter.ConvertTo(IconChar.ExclamationCircle.ToBitmap(Color.Red, IconSize), typeof(byte[]));
                    testResult["Status"] = StatusError;
                }
                else if (counter.warning > 0)
                {
                    testResult["Icon"] = (byte[])imageConverter.ConvertTo(IconChar.ExclamationTriangle.ToBitmap(Color.Orange, IconSize), typeof(byte[]));
                    testResult["Status"] = StatusWarning;
                }

                if (@event.test.errorStack != null)
                {
                    testResult["Error"] = @event.test.errorStack;
                }

                if (@event.test.failedExpectations != null)
                {
                    foreach (var expectation in @event.test.failedExpectations)
                    {
                        var rowExpectation = dataTableExpectations.NewRow();
                        rowExpectation["TestResultId"] = @event.test.id;
                        rowExpectation["Message"] = expectation.message;
                        rowExpectation["Caller"] = expectation.caller;

                        dataTableExpectations.Rows.Add(rowExpectation);

                        dataTableExpectations.AcceptChanges();
                    }
                }

                testResult.EndEdit();

                dataTableTestResults.AcceptChanges();

                var rowIndex = 0;
                foreach (DataGridViewRow gridRow in dataGridViewTestResults.Rows)
                {
                    if (gridRow.DataBoundItem is DataRowView rowTestResult)
                    {
                        if (rowTestResult["Id"].ToString().Equals(@event.test.id))
                        {
                            dataGridViewTestResults.FirstDisplayedScrollingRowIndex = rowIndex;
                            dataGridViewTestResults.Rows[rowIndex].Selected = true;

                            break;
                        }
                        rowIndex++;
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
                var rowTestResult = dataTableTestResults.NewRow();
                rowTestResult["Id"] = test.id;
                rowTestResult["Owner"] = test.ownerName;
                rowTestResult["Package"] = test.objectName;
                rowTestResult["Procedure"] = test.procedureName;
                rowTestResult["Name"] = test.name;
                rowTestResult["Description"] = test.description;
                rowTestResult["Icon"] = (byte[])imageConverter.ConvertTo(IconChar.None.ToBitmap(Color.Black, IconSize), typeof(byte[]));

                dataTableTestResults.Rows.Add(rowTestResult);
            }
        }

        private void FilterTestResults()
        {
            if (cbSuccess.Checked && cbFailure.Checked && cbError.Checked && cbDisabled.Checked)
            {
                dataViewTestResults.RowFilter = null;
            }
            else
            {
                var filter = "Status is null";

                if (cbSuccess.Checked)
                {
                    filter += $" or Status = '{StatusSuccess}'";
                }
                if (cbFailure.Checked)
                {
                    filter += $" or Status = '{StatusFailure}'";
                }
                if (cbError.Checked)
                {
                    filter += $" or Status = '{StatusError}'";
                }
                if (cbDisabled.Checked)
                {
                    filter += $" or Status = '{StatusDisabled}'";
                }

                dataViewTestResults.RowFilter = filter;
            }

            dataGridViewTestResults.DataSource = dataViewTestResults;
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
            if (dataGridViewTestResults.SelectedRows.Count > 0)
            {
                var row = dataGridViewTestResults.SelectedRows[0];

                if (row.DataBoundItem is DataRowView rowTestResult)
                {
                    txtTestOwner.Text = "" + rowTestResult.Row["Owner"];
                    txtTestPackage.Text = "" + rowTestResult.Row["Package"];
                    txtTestProcuedure.Text = "" + rowTestResult.Row["Procedure"];
                    txtTestName.Text = "" + rowTestResult.Row["Name"];
                    txtTestDescription.Text = "" + rowTestResult.Row["Description"];
                    txtTestSuitePath.Text = "" + rowTestResult.Row["Id"];

                    txtTestStart.Text = rowTestResult.Row["Start"].ToString().ToString(CultureInfo.CurrentCulture);
                    txtTestEnd.Text = rowTestResult.Row["End"].ToString().ToString(CultureInfo.CurrentCulture);
                    txtTestTime.Text = $"{rowTestResult.Row["Time"]} s";

                    txtErrorMessage.Text = rowTestResult.Row["Error"] == null ? "" : rowTestResult.Row["Error"].ToString().Replace("\n", "\r\n");

                    if (!Running)
                    {
                        if (rowTestResult.Row["Status"] == null)
                        {
                            tabs.SelectedTab = tabTest;
                        }
                        else if (rowTestResult.Row["Status"].ToString().Equals(StatusFailure))
                        {
                            tabs.SelectedTab = tabFailures;
                        }
                        else if (rowTestResult.Row["Status"].ToString().Equals(StatusError))
                        {
                            tabs.SelectedTab = tabErrors;
                        }
                        else
                        {
                            tabs.SelectedTab = tabTest;
                        }
                    }
                }
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
            var rowTestResult = dataTableTestResults.Rows[e.RowIndex];

            var methodInfo = pluginIntegration.GetType().GetMethod("OpenPackageBody");
            methodInfo.Invoke(pluginIntegration, new[] { rowTestResult["Owner"], rowTestResult["Package"] });
        }

        private void gridResults_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            rowIndexOnRightClick = e.RowIndex;
        }

        private async void menuItemRunTests_ClickAsync(object sender, EventArgs e)
        {
            var rowTestResult = dataTableTestResults.Rows[rowIndexOnRightClick];

            var testResultWindow = new TestRunnerWindow(pluginIntegration, username, password, database, connectAs, oracleHome);
            await testResultWindow.RunTestsAsync("PROCEDURE", rowTestResult["Owner"].ToString(), rowTestResult["Package"].ToString(), rowTestResult["Procedure"].ToString(), false);
        }

        private async void menuItemCoverage_ClickAsync(object sender, EventArgs e)
        {
            var rowTestResult = dataTableTestResults.Rows[rowIndexOnRightClick];

            var testResultWindow = new TestRunnerWindow(pluginIntegration, username, password, database, connectAs, oracleHome);
            await testResultWindow.RunTestsAsync("PROCEDURE", rowTestResult["Owner"].ToString(), rowTestResult["Package"].ToString(), rowTestResult["Procedure"].ToString(), true);
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

        private async void btnRun_Click(object sender, EventArgs e)
        {
            await RunTestsAsync(new List<string> { txtPath.Text }, false);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await RunTestsAsync(new List<string> { txtPath.Text }, true);
        }
    }
}