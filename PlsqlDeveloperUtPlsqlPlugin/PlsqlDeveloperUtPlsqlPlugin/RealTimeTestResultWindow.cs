using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using utPLSQL;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    public partial class RealTimeTestResultWindow : Form
    {
        private readonly RealTimeTestRunner testRunner;
        private BindingList<TestResult> testResults = new BindingList<TestResult>();

        public RealTimeTestResultWindow(RealTimeTestRunner testRunner)
        {
            this.testRunner = testRunner;
            InitializeComponent();

            var bindingSource = new BindingSource();
            bindingSource.DataSource = testResults;
            gridResults.DataSource = bindingSource;

            gridResults.Columns[0].MinimumWidth = 50;
            gridResults.Columns[1].MinimumWidth = 422;
            gridResults.Columns[2].MinimumWidth = 50;
            gridResults.Columns[3].MinimumWidth = 440;
        }

        internal void RunTests(string type, string owner, string name, string subType)
        {
            lblStatus.Text = "";

            txtTests.Text = "";
            txtFailures.Text = "";
            txtErrors.Text = "";
            txtDisabled.Text = "";
            txtTime.Text = "";

            testResults.Clear();

            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            Show();

            new Thread(() =>
            {
                testRunner.RunTests(type, owner, name, subType);
                testRunner.ConsumeResult(@event =>
                {
                    gridResults.BeginInvoke((MethodInvoker)delegate ()
                    {
                        if (@event.type.Equals("pre-run"))
                        {
                            lblStatus.Text = "Running...";

                            CreateTestResults(@event);
                        }
                        else if (@event.type.Equals("post-test"))
                        {
                            UpdateTestResult(@event);
                        }
                        else if (@event.type.Equals("post-run"))
                        {
                            lblStatus.Text = "Finished";

                            txtTests.Text = "" + (@event.run.counter.disabled + @event.run.counter.success + @event.run.counter.failure + @event.run.counter.error + @event.run.counter.warning);
                            txtFailures.Text = "" + @event.run.counter.failure;
                            txtErrors.Text = "" + @event.run.counter.error;
                            txtDisabled.Text = "" + @event.run.counter.disabled;
                            txtTime.Text = "" + @event.run.executionTime;

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
                        }
                        else if (counter.success > 0)
                        {
                            testResult.Result = "Success";
                        }
                        else if (counter.failure > 0)
                        {
                            testResult.Result = "Failure";
                        }
                        else if (counter.error > 0)
                        {
                            testResult.Result = "Error";
                        }
                        else if (counter.warning > 0)
                        {
                            testResult.Result = "Warning";
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
                    Name = $"{suiteName}.{test.name}"
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
