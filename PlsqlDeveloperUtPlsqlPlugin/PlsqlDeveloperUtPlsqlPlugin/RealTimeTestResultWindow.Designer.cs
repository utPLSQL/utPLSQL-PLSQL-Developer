
namespace PlsqlDeveloperUtPlsqlPlugin
{
    partial class RealTimeTestResultWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealTimeTestResultWindow));
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTests = new System.Windows.Forms.Label();
            this.txtTests = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblErrors = new System.Windows.Forms.Label();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.lblFailures = new System.Windows.Forms.Label();
            this.txtFailures = new System.Windows.Forms.TextBox();
            this.lblDisabled = new System.Windows.Forms.Label();
            this.txtDisabled = new System.Windows.Forms.TextBox();
            this.gridResults = new System.Windows.Forms.DataGridView();
            this.txtBar = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridResults)).BeginInit();
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
            this.lblTime.Location = new System.Drawing.Point(862, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(30, 13);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "Time";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(898, 6);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 9;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(262, 9);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(34, 13);
            this.lblErrors.TabIndex = 12;
            this.lblErrors.Text = "Errors";
            // 
            // txtErrors
            // 
            this.txtErrors.Location = new System.Drawing.Point(302, 6);
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ReadOnly = true;
            this.txtErrors.Size = new System.Drawing.Size(50, 20);
            this.txtErrors.TabIndex = 13;
            // 
            // lblFailures
            // 
            this.lblFailures.AutoSize = true;
            this.lblFailures.Location = new System.Drawing.Point(157, 9);
            this.lblFailures.Name = "lblFailures";
            this.lblFailures.Size = new System.Drawing.Size(43, 13);
            this.lblFailures.TabIndex = 14;
            this.lblFailures.Text = "Failures";
            // 
            // txtFailures
            // 
            this.txtFailures.Location = new System.Drawing.Point(206, 6);
            this.txtFailures.Name = "txtFailures";
            this.txtFailures.ReadOnly = true;
            this.txtFailures.Size = new System.Drawing.Size(50, 20);
            this.txtFailures.TabIndex = 15;
            // 
            // lblDisabled
            // 
            this.lblDisabled.AutoSize = true;
            this.lblDisabled.Location = new System.Drawing.Point(358, 9);
            this.lblDisabled.Name = "lblDisabled";
            this.lblDisabled.Size = new System.Drawing.Size(48, 13);
            this.lblDisabled.TabIndex = 16;
            this.lblDisabled.Text = "Disabled";
            // 
            // txtDisabled
            // 
            this.txtDisabled.Location = new System.Drawing.Point(412, 6);
            this.txtDisabled.Name = "txtDisabled";
            this.txtDisabled.ReadOnly = true;
            this.txtDisabled.Size = new System.Drawing.Size(50, 20);
            this.txtDisabled.TabIndex = 17;
            // 
            // gridResults
            // 
            this.gridResults.AllowUserToAddRows = false;
            this.gridResults.AllowUserToDeleteRows = false;
            this.gridResults.AllowUserToResizeRows = false;
            this.gridResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridResults.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gridResults.Location = new System.Drawing.Point(12, 85);
            this.gridResults.MultiSelect = false;
            this.gridResults.Name = "gridResults";
            this.gridResults.ReadOnly = true;
            this.gridResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridResults.RowHeadersVisible = false;
            this.gridResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridResults.ShowEditingIcon = false;
            this.gridResults.Size = new System.Drawing.Size(986, 605);
            this.gridResults.TabIndex = 18;
            // 
            // txtBar
            // 
            this.txtBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBar.Location = new System.Drawing.Point(12, 43);
            this.txtBar.Multiline = true;
            this.txtBar.Name = "txtBar";
            this.txtBar.ReadOnly = true;
            this.txtBar.Size = new System.Drawing.Size(986, 20);
            this.txtBar.TabIndex = 19;
            // 
            // txtStatus
            // 
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Location = new System.Drawing.Point(706, 9);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(150, 13);
            this.txtStatus.TabIndex = 20;
            // 
            // RealTimeTestResultWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtBar);
            this.Controls.Add(this.gridResults);
            this.Controls.Add(this.txtDisabled);
            this.Controls.Add(this.lblDisabled);
            this.Controls.Add(this.txtFailures);
            this.Controls.Add(this.lblFailures);
            this.Controls.Add(this.txtErrors);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtTests);
            this.Controls.Add(this.lblTests);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RealTimeTestResultWindow";
            this.Text = "utPLSQL TestRunner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestResultWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTests;
        private System.Windows.Forms.TextBox txtTests;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.TextBox txtErrors;
        private System.Windows.Forms.Label lblFailures;
        private System.Windows.Forms.TextBox txtFailures;
        private System.Windows.Forms.Label lblDisabled;
        private System.Windows.Forms.TextBox txtDisabled;
        private System.Windows.Forms.DataGridView gridResults;
        private System.Windows.Forms.TextBox txtBar;
        private System.Windows.Forms.TextBox txtStatus;
    }
}