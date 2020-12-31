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
            var realTimeTestRunner = new RealTimeTestRunner();
            realTimeTestRunner.Connect("toscamtest", "toscamtest", "CA40");

            var testRunnerWindow = new TestRunnerWindow(realTimeTestRunner, null);
            testRunnerWindow.RunTestsAsync("USER", null, "toscamtest", null, false);
        }
    }
}
