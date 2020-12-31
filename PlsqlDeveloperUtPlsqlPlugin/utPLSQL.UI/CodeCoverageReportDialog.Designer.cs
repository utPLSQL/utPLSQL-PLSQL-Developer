
namespace utPLSQL
{
    partial class CodeCoverageReportDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeCoverageReportDialog));
            this.txtPaths = new System.Windows.Forms.TextBox();
            this.txtSchemas = new System.Windows.Forms.TextBox();
            this.txtIncludes = new System.Windows.Forms.TextBox();
            this.txtExluces = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblPaths = new System.Windows.Forms.Label();
            this.lblIncludes = new System.Windows.Forms.Label();
            this.lblExcludes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPaths
            // 
            this.txtPaths.Location = new System.Drawing.Point(119, 12);
            this.txtPaths.Multiline = true;
            this.txtPaths.Name = "txtPaths";
            this.txtPaths.ReadOnly = true;
            this.txtPaths.Size = new System.Drawing.Size(453, 80);
            this.txtPaths.TabIndex = 0;
            this.txtPaths.TabStop = false;
            // 
            // txtSchemas
            // 
            this.txtSchemas.Location = new System.Drawing.Point(119, 98);
            this.txtSchemas.Name = "txtSchemas";
            this.txtSchemas.Size = new System.Drawing.Size(453, 20);
            this.txtSchemas.TabIndex = 1;
            this.txtSchemas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressed);
            // 
            // txtIncludes
            // 
            this.txtIncludes.Location = new System.Drawing.Point(119, 124);
            this.txtIncludes.Multiline = true;
            this.txtIncludes.Name = "txtIncludes";
            this.txtIncludes.Size = new System.Drawing.Size(453, 80);
            this.txtIncludes.TabIndex = 2;
            this.txtIncludes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressed);
            // 
            // txtExluces
            // 
            this.txtExluces.Location = new System.Drawing.Point(119, 210);
            this.txtExluces.Multiline = true;
            this.txtExluces.Name = "txtExluces";
            this.txtExluces.Size = new System.Drawing.Size(453, 80);
            this.txtExluces.TabIndex = 3;
            this.txtExluces.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Schemas under test";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(497, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRun.Location = new System.Drawing.Point(416, 296);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // lblPaths
            // 
            this.lblPaths.AutoSize = true;
            this.lblPaths.Location = new System.Drawing.Point(12, 15);
            this.lblPaths.Name = "lblPaths";
            this.lblPaths.Size = new System.Drawing.Size(79, 13);
            this.lblPaths.TabIndex = 7;
            this.lblPaths.Text = "utPLSQL paths";
            // 
            // lblIncludes
            // 
            this.lblIncludes.AutoSize = true;
            this.lblIncludes.Location = new System.Drawing.Point(12, 127);
            this.lblIncludes.Name = "lblIncludes";
            this.lblIncludes.Size = new System.Drawing.Size(79, 13);
            this.lblIncludes.TabIndex = 8;
            this.lblIncludes.Text = "Include objects";
            // 
            // lblExcludes
            // 
            this.lblExcludes.AutoSize = true;
            this.lblExcludes.Location = new System.Drawing.Point(12, 213);
            this.lblExcludes.Name = "lblExcludes";
            this.lblExcludes.Size = new System.Drawing.Size(82, 13);
            this.lblExcludes.TabIndex = 9;
            this.lblExcludes.Text = "Exclude objects";
            // 
            // CodeCoverateReportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 331);
            this.Controls.Add(this.lblExcludes);
            this.Controls.Add(this.lblIncludes);
            this.Controls.Add(this.lblPaths);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExluces);
            this.Controls.Add(this.txtIncludes);
            this.Controls.Add(this.txtSchemas);
            this.Controls.Add(this.txtPaths);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CodeCoverateReportDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Code Coverate Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPaths;
        private System.Windows.Forms.TextBox txtSchemas;
        private System.Windows.Forms.TextBox txtIncludes;
        private System.Windows.Forms.TextBox txtExluces;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblPaths;
        private System.Windows.Forms.Label lblIncludes;
        private System.Windows.Forms.Label lblExcludes;
    }
}