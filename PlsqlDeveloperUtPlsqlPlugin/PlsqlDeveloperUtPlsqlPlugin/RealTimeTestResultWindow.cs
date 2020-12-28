using FontAwesome.Sharp;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using utPLSQL;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    public partial class RealTimeTestResultWindow : Form
    {
        private const int IconSize = 24;

        private readonly RealTimeTestRunner testRunner;
        private BindingList<TestResult> testResults = new BindingList<TestResult>();
        private int totalNumberOfTests;

        public RealTimeTestResultWindow(RealTimeTestRunner testRunner)
        {
            this.testRunner = testRunner;
            InitializeComponent();

            var bindingSource = new BindingSource();
            bindingSource.DataSource = testResults;
            gridResults.DataSource = bindingSource;

            gridResults.Columns[0].HeaderText = "";
            gridResults.Columns[0].MinimumWidth = 30;
            gridResults.Columns[1].MinimumWidth = 424;
            gridResults.Columns[2].MinimumWidth = 50;
            gridResults.Columns[3].MinimumWidth = 460;
        }

        internal void RunTests(string type, string owner, string name, string subType)
        {
            txtTests.Text = "";
            txtFailures.Text = "";
            txtErrors.Text = "";
            txtDisabled.Text = "";
            txtStatus.Text = "";
            txtTime.Text = "";
            txtStatus.Text = "Running...";

            progressBar.ForeColor = Color.Green;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            testResults.Clear();

            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            Show();

            new Thread(() =>
            {
                testRunner.RunTests(type, owner, name, subType);

            }).Start();
            new Thread(() =>
            {
                var completetedTests = 0;

                testRunner.ConsumeResult(@event =>
                {
                    gridResults.BeginInvoke((MethodInvoker)delegate ()
                    {
                        if (@event.type.Equals("pre-run"))
                        {
                            totalNumberOfTests = @event.totalNumberOfTests;

                            progressBar.Minimum = 0;
                            progressBar.Maximum = totalNumberOfTests;

                            CreateTestResults(@event);

                            gridResults.Rows[0].Cells[0].Selected = false;
                        }
                        else if (@event.type.Equals("post-test"))
                        {
                            completetedTests++;
                            txtTests.Text = (completetedTests > totalNumberOfTests ? totalNumberOfTests : completetedTests) + "/" + totalNumberOfTests;
                            progressBar.Value = completetedTests;

                            UpdateTestResult(@event);
                        }
                        else if (@event.type.Equals("post-run"))
                        {
                            txtStatus.Text = "Finished";

                            txtTests.Text = (completetedTests > totalNumberOfTests ? totalNumberOfTests : completetedTests) + "/" + totalNumberOfTests;
                            txtFailures.Text = @event.run.counter.failure + "";
                            txtErrors.Text = @event.run.counter.error + "";
                            txtWarning.Text = @event.run.counter.warning + "";
                            txtDisabled.Text = @event.run.counter.disabled + "";
                            txtTime.Text = @event.run.executionTime + " s";

                            if (@event.run.counter.failure > 0 || @event.run.counter.error > 0)
                            {
                                progressBar.ForeColor = Color.DarkRed;
                            }

                        }
                    });
                });
            }).Start();
        }

        private void UpdateTestResult(@event @event)
        {
            if (@event.test != null)
            {
                foreach (var testResult in testResults)
                {
                    if (testResult.Id.Equals(@event.test.id))
                    {
                        testResult.Time = @event.test.executionTime;
                        var counter = @event.test.counter;
                        if (counter.disabled > 0)
                        {
                            testResult.Result = "Disabled";
                            testResult.Icon = IconChar.Ban.ToBitmap(Color.Gray, IconSize);
                        }
                        else if (counter.success > 0)
                        {
                            testResult.Result = "Success";
                            testResult.Icon = IconChar.Check.ToBitmap(Color.Green, IconSize);
                        }
                        else if (counter.failure > 0)
                        {
                            testResult.Result = "Failure";
                            testResult.Icon = IconChar.TimesCircle.ToBitmap(IconFont.Solid, IconSize, Color.Orange);
                        }
                        else if (counter.error > 0)
                        {
                            testResult.Result = "Error";
                            testResult.Icon = IconChar.ExclamationCircle.ToBitmap(Color.Red, IconSize);
                        }
                        else if (counter.warning > 0)
                        {
                            testResult.Result = "Warning";
                            testResult.Icon = IconChar.ExclamationTriangle.ToBitmap(Color.Orange, IconSize);
                        }

                        if (@event.test.errorStack != null)
                        {
                            testResult.Error = @event.test.errorStack;
                        }
                        gridResults.Refresh();
                    }
                }
            }
        }

        private void CreateTestResults(@event @event)
        {
            CreateTestResults(null, @event.items);
            CreateTestResults(@event.suite);
            CreateTestResults(null, @event.test);
        }

        private void CreateTestResults(suite suite, items items)
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
                        CreateTestResults(suite, test);
                    }
                }
            }
        }

        private void CreateTestResults(suite suite)
        {
            if (suite != null && suite.items != null)
            {
                CreateTestResults(suite, suite.items);
            }
        }

        private void CreateTestResults(suite suite, test test)
        {
            if (test != null)
            {
                var suiteName = suite == null ? "" : suite.name;
                testResults.Add(new TestResult
                {
                    Id = test.id,
                    Result = "",
                    Name = $"{suiteName}.{test.name}",
                    Icon = IconChar.None.ToBitmap(Color.Black, IconSize)
                });
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Hide();
        }

        private void TestResultWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

    }
}
