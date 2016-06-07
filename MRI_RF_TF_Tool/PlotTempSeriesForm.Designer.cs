namespace MRI_RF_TF_Tool
{
    partial class PlotTempSeriesForm
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
            this.tempSeriesGraphControl = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // tempSeriesGraphControl
            // 
            this.tempSeriesGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tempSeriesGraphControl.Location = new System.Drawing.Point(0, 0);
            this.tempSeriesGraphControl.Name = "tempSeriesGraphControl";
            this.tempSeriesGraphControl.ScrollGrace = 0D;
            this.tempSeriesGraphControl.ScrollMaxX = 0D;
            this.tempSeriesGraphControl.ScrollMaxY = 0D;
            this.tempSeriesGraphControl.ScrollMaxY2 = 0D;
            this.tempSeriesGraphControl.ScrollMinX = 0D;
            this.tempSeriesGraphControl.ScrollMinY = 0D;
            this.tempSeriesGraphControl.ScrollMinY2 = 0D;
            this.tempSeriesGraphControl.Size = new System.Drawing.Size(417, 341);
            this.tempSeriesGraphControl.TabIndex = 0;
            this.tempSeriesGraphControl.UseExtendedPrintDialog = true;
            // 
            // PlotTempSeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 341);
            this.Controls.Add(this.tempSeriesGraphControl);
            this.Name = "PlotTempSeriesForm";
            this.Text = "PlotTempSeriesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl tempSeriesGraphControl;
    }
}