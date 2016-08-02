using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Data.Matlab;

namespace MRI_RF_TF_Tool {
    public partial class AdjustTFForm : Form {
        public AdjustTFForm() {
            InitializeComponent();
            MagGraphControl.GraphPane.IsFontsScaled = false;
            MagGraphControl.GraphPane.Title.IsVisible = false;
            MagGraphControl.GraphPane.XAxis.Title.Text = "Position (cm)";
            MagGraphControl.GraphPane.YAxis.Title.Text = "Magnitude (AU)";
            MagGraphControl.GraphPane.XAxis.Title.FontSpec.Size *= 0.7f;
            MagGraphControl.GraphPane.YAxis.Title.FontSpec.Size *= 0.7f;
            MagGraphControl.GraphPane.XAxis.Title.IsVisible = false;
            phaseGraphControl.GraphPane.IsFontsScaled = false;
            phaseGraphControl.GraphPane.Title.IsVisible = false;
            phaseGraphControl.GraphPane.XAxis.Title.Text = "Position (cm)";
            phaseGraphControl.GraphPane.YAxis.Title.Text = "Phase (degrees)";
            phaseGraphControl.GraphPane.XAxis.Title.FontSpec.Size *= 0.7f;
            phaseGraphControl.GraphPane.YAxis.Title.FontSpec.Size *= 0.7f;
            phaseGraphControl.GraphPane.XAxis.Title.IsVisible = false;
        }
        Vector<double> TFz;
        Vector<Complex> TFSr;
        Vector<double> Refz;
        Vector<Complex> RefSr;

        private void Replot() {
            var magGP = MagGraphControl.GraphPane;
            magGP.CurveList.Clear();
            if(TFz != null && TFSr != null) {
                
            }
        }
        private void BrowseTFButton_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Neuro Orion MRI RF Heating TF Files";
            ofd.Filter = "Matlab MAT (*.mat)|*.mat|All Files (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            try {
                TFz = MatlabReader.Read<double>(ofd.FileName, "z").Column(0);
                TFSr = MatlabReader.Read<Complex>(ofd.FileName, "Sr").Column(0);

            }
            catch (Exception ex) {
                TFz = null;
                TFSr = null;
                TFFilenameLabel.Text = "...";
                Replot();
                MessageBox.Show(this, ex.ToString(), "TF Reading Error");
                return;
            }
        }
    }
}
