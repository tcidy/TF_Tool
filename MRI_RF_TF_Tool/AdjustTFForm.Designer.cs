﻿namespace MRI_RF_TF_Tool {
    partial class AdjustTFForm {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BackgroundTFFilenameLabel = new System.Windows.Forms.Label();
            this.TFLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseTFButton = new System.Windows.Forms.Button();
            this.BrowseRefButton = new System.Windows.Forms.Button();
            this.TFFilenameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.VisualizationGroupbox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.MagGraphControl = new ZedGraph.ZedGraphControl();
            this.phaseGraphControl = new ZedGraph.ZedGraphControl();
            this.FilterGroupbox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.TruncateLabel = new System.Windows.Forms.Label();
            this.TruncateMinTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TruncateMaxTextBox = new System.Windows.Forms.TextBox();
            this.TruncateErrorLabel = new System.Windows.Forms.Label();
            this.NormalizeCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.ExtrapolateMinTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ExtrapolateMaxTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.InterpolationModeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.extrapolationPointsTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ExtrapolateErrorLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.TFminvalueTextbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TFmaxvalueTextbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TFPhaseMinTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TFPhaseMaxTextBox = new System.Windows.Forms.TextBox();
            this.forcedValsErrorLabel = new System.Windows.Forms.Label();
            this.SaveAsButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.VisualizationGroupbox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.FilterGroupbox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(907, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TF Selection";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.BackgroundTFFilenameLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TFLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BrowseTFButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BrowseRefButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TFFilenameLabel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(899, 72);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BackgroundTFFilenameLabel
            // 
            this.BackgroundTFFilenameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BackgroundTFFilenameLabel.AutoSize = true;
            this.BackgroundTFFilenameLabel.Location = new System.Drawing.Point(293, 45);
            this.BackgroundTFFilenameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BackgroundTFFilenameLabel.Name = "BackgroundTFFilenameLabel";
            this.BackgroundTFFilenameLabel.Size = new System.Drawing.Size(20, 17);
            this.BackgroundTFFilenameLabel.TabIndex = 5;
            this.BackgroundTFFilenameLabel.Text = "...";
            // 
            // TFLabel
            // 
            this.TFLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TFLabel.AutoSize = true;
            this.TFLabel.Location = new System.Drawing.Point(4, 9);
            this.TFLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TFLabel.Name = "TFLabel";
            this.TFLabel.Size = new System.Drawing.Size(29, 17);
            this.TFLabel.TabIndex = 0;
            this.TFLabel.Text = "TF:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Background TF (optional):";
            // 
            // BrowseTFButton
            // 
            this.BrowseTFButton.Location = new System.Drawing.Point(185, 4);
            this.BrowseTFButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrowseTFButton.Name = "BrowseTFButton";
            this.BrowseTFButton.Size = new System.Drawing.Size(100, 28);
            this.BrowseTFButton.TabIndex = 2;
            this.BrowseTFButton.Text = "Browse...";
            this.BrowseTFButton.UseVisualStyleBackColor = true;
            this.BrowseTFButton.Click += new System.EventHandler(this.BrowseTFButton_Click);
            // 
            // BrowseRefButton
            // 
            this.BrowseRefButton.Location = new System.Drawing.Point(185, 40);
            this.BrowseRefButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrowseRefButton.Name = "BrowseRefButton";
            this.BrowseRefButton.Size = new System.Drawing.Size(100, 28);
            this.BrowseRefButton.TabIndex = 3;
            this.BrowseRefButton.Text = "Browse...";
            this.BrowseRefButton.UseVisualStyleBackColor = true;
            this.BrowseRefButton.Click += new System.EventHandler(this.BrowseRefButton_Click);
            // 
            // TFFilenameLabel
            // 
            this.TFFilenameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TFFilenameLabel.AutoSize = true;
            this.TFFilenameLabel.Location = new System.Drawing.Point(293, 9);
            this.TFFilenameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TFFilenameLabel.Name = "TFFilenameLabel";
            this.TFFilenameLabel.Size = new System.Drawing.Size(20, 17);
            this.TFFilenameLabel.TabIndex = 4;
            this.TFFilenameLabel.Text = "...";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.VisualizationGroupbox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.FilterGroupbox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.SaveAsButton, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(915, 582);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // VisualizationGroupbox
            // 
            this.VisualizationGroupbox.AutoSize = true;
            this.VisualizationGroupbox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.VisualizationGroupbox.Controls.Add(this.tableLayoutPanel3);
            this.VisualizationGroupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisualizationGroupbox.Location = new System.Drawing.Point(4, 107);
            this.VisualizationGroupbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VisualizationGroupbox.Name = "VisualizationGroupbox";
            this.VisualizationGroupbox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VisualizationGroupbox.Size = new System.Drawing.Size(907, 260);
            this.VisualizationGroupbox.TabIndex = 1;
            this.VisualizationGroupbox.TabStop = false;
            this.VisualizationGroupbox.Text = "Visualization";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.MagGraphControl, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.phaseGraphControl, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(899, 237);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // MagGraphControl
            // 
            this.MagGraphControl.AutoSize = true;
            this.MagGraphControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MagGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MagGraphControl.Location = new System.Drawing.Point(5, 5);
            this.MagGraphControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MagGraphControl.Name = "MagGraphControl";
            this.MagGraphControl.ScrollGrace = 0D;
            this.MagGraphControl.ScrollMaxX = 0D;
            this.MagGraphControl.ScrollMaxY = 0D;
            this.MagGraphControl.ScrollMaxY2 = 0D;
            this.MagGraphControl.ScrollMinX = 0D;
            this.MagGraphControl.ScrollMinY = 0D;
            this.MagGraphControl.ScrollMinY2 = 0D;
            this.MagGraphControl.Size = new System.Drawing.Size(889, 108);
            this.MagGraphControl.TabIndex = 0;
            this.MagGraphControl.UseExtendedPrintDialog = true;
            // 
            // phaseGraphControl
            // 
            this.phaseGraphControl.AutoSize = true;
            this.phaseGraphControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.phaseGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phaseGraphControl.Location = new System.Drawing.Point(5, 123);
            this.phaseGraphControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.phaseGraphControl.Name = "phaseGraphControl";
            this.phaseGraphControl.ScrollGrace = 0D;
            this.phaseGraphControl.ScrollMaxX = 0D;
            this.phaseGraphControl.ScrollMaxY = 0D;
            this.phaseGraphControl.ScrollMaxY2 = 0D;
            this.phaseGraphControl.ScrollMinX = 0D;
            this.phaseGraphControl.ScrollMinY = 0D;
            this.phaseGraphControl.ScrollMinY2 = 0D;
            this.phaseGraphControl.Size = new System.Drawing.Size(889, 109);
            this.phaseGraphControl.TabIndex = 1;
            this.phaseGraphControl.UseExtendedPrintDialog = true;
            // 
            // FilterGroupbox
            // 
            this.FilterGroupbox.AutoSize = true;
            this.FilterGroupbox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FilterGroupbox.Controls.Add(this.tableLayoutPanel4);
            this.FilterGroupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterGroupbox.Location = new System.Drawing.Point(4, 375);
            this.FilterGroupbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilterGroupbox.Name = "FilterGroupbox";
            this.FilterGroupbox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilterGroupbox.Size = new System.Drawing.Size(907, 168);
            this.FilterGroupbox.TabIndex = 2;
            this.FilterGroupbox.TabStop = false;
            this.FilterGroupbox.Text = "Filter";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.NormalizeCheckBox, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel3, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(899, 145);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.TruncateLabel);
            this.flowLayoutPanel1.Controls.Add(this.TruncateMinTextBox);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.TruncateMaxTextBox);
            this.flowLayoutPanel1.Controls.Add(this.TruncateErrorLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(891, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // TruncateLabel
            // 
            this.TruncateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TruncateLabel.AutoSize = true;
            this.TruncateLabel.Location = new System.Drawing.Point(4, 6);
            this.TruncateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TruncateLabel.Name = "TruncateLabel";
            this.TruncateLabel.Size = new System.Drawing.Size(81, 17);
            this.TruncateLabel.TabIndex = 0;
            this.TruncateLabel.Text = "Truncate to";
            // 
            // TruncateMinTextBox
            // 
            this.TruncateMinTextBox.Location = new System.Drawing.Point(93, 4);
            this.TruncateMinTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TruncateMinTextBox.Name = "TruncateMinTextBox";
            this.TruncateMinTextBox.Size = new System.Drawing.Size(77, 22);
            this.TruncateMinTextBox.TabIndex = 1;
            this.TruncateMinTextBox.TextChanged += new System.EventHandler(this.HangleTextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "≤ x ≤";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TruncateMaxTextBox
            // 
            this.TruncateMaxTextBox.Location = new System.Drawing.Point(224, 4);
            this.TruncateMaxTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TruncateMaxTextBox.Name = "TruncateMaxTextBox";
            this.TruncateMaxTextBox.Size = new System.Drawing.Size(84, 22);
            this.TruncateMaxTextBox.TabIndex = 3;
            this.TruncateMaxTextBox.TextChanged += new System.EventHandler(this.HangleTextChanged);
            // 
            // TruncateErrorLabel
            // 
            this.TruncateErrorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TruncateErrorLabel.AutoSize = true;
            this.TruncateErrorLabel.ForeColor = System.Drawing.Color.Crimson;
            this.TruncateErrorLabel.Location = new System.Drawing.Point(316, 6);
            this.TruncateErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TruncateErrorLabel.Name = "TruncateErrorLabel";
            this.TruncateErrorLabel.Size = new System.Drawing.Size(26, 17);
            this.TruncateErrorLabel.TabIndex = 4;
            this.TruncateErrorLabel.Text = "<--";
            // 
            // NormalizeCheckBox
            // 
            this.NormalizeCheckBox.AutoSize = true;
            this.NormalizeCheckBox.Location = new System.Drawing.Point(4, 120);
            this.NormalizeCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NormalizeCheckBox.Name = "NormalizeCheckBox";
            this.NormalizeCheckBox.Size = new System.Drawing.Size(198, 21);
            this.NormalizeCheckBox.TabIndex = 1;
            this.NormalizeCheckBox.Text = "Normalize max(abs(TF))=1";
            this.NormalizeCheckBox.UseVisualStyleBackColor = true;
            this.NormalizeCheckBox.CheckedChanged += new System.EventHandler(this.NormalizeCheckBox_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.ExtrapolateMinTextBox);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.ExtrapolateMaxTextBox);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.InterpolationModeComboBox);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.extrapolationPointsTextBox);
            this.flowLayoutPanel2.Controls.Add(this.label7);
            this.flowLayoutPanel2.Controls.Add(this.ExtrapolateErrorLabel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 42);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(891, 32);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Extrapolate to ";
            // 
            // ExtrapolateMinTextBox
            // 
            this.ExtrapolateMinTextBox.Location = new System.Drawing.Point(111, 4);
            this.ExtrapolateMinTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExtrapolateMinTextBox.Name = "ExtrapolateMinTextBox";
            this.ExtrapolateMinTextBox.Size = new System.Drawing.Size(84, 22);
            this.ExtrapolateMinTextBox.TabIndex = 4;
            this.ExtrapolateMinTextBox.TextChanged += new System.EventHandler(this.HangleTextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "≤ x ≤";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExtrapolateMaxTextBox
            // 
            this.ExtrapolateMaxTextBox.Location = new System.Drawing.Point(249, 4);
            this.ExtrapolateMaxTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExtrapolateMaxTextBox.Name = "ExtrapolateMaxTextBox";
            this.ExtrapolateMaxTextBox.Size = new System.Drawing.Size(56, 22);
            this.ExtrapolateMaxTextBox.TabIndex = 6;
            this.ExtrapolateMaxTextBox.TextChanged += new System.EventHandler(this.HangleTextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = " using ";
            // 
            // InterpolationModeComboBox
            // 
            this.InterpolationModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InterpolationModeComboBox.Items.AddRange(new object[] {
            "linear fit",
            "cubic fit"});
            this.InterpolationModeComboBox.Location = new System.Drawing.Point(371, 4);
            this.InterpolationModeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InterpolationModeComboBox.Name = "InterpolationModeComboBox";
            this.InterpolationModeComboBox.Size = new System.Drawing.Size(160, 24);
            this.InterpolationModeComboBox.TabIndex = 9;
            this.InterpolationModeComboBox.SelectedIndexChanged += new System.EventHandler(this.InterpolationModeComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(539, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = " of ";
            // 
            // extrapolationPointsTextBox
            // 
            this.extrapolationPointsTextBox.Location = new System.Drawing.Point(575, 4);
            this.extrapolationPointsTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.extrapolationPointsTextBox.Name = "extrapolationPointsTextBox";
            this.extrapolationPointsTextBox.Size = new System.Drawing.Size(47, 22);
            this.extrapolationPointsTextBox.TabIndex = 11;
            this.extrapolationPointsTextBox.Text = "5";
            this.extrapolationPointsTextBox.TextChanged += new System.EventHandler(this.extrapolationPointsTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(630, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "points.";
            // 
            // ExtrapolateErrorLabel
            // 
            this.ExtrapolateErrorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ExtrapolateErrorLabel.AutoSize = true;
            this.ExtrapolateErrorLabel.ForeColor = System.Drawing.Color.Crimson;
            this.ExtrapolateErrorLabel.Location = new System.Drawing.Point(688, 7);
            this.ExtrapolateErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ExtrapolateErrorLabel.Name = "ExtrapolateErrorLabel";
            this.ExtrapolateErrorLabel.Size = new System.Drawing.Size(26, 17);
            this.ExtrapolateErrorLabel.TabIndex = 7;
            this.ExtrapolateErrorLabel.Text = "<--";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.label8);
            this.flowLayoutPanel3.Controls.Add(this.TFminvalueTextbox);
            this.flowLayoutPanel3.Controls.Add(this.label9);
            this.flowLayoutPanel3.Controls.Add(this.TFmaxvalueTextbox);
            this.flowLayoutPanel3.Controls.Add(this.label10);
            this.flowLayoutPanel3.Controls.Add(this.TFPhaseMinTextBox);
            this.flowLayoutPanel3.Controls.Add(this.label11);
            this.flowLayoutPanel3.Controls.Add(this.TFPhaseMaxTextBox);
            this.flowLayoutPanel3.Controls.Add(this.forcedValsErrorLabel);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(4, 82);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(891, 30);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "     Forcing: |TF(x_min)|=";
            // 
            // TFminvalueTextbox
            // 
            this.TFminvalueTextbox.Location = new System.Drawing.Point(172, 4);
            this.TFminvalueTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TFminvalueTextbox.Name = "TFminvalueTextbox";
            this.TFminvalueTextbox.Size = new System.Drawing.Size(56, 22);
            this.TFminvalueTextbox.TabIndex = 7;
            this.TFminvalueTextbox.TextChanged += new System.EventHandler(this.HangleTextChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(236, 6);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = ", |TF(x_max)|=";
            // 
            // TFmaxvalueTextbox
            // 
            this.TFmaxvalueTextbox.Location = new System.Drawing.Point(340, 4);
            this.TFmaxvalueTextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TFmaxvalueTextbox.Name = "TFmaxvalueTextbox";
            this.TFmaxvalueTextbox.Size = new System.Drawing.Size(56, 22);
            this.TFmaxvalueTextbox.TabIndex = 9;
            this.TFmaxvalueTextbox.TextChanged += new System.EventHandler(this.HangleTextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(404, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = ", θ(TF(x_min))=";
            // 
            // TFPhaseMinTextBox
            // 
            this.TFPhaseMinTextBox.Location = new System.Drawing.Point(517, 4);
            this.TFPhaseMinTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TFPhaseMinTextBox.Name = "TFPhaseMinTextBox";
            this.TFPhaseMinTextBox.Size = new System.Drawing.Size(56, 22);
            this.TFPhaseMinTextBox.TabIndex = 12;
            this.TFPhaseMinTextBox.TextChanged += new System.EventHandler(this.HangleTextChanged);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(581, 6);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 17);
            this.label11.TabIndex = 13;
            this.label11.Text = ", and θ(TF(x_max))=";
            // 
            // TFPhaseMaxTextBox
            // 
            this.TFPhaseMaxTextBox.Location = new System.Drawing.Point(725, 4);
            this.TFPhaseMaxTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TFPhaseMaxTextBox.Name = "TFPhaseMaxTextBox";
            this.TFPhaseMaxTextBox.Size = new System.Drawing.Size(56, 22);
            this.TFPhaseMaxTextBox.TabIndex = 14;
            this.TFPhaseMaxTextBox.TextChanged += new System.EventHandler(this.HangleTextChanged);
            // 
            // forcedValsErrorLabel
            // 
            this.forcedValsErrorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.forcedValsErrorLabel.AutoSize = true;
            this.forcedValsErrorLabel.ForeColor = System.Drawing.Color.Crimson;
            this.forcedValsErrorLabel.Location = new System.Drawing.Point(789, 6);
            this.forcedValsErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.forcedValsErrorLabel.Name = "forcedValsErrorLabel";
            this.forcedValsErrorLabel.Size = new System.Drawing.Size(26, 17);
            this.forcedValsErrorLabel.TabIndex = 10;
            this.forcedValsErrorLabel.Text = "<--";
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveAsButton.AutoSize = true;
            this.SaveAsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveAsButton.Location = new System.Drawing.Point(808, 551);
            this.SaveAsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(103, 27);
            this.SaveAsButton.TabIndex = 3;
            this.SaveAsButton.Text = "Save TF As...";
            this.SaveAsButton.UseVisualStyleBackColor = true;
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // AdjustTFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 582);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdjustTFForm";
            this.Text = "Adjust TF";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.VisualizationGroupbox.ResumeLayout(false);
            this.VisualizationGroupbox.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.FilterGroupbox.ResumeLayout(false);
            this.FilterGroupbox.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label BackgroundTFFilenameLabel;
        private System.Windows.Forms.Label TFLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseTFButton;
        private System.Windows.Forms.Button BrowseRefButton;
        private System.Windows.Forms.Label TFFilenameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox VisualizationGroupbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ZedGraph.ZedGraphControl MagGraphControl;
        private ZedGraph.ZedGraphControl phaseGraphControl;
        private System.Windows.Forms.GroupBox FilterGroupbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox NormalizeCheckBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label TruncateLabel;
        private System.Windows.Forms.TextBox TruncateMinTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TruncateMaxTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ExtrapolateMinTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ExtrapolateMaxTextBox;
        private System.Windows.Forms.Button SaveAsButton;
        private System.Windows.Forms.Label TruncateErrorLabel;
        private System.Windows.Forms.Label ExtrapolateErrorLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox InterpolationModeComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox extrapolationPointsTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TFminvalueTextbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TFmaxvalueTextbox;
        private System.Windows.Forms.Label forcedValsErrorLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TFPhaseMinTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TFPhaseMaxTextBox;
    }
}