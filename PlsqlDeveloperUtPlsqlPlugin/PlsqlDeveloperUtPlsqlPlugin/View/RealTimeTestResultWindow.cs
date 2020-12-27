using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    public partial class RealTimeTestResultWindow : Form
    {
        private readonly RealTimeTestRunner testRunner = new RealTimeTestRunner();

        public RealTimeTestResultWindow()
        {
            InitializeComponent();
        }

        internal void RunTests(string type, string owner, string name, string subType)
        {
            lblStatus.Text = "Running...";

            txtTests.Text = "";
            txtFailures.Text = "";
            txtErrors.Text = "";
            txtDisabled.Text = "";
            txtTime.Text = "";
            txtResult.Text = "";

            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            Show();

            new Thread(() =>
            {
                try
                {
                    testRunner.Run(type, owner, name, subType);
                    testRunner.GetResult(resultLine =>
                    {
                        txtResult.BeginInvoke((MethodInvoker)delegate ()
                        {
                            txtResult.Text = txtResult.Text + "\r\n" + resultLine;
                        });
                    });
                }
                catch (Exception e)
                {
                    txtResult.BeginInvoke((MethodInvoker)delegate ()
                    {
                        txtResult.Text = e.Message;
                    });
                }
            }).Start();
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
