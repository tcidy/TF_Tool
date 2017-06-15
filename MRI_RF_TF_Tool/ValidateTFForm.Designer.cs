namespace MRI_RF_TF_Tool {
    partial class ValidateTFForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TransferFunctionFilenameLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BrowseTransferFunctionButton = new System.Windows.Forms.Button();
            this.ViewTFButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.TemperatureRadioButton = new System.Windows.Forms.RadioButton();
            this.voltageRadioButton = new System.Windows.Forms.RadioButton();
            this.ETanFilesLabel = new System.Windows.Forms.Label();
            this.ETanFilesListBox = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddEtanFilesButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.clearEtanButton = new System.Windows.Forms.Button();
            this.SummaryFileLabel = new System.Windows.Forms.Label();
            this.summaryFilenameLabel = new System.Windows.Forms.Label();
            this.summaryFileBrowseButton = new System.Windows.Forms.Button();
            this.percentUncLabel = new System.Windows.Forms.Label();
            this.pcentUncTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.uncOffsetTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveSummaryFileCheckbox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddEtanFilesForScale = new System.Windows.Forms.Button();
            this.Remove2 = new System.Windows.Forms.Button();
            this.clearScaleEtanButton = new System.Windows.Forms.Button();
            this.EtanFileListForScaling = new System.Windows.Forms.ListBox();
            this.ValidateButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.Manual_V = new System.Windows.Forms.RadioButton();
            this.Auto_V = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.numPathways = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioK1Rate = new System.Windows.Forms.RadioButton();
            this.radioTrendSlope = new System.Windows.Forms.RadioButton();
            this.radioScaleFactor = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveOptFileCheckbox = new System.Windows.Forms.CheckBox();
            this.saveOPTTFcheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TFAdjPanel = new System.Windows.Forms.Panel();
            this.truncateLengthBegin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.offsetR = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.offsetP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TFAutoAdj = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.truncateLengthEnd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            this.TFAdjPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 357F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Controls.Add(this.TransferFunctionFilenameLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ETanFilesLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ETanFilesListBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.SummaryFileLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.summaryFilenameLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.summaryFileBrowseButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.percentUncLabel, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.pcentUncTextBox, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.saveSummaryFileCheckbox, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.EtanFileListForScaling, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.ValidateButton, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel6, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel7, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel8, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel9, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.TFAdjPanel, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 636);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // TransferFunctionFilenameLabel
            // 
            this.TransferFunctionFilenameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferFunctionFilenameLabel.Location = new System.Drawing.Point(237, 37);
            this.TransferFunctionFilenameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TransferFunctionFilenameLabel.Name = "TransferFunctionFilenameLabel";
            this.TransferFunctionFilenameLabel.Size = new System.Drawing.Size(350, 21);
            this.TransferFunctionFilenameLabel.TabIndex = 3;
            this.TransferFunctionFilenameLabel.Text = "Unspecified";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.BrowseTransferFunctionButton);
            this.flowLayoutPanel1.Controls.Add(this.ViewTFButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(237, 62);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(350, 36);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // BrowseTransferFunctionButton
            // 
            this.BrowseTransferFunctionButton.Location = new System.Drawing.Point(4, 4);
            this.BrowseTransferFunctionButton.Margin = new System.Windows.Forms.Padding(4);
            this.BrowseTransferFunctionButton.Name = "BrowseTransferFunctionButton";
            this.BrowseTransferFunctionButton.Size = new System.Drawing.Size(100, 28);
            this.BrowseTransferFunctionButton.TabIndex = 0;
            this.BrowseTransferFunctionButton.Text = "Browse...";
            this.BrowseTransferFunctionButton.UseVisualStyleBackColor = true;
            this.BrowseTransferFunctionButton.Click += new System.EventHandler(this.BrowseTransferFunctionButton_Click);
            // 
            // ViewTFButton
            // 
            this.ViewTFButton.Enabled = false;
            this.ViewTFButton.Location = new System.Drawing.Point(112, 4);
            this.ViewTFButton.Margin = new System.Windows.Forms.Padding(4);
            this.ViewTFButton.Name = "ViewTFButton";
            this.ViewTFButton.Size = new System.Drawing.Size(100, 28);
            this.ViewTFButton.TabIndex = 1;
            this.ViewTFButton.Text = "View....";
            this.ViewTFButton.UseVisualStyleBackColor = true;
            this.ViewTFButton.Click += new System.EventHandler(this.ViewTFButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.TemperatureRadioButton);
            this.flowLayoutPanel2.Controls.Add(this.voltageRadioButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(237, 4);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(350, 29);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // TemperatureRadioButton
            // 
            this.TemperatureRadioButton.AutoSize = true;
            this.TemperatureRadioButton.Checked = true;
            this.TemperatureRadioButton.Location = new System.Drawing.Point(4, 4);
            this.TemperatureRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.TemperatureRadioButton.Name = "TemperatureRadioButton";
            this.TemperatureRadioButton.Size = new System.Drawing.Size(111, 21);
            this.TemperatureRadioButton.TabIndex = 0;
            this.TemperatureRadioButton.TabStop = true;
            this.TemperatureRadioButton.Text = "Temperature";
            this.TemperatureRadioButton.UseVisualStyleBackColor = true;
            // 
            // voltageRadioButton
            // 
            this.voltageRadioButton.AutoSize = true;
            this.voltageRadioButton.Location = new System.Drawing.Point(123, 4);
            this.voltageRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.voltageRadioButton.Name = "voltageRadioButton";
            this.voltageRadioButton.Size = new System.Drawing.Size(128, 21);
            this.voltageRadioButton.TabIndex = 1;
            this.voltageRadioButton.Text = "Header Voltage";
            this.voltageRadioButton.UseVisualStyleBackColor = true;
            this.voltageRadioButton.CheckedChanged += new System.EventHandler(this.voltageRadioButton_CheckedChanged);
            // 
            // ETanFilesLabel
            // 
            this.ETanFilesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ETanFilesLabel.AutoSize = true;
            this.ETanFilesLabel.Location = new System.Drawing.Point(150, 157);
            this.ETanFilesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ETanFilesLabel.Name = "ETanFilesLabel";
            this.ETanFilesLabel.Size = new System.Drawing.Size(79, 17);
            this.ETanFilesLabel.TabIndex = 8;
            this.ETanFilesLabel.Text = "ETan Files:";
            // 
            // ETanFilesListBox
            // 
            this.ETanFilesListBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ETanFilesListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ETanFilesListBox.FormattingEnabled = true;
            this.ETanFilesListBox.ItemHeight = 16;
            this.ETanFilesListBox.Location = new System.Drawing.Point(237, 161);
            this.ETanFilesListBox.Margin = new System.Windows.Forms.Padding(4);
            this.ETanFilesListBox.Name = "ETanFilesListBox";
            this.ETanFilesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ETanFilesListBox.Size = new System.Drawing.Size(350, 212);
            this.ETanFilesListBox.TabIndex = 9;
            this.ETanFilesListBox.SelectedIndexChanged += new System.EventHandler(this.ETanFilesListBox_SelectedIndexChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.AddEtanFilesButton);
            this.flowLayoutPanel3.Controls.Add(this.RemoveButton);
            this.flowLayoutPanel3.Controls.Add(this.clearEtanButton);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(237, 381);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(350, 36);
            this.flowLayoutPanel3.TabIndex = 10;
            this.flowLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel3_Paint);
            // 
            // AddEtanFilesButton
            // 
            this.AddEtanFilesButton.Location = new System.Drawing.Point(4, 4);
            this.AddEtanFilesButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddEtanFilesButton.Name = "AddEtanFilesButton";
            this.AddEtanFilesButton.Size = new System.Drawing.Size(213, 28);
            this.AddEtanFilesButton.TabIndex = 0;
            this.AddEtanFilesButton.Text = "Add Etan for Validation";
            this.AddEtanFilesButton.UseVisualStyleBackColor = true;
            this.AddEtanFilesButton.Click += new System.EventHandler(this.AddEtanFilesButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(225, 4);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(82, 28);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // clearEtanButton
            // 
            this.clearEtanButton.Location = new System.Drawing.Point(307, 4);
            this.clearEtanButton.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.clearEtanButton.Name = "clearEtanButton";
            this.clearEtanButton.Size = new System.Drawing.Size(32, 28);
            this.clearEtanButton.TabIndex = 2;
            this.clearEtanButton.Text = "All";
            this.clearEtanButton.UseVisualStyleBackColor = true;
            this.clearEtanButton.Click += new System.EventHandler(this.clearEtanButton_Click);
            // 
            // SummaryFileLabel
            // 
            this.SummaryFileLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SummaryFileLabel.AutoSize = true;
            this.SummaryFileLabel.Location = new System.Drawing.Point(132, 102);
            this.SummaryFileLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SummaryFileLabel.Name = "SummaryFileLabel";
            this.SummaryFileLabel.Size = new System.Drawing.Size(97, 17);
            this.SummaryFileLabel.TabIndex = 5;
            this.SummaryFileLabel.Text = "Summary File:";
            // 
            // summaryFilenameLabel
            // 
            this.summaryFilenameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryFilenameLabel.Location = new System.Drawing.Point(237, 102);
            this.summaryFilenameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.summaryFilenameLabel.Name = "summaryFilenameLabel";
            this.summaryFilenameLabel.Size = new System.Drawing.Size(350, 17);
            this.summaryFilenameLabel.TabIndex = 6;
            this.summaryFilenameLabel.Text = "Unspecified";
            // 
            // summaryFileBrowseButton
            // 
            this.summaryFileBrowseButton.Location = new System.Drawing.Point(237, 123);
            this.summaryFileBrowseButton.Margin = new System.Windows.Forms.Padding(4);
            this.summaryFileBrowseButton.Name = "summaryFileBrowseButton";
            this.summaryFileBrowseButton.Size = new System.Drawing.Size(100, 28);
            this.summaryFileBrowseButton.TabIndex = 7;
            this.summaryFileBrowseButton.Text = "Browse...";
            this.summaryFileBrowseButton.UseVisualStyleBackColor = true;
            this.summaryFileBrowseButton.Click += new System.EventHandler(this.summaryFileBrowseButton_Click);
            // 
            // percentUncLabel
            // 
            this.percentUncLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.percentUncLabel.AutoSize = true;
            this.percentUncLabel.Location = new System.Drawing.Point(4, 487);
            this.percentUncLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.percentUncLabel.Name = "percentUncLabel";
            this.percentUncLabel.Size = new System.Drawing.Size(225, 17);
            this.percentUncLabel.TabIndex = 15;
            this.percentUncLabel.Text = "% Combined TF Uncertainty (k=1):";
            // 
            // pcentUncTextBox
            // 
            this.pcentUncTextBox.Location = new System.Drawing.Point(237, 485);
            this.pcentUncTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pcentUncTextBox.Name = "pcentUncTextBox";
            this.pcentUncTextBox.Size = new System.Drawing.Size(132, 22);
            this.pcentUncTextBox.TabIndex = 16;
            this.pcentUncTextBox.Text = "34";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 521);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "TF Uncertainty offset:";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel4.Controls.Add(this.uncOffsetTextBox);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(237, 515);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(140, 30);
            this.flowLayoutPanel4.TabIndex = 19;
            // 
            // uncOffsetTextBox
            // 
            this.uncOffsetTextBox.Location = new System.Drawing.Point(4, 4);
            this.uncOffsetTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.uncOffsetTextBox.Name = "uncOffsetTextBox";
            this.uncOffsetTextBox.Size = new System.Drawing.Size(132, 22);
            this.uncOffsetTextBox.TabIndex = 18;
            this.uncOffsetTextBox.Text = "0.5";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Type:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Transfer Function:";
            // 
            // saveSummaryFileCheckbox
            // 
            this.saveSummaryFileCheckbox.AutoSize = true;
            this.saveSummaryFileCheckbox.Checked = true;
            this.saveSummaryFileCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveSummaryFileCheckbox.Location = new System.Drawing.Point(237, 456);
            this.saveSummaryFileCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.saveSummaryFileCheckbox.Name = "saveSummaryFileCheckbox";
            this.saveSummaryFileCheckbox.Size = new System.Drawing.Size(151, 21);
            this.saveSummaryFileCheckbox.TabIndex = 14;
            this.saveSummaryFileCheckbox.Text = "Save Summary File";
            this.saveSummaryFileCheckbox.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.AddEtanFilesForScale);
            this.flowLayoutPanel5.Controls.Add(this.Remove2);
            this.flowLayoutPanel5.Controls.Add(this.clearScaleEtanButton);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(594, 380);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(351, 37);
            this.flowLayoutPanel5.TabIndex = 22;
            // 
            // AddEtanFilesForScale
            // 
            this.AddEtanFilesForScale.Location = new System.Drawing.Point(4, 4);
            this.AddEtanFilesForScale.Margin = new System.Windows.Forms.Padding(4);
            this.AddEtanFilesForScale.Name = "AddEtanFilesForScale";
            this.AddEtanFilesForScale.Size = new System.Drawing.Size(229, 28);
            this.AddEtanFilesForScale.TabIndex = 0;
            this.AddEtanFilesForScale.Text = "Add Etan for TF Scaling";
            this.AddEtanFilesForScale.UseVisualStyleBackColor = true;
            this.AddEtanFilesForScale.Click += new System.EventHandler(this.AddEtanFilesForScale_Click);
            // 
            // Remove2
            // 
            this.Remove2.Location = new System.Drawing.Point(241, 4);
            this.Remove2.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.Remove2.Name = "Remove2";
            this.Remove2.Size = new System.Drawing.Size(69, 28);
            this.Remove2.TabIndex = 1;
            this.Remove2.Text = "Remove";
            this.Remove2.UseVisualStyleBackColor = true;
            this.Remove2.Click += new System.EventHandler(this.Remove2_Click);
            // 
            // clearScaleEtanButton
            // 
            this.clearScaleEtanButton.Location = new System.Drawing.Point(310, 4);
            this.clearScaleEtanButton.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.clearScaleEtanButton.Name = "clearScaleEtanButton";
            this.clearScaleEtanButton.Size = new System.Drawing.Size(32, 28);
            this.clearScaleEtanButton.TabIndex = 2;
            this.clearScaleEtanButton.Text = "All";
            this.clearScaleEtanButton.UseVisualStyleBackColor = true;
            this.clearScaleEtanButton.Click += new System.EventHandler(this.clearScaleEtanButton_Click);
            // 
            // EtanFileListForScaling
            // 
            this.EtanFileListForScaling.Dock = System.Windows.Forms.DockStyle.Top;
            this.EtanFileListForScaling.FormattingEnabled = true;
            this.EtanFileListForScaling.ItemHeight = 16;
            this.EtanFileListForScaling.Location = new System.Drawing.Point(594, 160);
            this.EtanFileListForScaling.Name = "EtanFileListForScaling";
            this.EtanFileListForScaling.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.EtanFileListForScaling.Size = new System.Drawing.Size(351, 212);
            this.EtanFileListForScaling.TabIndex = 21;
            // 
            // ValidateButton
            // 
            this.ValidateButton.Location = new System.Drawing.Point(237, 553);
            this.ValidateButton.Margin = new System.Windows.Forms.Padding(4);
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Size = new System.Drawing.Size(155, 25);
            this.ValidateButton.TabIndex = 13;
            this.ValidateButton.Text = "Validate";
            this.ValidateButton.UseVisualStyleBackColor = true;
            this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.Manual_V);
            this.flowLayoutPanel6.Controls.Add(this.Auto_V);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(594, 122);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(351, 32);
            this.flowLayoutPanel6.TabIndex = 23;
            // 
            // Manual_V
            // 
            this.Manual_V.AutoSize = true;
            this.Manual_V.Checked = true;
            this.Manual_V.Location = new System.Drawing.Point(3, 3);
            this.Manual_V.Name = "Manual_V";
            this.Manual_V.Size = new System.Drawing.Size(140, 21);
            this.Manual_V.TabIndex = 0;
            this.Manual_V.TabStop = true;
            this.Manual_V.Text = "Manually Validate";
            this.Manual_V.UseVisualStyleBackColor = true;
            this.Manual_V.CheckedChanged += new System.EventHandler(this.Manual_V_CheckedChanged);
            // 
            // Auto_V
            // 
            this.Auto_V.AutoSize = true;
            this.Auto_V.Location = new System.Drawing.Point(149, 3);
            this.Auto_V.Name = "Auto_V";
            this.Auto_V.Size = new System.Drawing.Size(113, 21);
            this.Auto_V.TabIndex = 1;
            this.Auto_V.Text = "Auto Validate";
            this.Auto_V.UseVisualStyleBackColor = true;
            this.Auto_V.CheckedChanged += new System.EventHandler(this.Auto_V_CheckedChanged);
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.numPathways);
            this.flowLayoutPanel7.Controls.Add(this.label4);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(594, 424);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(348, 25);
            this.flowLayoutPanel7.TabIndex = 24;
            // 
            // numPathways
            // 
            this.numPathways.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numPathways.Enabled = false;
            this.numPathways.Location = new System.Drawing.Point(3, 3);
            this.numPathways.Name = "numPathways";
            this.numPathways.Size = new System.Drawing.Size(23, 22);
            this.numPathways.TabIndex = 1;
            this.numPathways.Text = "3";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(32, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "pathways for scaling";
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.radioK1Rate);
            this.flowLayoutPanel8.Controls.Add(this.radioTrendSlope);
            this.flowLayoutPanel8.Controls.Add(this.radioScaleFactor);
            this.flowLayoutPanel8.Location = new System.Drawing.Point(594, 484);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(348, 22);
            this.flowLayoutPanel8.TabIndex = 25;
            // 
            // radioK1Rate
            // 
            this.radioK1Rate.AutoSize = true;
            this.radioK1Rate.Checked = true;
            this.radioK1Rate.Location = new System.Drawing.Point(3, 3);
            this.radioK1Rate.Name = "radioK1Rate";
            this.radioK1Rate.Size = new System.Drawing.Size(76, 21);
            this.radioK1Rate.TabIndex = 0;
            this.radioK1Rate.TabStop = true;
            this.radioK1Rate.Text = "K1Rate";
            this.toolTip1.SetToolTip(this.radioK1Rate, "Sort by passing rate");
            this.radioK1Rate.UseVisualStyleBackColor = true;
            // 
            // radioTrendSlope
            // 
            this.radioTrendSlope.AutoSize = true;
            this.radioTrendSlope.Location = new System.Drawing.Point(85, 3);
            this.radioTrendSlope.Name = "radioTrendSlope";
            this.radioTrendSlope.Size = new System.Drawing.Size(103, 21);
            this.radioTrendSlope.TabIndex = 1;
            this.radioTrendSlope.Text = "TrendSlope";
            this.toolTip1.SetToolTip(this.radioTrendSlope, "Sort by trendline slope (closest to 1)");
            this.radioTrendSlope.UseVisualStyleBackColor = true;
            // 
            // radioScaleFactor
            // 
            this.radioScaleFactor.AutoSize = true;
            this.radioScaleFactor.Location = new System.Drawing.Point(194, 3);
            this.radioScaleFactor.Name = "radioScaleFactor";
            this.radioScaleFactor.Size = new System.Drawing.Size(104, 21);
            this.radioScaleFactor.TabIndex = 2;
            this.radioScaleFactor.Text = "ScaleFactor";
            this.toolTip1.SetToolTip(this.radioScaleFactor, "Sort by scaling factor smallest to largest");
            this.radioScaleFactor.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.Controls.Add(this.saveOptFileCheckbox);
            this.flowLayoutPanel9.Controls.Add(this.saveOPTTFcheckBox);
            this.flowLayoutPanel9.Location = new System.Drawing.Point(236, 424);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(351, 24);
            this.flowLayoutPanel9.TabIndex = 27;
            // 
            // saveOptFileCheckbox
            // 
            this.saveOptFileCheckbox.AutoSize = true;
            this.saveOptFileCheckbox.Checked = true;
            this.saveOptFileCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveOptFileCheckbox.Location = new System.Drawing.Point(3, 3);
            this.saveOptFileCheckbox.Name = "saveOptFileCheckbox";
            this.saveOptFileCheckbox.Size = new System.Drawing.Size(170, 21);
            this.saveOptFileCheckbox.TabIndex = 20;
            this.saveOptFileCheckbox.Text = "Save Optimization File";
            this.saveOptFileCheckbox.UseVisualStyleBackColor = true;
            // 
            // saveOPTTFcheckBox
            // 
            this.saveOPTTFcheckBox.AutoSize = true;
            this.saveOPTTFcheckBox.Location = new System.Drawing.Point(179, 3);
            this.saveOPTTFcheckBox.Name = "saveOPTTFcheckBox";
            this.saveOPTTFcheckBox.Size = new System.Drawing.Size(116, 21);
            this.saveOPTTFcheckBox.TabIndex = 21;
            this.saveOPTTFcheckBox.Text = "Save OPT TF";
            this.saveOPTTFcheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Sort results by:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // TFAdjPanel
            // 
            this.TFAdjPanel.Controls.Add(this.label9);
            this.TFAdjPanel.Controls.Add(this.truncateLengthEnd);
            this.TFAdjPanel.Controls.Add(this.truncateLengthBegin);
            this.TFAdjPanel.Controls.Add(this.label6);
            this.TFAdjPanel.Controls.Add(this.offsetR);
            this.TFAdjPanel.Controls.Add(this.label8);
            this.TFAdjPanel.Controls.Add(this.offsetP);
            this.TFAdjPanel.Controls.Add(this.label7);
            this.TFAdjPanel.Location = new System.Drawing.Point(594, 552);
            this.TFAdjPanel.Name = "TFAdjPanel";
            this.TFAdjPanel.Size = new System.Drawing.Size(351, 62);
            this.TFAdjPanel.TabIndex = 29;
            // 
            // truncateLengthBegin
            // 
            this.truncateLengthBegin.Location = new System.Drawing.Point(97, 32);
            this.truncateLengthBegin.Name = "truncateLengthBegin";
            this.truncateLengthBegin.Size = new System.Drawing.Size(43, 22);
            this.truncateLengthBegin.TabIndex = 5;
            this.truncateLengthBegin.Text = "0.04";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "truncate Left";
            // 
            // offsetR
            // 
            this.offsetR.Location = new System.Drawing.Point(177, 3);
            this.offsetR.Name = "offsetR";
            this.offsetR.Size = new System.Drawing.Size(29, 22);
            this.offsetR.TabIndex = 3;
            this.offsetR.Text = "0.8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(109, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "offset rate";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // offsetP
            // 
            this.offsetP.Location = new System.Drawing.Point(85, 2);
            this.offsetP.Name = "offsetP";
            this.offsetP.Size = new System.Drawing.Size(18, 22);
            this.offsetP.TabIndex = 1;
            this.offsetP.Text = "1";
            this.offsetP.TextChanged += new System.EventHandler(this.offsetP_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "offset points";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TFAutoAdj);
            this.panel2.Location = new System.Drawing.Point(594, 514);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 32);
            this.panel2.TabIndex = 30;
            // 
            // TFAutoAdj
            // 
            this.TFAutoAdj.AutoSize = true;
            this.TFAutoAdj.Location = new System.Drawing.Point(4, 3);
            this.TFAutoAdj.Name = "TFAutoAdj";
            this.TFAutoAdj.Size = new System.Drawing.Size(123, 21);
            this.TFAutoAdj.TabIndex = 0;
            this.TFAutoAdj.Text = "TF Auto Adjust";
            this.TFAutoAdj.UseVisualStyleBackColor = true;
            this.TFAutoAdj.CheckedChanged += new System.EventHandler(this.TFAutoAdj_CheckedChanged);
            // 
            // truncateLengthEnd
            // 
            this.truncateLengthEnd.Location = new System.Drawing.Point(190, 32);
            this.truncateLengthEnd.Name = "truncateLengthEnd";
            this.truncateLengthEnd.Size = new System.Drawing.Size(43, 22);
            this.truncateLengthEnd.TabIndex = 6;
            this.truncateLengthEnd.Text = "0.04";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(147, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Right";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // ValidateTFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 636);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ValidateTFForm";
            this.Text = "Validate Transfer Function";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            this.TFAdjPanel.ResumeLayout(false);
            this.TFAdjPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TransferFunctionFilenameLabel;
        private System.Windows.Forms.Button BrowseTransferFunctionButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ViewTFButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton TemperatureRadioButton;
        private System.Windows.Forms.RadioButton voltageRadioButton;
        private System.Windows.Forms.Label ETanFilesLabel;
        private System.Windows.Forms.ListBox ETanFilesListBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button AddEtanFilesButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Label SummaryFileLabel;
        private System.Windows.Forms.Label summaryFilenameLabel;
        private System.Windows.Forms.Button summaryFileBrowseButton;
        private System.Windows.Forms.Button ValidateButton;
        private System.Windows.Forms.Label percentUncLabel;
        private System.Windows.Forms.TextBox pcentUncTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.TextBox uncOffsetTextBox;
        private System.Windows.Forms.CheckBox saveOptFileCheckbox;
        private System.Windows.Forms.CheckBox saveSummaryFileCheckbox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Button AddEtanFilesForScale;
        private System.Windows.Forms.Button Remove2;
        private System.Windows.Forms.ListBox EtanFileListForScaling;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.RadioButton Manual_V;
        private System.Windows.Forms.RadioButton Auto_V;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.TextBox numPathways;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.RadioButton radioTrendSlope;
        private System.Windows.Forms.RadioButton radioK1Rate;
        private System.Windows.Forms.RadioButton radioScaleFactor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.CheckBox saveOPTTFcheckBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button clearEtanButton;
        private System.Windows.Forms.Button clearScaleEtanButton;
        private System.Windows.Forms.Panel TFAdjPanel;
        private System.Windows.Forms.TextBox offsetR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox offsetP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox TFAutoAdj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox truncateLengthBegin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox truncateLengthEnd;
    }
}