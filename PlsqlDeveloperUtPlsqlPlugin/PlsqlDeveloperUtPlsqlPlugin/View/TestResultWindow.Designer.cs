
namespace PlsqlDeveloperUtPlsqlPlugin
{
    partial class TestResultWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestResultWindow));
            this.btnClose = new System.Windows.Forms.Button();
            this.treeResult = new System.Windows.Forms.TreeView();
            this.lblTests = new System.Windows.Forms.Label();
            this.txtTests = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(12, 696);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 21);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // treeResult
            // 
            this.treeResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeResult.Location = new System.Drawing.Point(12, 32);
            this.treeResult.Name = "treeResult";
            this.treeResult.Size = new System.Drawing.Size(986, 658);
            this.treeResult.TabIndex = 5;
            // 
            // lblTests
            // 
            this.lblTests.AutoSize = true;
            this.lblTests.Location = new System.Drawing.Point(12, 9);
            this.lblTests.Name = "lblTests";
            this.lblTests.Size = new System.Drawing.Size(33, 13);
            this.lblTests.TabIndex = 6;
            this.lblTests.Text = "Tests";
            // 
            // txtTests
            // 
            this.txtTests.Location = new System.Drawing.Point(51, 6);
            this.txtTests.Name = "txtTests";
            this.txtTests.ReadOnly = true;
            this.txtTests.Size = new System.Drawing.Size(100, 20);
            this.txtTests.TabIndex = 7;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(197, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(30, 13);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "Time";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(233, 6);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 9;
            // 
            // TestResultWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtTests);
            this.Controls.Add(this.lblTests);
            this.Controls.Add(this.treeResult);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestResultWindow";
            this.Text = "utPLSQL TestRunner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestResultWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TreeView treeResult;
        private System.Windows.Forms.Label lblTests;
        private System.Windows.Forms.TextBox txtTests;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtTime;
    }
}