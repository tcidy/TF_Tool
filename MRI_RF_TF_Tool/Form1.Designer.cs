namespace MRI_RF_TF_Tool
{
    partial class Form1
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
            this.CompareTFButton = new System.Windows.Forms.Button();
            this.ProcessTempDataButton = new System.Windows.Forms.Button();
            this.ProcessTempDataGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.VoltageModeRadioButton = new System.Windows.Forms.RadioButton();
            this.TemperatureModeRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TempMeasIntervalTextBox = new System.Windows.Forms.TextBox();
            this.TempMeasIntervalLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.NeuroRadioButton = new System.Windows.Forms.RadioButton();
            this.CRMRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.DoDataProcessingPlotsCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ScaleTFButton = new System.Windows.Forms.Button();
            this.validateButton = new System.Windows.Forms.Button();
            this.ProcessTempDataGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompareTFButton
            // 
            this.CompareTFButton.Location = new System.Drawing.Point(3, 61);
            this.CompareTFButton.Name = "CompareTFButton";
            this.CompareTFButton.Size = new System.Drawing.Size(93, 23);
            this.CompareTFButton.TabIndex = 0;
            this.CompareTFButton.Text = "Compare TFs";
            this.CompareTFButton.UseVisualStyleBackColor = true;
            this.CompareTFButton.Click += new System.EventHandler(this.CompareTFButton_Click);
            // 
            // ProcessTempDataButton
            // 
            this.ProcessTempDataButton.Location = new System.Drawing.Point(177, 110);
            this.ProcessTempDataButton.Name = "ProcessTempDataButton";
            this.ProcessTempDataButton.Size = new System.Drawing.Size(113, 29);
            this.ProcessTempDataButton.TabIndex = 1;
            this.ProcessTempDataButton.Text = "Process Data";
            this.ProcessTempDataButton.UseVisualStyleBackColor = true;
            this.ProcessTempDataButton.Click += new System.EventHandler(this.ProcessTempDataButton_Click);
            // 
            // ProcessTempDataGroupBox
            // 
            this.ProcessTempDataGroupBox.AutoSize = true;
            this.ProcessTempDataGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.SetColumnSpan(this.ProcessTempDataGroupBox, 2);
            this.ProcessTempDataGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.ProcessTempDataGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProcessTempDataGroupBox.Location = new System.Drawing.Point(3, 90);
            this.ProcessTempDataGroupBox.Name = "ProcessTempDataGroupBox";
            this.ProcessTempDataGroupBox.Size = new System.Drawing.Size(525, 161);
            this.ProcessTempDataGroupBox.TabIndex = 2;
            this.ProcessTempDataGroupBox.TabStop = false;
            this.ProcessTempDataGroupBox.Text = "Process Data";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProcessTempDataButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.TempMeasIntervalTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TempMeasIntervalLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DoDataProcessingPlotsCheckBox, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(519, 142);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.VoltageModeRadioButton);
            this.flowLayoutPanel2.Controls.Add(this.TemperatureModeRadioButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(177, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(339, 23);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // VoltageModeRadioButton
            // 
            this.VoltageModeRadioButton.AutoSize = true;
            this.VoltageModeRadioButton.Checked = true;
            this.VoltageModeRadioButton.Location = new System.Drawing.Point(3, 3);
            this.VoltageModeRadioButton.Name = "VoltageModeRadioButton";
            this.VoltageModeRadioButton.Size = new System.Drawing.Size(99, 17);
            this.VoltageModeRadioButton.TabIndex = 0;
            this.VoltageModeRadioButton.TabStop = true;
            this.VoltageModeRadioButton.Text = "Header Voltage";
            this.VoltageModeRadioButton.UseVisualStyleBackColor = true;
            this.VoltageModeRadioButton.CheckedChanged += new System.EventHandler(this.ModeRadioButtonChecked);
            // 
            // TemperatureModeRadioButton
            // 
            this.TemperatureModeRadioButton.AutoSize = true;
            this.TemperatureModeRadioButton.Location = new System.Drawing.Point(108, 3);
            this.TemperatureModeRadioButton.Name = "TemperatureModeRadioButton";
            this.TemperatureModeRadioButton.Size = new System.Drawing.Size(85, 17);
            this.TemperatureModeRadioButton.TabIndex = 1;
            this.TemperatureModeRadioButton.Text = "Temperature";
            this.TemperatureModeRadioButton.UseVisualStyleBackColor = true;
            this.TemperatureModeRadioButton.CheckedChanged += new System.EventHandler(this.ModeRadioButtonChecked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Type:";
            // 
            // TempMeasIntervalTextBox
            // 
            this.TempMeasIntervalTextBox.Location = new System.Drawing.Point(177, 32);
            this.TempMeasIntervalTextBox.Name = "TempMeasIntervalTextBox";
            this.TempMeasIntervalTextBox.Size = new System.Drawing.Size(100, 20);
            this.TempMeasIntervalTextBox.TabIndex = 2;
            this.TempMeasIntervalTextBox.Text = "120";
            // 
            // TempMeasIntervalLabel
            // 
            this.TempMeasIntervalLabel.AutoSize = true;
            this.TempMeasIntervalLabel.Location = new System.Drawing.Point(3, 29);
            this.TempMeasIntervalLabel.Name = "TempMeasIntervalLabel";
            this.TempMeasIntervalLabel.Size = new System.Drawing.Size(168, 13);
            this.TempMeasIntervalLabel.TabIndex = 3;
            this.TempMeasIntervalLabel.Text = "Temp Measurement Interval (sec):";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.NeuroRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.CRMRadioButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(177, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(339, 23);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // NeuroRadioButton
            // 
            this.NeuroRadioButton.AutoSize = true;
            this.NeuroRadioButton.Checked = true;
            this.NeuroRadioButton.Location = new System.Drawing.Point(3, 3);
            this.NeuroRadioButton.Name = "NeuroRadioButton";
            this.NeuroRadioButton.Size = new System.Drawing.Size(54, 17);
            this.NeuroRadioButton.TabIndex = 0;
            this.NeuroRadioButton.TabStop = true;
            this.NeuroRadioButton.Text = "Neuro";
            this.NeuroRadioButton.UseVisualStyleBackColor = true;
            // 
            // CRMRadioButton
            // 
            this.CRMRadioButton.AutoSize = true;
            this.CRMRadioButton.Location = new System.Drawing.Point(63, 3);
            this.CRMRadioButton.Name = "CRMRadioButton";
            this.CRMRadioButton.Size = new System.Drawing.Size(49, 17);
            this.CRMRadioButton.TabIndex = 1;
            this.CRMRadioButton.Text = "CRM";
            this.CRMRadioButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data Type:";
            // 
            // DoDataProcessingPlotsCheckBox
            // 
            this.DoDataProcessingPlotsCheckBox.AutoSize = true;
            this.DoDataProcessingPlotsCheckBox.Checked = true;
            this.DoDataProcessingPlotsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DoDataProcessingPlotsCheckBox.Location = new System.Drawing.Point(177, 87);
            this.DoDataProcessingPlotsCheckBox.Name = "DoDataProcessingPlotsCheckBox";
            this.DoDataProcessingPlotsCheckBox.Size = new System.Drawing.Size(112, 17);
            this.DoDataProcessingPlotsCheckBox.TabIndex = 8;
            this.DoDataProcessingPlotsCheckBox.Text = "Display Data Plots";
            this.DoDataProcessingPlotsCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.ProcessTempDataGroupBox, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.CompareTFButton, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.ScaleTFButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.validateButton, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(531, 317);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // ScaleTFButton
            // 
            this.ScaleTFButton.Location = new System.Drawing.Point(3, 3);
            this.ScaleTFButton.Name = "ScaleTFButton";
            this.ScaleTFButton.Size = new System.Drawing.Size(93, 23);
            this.ScaleTFButton.TabIndex = 3;
            this.ScaleTFButton.Text = "Scale TFs";
            this.ScaleTFButton.UseVisualStyleBackColor = true;
            this.ScaleTFButton.Click += new System.EventHandler(this.ScaleTFButton_Click);
            // 
            // validateButton
            // 
            this.validateButton.Location = new System.Drawing.Point(3, 32);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(93, 23);
            this.validateButton.TabIndex = 4;
            this.validateButton.Text = "Validate TFs";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.validateButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 317);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "Form1";
            this.Text = "TF Processing Utility";
            this.ProcessTempDataGroupBox.ResumeLayout(false);
            this.ProcessTempDataGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CompareTFButton;
        private System.Windows.Forms.Button ProcessTempDataButton;
        private System.Windows.Forms.GroupBox ProcessTempDataGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TempMeasIntervalTextBox;
        private System.Windows.Forms.Label TempMeasIntervalLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton NeuroRadioButton;
        private System.Windows.Forms.RadioButton CRMRadioButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton VoltageModeRadioButton;
        private System.Windows.Forms.RadioButton TemperatureModeRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox DoDataProcessingPlotsCheckBox;
        private System.Windows.Forms.Button ScaleTFButton;
        private System.Windows.Forms.Button validateButton;
    }
}

