
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
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblWarning = new System.Windows.Forms.Label();
            this.txtWarning = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
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
            this.lblErrors.Location = new System.Drawing.Point(183, 9);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(34, 13);
            this.lblErrors.TabIndex = 12;
            this.lblErrors.Text = "Errors";
            // 
            // txtErrors
            // 
            this.txtErrors.Location = new System.Drawing.Point(223, 6);
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ReadOnly = true;
            this.txtErrors.Size = new System.Drawing.Size(50, 20);
            this.txtErrors.TabIndex = 13;
            this.txtErrors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFailures
            // 
            this.lblFailures.AutoSize = true;
            this.lblFailures.Location = new System.Drawing.Point(305, 9);
            this.lblFailures.Name = "lblFailures";
            this.lblFailures.Size = new System.Drawing.Size(43, 13);
            this.lblFailures.TabIndex = 14;
            this.lblFailures.Text = "Failures";
            // 
            // txtFailures
            // 
            this.txtFailures.Location = new System.Drawing.Point(354, 6);
            this.txtFailures.Name = "txtFailures";
            this.txtFailures.ReadOnly = true;
            this.txtFailures.Size = new System.Drawing.Size(50, 20);
            this.txtFailures.TabIndex = 15;
            this.txtFailures.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDisabled
            // 
            this.lblDisabled.AutoSize = true;
            this.lblDisabled.Location = new System.Drawing.Point(571, 9);
            this.lblDisabled.Name = "lblDisabled";
            this.lblDisabled.Size = new System.Drawing.Size(48, 13);
            this.lblDisabled.TabIndex = 16;
            this.lblDisabled.Text = "Disabled";
            // 
            // txtDisabled
            // 
            this.txtDisabled.Location = new System.Drawing.Point(625, 6);
            this.txtDisabled.Name = "txtDisabled";
            this.txtDisabled.ReadOnly = true;
            this.txtDisabled.Size = new System.Drawing.Size(50, 20);
            this.txtDisabled.TabIndex = 17;
            this.txtDisabled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.gridResults.ShowEditingIcon = false;
            this.gridResults.Size = new System.Drawing.Size(986, 605);
            this.gridResults.TabIndex = 18;
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
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 32);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(983, 23);
            this.progressBar.TabIndex = 21;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Location = new System.Drawing.Point(436, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(47, 13);
            this.lblWarning.TabIndex = 22;
            this.lblWarning.Text = "Warning";
            // 
            // txtWarning
            // 
            this.txtWarning.Location = new System.Drawing.Point(489, 6);
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.ReadOnly = true;
            this.txtWarning.Size = new System.Drawing.Size(50, 20);
            this.txtWarning.TabIndex = 23;
            this.txtWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Orange;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Orange;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconPictureBox1.IconSize = 20;
            this.iconPictureBox1.Location = new System.Drawing.Point(284, 8);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(20, 20);
            this.iconPictureBox1.TabIndex = 24;
            this.iconPictureBox1.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Red;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Red;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 20;
            this.iconPictureBox2.Location = new System.Drawing.Point(162, 8);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(20, 20);
            this.iconPictureBox2.TabIndex = 25;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.Orange;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.iconPictureBox3.IconColor = System.Drawing.Color.Orange;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 20;
            this.iconPictureBox3.Location = new System.Drawing.Point(415, 8);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(20, 20);
            this.iconPictureBox3.TabIndex = 26;
            this.iconPictureBox3.TabStop = false;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox4.ForeColor = System.Drawing.Color.Gray;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.iconPictureBox4.IconColor = System.Drawing.Color.Gray;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 20;
            this.iconPictureBox4.Location = new System.Drawing.Point(550, 8);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(20, 20);
            this.iconPictureBox4.TabIndex = 27;
            this.iconPictureBox4.TabStop = false;
            // 
            // RealTimeTestResultWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.iconPictureBox4);
            this.Controls.Add(this.iconPictureBox3);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.txtWarning);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtStatus);
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
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "RealTimeTestResultWindow";
            this.Text = "utPLSQL TestRunner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestResultWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
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
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.TextBox txtWarning;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
    }
}