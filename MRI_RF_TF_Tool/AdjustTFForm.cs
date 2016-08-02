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
using MathNet.Numerics.Interpolation;
using ZedGraph;

namespace MRI_RF_TF_Tool {
    public partial class AdjustTFForm : Form {
        public AdjustTFForm() {
            InitializeComponent();

            TruncateErrorLabel.Text = "";
            ExtrapolateErrorLabel.Text = "";

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
            phaseGraphControl.GraphPane.YAxis.Title.Text = "Phase (rad)";
            phaseGraphControl.GraphPane.XAxis.Title.FontSpec.Size *= 0.7f;
            phaseGraphControl.GraphPane.YAxis.Title.FontSpec.Size *= 0.7f;
            phaseGraphControl.GraphPane.XAxis.Title.IsVisible = false;
        }
        Vector<double> TFz;
        Vector<Complex> TFSr;
        Vector<double> TFadjustedZ;
        Vector<Complex> TFadjustedSr;
        string TFFilename;
        Vector<double> Bkgz;
        Vector<Complex> BkgSr;
        string BkgFilename;
        private void AddTFToGps(Vector<double> z, Vector<Complex> sr,
            string name, Color color, SymbolType symbol = SymbolType.None, bool drawLine = true,
            bool normalizeMaxMagnitude = false, System.Drawing.Drawing2D.DashStyle style =
            System.Drawing.Drawing2D.DashStyle.Solid) {
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
            liMag.Line.Style = style;
            var liPhase = phaseGP.AddCurve(name, pplphase, color,symbol);
            liPhase.Line.IsVisible = drawLine;
            liPhase.Line.Style = style;
        }
        private void Replot() {
            Readjust();
            var magGP = MagGraphControl.GraphPane;
            var phaseGP = phaseGraphControl.GraphPane;
            magGP.CurveList.Clear();
            phaseGP.CurveList.Clear();
            string normStr = "";
            if (NormalizeCheckBox.Checked)
                normStr = " (normalized)";
            if(Bkgz != null && BkgSr != null)
                AddTFToGps(Bkgz, BkgSr, "Reference" + normStr, Color.Gray, SymbolType.None, drawLine: true,
                    normalizeMaxMagnitude: NormalizeCheckBox.Checked, style: System.Drawing.Drawing2D.DashStyle.Dash);
            if (TFz != null && TFSr != null) {
                AddTFToGps(TFz, TFSr, "TF" + normStr, Color.Blue, SymbolType.XCross, drawLine: false,
                    normalizeMaxMagnitude: NormalizeCheckBox.Checked);
            }
            if (TFadjustedZ != null && TFadjustedSr != null) {
                AddTFToGps(TFadjustedZ, TFadjustedSr, "Adjusted TF",
                    Color.Black, SymbolType.XCross, drawLine: true);
            }

            magGP.AxisChange();
            phaseGP.AxisChange();
            MagGraphControl.Invalidate();
            phaseGraphControl.Invalidate();
        }
        private void Readjust() {

            double truncateMin = double.NaN;
            double truncateMax = double.NaN;
            TruncateErrorLabel.Text = "";
            ExtrapolateErrorLabel.Text = "";
            bool error = false;
            int mini = 0;
            int maxi = TFSr.Count - 1;
            if (TruncateMinTextBox.Text.Trim() != "") {
                if (!Double.TryParse(TruncateMinTextBox.Text, out truncateMin)) {
                    TruncateErrorLabel.Text = "<--- Parse error"; error = true;
                }
                else {
                    var v = TFz.Find(x => (x+x*1e-5 >= truncateMin));
                    if (v != null)
                        mini = v.Item1;
                    else {
                        TruncateErrorLabel.Text = "<--- No values remaining"; error = true;
                    }

                }
            }
            if (TruncateMaxTextBox.Text.Trim() != "") {
                if (!Double.TryParse(TruncateMaxTextBox.Text, out truncateMax)) {
                    TruncateErrorLabel.Text = "<--- Parse error"; error = true;
                }
                else {
                    var v = TFz.Find(x => (x-x*1e-5> truncateMax));
                    if (v == null)
                        maxi = TFz.Count -1;
                    else if (v.Item1 == 0) {
                        TruncateErrorLabel.Text = "<--- No values remaining"; error = true;
                    } else {
                        maxi = v.Item1 - 1;
                    }
                }
            }
            if (!error && maxi < mini) {
                TruncateErrorLabel.Text = "<--- No values remaining"; error = true;
            }
            if (error) {
                TFadjustedZ = null;
                TFadjustedSr = null;
                return;
            }
            TFadjustedZ = TFz.SubVector(mini, maxi - mini + 1);
            TFadjustedSr = TFSr.SubVector(mini, maxi - mini + 1);

            // Extrapolation
            if (ExtrapolateMaxTextBox.Text.Trim() != "") {
                double extrapMax;
                double currentMax = TFadjustedZ.Last();
                if (TFz.Count < 3) {
                    ExtrapolateErrorLabel.Text = "<--- At least three datapoints required"; error = true;
                } else if(!double.TryParse(ExtrapolateMaxTextBox.Text, out extrapMax)) {
                    ExtrapolateErrorLabel.Text = "<--- Parse error"; error = true;
                } else if (extrapMax > currentMax) {
                    double dx = TFadjustedZ[1] - TFadjustedZ[0];
                    int numextra = 1 + (int)((extrapMax - currentMax)/dx);
                    if (numextra > 300) {
                        ExtrapolateErrorLabel.Text = "<--- Only 300 points may be extrapolated"; error = true;
                    }else {
                        var mags = TFadjustedSr.Select(x => x.Magnitude);
                        var phases = TFadjustedSr.Select(x => x.Phase);
                        /* CubicSpline spline = CubicSpline.InterpolateNatural(
                             TFadjustedZ, mags);*/
                        CubicSpline magspline = CubicSpline.InterpolateBoundaries(
                            TFadjustedZ, mags, SplineBoundaryCondition.ParabolicallyTerminated, 0,
                            SplineBoundaryCondition.ParabolicallyTerminated, 0);
                        CubicSpline phasepline = CubicSpline.InterpolateBoundaries(
                            TFadjustedZ, phases, SplineBoundaryCondition.ParabolicallyTerminated, 0,
                            SplineBoundaryCondition.ParabolicallyTerminated, 0);
                        var newx = Vector<double>.Build.Dense(numextra, i => currentMax + dx * (1 + i));
                        var newy = newx.Select(x => Complex.FromPolarCoordinates(
                            magspline.Interpolate(x), phasepline.Interpolate(x)));
                        TFadjustedZ = Vector<double>.Build.DenseOfEnumerable(TFadjustedZ.Concat(newx));
                        TFadjustedSr = Vector<Complex>.Build.DenseOfEnumerable(TFadjustedSr.Concat(newy));
                    }
                }
            }
            if (ExtrapolateMinTextBox.Text.Trim() != "") {
                double extrapMin;
                double currentMin = TFadjustedZ[0];
                if (TFz.Count < 3) {
                    ExtrapolateErrorLabel.Text = "<--- At least three datapoints required"; error = true;
                }
                else if (!double.TryParse(ExtrapolateMinTextBox.Text, out extrapMin)) {
                    ExtrapolateErrorLabel.Text = "<--- Parse error"; error = true;
                }
                else if (extrapMin < currentMin) {
                    double dx = TFadjustedZ[1] - TFadjustedZ[0];
                    int numextra = 1 + (int)((currentMin - extrapMin) / dx);
                    if (numextra > 300) {
                        ExtrapolateErrorLabel.Text = "<--- Only 300 points may be extrapolated"; error = true;
                    }
                    else {
                        var mags = TFadjustedSr.Select(x => x.Magnitude);
                        var phases = TFadjustedSr.Select(x => x.Phase);
                        /* CubicSpline spline = CubicSpline.InterpolateNatural(
                             TFadjustedZ, mags);*/
                        CubicSpline magspline = CubicSpline.InterpolateBoundaries(
                            TFadjustedZ, mags, SplineBoundaryCondition.ParabolicallyTerminated, 0,
                            SplineBoundaryCondition.ParabolicallyTerminated, 0);
                        CubicSpline phasepline = CubicSpline.InterpolateBoundaries(
                            TFadjustedZ, phases, SplineBoundaryCondition.ParabolicallyTerminated, 0,
                            SplineBoundaryCondition.ParabolicallyTerminated, 0);
                        var newx = Vector<double>.Build.Dense(numextra, i => currentMin - dx * (numextra-i));
                        var newy = newx.Select(x => Complex.FromPolarCoordinates(
                            magspline.Interpolate(x), phasepline.Interpolate(x)));
                        TFadjustedZ = Vector<double>.Build.DenseOfEnumerable(newx.Concat(TFadjustedZ));
                        TFadjustedSr = Vector<Complex>.Build.DenseOfEnumerable(newy.Concat(TFadjustedSr));
                    }
                }
            }
            if (error) {
                TFadjustedZ = null;
                TFadjustedSr = null;
                return;
            }
            // Normalization
            if (NormalizeCheckBox.Checked) {
                double max = TFadjustedSr.AbsoluteMaximum().Magnitude;
                if (max > 0)
                    TFadjustedSr = TFadjustedSr.Divide(max);
            }
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

        private void HangleTextChanged(object sender, EventArgs e) {
            Replot();
        }

        private void SaveAsButton_Click(object sender, EventArgs e) {
            Readjust();
            if (TFadjustedZ == null) {
                MessageBox.Show(this, "Cannot save an adjusted TF while in an error state.",
                    "Error saving", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
             }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Matlab MAT (*.mat)|*.mat|All Files (*.*)|*.*";
            sfd.FileName = Path.GetFileNameWithoutExtension(TFFilename) + "_adj.mat";
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var Z = CreateMatrix.DenseOfColumns(new IEnumerable<double>[] { TFadjustedZ });
            var Sr = CreateMatrix.DenseOfColumnVectors(new Vector<Complex>[] { TFadjustedSr });

            var matrices = new List<MatlabMatrix>();
            matrices.Add(MatlabWriter.Pack(Z, "z"));
            matrices.Add(MatlabWriter.Pack(Sr, "Sr"));
            MatlabWriter.Store(sfd.FileName, matrices);
        }
    }
}
