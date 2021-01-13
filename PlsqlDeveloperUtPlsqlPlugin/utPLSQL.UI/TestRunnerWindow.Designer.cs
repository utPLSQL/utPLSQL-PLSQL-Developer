
namespace utPLSQL
{
    partial class TestRunnerWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestRunnerWindow));
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
            this.dataGridViewTestResults = new System.Windows.Forms.DataGridView();
            this.contextMenuResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemRunTests = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCoverage = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSet = new System.Data.DataSet();
            this.dataTableTestResults = new System.Data.DataTable();
            this.dataColumnTestResultId = new System.Data.DataColumn();
            this.dataColumnTestResultIcon = new System.Data.DataColumn();
            this.dataColumnTestResultPackage = new System.Data.DataColumn();
            this.dataColumnTestResultProcedure = new System.Data.DataColumn();
            this.dataColumnTestResultTime = new System.Data.DataColumn();
            this.dataColumnTestResultStatus = new System.Data.DataColumn();
            this.dataColumnTestResultStart = new System.Data.DataColumn();
            this.dataColumnTestResultEnd = new System.Data.DataColumn();
            this.dataColumnTestResultOwner = new System.Data.DataColumn();
            this.dataColumnTestResultName = new System.Data.DataColumn();
            this.dataColumnTestResultDescription = new System.Data.DataColumn();
            this.dataColumnTestResultError = new System.Data.DataColumn();
            this.dataTableExpectations = new System.Data.DataTable();
            this.dataColumnExpectationTestResultId = new System.Data.DataColumn();
            this.dataColumnExpectationMessage = new System.Data.DataColumn();
            this.dataColumnExpectationCaller = new System.Data.DataColumn();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.txtTestSuitePath = new System.Windows.Forms.TextBox();
            this.lblTestSuitePath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestTime = new System.Windows.Forms.TextBox();
            this.lblTestTime = new System.Windows.Forms.Label();
            this.lblTestEnd = new System.Windows.Forms.Label();
            this.txtTestEnd = new System.Windows.Forms.TextBox();
            this.txtTestStart = new System.Windows.Forms.TextBox();
            this.lblTestStart = new System.Windows.Forms.Label();
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.lblTestName = new System.Windows.Forms.Label();
            this.txtTestDescription = new System.Windows.Forms.TextBox();
            this.lblTestDescription = new System.Windows.Forms.Label();
            this.txtTestProcuedure = new System.Windows.Forms.TextBox();
            this.lblTestProcedure = new System.Windows.Forms.Label();
            this.txtTestPackage = new System.Windows.Forms.TextBox();
            this.lblTestPackage = new System.Windows.Forms.Label();
            this.txtTestOwner = new System.Windows.Forms.TextBox();
            this.lblTestOwner = new System.Windows.Forms.Label();
            this.tabFailures = new System.Windows.Forms.TabPage();
            this.txtFailureMessage = new System.Windows.Forms.TextBox();
            this.dataGridViewExpectations = new System.Windows.Forms.DataGridView();
            this.tabErrors = new System.Windows.Forms.TabPage();
            this.txtErrorMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.cbFailure = new System.Windows.Forms.CheckBox();
            this.cbSuccess = new System.Windows.Forms.CheckBox();
            this.cbError = new System.Windows.Forms.CheckBox();
            this.cbDisabled = new System.Windows.Forms.CheckBox();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.txtSuccess = new System.Windows.Forms.TextBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnRunWithCoverage = new System.Windows.Forms.Button();
            this.colorProgressBar = new ColorProgressBar.ColorProgressBar();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procedureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iconDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataColumnExpectationLine = new System.Data.DataColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestResults)).BeginInit();
            this.contextMenuResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableTestResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableExpectations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabTest.SuspendLayout();
            this.tabFailures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpectations)).BeginInit();
            this.tabErrors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(919, 694);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTests
            // 
            this.lblTests.AutoSize = true;
            this.lblTests.Location = new System.Drawing.Point(12, 49);
            this.lblTests.Name = "lblTests";
            this.lblTests.Size = new System.Drawing.Size(33, 13);
            this.lblTests.TabIndex = 6;
            this.lblTests.Text = "Tests";
            // 
            // txtTests
            // 
            this.txtTests.Location = new System.Drawing.Point(51, 45);
            this.txtTests.Name = "txtTests";
            this.txtTests.ReadOnly = true;
            this.txtTests.Size = new System.Drawing.Size(120, 20);
            this.txtTests.TabIndex = 7;
            this.txtTests.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(842, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(30, 13);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "Time";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(878, 6);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(120, 20);
            this.txtTime.TabIndex = 9;
            this.txtTime.TabStop = false;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(556, 49);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(34, 13);
            this.lblErrors.TabIndex = 12;
            this.lblErrors.Text = "Errors";
            // 
            // txtErrors
            // 
            this.txtErrors.Location = new System.Drawing.Point(596, 45);
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ReadOnly = true;
            this.txtErrors.Size = new System.Drawing.Size(50, 20);
            this.txtErrors.TabIndex = 13;
            this.txtErrors.TabStop = false;
            this.txtErrors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFailures
            // 
            this.lblFailures.AutoSize = true;
            this.lblFailures.Location = new System.Drawing.Point(394, 49);
            this.lblFailures.Name = "lblFailures";
            this.lblFailures.Size = new System.Drawing.Size(43, 13);
            this.lblFailures.TabIndex = 14;
            this.lblFailures.Text = "Failures";
            // 
            // txtFailures
            // 
            this.txtFailures.Location = new System.Drawing.Point(443, 45);
            this.txtFailures.Name = "txtFailures";
            this.txtFailures.ReadOnly = true;
            this.txtFailures.Size = new System.Drawing.Size(50, 20);
            this.txtFailures.TabIndex = 15;
            this.txtFailures.TabStop = false;
            this.txtFailures.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDisabled
            // 
            this.lblDisabled.AutoSize = true;
            this.lblDisabled.Location = new System.Drawing.Point(709, 49);
            this.lblDisabled.Name = "lblDisabled";
            this.lblDisabled.Size = new System.Drawing.Size(48, 13);
            this.lblDisabled.TabIndex = 16;
            this.lblDisabled.Text = "Disabled";
            // 
            // txtDisabled
            // 
            this.txtDisabled.Location = new System.Drawing.Point(763, 45);
            this.txtDisabled.Name = "txtDisabled";
            this.txtDisabled.ReadOnly = true;
            this.txtDisabled.Size = new System.Drawing.Size(50, 20);
            this.txtDisabled.TabIndex = 17;
            this.txtDisabled.TabStop = false;
            this.txtDisabled.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridViewTestResults
            // 
            this.dataGridViewTestResults.AllowUserToAddRows = false;
            this.dataGridViewTestResults.AllowUserToDeleteRows = false;
            this.dataGridViewTestResults.AllowUserToResizeRows = false;
            this.dataGridViewTestResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTestResults.AutoGenerateColumns = false;
            this.dataGridViewTestResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iconDataGridViewImageColumn,
            this.packageDataGridViewTextBoxColumn,
            this.procedureDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn});
            this.dataGridViewTestResults.ContextMenuStrip = this.contextMenuResults;
            this.dataGridViewTestResults.DataMember = "TestResults";
            this.dataGridViewTestResults.DataSource = this.dataSet;
            this.dataGridViewTestResults.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridViewTestResults.Location = new System.Drawing.Point(12, 126);
            this.dataGridViewTestResults.MultiSelect = false;
            this.dataGridViewTestResults.Name = "dataGridViewTestResults";
            this.dataGridViewTestResults.ReadOnly = true;
            this.dataGridViewTestResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewTestResults.RowHeadersVisible = false;
            this.dataGridViewTestResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTestResults.ShowEditingIcon = false;
            this.dataGridViewTestResults.Size = new System.Drawing.Size(986, 324);
            this.dataGridViewTestResults.TabIndex = 18;
            this.dataGridViewTestResults.TabStop = false;
            this.dataGridViewTestResults.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.gridResults_CellContextMenuStripNeeded);
            this.dataGridViewTestResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridResults_CellDoubleClick);
            this.dataGridViewTestResults.SelectionChanged += new System.EventHandler(this.gridResults_SelectionChanged);
            // 
            // contextMenuResults
            // 
            this.contextMenuResults.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.contextMenuResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRunTests,
            this.menuItemCoverage});
            this.contextMenuResults.Name = "contextMenuResults";
            this.contextMenuResults.Size = new System.Drawing.Size(180, 48);
            // 
            // menuItemRunTests
            // 
            this.menuItemRunTests.Name = "menuItemRunTests";
            this.menuItemRunTests.Size = new System.Drawing.Size(179, 22);
            this.menuItemRunTests.Text = "Run Test";
            this.menuItemRunTests.Click += new System.EventHandler(this.menuItemRunTests_ClickAsync);
            // 
            // menuItemCoverage
            // 
            this.menuItemCoverage.Name = "menuItemCoverage";
            this.menuItemCoverage.Size = new System.Drawing.Size(179, 22);
            this.menuItemCoverage.Text = "Run Code Coverage";
            this.menuItemCoverage.Click += new System.EventHandler(this.menuItemCoverage_ClickAsync);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableTestResults,
            this.dataTableExpectations});
            // 
            // dataTableTestResults
            // 
            this.dataTableTestResults.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnTestResultId,
            this.dataColumnTestResultIcon,
            this.dataColumnTestResultPackage,
            this.dataColumnTestResultProcedure,
            this.dataColumnTestResultTime,
            this.dataColumnTestResultStatus,
            this.dataColumnTestResultStart,
            this.dataColumnTestResultEnd,
            this.dataColumnTestResultOwner,
            this.dataColumnTestResultName,
            this.dataColumnTestResultDescription,
            this.dataColumnTestResultError});
            this.dataTableTestResults.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id"}, true)});
            this.dataTableTestResults.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumnTestResultId};
            this.dataTableTestResults.TableName = "TestResults";
            // 
            // dataColumnTestResultId
            // 
            this.dataColumnTestResultId.AllowDBNull = false;
            this.dataColumnTestResultId.Caption = "Id";
            this.dataColumnTestResultId.ColumnName = "Id";
            // 
            // dataColumnTestResultIcon
            // 
            this.dataColumnTestResultIcon.Caption = "Icon";
            this.dataColumnTestResultIcon.ColumnName = "Icon";
            this.dataColumnTestResultIcon.DataType = typeof(byte[]);
            // 
            // dataColumnTestResultPackage
            // 
            this.dataColumnTestResultPackage.Caption = "Package";
            this.dataColumnTestResultPackage.ColumnName = "Package";
            // 
            // dataColumnTestResultProcedure
            // 
            this.dataColumnTestResultProcedure.Caption = "Procedure";
            this.dataColumnTestResultProcedure.ColumnName = "Procedure";
            // 
            // dataColumnTestResultTime
            // 
            this.dataColumnTestResultTime.Caption = "Time";
            this.dataColumnTestResultTime.ColumnName = "Time";
            this.dataColumnTestResultTime.DataType = typeof(decimal);
            // 
            // dataColumnTestResultStatus
            // 
            this.dataColumnTestResultStatus.Caption = "Status";
            this.dataColumnTestResultStatus.ColumnName = "Status";
            // 
            // dataColumnTestResultStart
            // 
            this.dataColumnTestResultStart.Caption = "Start";
            this.dataColumnTestResultStart.ColumnName = "Start";
            this.dataColumnTestResultStart.DataType = typeof(System.DateTime);
            // 
            // dataColumnTestResultEnd
            // 
            this.dataColumnTestResultEnd.Caption = "End";
            this.dataColumnTestResultEnd.ColumnName = "End";
            this.dataColumnTestResultEnd.DataType = typeof(System.DateTime);
            // 
            // dataColumnTestResultOwner
            // 
            this.dataColumnTestResultOwner.Caption = "Owner";
            this.dataColumnTestResultOwner.ColumnName = "Owner";
            // 
            // dataColumnTestResultName
            // 
            this.dataColumnTestResultName.Caption = "Name";
            this.dataColumnTestResultName.ColumnName = "Name";
            // 
            // dataColumnTestResultDescription
            // 
            this.dataColumnTestResultDescription.Caption = "Description";
            this.dataColumnTestResultDescription.ColumnName = "Description";
            // 
            // dataColumnTestResultError
            // 
            this.dataColumnTestResultError.Caption = "Error";
            this.dataColumnTestResultError.ColumnName = "Error";
            // 
            // dataTableExpectations
            // 
            this.dataTableExpectations.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnExpectationTestResultId,
            this.dataColumnExpectationMessage,
            this.dataColumnExpectationCaller,
            this.dataColumnExpectationLine});
            this.dataTableExpectations.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.ForeignKeyConstraint("FkTestResult", "TestResults", new string[] {
                        "Id"}, new string[] {
                        "TestResultId"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.dataTableExpectations.TableName = "Expectations";
            // 
            // dataColumnExpectationTestResultId
            // 
            this.dataColumnExpectationTestResultId.Caption = "TestResultId";
            this.dataColumnExpectationTestResultId.ColumnName = "TestResultId";
            // 
            // dataColumnExpectationMessage
            // 
            this.dataColumnExpectationMessage.Caption = "Message";
            this.dataColumnExpectationMessage.ColumnName = "Message";
            // 
            // dataColumnExpectationCaller
            // 
            this.dataColumnExpectationCaller.Caption = "Caller";
            this.dataColumnExpectationCaller.ColumnName = "Caller";
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(16, 703);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(699, 13);
            this.txtStatus.TabIndex = 7;
            this.txtStatus.TabStop = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Orange;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Orange;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconPictureBox1.IconSize = 20;
            this.iconPictureBox1.Location = new System.Drawing.Point(369, 47);
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
            this.iconPictureBox2.Location = new System.Drawing.Point(530, 47);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(20, 20);
            this.iconPictureBox2.TabIndex = 25;
            this.iconPictureBox2.TabStop = false;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabTest);
            this.tabs.Controls.Add(this.tabFailures);
            this.tabs.Controls.Add(this.tabErrors);
            this.tabs.Location = new System.Drawing.Point(12, 465);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(986, 225);
            this.tabs.TabIndex = 28;
            this.tabs.TabStop = false;
            // 
            // tabTest
            // 
            this.tabTest.BackColor = System.Drawing.SystemColors.Control;
            this.tabTest.Controls.Add(this.txtTestSuitePath);
            this.tabTest.Controls.Add(this.lblTestSuitePath);
            this.tabTest.Controls.Add(this.label2);
            this.tabTest.Controls.Add(this.txtTestTime);
            this.tabTest.Controls.Add(this.lblTestTime);
            this.tabTest.Controls.Add(this.lblTestEnd);
            this.tabTest.Controls.Add(this.txtTestEnd);
            this.tabTest.Controls.Add(this.txtTestStart);
            this.tabTest.Controls.Add(this.lblTestStart);
            this.tabTest.Controls.Add(this.txtTestName);
            this.tabTest.Controls.Add(this.lblTestName);
            this.tabTest.Controls.Add(this.txtTestDescription);
            this.tabTest.Controls.Add(this.lblTestDescription);
            this.tabTest.Controls.Add(this.txtTestProcuedure);
            this.tabTest.Controls.Add(this.lblTestProcedure);
            this.tabTest.Controls.Add(this.txtTestPackage);
            this.tabTest.Controls.Add(this.lblTestPackage);
            this.tabTest.Controls.Add(this.txtTestOwner);
            this.tabTest.Controls.Add(this.lblTestOwner);
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(978, 199);
            this.tabTest.TabIndex = 2;
            this.tabTest.Text = "Test";
            // 
            // txtTestSuitePath
            // 
            this.txtTestSuitePath.Location = new System.Drawing.Point(72, 142);
            this.txtTestSuitePath.Name = "txtTestSuitePath";
            this.txtTestSuitePath.ReadOnly = true;
            this.txtTestSuitePath.Size = new System.Drawing.Size(900, 20);
            this.txtTestSuitePath.TabIndex = 40;
            this.txtTestSuitePath.TabStop = false;
            // 
            // lblTestSuitePath
            // 
            this.lblTestSuitePath.AutoSize = true;
            this.lblTestSuitePath.Location = new System.Drawing.Point(6, 145);
            this.lblTestSuitePath.Name = "lblTestSuitePath";
            this.lblTestSuitePath.Size = new System.Drawing.Size(56, 13);
            this.lblTestSuitePath.TabIndex = 39;
            this.lblTestSuitePath.Text = "Suite Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 38;
            // 
            // txtTestTime
            // 
            this.txtTestTime.Location = new System.Drawing.Point(392, 168);
            this.txtTestTime.Name = "txtTestTime";
            this.txtTestTime.ReadOnly = true;
            this.txtTestTime.Size = new System.Drawing.Size(120, 20);
            this.txtTestTime.TabIndex = 37;
            this.txtTestTime.TabStop = false;
            // 
            // lblTestTime
            // 
            this.lblTestTime.AutoSize = true;
            this.lblTestTime.Location = new System.Drawing.Point(356, 171);
            this.lblTestTime.Name = "lblTestTime";
            this.lblTestTime.Size = new System.Drawing.Size(30, 13);
            this.lblTestTime.TabIndex = 36;
            this.lblTestTime.Text = "Time";
            // 
            // lblTestEnd
            // 
            this.lblTestEnd.AutoSize = true;
            this.lblTestEnd.Location = new System.Drawing.Point(198, 171);
            this.lblTestEnd.Name = "lblTestEnd";
            this.lblTestEnd.Size = new System.Drawing.Size(26, 13);
            this.lblTestEnd.TabIndex = 35;
            this.lblTestEnd.Text = "End";
            // 
            // txtTestEnd
            // 
            this.txtTestEnd.Location = new System.Drawing.Point(230, 168);
            this.txtTestEnd.Name = "txtTestEnd";
            this.txtTestEnd.ReadOnly = true;
            this.txtTestEnd.Size = new System.Drawing.Size(120, 20);
            this.txtTestEnd.TabIndex = 34;
            this.txtTestEnd.TabStop = false;
            // 
            // txtTestStart
            // 
            this.txtTestStart.Location = new System.Drawing.Point(72, 168);
            this.txtTestStart.Name = "txtTestStart";
            this.txtTestStart.ReadOnly = true;
            this.txtTestStart.Size = new System.Drawing.Size(120, 20);
            this.txtTestStart.TabIndex = 33;
            this.txtTestStart.TabStop = false;
            // 
            // lblTestStart
            // 
            this.lblTestStart.AutoSize = true;
            this.lblTestStart.Location = new System.Drawing.Point(6, 171);
            this.lblTestStart.Name = "lblTestStart";
            this.lblTestStart.Size = new System.Drawing.Size(29, 13);
            this.lblTestStart.TabIndex = 32;
            this.lblTestStart.Text = "Start";
            // 
            // txtTestName
            // 
            this.txtTestName.Location = new System.Drawing.Point(72, 90);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.ReadOnly = true;
            this.txtTestName.Size = new System.Drawing.Size(900, 20);
            this.txtTestName.TabIndex = 31;
            this.txtTestName.TabStop = false;
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.Location = new System.Drawing.Point(6, 93);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(35, 13);
            this.lblTestName.TabIndex = 30;
            this.lblTestName.Text = "Name";
            // 
            // txtTestDescription
            // 
            this.txtTestDescription.Location = new System.Drawing.Point(72, 116);
            this.txtTestDescription.Name = "txtTestDescription";
            this.txtTestDescription.ReadOnly = true;
            this.txtTestDescription.Size = new System.Drawing.Size(900, 20);
            this.txtTestDescription.TabIndex = 29;
            this.txtTestDescription.TabStop = false;
            // 
            // lblTestDescription
            // 
            this.lblTestDescription.AutoSize = true;
            this.lblTestDescription.Location = new System.Drawing.Point(6, 119);
            this.lblTestDescription.Name = "lblTestDescription";
            this.lblTestDescription.Size = new System.Drawing.Size(60, 13);
            this.lblTestDescription.TabIndex = 6;
            this.lblTestDescription.Text = "Description";
            // 
            // txtTestProcuedure
            // 
            this.txtTestProcuedure.Location = new System.Drawing.Point(72, 64);
            this.txtTestProcuedure.Name = "txtTestProcuedure";
            this.txtTestProcuedure.ReadOnly = true;
            this.txtTestProcuedure.Size = new System.Drawing.Size(900, 20);
            this.txtTestProcuedure.TabIndex = 5;
            this.txtTestProcuedure.TabStop = false;
            // 
            // lblTestProcedure
            // 
            this.lblTestProcedure.AutoSize = true;
            this.lblTestProcedure.Location = new System.Drawing.Point(6, 67);
            this.lblTestProcedure.Name = "lblTestProcedure";
            this.lblTestProcedure.Size = new System.Drawing.Size(56, 13);
            this.lblTestProcedure.TabIndex = 4;
            this.lblTestProcedure.Text = "Procedure";
            // 
            // txtTestPackage
            // 
            this.txtTestPackage.Location = new System.Drawing.Point(72, 38);
            this.txtTestPackage.Name = "txtTestPackage";
            this.txtTestPackage.ReadOnly = true;
            this.txtTestPackage.Size = new System.Drawing.Size(900, 20);
            this.txtTestPackage.TabIndex = 3;
            this.txtTestPackage.TabStop = false;
            // 
            // lblTestPackage
            // 
            this.lblTestPackage.AutoSize = true;
            this.lblTestPackage.Location = new System.Drawing.Point(6, 41);
            this.lblTestPackage.Name = "lblTestPackage";
            this.lblTestPackage.Size = new System.Drawing.Size(50, 13);
            this.lblTestPackage.TabIndex = 2;
            this.lblTestPackage.Text = "Package";
            // 
            // txtTestOwner
            // 
            this.txtTestOwner.Location = new System.Drawing.Point(72, 12);
            this.txtTestOwner.Name = "txtTestOwner";
            this.txtTestOwner.ReadOnly = true;
            this.txtTestOwner.Size = new System.Drawing.Size(900, 20);
            this.txtTestOwner.TabIndex = 1;
            this.txtTestOwner.TabStop = false;
            // 
            // lblTestOwner
            // 
            this.lblTestOwner.AutoSize = true;
            this.lblTestOwner.Location = new System.Drawing.Point(6, 15);
            this.lblTestOwner.Name = "lblTestOwner";
            this.lblTestOwner.Size = new System.Drawing.Size(38, 13);
            this.lblTestOwner.TabIndex = 0;
            this.lblTestOwner.Text = "Owner";
            // 
            // tabFailures
            // 
            this.tabFailures.BackColor = System.Drawing.SystemColors.Control;
            this.tabFailures.Controls.Add(this.txtFailureMessage);
            this.tabFailures.Controls.Add(this.dataGridViewExpectations);
            this.tabFailures.Location = new System.Drawing.Point(4, 22);
            this.tabFailures.Name = "tabFailures";
            this.tabFailures.Padding = new System.Windows.Forms.Padding(3);
            this.tabFailures.Size = new System.Drawing.Size(978, 199);
            this.tabFailures.TabIndex = 0;
            this.tabFailures.Text = "Failures";
            // 
            // txtFailureMessage
            // 
            this.txtFailureMessage.Location = new System.Drawing.Point(131, 6);
            this.txtFailureMessage.Multiline = true;
            this.txtFailureMessage.Name = "txtFailureMessage";
            this.txtFailureMessage.ReadOnly = true;
            this.txtFailureMessage.Size = new System.Drawing.Size(841, 187);
            this.txtFailureMessage.TabIndex = 1;
            this.txtFailureMessage.TabStop = false;
            // 
            // dataGridViewExpectations
            // 
            this.dataGridViewExpectations.AllowUserToAddRows = false;
            this.dataGridViewExpectations.AllowUserToDeleteRows = false;
            this.dataGridViewExpectations.AutoGenerateColumns = false;
            this.dataGridViewExpectations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpectations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Line});
            this.dataGridViewExpectations.DataMember = "Expectations";
            this.dataGridViewExpectations.DataSource = this.dataSet;
            this.dataGridViewExpectations.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewExpectations.MultiSelect = false;
            this.dataGridViewExpectations.Name = "dataGridViewExpectations";
            this.dataGridViewExpectations.ReadOnly = true;
            this.dataGridViewExpectations.RowHeadersVisible = false;
            this.dataGridViewExpectations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExpectations.ShowEditingIcon = false;
            this.dataGridViewExpectations.Size = new System.Drawing.Size(119, 187);
            this.dataGridViewExpectations.TabIndex = 0;
            this.dataGridViewExpectations.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTestFailures_CellDoubleClick);
            this.dataGridViewExpectations.SelectionChanged += new System.EventHandler(this.dataGridViewExpectations_SelectionChanged);
            // 
            // tabErrors
            // 
            this.tabErrors.BackColor = System.Drawing.SystemColors.Control;
            this.tabErrors.Controls.Add(this.txtErrorMessage);
            this.tabErrors.Location = new System.Drawing.Point(4, 22);
            this.tabErrors.Name = "tabErrors";
            this.tabErrors.Padding = new System.Windows.Forms.Padding(3);
            this.tabErrors.Size = new System.Drawing.Size(978, 199);
            this.tabErrors.TabIndex = 1;
            this.tabErrors.Text = "Errors";
            // 
            // txtErrorMessage
            // 
            this.txtErrorMessage.Location = new System.Drawing.Point(3, 6);
            this.txtErrorMessage.Multiline = true;
            this.txtErrorMessage.Name = "txtErrorMessage";
            this.txtErrorMessage.ReadOnly = true;
            this.txtErrorMessage.Size = new System.Drawing.Size(969, 188);
            this.txtErrorMessage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Path";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(51, 6);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(466, 20);
            this.txtPath.TabIndex = 30;
            this.txtPath.TabStop = false;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(523, 9);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(29, 13);
            this.lblStart.TabIndex = 31;
            this.lblStart.Text = "Start";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(558, 6);
            this.txtStart.Name = "txtStart";
            this.txtStart.ReadOnly = true;
            this.txtStart.Size = new System.Drawing.Size(120, 20);
            this.txtStart.TabIndex = 32;
            this.txtStart.TabStop = false;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(684, 9);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(26, 13);
            this.lblEnd.TabIndex = 33;
            this.lblEnd.Text = "End";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(716, 6);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.ReadOnly = true;
            this.txtEnd.Size = new System.Drawing.Size(120, 20);
            this.txtEnd.TabIndex = 34;
            this.txtEnd.TabStop = false;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox4.ForeColor = System.Drawing.Color.Gray;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.iconPictureBox4.IconColor = System.Drawing.Color.Gray;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 20;
            this.iconPictureBox4.Location = new System.Drawing.Point(683, 47);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(20, 20);
            this.iconPictureBox4.TabIndex = 27;
            this.iconPictureBox4.TabStop = false;
            // 
            // cbFailure
            // 
            this.cbFailure.AutoSize = true;
            this.cbFailure.Checked = true;
            this.cbFailure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFailure.Location = new System.Drawing.Point(499, 48);
            this.cbFailure.Name = "cbFailure";
            this.cbFailure.Size = new System.Drawing.Size(15, 14);
            this.cbFailure.TabIndex = 1;
            this.cbFailure.UseVisualStyleBackColor = true;
            this.cbFailure.CheckedChanged += new System.EventHandler(this.cbFailures_CheckedChanged);
            // 
            // cbSuccess
            // 
            this.cbSuccess.AutoSize = true;
            this.cbSuccess.Checked = true;
            this.cbSuccess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSuccess.Location = new System.Drawing.Point(338, 48);
            this.cbSuccess.Name = "cbSuccess";
            this.cbSuccess.Size = new System.Drawing.Size(15, 14);
            this.cbSuccess.TabIndex = 0;
            this.cbSuccess.UseVisualStyleBackColor = true;
            this.cbSuccess.CheckedChanged += new System.EventHandler(this.cbSuccess_CheckedChanged);
            // 
            // cbError
            // 
            this.cbError.AutoSize = true;
            this.cbError.Checked = true;
            this.cbError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbError.Location = new System.Drawing.Point(652, 48);
            this.cbError.Name = "cbError";
            this.cbError.Size = new System.Drawing.Size(15, 14);
            this.cbError.TabIndex = 2;
            this.cbError.UseVisualStyleBackColor = true;
            this.cbError.CheckedChanged += new System.EventHandler(this.cbErrors_CheckedChanged);
            // 
            // cbDisabled
            // 
            this.cbDisabled.AutoSize = true;
            this.cbDisabled.Checked = true;
            this.cbDisabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDisabled.Location = new System.Drawing.Point(819, 48);
            this.cbDisabled.Name = "cbDisabled";
            this.cbDisabled.Size = new System.Drawing.Size(15, 14);
            this.cbDisabled.TabIndex = 3;
            this.cbDisabled.UseVisualStyleBackColor = true;
            this.cbDisabled.CheckedChanged += new System.EventHandler(this.cbDisabled_CheckedChanged);
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Location = new System.Drawing.Point(228, 49);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(48, 13);
            this.lblSuccess.TabIndex = 3;
            this.lblSuccess.Text = "Success";
            // 
            // txtSuccess
            // 
            this.txtSuccess.Location = new System.Drawing.Point(282, 45);
            this.txtSuccess.Name = "txtSuccess";
            this.txtSuccess.ReadOnly = true;
            this.txtSuccess.Size = new System.Drawing.Size(50, 20);
            this.txtSuccess.TabIndex = 40;
            this.txtSuccess.TabStop = false;
            this.txtSuccess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.DarkGreen;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.iconPictureBox3.IconColor = System.Drawing.Color.DarkGreen;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconPictureBox3.IconSize = 20;
            this.iconPictureBox3.Location = new System.Drawing.Point(202, 47);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(20, 20);
            this.iconPictureBox3.TabIndex = 41;
            this.iconPictureBox3.TabStop = false;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(722, 694);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnRunWithCoverage
            // 
            this.btnRunWithCoverage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunWithCoverage.Location = new System.Drawing.Point(803, 694);
            this.btnRunWithCoverage.Name = "btnRunWithCoverage";
            this.btnRunWithCoverage.Size = new System.Drawing.Size(110, 23);
            this.btnRunWithCoverage.TabIndex = 6;
            this.btnRunWithCoverage.Text = "Run with Coverage";
            this.btnRunWithCoverage.UseVisualStyleBackColor = true;
            this.btnRunWithCoverage.Click += new System.EventHandler(this.button1_Click);
            // 
            // colorProgressBar
            // 
            this.colorProgressBar.BarColor = System.Drawing.Color.Green;
            this.colorProgressBar.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colorProgressBar.Location = new System.Drawing.Point(12, 86);
            this.colorProgressBar.Maximum = 100;
            this.colorProgressBar.Minimum = 0;
            this.colorProgressBar.Name = "colorProgressBar";
            this.colorProgressBar.Size = new System.Drawing.Size(986, 23);
            this.colorProgressBar.Step = 10;
            this.colorProgressBar.TabIndex = 43;
            this.colorProgressBar.Value = 0;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            this.timeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.timeDataGridViewTextBoxColumn.FillWeight = 203.0457F;
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // procedureDataGridViewTextBoxColumn
            // 
            this.procedureDataGridViewTextBoxColumn.DataPropertyName = "Procedure";
            this.procedureDataGridViewTextBoxColumn.FillWeight = 182.3871F;
            this.procedureDataGridViewTextBoxColumn.HeaderText = "Procedure";
            this.procedureDataGridViewTextBoxColumn.Name = "procedureDataGridViewTextBoxColumn";
            this.procedureDataGridViewTextBoxColumn.ReadOnly = true;
            this.procedureDataGridViewTextBoxColumn.Width = 530;
            // 
            // packageDataGridViewTextBoxColumn
            // 
            this.packageDataGridViewTextBoxColumn.DataPropertyName = "Package";
            this.packageDataGridViewTextBoxColumn.FillWeight = 14.3167F;
            this.packageDataGridViewTextBoxColumn.HeaderText = "Package";
            this.packageDataGridViewTextBoxColumn.Name = "packageDataGridViewTextBoxColumn";
            this.packageDataGridViewTextBoxColumn.ReadOnly = true;
            this.packageDataGridViewTextBoxColumn.Width = 300;
            // 
            // iconDataGridViewImageColumn
            // 
            this.iconDataGridViewImageColumn.DataPropertyName = "Icon";
            this.iconDataGridViewImageColumn.FillWeight = 0.2504606F;
            this.iconDataGridViewImageColumn.HeaderText = "";
            this.iconDataGridViewImageColumn.Name = "iconDataGridViewImageColumn";
            this.iconDataGridViewImageColumn.ReadOnly = true;
            this.iconDataGridViewImageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.iconDataGridViewImageColumn.Width = 35;
            // 
            // dataColumnExpectationLine
            // 
            this.dataColumnExpectationLine.Caption = "Line";
            this.dataColumnExpectationLine.ColumnName = "Line";
            // 
            // Line
            // 
            this.Line.DataPropertyName = "Line";
            this.Line.FillWeight = 101.5228F;
            this.Line.HeaderText = "Line";
            this.Line.Name = "Line";
            this.Line.ReadOnly = true;
            // 
            // TestRunnerWindow
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.colorProgressBar);
            this.Controls.Add(this.btnRunWithCoverage);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.iconPictureBox3);
            this.Controls.Add(this.txtSuccess);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.cbDisabled);
            this.Controls.Add(this.cbError);
            this.Controls.Add(this.cbSuccess);
            this.Controls.Add(this.cbFailure);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.iconPictureBox4);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.dataGridViewTestResults);
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
            this.Name = "TestRunnerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "utPLSQL TestRunner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestResultWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestResults)).EndInit();
            this.contextMenuResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableTestResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableExpectations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabTest.ResumeLayout(false);
            this.tabTest.PerformLayout();
            this.tabFailures.ResumeLayout(false);
            this.tabFailures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpectations)).EndInit();
            this.tabErrors.ResumeLayout(false);
            this.tabErrors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridViewTestResults;
        private System.Windows.Forms.TextBox txtStatus;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabFailures;
        private System.Windows.Forms.TabPage tabErrors;
        private System.Windows.Forms.TextBox txtErrorMessage;
        private System.Windows.Forms.TabPage tabTest;
        private System.Windows.Forms.Label lblTestOwner;
        private System.Windows.Forms.TextBox txtTestOwner;
        private System.Windows.Forms.Label lblTestPackage;
        private System.Windows.Forms.TextBox txtTestPackage;
        private System.Windows.Forms.Label lblTestProcedure;
        private System.Windows.Forms.TextBox txtTestProcuedure;
        private System.Windows.Forms.Label lblTestDescription;
        private System.Windows.Forms.TextBox txtTestDescription;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.Label lblTestStart;
        private System.Windows.Forms.TextBox txtTestStart;
        private System.Windows.Forms.TextBox txtTestEnd;
        private System.Windows.Forms.Label lblTestEnd;
        private System.Windows.Forms.DataGridView dataGridViewExpectations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label lblTestTime;
        private System.Windows.Forms.TextBox txtTestTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTestSuitePath;
        private System.Windows.Forms.TextBox txtTestSuitePath;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private System.Windows.Forms.ContextMenuStrip contextMenuResults;
        private System.Windows.Forms.ToolStripMenuItem menuItemRunTests;
        private System.Windows.Forms.ToolStripMenuItem menuItemCoverage;
        private System.Windows.Forms.CheckBox cbFailure;
        private System.Windows.Forms.CheckBox cbSuccess;
        private System.Windows.Forms.CheckBox cbError;
        private System.Windows.Forms.CheckBox cbDisabled;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.TextBox txtSuccess;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnRunWithCoverage;
        private System.Data.DataSet dataSet;
        private System.Data.DataTable dataTableTestResults;
        private System.Data.DataColumn dataColumnTestResultId;
        private System.Data.DataColumn dataColumnTestResultIcon;
        private System.Data.DataColumn dataColumnTestResultPackage;
        private System.Data.DataColumn dataColumnTestResultProcedure;
        private System.Data.DataColumn dataColumnTestResultTime;
        private System.Data.DataColumn dataColumnTestResultStatus;
        private System.Data.DataColumn dataColumnTestResultStart;
        private System.Data.DataColumn dataColumnTestResultEnd;
        private System.Data.DataColumn dataColumnTestResultOwner;
        private System.Data.DataColumn dataColumnTestResultName;
        private System.Data.DataColumn dataColumnTestResultDescription;
        private System.Data.DataColumn dataColumnTestResultError;
        private System.Data.DataTable dataTableExpectations;
        private System.Data.DataColumn dataColumnExpectationTestResultId;
        private System.Data.DataColumn dataColumnExpectationMessage;
        private System.Data.DataColumn dataColumnExpectationCaller;
        private ColorProgressBar.ColorProgressBar colorProgressBar;
        private System.Windows.Forms.TextBox txtFailureMessage;
        private System.Windows.Forms.DataGridViewImageColumn iconDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn procedureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Data.DataColumn dataColumnExpectationLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
    }
}