﻿using FontAwesome.Sharp;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace utPLSQL
{
    public partial class TestRunnerWindow : Form
    {
        public bool Running { get; set; }

        private const int IconSize = 24;
        private const int Steps = 1000;

        private readonly RealTimeTestRunner testRunner;
        private readonly object pluginIntegration;
        private readonly BindingList<TestResult> testResults = new BindingList<TestResult>();

        private int totalNumberOfTests;
        private int rowIndexOnRightClick;

        public TestRunnerWindow(RealTimeTestRunner testRunner, object pluginIntegration)
        {
            this.testRunner = testRunner;
            this.pluginIntegration = pluginIntegration;

            InitializeComponent();

            var bindingSource = new BindingSource { DataSource = testResults };
            gridResults.DataSource = bindingSource;

            gridResults.Columns[0].HeaderText = "";
            gridResults.Columns[0].MinimumWidth = 30;
            gridResults.Columns[1].MinimumWidth = 235;
            gridResults.Columns[2].MinimumWidth = 600;
            gridResults.Columns[3].MinimumWidth = 100;
            gridResults.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void RunTestsAsync(string type, string owner, string name, string procedure, bool coverage)
        {
            ResetComponents();

            testResults.Clear();

            SetWindowTitle(type, owner, name, procedure);

            if (coverage)
            {
                var codeCoverageReportDialog = new CodeCoverageReportDialog(getPath(type, owner, name, procedure));
                var dialogResult = codeCoverageReportDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    txtStatus.Text = "Running tests with coverage...";

                    RunWithCoverage(type, owner, name, procedure, codeCoverageReportDialog);

                    Show();

                    CollectResults(true);
                    CollectReport();
                }
            }
            else
            {
                txtStatus.Text = "Running tests...";

                RunTests(type, owner, name, procedure);

                Show();

                CollectResults(false);
            }
        }

        private void RunTests(string type, string owner, string name, string procedure)
        {
            Task.Factory.StartNew(() => testRunner.RunTests(type, owner, name, procedure));
            Running = true;
        }

        private void RunWithCoverage(string type, string owner, string name, string procedure,
            CodeCoverageReportDialog codeCoverageReporteReportDialog)
        {
            var schemas = ConvertToVarcharList(codeCoverageReporteReportDialog.GetSchemas());
            var includes = ConvertToVarcharList(codeCoverageReporteReportDialog.GetIncludes());
            var excludes = ConvertToVarcharList(codeCoverageReporteReportDialog.GetExcludes());

            Task.Factory.StartNew(() =>
                testRunner.RunTestsWithCoverage(type, owner, name, procedure, schemas, includes, excludes));
            Running = true;
        }

        private void CollectResults(bool coverage)
        {
            var completedTests = 0;

            Task.Factory.StartNew(() => testRunner.ConsumeResult(@event =>
            {
                if (@event.type.Equals("pre-run"))
                {
                    gridResults.BeginInvoke((MethodInvoker)delegate ()
                   {
                       totalNumberOfTests = @event.totalNumberOfTests;

                       progressBar.Minimum = 0;
                       progressBar.Maximum = totalNumberOfTests * Steps;
                       progressBar.Step = Steps;
                       CreateTestResults(@event);

                       gridResults.Rows[0].Selected = false;
                   });
                }
                else if (@event.type.Equals("post-test"))
                {
                    gridResults.BeginInvoke((MethodInvoker)delegate ()
                   {
                       completedTests++;

                       txtTests.Text =
                           (completedTests > totalNumberOfTests ? totalNumberOfTests : completedTests) + "/" +
                           totalNumberOfTests;
                       UpdateProgressBar(completedTests);

                       UpdateTestResult(@event);
                   });
                }
                else if (@event.type.Equals("post-run"))
                {
                    gridResults.BeginInvoke((MethodInvoker)delegate ()
                   {
                       txtStart.Text = @event.run.startTime.ToString(CultureInfo.CurrentCulture);
                       txtEnd.Text = @event.run.endTime.ToString(CultureInfo.CurrentCulture);
                       txtTime.Text = @event.run.executionTime + " s";

                       txtTests.Text =
                           (completedTests > totalNumberOfTests ? totalNumberOfTests : completedTests) + "/" +
                           totalNumberOfTests;
                       txtFailures.Text = @event.run.counter.failure + "";
                       txtErrors.Text = @event.run.counter.error + "";
                       txtDisabled.Text = @event.run.counter.disabled + "";

                       if (@event.run.counter.failure > 0 || @event.run.counter.error > 0)
                       {
                           progressBar.ForeColor = Color.DarkRed;
                       }

                       if (!coverage)
                       {
                           txtStatus.Text = "Finished";

                           Running = false;
                       }
                   });
                }
            }));
        }

        private void CollectReport()
        {
            Task.Factory.StartNew(() =>
            {
                string report = testRunner.GetCoverageReport();

                string filePath = $"{Path.GetTempPath()}\\utPLSQL_Coverage_Report_{Guid.NewGuid()}.html";
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(report);
                }

                txtStatus.BeginInvoke((MethodInvoker)delegate () { txtStatus.Text = "Finished"; });

                Running = false;

                System.Diagnostics.Process.Start(filePath);
            });
        }

        private string ConvertToVarcharList(string listValue)
        {
            if (String.IsNullOrWhiteSpace(listValue))
            {
                return null;
            }
            else
            {
                if (listValue.Contains(" "))
                {
                    string[] parts = listValue.Split(' ');
                    return JoinParts(parts);
                }
                else if (listValue.Contains(","))
                {
                    string[] parts = listValue.Split(',');
                    return JoinParts(parts);
                }
                else if (listValue.Contains("\n"))
                {
                    string[] parts = listValue.Split('\n');
                    return JoinParts(parts);
                }
                else
                {
                    return $"'{listValue}'";
                }
            }
        }

        private static string JoinParts(string[] parts)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (var part in parts)
            {
                if (!string.IsNullOrEmpty(part))
                {
                    if (!first)
                    {
                        sb.Append(",");
                    }

                    sb.Append("'").Append(part).Append("'");

                    first = false;
                }
            }

            return sb.ToString();
        }

        private void UpdateProgressBar(int completedTests)
        {
            int newValue = (completedTests * Steps) + 1;
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
            string path = getPath(type, owner, name, procedure);

            if (type.Equals(RealTimeTestRunner.User))
            {
                this.Text = name + " " + startTime;
                txtTestExecution.Text = $"All Tests of {path}";
            }
            else if (type.Equals(RealTimeTestRunner.Package))
            {
                this.Text = $"{owner}.{name}" + " " + startTime;
                txtTestExecution.Text = $"Package {path}";
            }
            else if (type.Equals(RealTimeTestRunner.Procedure))
            {
                this.Text = $"{owner}.{name}" + " " + startTime;
                txtTestExecution.Text = $"Procedure {path}";
            }
            else if (type.Equals(RealTimeTestRunner.All))
            {
                this.Text = owner + " " + startTime;
                txtTestExecution.Text = $"All Tests of {path}";
            }
        }

        private string getPath(string type, string owner, string name, string procedure)
        {
            if (type.Equals(RealTimeTestRunner.User))
            {
                return name;
            }
            else if (type.Equals(RealTimeTestRunner.Package))
            {
                return $"{owner}.{name}";
            }
            else if (type.Equals(RealTimeTestRunner.Procedure))
            {
                return $"{owner}.{name}.{procedure}";
            }
            else if (type.Equals(RealTimeTestRunner.All))
            {
                return owner;
            }
            else
            {
                return "";
            }
        }

        private void ResetComponents()
        {
            txtTestExecution.Text = "";
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
                        }
                        else if (counter.success > 0)
                        {
                            testResult.Icon = IconChar.Check.ToBitmap(Color.Green, IconSize);
                        }
                        else if (counter.failure > 0)
                        {
                            testResult.Icon = IconChar.TimesCircle.ToBitmap(IconFont.Solid, IconSize, Color.Orange);
                        }
                        else if (counter.error > 0)
                        {
                            testResult.Icon = IconChar.ExclamationCircle.ToBitmap(Color.Red, IconSize);
                        }
                        else if (counter.warning > 0)
                        {
                            testResult.Icon = IconChar.ExclamationTriangle.ToBitmap(Color.Orange, IconSize);
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
                        var rowIndex = testResults.IndexOf(testResult);
                        gridResults.FirstDisplayedScrollingRowIndex = rowIndex;
                        gridResults.Rows[rowIndex].Selected = true;
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

        private void btnClose_Click(object sender, System.EventArgs e)
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
                }
            }
        }

        private void gridResults_SelectionChanged(object sender, EventArgs e)
        {
            if (gridResults.SelectedRows.Count > 0)
            {
                var row = gridResults.SelectedRows[0];
                var testResult = (TestResult)row.DataBoundItem;

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

            MethodInfo methodInfo = pluginIntegration.GetType().GetMethod("OpenPackageBody");
            methodInfo.Invoke(pluginIntegration, new object[] { testResult.Owner, testResult.Package });
        }

        private void gridResults_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            rowIndexOnRightClick = e.RowIndex;
        }

        private void menuItemRunTests_Click(object sender, EventArgs e)
        {
            var testResult = testResults[rowIndexOnRightClick];

            var testResultWindow = new TestRunnerWindow(testRunner, pluginIntegration);
            testResultWindow.RunTestsAsync(RealTimeTestRunner.Procedure, testResult.Owner, testResult.Package,
                testResult.Procedure, false);
        }

        private void menuItemCoverage_Click(object sender, EventArgs e)
        {
            var testResult = testResults[rowIndexOnRightClick];

            var testResultWindow = new TestRunnerWindow(testRunner, pluginIntegration);
            testResultWindow.RunTestsAsync(RealTimeTestRunner.Procedure, testResult.Owner, testResult.Package,
                testResult.Procedure, true);
        }
    }
}