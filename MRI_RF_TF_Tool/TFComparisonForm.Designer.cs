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
            this.ZGCMag = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ZGCPhase = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ZGCMag
            // 
            this.ZGCMag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZGCMag.Location = new System.Drawing.Point(3, 3);
            this.ZGCMag.Name = "ZGCMag";
            this.ZGCMag.ScrollGrace = 0D;
            this.ZGCMag.ScrollMaxX = 0D;
            this.ZGCMag.ScrollMaxY = 0D;
            this.ZGCMag.ScrollMaxY2 = 0D;
            this.ZGCMag.ScrollMinX = 0D;
            this.ZGCMag.ScrollMinY = 0D;
            this.ZGCMag.ScrollMinY2 = 0D;
            this.ZGCMag.Size = new System.Drawing.Size(438, 163);
            this.ZGCMag.TabIndex = 0;
            this.ZGCMag.UseExtendedPrintDialog = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ZGCPhase, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ZGCMag, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 338);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ZGCPhase
            // 
            this.ZGCPhase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZGCPhase.Location = new System.Drawing.Point(3, 172);
            this.ZGCPhase.Name = "ZGCPhase";
            this.ZGCPhase.ScrollGrace = 0D;
            this.ZGCPhase.ScrollMaxX = 0D;
            this.ZGCPhase.ScrollMaxY = 0D;
            this.ZGCPhase.ScrollMaxY2 = 0D;
            this.ZGCPhase.ScrollMinX = 0D;
            this.ZGCPhase.ScrollMinY = 0D;
            this.ZGCPhase.ScrollMinY2 = 0D;
            this.ZGCPhase.Size = new System.Drawing.Size(438, 163);
            this.ZGCPhase.TabIndex = 1;
            this.ZGCPhase.UseExtendedPrintDialog = true;
            // 
            // TFComparisonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 338);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TFComparisonForm";
            this.Text = "TF Comparison";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl ZGCMag;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ZedGraph.ZedGraphControl ZGCPhase;
    }
}