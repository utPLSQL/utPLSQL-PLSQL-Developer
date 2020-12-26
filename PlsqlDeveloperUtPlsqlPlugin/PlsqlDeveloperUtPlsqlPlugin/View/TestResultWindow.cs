﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    public partial class TestResultWindow : Form
    {
        private readonly JUnitTestRunner testRunner = new JUnitTestRunner();

        public TestResultWindow()
        {
            InitializeComponent();
        }

        internal void RunTests(string type, string owner, string name, string subType)
        {
            lblStatus.Text = "Running...";

            testRunner.Run(type, owner, name, subType);
            ShowResult();
        }
        private void ShowResult()
        {
            txtTests.Text = "";
            txtFailures.Text = "";
            txtErrors.Text = "";
            txtDisabled.Text = "";
            txtTime.Text = "";
            treeResult.Nodes.Clear();

            var testsuites = testRunner.GetJUnitResult();

            if (testsuites != null)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }
                Show();

                txtTests.Text = testsuites.tests;
                txtFailures.Text = testsuites.failures;
                txtErrors.Text = testsuites.errors;
                txtDisabled.Text = testsuites.disabled;
                txtTime.Text = testsuites.time;

                try
                {
                    testsuite alltests = testsuites.testsuite[0];

                    var tnAlltests = new TreeNode($"{alltests.name} ({alltests.tests})");
                    foreach (testsuite testsuite in alltests.testsuite1)
                    {
                        TreeNode tnTestsuite = new TreeNode($"{testsuite.name} ({testsuite.tests})");
                        tnAlltests.Nodes.Add(tnTestsuite);

                        if (testsuite.testcase != null)
                        {
                            foreach (var testcase in testsuite.testcase)
                            {
                                var tnTestcase = new TreeNode(testcase.name);
                                tnTestsuite.Nodes.Add(tnTestcase);

                                if (testcase.error != null)
                                {
                                    tnTestcase.ForeColor = Color.DarkRed;
                                    foreach (var error in testcase.error)
                                    {
                                        if (error.Text.Length > 0)
                                        {
                                            var tnError = new TreeNode(error.Text[0]);
                                            tnTestcase.Nodes.Add(tnError);
                                        }
                                    }
                                }
                                else if (testcase.failure != null)
                                {
                                    tnTestcase.ForeColor = Color.DarkRed;
                                    foreach (var failure in testcase.failure)
                                    {
                                        if (failure.Text.Length > 0)
                                        {
                                            var tnFailure = new TreeNode(failure.Text[0]);
                                            tnTestcase.Nodes.Add(tnFailure);
                                        }
                                    }
                                }
                                else
                                {
                                    tnTestcase.ForeColor = testcase.status == null ? Color.DarkGreen : Color.DarkRed;
                                }
                            }
                        }
                    }

                    treeResult.Nodes.Add(tnAlltests);
                    treeResult.ExpandAll();

                    lblStatus.Text = "Finished";
                }
                catch (Exception e)
                {
                    lblStatus.Text = "Error";
                    MessageBox.Show("End " + e.Message);
                }
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
