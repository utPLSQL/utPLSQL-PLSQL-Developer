using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace utPLSQL.UI.Standalone
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnRunTests_Click(object sender, EventArgs e)
        {
            var realTimeTestRunner = new RealTimeTestRunner();
            realTimeTestRunner.Connect("toscamtest", "toscamtest", "CA40");

            var testRunnerWindow = new TestRunnerWindow(realTimeTestRunner);
            testRunnerWindow.RunTestsAsync("USER", null, "toscamtest", null, false);
        }
    }
}
