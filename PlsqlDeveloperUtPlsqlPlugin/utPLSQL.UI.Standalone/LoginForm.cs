using System;
using System.Windows.Forms;

namespace utPLSQL.UI.Standalone
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnRunTests_Click(object sender, EventArgs e)
        {
            var testRunnerWindow = new TestRunnerWindow(null, txtUsername.Text, txtPassword.Text, txtDatabase.Text, null);
            testRunnerWindow.RunTestsAsync("USER", null, txtUsername.Text, null, false);
        }

        private void btnCodeCoverage_Click(object sender, EventArgs e)
        {
            var testRunnerWindow = new TestRunnerWindow(null, txtUsername.Text, txtPassword.Text, txtDatabase.Text, null);
            testRunnerWindow.RunTestsAsync("USER", null, txtUsername.Text, null, true);
        }
    }
}
