namespace MRI_RF_TF_Tool {
    partial class ScaleTFForm {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TransferFunctionFilenameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.SummaryFileLabel = new System.Windows.Forms.Label();
            this.summaryFilenameLabel = new System.Windows.Forms.Label();
            this.summaryFileBrowseButton = new System.Windows.Forms.Button();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.saveSummaryFileCheckbox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TransferFunctionFilenameLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ETanFilesLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ETanFilesListBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.SummaryFileLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.summaryFilenameLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.summaryFileBrowseButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.AnalyzeButton, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.saveSummaryFileCheckbox, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(465, 366);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Transfer Function:";
            // 
            // TransferFunctionFilenameLabel
            // 
            this.TransferFunctionFilenameLabel.AutoSize = true;
            this.TransferFunctionFilenameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferFunctionFilenameLabel.Location = new System.Drawing.Point(102, 29);
            this.TransferFunctionFilenameLabel.Name = "TransferFunctionFilenameLabel";
            this.TransferFunctionFilenameLabel.Size = new System.Drawing.Size(63, 13);
            this.TransferFunctionFilenameLabel.TabIndex = 3;
            this.TransferFunctionFilenameLabel.Text = "Unspecified";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Type:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.BrowseTransferFunctionButton);
            this.flowLayoutPanel1.Controls.Add(this.ViewTFButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(102, 45);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(360, 29);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // BrowseTransferFunctionButton
            // 
            this.BrowseTransferFunctionButton.Location = new System.Drawing.Point(3, 3);
            this.BrowseTransferFunctionButton.Name = "BrowseTransferFunctionButton";
            this.BrowseTransferFunctionButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseTransferFunctionButton.TabIndex = 0;
            this.BrowseTransferFunctionButton.Text = "Browse...";
            this.BrowseTransferFunctionButton.UseVisualStyleBackColor = true;
            this.BrowseTransferFunctionButton.Click += new System.EventHandler(this.BrowseTransferFunctionButton_Click);
            // 
            // ViewTFButton
            // 
            this.ViewTFButton.Enabled = false;
            this.ViewTFButton.Location = new System.Drawing.Point(84, 3);
            this.ViewTFButton.Name = "ViewTFButton";
            this.ViewTFButton.Size = new System.Drawing.Size(75, 23);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(102, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(360, 23);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // TemperatureRadioButton
            // 
            this.TemperatureRadioButton.AutoSize = true;
            this.TemperatureRadioButton.Checked = true;
            this.TemperatureRadioButton.Location = new System.Drawing.Point(3, 3);
            this.TemperatureRadioButton.Name = "TemperatureRadioButton";
            this.TemperatureRadioButton.Size = new System.Drawing.Size(85, 17);
            this.TemperatureRadioButton.TabIndex = 0;
            this.TemperatureRadioButton.TabStop = true;
            this.TemperatureRadioButton.Text = "Temperature";
            this.TemperatureRadioButton.UseVisualStyleBackColor = true;
            // 
            // voltageRadioButton
            // 
            this.voltageRadioButton.AutoSize = true;
            this.voltageRadioButton.Location = new System.Drawing.Point(94, 3);
            this.voltageRadioButton.Name = "voltageRadioButton";
            this.voltageRadioButton.Size = new System.Drawing.Size(61, 17);
            this.voltageRadioButton.TabIndex = 1;
            this.voltageRadioButton.Text = "Voltage";
            this.voltageRadioButton.UseVisualStyleBackColor = true;
            // 
            // ETanFilesLabel
            // 
            this.ETanFilesLabel.AutoSize = true;
            this.ETanFilesLabel.Location = new System.Drawing.Point(3, 119);
            this.ETanFilesLabel.Name = "ETanFilesLabel";
            this.ETanFilesLabel.Size = new System.Drawing.Size(60, 13);
            this.ETanFilesLabel.TabIndex = 8;
            this.ETanFilesLabel.Text = "ETan Files:";
            // 
            // ETanFilesListBox
            // 
            this.ETanFilesListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ETanFilesListBox.FormattingEnabled = true;
            this.ETanFilesListBox.Location = new System.Drawing.Point(102, 122);
            this.ETanFilesListBox.Name = "ETanFilesListBox";
            this.ETanFilesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ETanFilesListBox.Size = new System.Drawing.Size(360, 69);
            this.ETanFilesListBox.TabIndex = 9;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.AddEtanFilesButton);
            this.flowLayoutPanel3.Controls.Add(this.RemoveButton);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(102, 197);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(360, 29);
            this.flowLayoutPanel3.TabIndex = 10;
            // 
            // AddEtanFilesButton
            // 
            this.AddEtanFilesButton.Location = new System.Drawing.Point(3, 3);
            this.AddEtanFilesButton.Name = "AddEtanFilesButton";
            this.AddEtanFilesButton.Size = new System.Drawing.Size(75, 23);
            this.AddEtanFilesButton.TabIndex = 0;
            this.AddEtanFilesButton.Text = "Add...";
            this.AddEtanFilesButton.UseVisualStyleBackColor = true;
            this.AddEtanFilesButton.Click += new System.EventHandler(this.AddEtanFilesButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(84, 3);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // SummaryFileLabel
            // 
            this.SummaryFileLabel.AutoSize = true;
            this.SummaryFileLabel.Location = new System.Drawing.Point(3, 77);
            this.SummaryFileLabel.Name = "SummaryFileLabel";
            this.SummaryFileLabel.Size = new System.Drawing.Size(72, 13);
            this.SummaryFileLabel.TabIndex = 5;
            this.SummaryFileLabel.Text = "Summary File:";
            // 
            // summaryFilenameLabel
            // 
            this.summaryFilenameLabel.AutoSize = true;
            this.summaryFilenameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryFilenameLabel.Location = new System.Drawing.Point(102, 77);
            this.summaryFilenameLabel.Name = "summaryFilenameLabel";
            this.summaryFilenameLabel.Size = new System.Drawing.Size(63, 13);
            this.summaryFilenameLabel.TabIndex = 6;
            this.summaryFilenameLabel.Text = "Unspecified";
            // 
            // summaryFileBrowseButton
            // 
            this.summaryFileBrowseButton.Location = new System.Drawing.Point(102, 93);
            this.summaryFileBrowseButton.Name = "summaryFileBrowseButton";
            this.summaryFileBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.summaryFileBrowseButton.TabIndex = 7;
            this.summaryFileBrowseButton.Text = "Browse...";
            this.summaryFileBrowseButton.UseVisualStyleBackColor = true;
            this.summaryFileBrowseButton.Click += new System.EventHandler(this.summaryFileBrowseButton_Click);
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.Location = new System.Drawing.Point(102, 255);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(75, 23);
            this.AnalyzeButton.TabIndex = 13;
            this.AnalyzeButton.Text = "Run Analysis....";
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            this.AnalyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // saveSummaryFileCheckbox
            // 
            this.saveSummaryFileCheckbox.AutoSize = true;
            this.saveSummaryFileCheckbox.Location = new System.Drawing.Point(102, 232);
            this.saveSummaryFileCheckbox.Name = "saveSummaryFileCheckbox";
            this.saveSummaryFileCheckbox.Size = new System.Drawing.Size(116, 17);
            this.saveSummaryFileCheckbox.TabIndex = 14;
            this.saveSummaryFileCheckbox.Text = "Save Summary File";
            this.saveSummaryFileCheckbox.UseVisualStyleBackColor = true;
            // 
            // ScaleTFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 366);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ScaleTFForm";
            this.Text = "Scale Transfer Function";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
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
        private System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.CheckBox saveSummaryFileCheckbox;
    }
}