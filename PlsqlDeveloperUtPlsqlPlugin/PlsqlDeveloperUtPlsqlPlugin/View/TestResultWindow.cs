using System.Drawing;
using System.Windows.Forms;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    public partial class TestResultWindow : Form
    {
        private TestRunner testRunner = new TestRunner();

        public TestResultWindow()
        {
            InitializeComponent();
        }

        internal void RunTests(string type, string owner, string name, string subType)
        {
            testRunner.Run(type, owner, name, subType);
            ShowResult();
        }
        private void ShowResult()
        {
            txtTests.Text = "";
            txtTime.Text = "";
            treeResult.Nodes.Clear();

            var testSuites = testRunner.GetJUnitResult();

            if (testSuites != null)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }
                Show();

                txtTests.Text = "" + testSuites.Tests;
                txtTime.Text = testSuites.Time;

                var root = new TreeNode($"{testSuites.TestSuite.Name} ({testSuites.TestSuite.Tests})");
                foreach (TestSuite testSuite in testSuites.TestSuite.TestSuites)
                {
                    TreeNode tnTestSuite = new TreeNode($"{testSuite.Name} ({testSuite.Tests})");
                    root.Nodes.Add(tnTestSuite);

                    foreach (var testCase in testSuite.TestCases)
                    {
                        var tnTestCase = new TreeNode($"{testCase.Name}");
                        tnTestSuite.Nodes.Add(tnTestCase);

                        if (testCase.Error != null)
                        {
                            tnTestCase.ForeColor = Color.DarkRed;
                            var tnError = new TreeNode(testCase.Error);
                            tnTestCase.Nodes.Add(tnError);
                        }
                        else
                        {
                            tnTestCase.ForeColor = testCase.Status == null ? Color.DarkGreen : Color.DarkRed;
                        }
                    }
                }

                treeResult.Nodes.Add(root);
                treeResult.ExpandAll();
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
