namespace MRI_RF_TF_Tool {
    partial class TFFitPlotForm {
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
            this.fitPlotGraphControl = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // fitPlotGraphControl
            // 
            this.fitPlotGraphControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fitPlotGraphControl.Location = new System.Drawing.Point(0, 0);
            this.fitPlotGraphControl.Name = "fitPlotGraphControl";
            this.fitPlotGraphControl.ScrollGrace = 0D;
            this.fitPlotGraphControl.ScrollMaxX = 0D;
            this.fitPlotGraphControl.ScrollMaxY = 0D;
            this.fitPlotGraphControl.ScrollMaxY2 = 0D;
            this.fitPlotGraphControl.ScrollMinX = 0D;
            this.fitPlotGraphControl.ScrollMinY = 0D;
            this.fitPlotGraphControl.ScrollMinY2 = 0D;
            this.fitPlotGraphControl.Size = new System.Drawing.Size(284, 262);
            this.fitPlotGraphControl.TabIndex = 0;
            this.fitPlotGraphControl.UseExtendedPrintDialog = true;
            // 
            // TFFitPlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.fitPlotGraphControl);
            this.Name = "TFFitPlotForm";
            this.Text = "TF Fit Plot";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl fitPlotGraphControl;
    }
}