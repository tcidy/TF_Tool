using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Data.Matlab;
using ZedGraph;

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
        string TFFilename;
        Vector<double> Bkgz;
        Vector<Complex> BkgSr;
        string BkgFilename;
        private void AddTFToGps(Vector<double> z, Vector<Complex> sr,
            string name, Color color, SymbolType symbol = SymbolType.None, bool drawLine = true,
            bool normalizeMaxMagnitude = false) {
            var magGP = MagGraphControl.GraphPane;
            var phaseGP = phaseGraphControl.GraphPane;

            var srmag = sr.Map(c => c.Magnitude);
            if (normalizeMaxMagnitude) {
                double max = srmag.Maximum();
                if (max > 0)
                    srmag = srmag.Divide(max);
            }
            var srphase = sr.Map(c => c.Phase);
            srphase = srphase.Unwrap();
            PointPairList pplmag = new PointPairList(
                z.ToArray(),
                srmag.ToArray()
                );
            PointPairList pplphase = new PointPairList(
                z.ToArray(),
                srphase.ToArray());

            var liMag = magGP.AddCurve(name, pplmag, color, symbol);
            liMag.Line.IsVisible = drawLine;
            var liPhase = phaseGP.AddCurve(name, pplphase, color,symbol);
            liPhase.Line.IsVisible = drawLine;
        }
        private void Replot() {
            var magGP = MagGraphControl.GraphPane;
            var phaseGP = phaseGraphControl.GraphPane;
            magGP.CurveList.Clear();
            phaseGP.CurveList.Clear();
            if(Bkgz != null && BkgSr != null)
                AddTFToGps(Bkgz, BkgSr, "Reference", Color.Gray, SymbolType.None, drawLine: true,
                    normalizeMaxMagnitude: NormalizeCheckBox.Checked);
            if (TFz != null && TFSr != null) {
                AddTFToGps(TFz, TFSr, "TF", Color.Blue, SymbolType.XCross, drawLine: false);
            }

            magGP.AxisChange();
            phaseGP.AxisChange();
            MagGraphControl.Invalidate();
            phaseGraphControl.Invalidate();
        }
        private void Readjust() {

        }
        private void BrowseTFButton_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            
            if (Directory.Exists(@"C: \Users\ConraN01\Documents\"))
                ofd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Neuro Orion MRI RF Heating TF Files";
            ofd.Filter = "Matlab MAT (*.mat)|*.mat|All Files (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            try {
                TFz = MatlabReader.Read<double>(ofd.FileName, "z").Column(0);
                TFSr = MatlabReader.Read<Complex>(ofd.FileName, "Sr").Column(0);
                TFFilename = ofd.FileName;
                TFFilenameLabel.Text = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
            } catch (Exception ex) {
                TFz = null;
                TFSr = null;
                TFFilenameLabel.Text = "...";
                TFFilename = null;
                Replot();
                MessageBox.Show(this, ex.ToString(), "TF Reading Error");
                return;
            }
            Replot();
        }

        private void BrowseRefButton_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if(Directory.Exists(@"C: \Users\ConraN01\Documents\"))
                ofd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Neuro Orion MRI RF Heating TF Files";
            ofd.Filter = "Matlab MAT (*.mat)|*.mat|All Files (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            try {
                Bkgz = MatlabReader.Read<double>(ofd.FileName, "z").Column(0);
                BkgSr = MatlabReader.Read<Complex>(ofd.FileName, "Sr").Column(0);
                BkgFilename = ofd.FileName;
                BackgroundTFFilenameLabel.Text = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
            }
            catch (Exception ex) {
                Bkgz = null;
                BkgSr = null;
                BackgroundTFFilenameLabel.Text = "...";
                BkgFilename = null;
                Replot();
                MessageBox.Show(this, ex.ToString(), "TF Reading Error");
                return;
            }
            Replot();
        }

        private void NormalizeCheckBox_CheckedChanged(object sender, EventArgs e) {
            Replot();
        }
    }
}
