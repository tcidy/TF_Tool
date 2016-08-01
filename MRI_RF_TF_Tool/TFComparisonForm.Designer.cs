namespace MRI_RF_TF_Tool
{
    partial class TFComparisonForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MagnitudeGroupbox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ZGCMag = new ZedGraph.ZedGraphControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.NoNormalizationRadioButton = new System.Windows.Forms.RadioButton();
            this.MaximumNormalizationRadioButton = new System.Windows.Forms.RadioButton();
            this.MeanNormalizationRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ZGCPhase = new ZedGraph.ZedGraphControl();
            this.AlignPhasesCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.MagnitudeGroupbox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.MagnitudeGroupbox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(689, 456);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // MagnitudeGroupbox
            // 
            this.MagnitudeGroupbox.Controls.Add(this.tableLayoutPanel2);
            this.MagnitudeGroupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MagnitudeGroupbox.Location = new System.Drawing.Point(3, 3);
            this.MagnitudeGroupbox.Name = "MagnitudeGroupbox";
            this.MagnitudeGroupbox.Size = new System.Drawing.Size(683, 222);
            this.MagnitudeGroupbox.TabIndex = 3;
            this.MagnitudeGroupbox.TabStop = false;
            this.MagnitudeGroupbox.Text = "Magnitude";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.ZGCMag, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(677, 203);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ZGCMag
            // 
            this.ZGCMag.AutoSize = true;
            this.ZGCMag.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ZGCMag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZGCMag.Location = new System.Drawing.Point(3, 32);
            this.ZGCMag.Name = "ZGCMag";
            this.ZGCMag.ScrollGrace = 0D;
            this.ZGCMag.ScrollMaxX = 0D;
            this.ZGCMag.ScrollMaxY = 0D;
            this.ZGCMag.ScrollMaxY2 = 0D;
            this.ZGCMag.ScrollMinX = 0D;
            this.ZGCMag.ScrollMinY = 0D;
            this.ZGCMag.ScrollMinY2 = 0D;
            this.ZGCMag.Size = new System.Drawing.Size(671, 168);
            this.ZGCMag.TabIndex = 6;
            this.ZGCMag.UseExtendedPrintDialog = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.NoNormalizationRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.MaximumNormalizationRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.MeanNormalizationRadioButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(671, 23);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Normalization:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // NoNormalizationRadioButton
            // 
            this.NoNormalizationRadioButton.AutoSize = true;
            this.NoNormalizationRadioButton.Checked = true;
            this.NoNormalizationRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoNormalizationRadioButton.Location = new System.Drawing.Point(82, 3);
            this.NoNormalizationRadioButton.Name = "NoNormalizationRadioButton";
            this.NoNormalizationRadioButton.Size = new System.Drawing.Size(51, 17);
            this.NoNormalizationRadioButton.TabIndex = 0;
            this.NoNormalizationRadioButton.TabStop = true;
            this.NoNormalizationRadioButton.Text = "None";
            this.NoNormalizationRadioButton.UseVisualStyleBackColor = true;
            this.NoNormalizationRadioButton.CheckedChanged += new System.EventHandler(this.NormalizationRadioButton_CheckedChanged);
            // 
            // MaximumNormalizationRadioButton
            // 
            this.MaximumNormalizationRadioButton.AutoSize = true;
            this.MaximumNormalizationRadioButton.Location = new System.Drawing.Point(139, 3);
            this.MaximumNormalizationRadioButton.Name = "MaximumNormalizationRadioButton";
            this.MaximumNormalizationRadioButton.Size = new System.Drawing.Size(69, 17);
            this.MaximumNormalizationRadioButton.TabIndex = 1;
            this.MaximumNormalizationRadioButton.Text = "Maximum";
            this.MaximumNormalizationRadioButton.UseVisualStyleBackColor = true;
            this.MaximumNormalizationRadioButton.CheckedChanged += new System.EventHandler(this.NormalizationRadioButton_CheckedChanged);
            // 
            // MeanNormalizationRadioButton
            // 
            this.MeanNormalizationRadioButton.AutoSize = true;
            this.MeanNormalizationRadioButton.Location = new System.Drawing.Point(214, 3);
            this.MeanNormalizationRadioButton.Name = "MeanNormalizationRadioButton";
            this.MeanNormalizationRadioButton.Size = new System.Drawing.Size(52, 17);
            this.MeanNormalizationRadioButton.TabIndex = 2;
            this.MeanNormalizationRadioButton.Text = "Mean";
            this.MeanNormalizationRadioButton.UseVisualStyleBackColor = true;
            this.MeanNormalizationRadioButton.CheckedChanged += new System.EventHandler(this.NormalizationRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(683, 222);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phase";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.ZGCPhase, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.AlignPhasesCheckBox, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(677, 203);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // ZGCPhase
            // 
            this.ZGCPhase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZGCPhase.Location = new System.Drawing.Point(3, 26);
            this.ZGCPhase.Name = "ZGCPhase";
            this.ZGCPhase.ScrollGrace = 0D;
            this.ZGCPhase.ScrollMaxX = 0D;
            this.ZGCPhase.ScrollMaxY = 0D;
            this.ZGCPhase.ScrollMaxY2 = 0D;
            this.ZGCPhase.ScrollMinX = 0D;
            this.ZGCPhase.ScrollMinY = 0D;
            this.ZGCPhase.ScrollMinY2 = 0D;
            this.ZGCPhase.Size = new System.Drawing.Size(671, 174);
            this.ZGCPhase.TabIndex = 4;
            this.ZGCPhase.UseExtendedPrintDialog = true;
            // 
            // AlignPhasesCheckBox
            // 
            this.AlignPhasesCheckBox.AutoSize = true;
            this.AlignPhasesCheckBox.Checked = true;
            this.AlignPhasesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AlignPhasesCheckBox.Location = new System.Drawing.Point(3, 3);
            this.AlignPhasesCheckBox.Name = "AlignPhasesCheckBox";
            this.AlignPhasesCheckBox.Size = new System.Drawing.Size(220, 17);
            this.AlignPhasesCheckBox.TabIndex = 3;
            this.AlignPhasesCheckBox.Text = "Align phases (by subtracting first element)";
            this.AlignPhasesCheckBox.UseVisualStyleBackColor = true;
            this.AlignPhasesCheckBox.CheckedChanged += new System.EventHandler(this.AlignPhasesCheckBox_CheckedChanged);
            // 
            // TFComparisonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 456);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TFComparisonForm";
            this.Text = "TF Comparison";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.MagnitudeGroupbox.ResumeLayout(false);
            this.MagnitudeGroupbox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox MagnitudeGroupbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ZedGraph.ZedGraphControl ZGCMag;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ZedGraph.ZedGraphControl ZGCPhase;
        private System.Windows.Forms.CheckBox AlignPhasesCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton NoNormalizationRadioButton;
        private System.Windows.Forms.RadioButton MaximumNormalizationRadioButton;
        private System.Windows.Forms.RadioButton MeanNormalizationRadioButton;
    }
}