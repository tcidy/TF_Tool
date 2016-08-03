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
using MathNet.Numerics;

namespace MRI_RF_TF_Tool {
    public partial class AdjustTFForm : Form {
        int DropDownWidth(ComboBox myCombo) {
            int maxWidth = 0;
            int temp = 0;
            System.Windows.Forms.Label label1 = new System.Windows.Forms.Label();

            foreach (var obj in myCombo.Items) {
                label1.Text = obj.ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth) {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            return maxWidth + SystemInformation.VerticalScrollBarWidth;
        }

        public AdjustTFForm() {
            InitializeComponent();

            TruncateErrorLabel.Text = "";
            ExtrapolateErrorLabel.Text = "";
            forcedValsErrorLabel.Text = "";

            InterpolationModeComboBox.SelectedIndex = 0;
            InterpolationModeComboBox.Width = DropDownWidth(InterpolationModeComboBox);

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
            double scaleFactor = 1.0, System.Drawing.Drawing2D.DashStyle style =
            System.Drawing.Drawing2D.DashStyle.Solid) {
            var magGP = MagGraphControl.GraphPane;
            var phaseGP = phaseGraphControl.GraphPane;

            var srmag = sr.Map(c => c.Magnitude);
            srmag = srmag.Multiply(scaleFactor);
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
        double adjustmentScaleFactor = 1;
        private void Replot() {
            TFadjustedSr = null;
            TFadjustedZ = null;
            double scaleFactor = 1;
            double bkgScaleFactor = 1;

            if (TFSr != null)
                Readjust();
            if (NormalizeCheckBox.Checked) {
                if (BkgSr != null)
                    bkgScaleFactor = (BkgSr.AbsoluteMaximum().Magnitude);
                if (bkgScaleFactor == 0)
                    bkgScaleFactor = 1;
                else
                    bkgScaleFactor = 1 / bkgScaleFactor;
            }

            var magGP = MagGraphControl.GraphPane;
            var phaseGP = phaseGraphControl.GraphPane;
            magGP.CurveList.Clear();
            phaseGP.CurveList.Clear();
            string normStr = "";
            if (NormalizeCheckBox.Checked)
                normStr = " (normalized)";
            if(Bkgz != null && BkgSr != null)
                AddTFToGps(Bkgz, BkgSr, "Reference" + normStr, Color.Gray, SymbolType.None, drawLine: true,
                    scaleFactor: bkgScaleFactor, style: System.Drawing.Drawing2D.DashStyle.Dash);
            if (TFz != null && TFSr != null) {
                AddTFToGps(TFz, TFSr, "TF" + normStr, Color.Blue, SymbolType.XCross, drawLine: false,
                    scaleFactor: adjustmentScaleFactor);
            }
            if (TFadjustedZ != null && TFadjustedSr != null) {
                AddTFToGps(TFadjustedZ, TFadjustedSr, "Adjusted TF",
                    color: Color.Black, symbol: SymbolType.XCross, drawLine: true);
            }

            magGP.AxisChange();
            phaseGP.AxisChange();
            MagGraphControl.Invalidate();
            phaseGraphControl.Invalidate();
        }
        public Func<double, double> MakeInterpolator(IEnumerable<double> x, IEnumerable<double> y) {

            SplineBoundaryCondition bc;
            int xlength = x.Count();
            int mode = InterpolationModeComboBox.SelectedIndex;
            if (mode == 0 || mode == 1 || mode == 2) {
                int order;
                order = mode + 1; // linear => 1; quadratic => 2; cubic => 3
                int npoints;
                if (!int.TryParse(extrapolationPointsTextBox.Text, out npoints))
                    throw new Exception("Cannot parse number of points");
                if (npoints > xlength)
                    throw new Exception("Too many points required");
                if (npoints < order)
                    throw new Exception("More points must be used");
                var leftInterp = Fit.PolynomialFunc(x.Take(npoints).ToArray(), y.Take(npoints).ToArray(),
                    order);
                var rightInterp = Fit.PolynomialFunc(x.Reverse().Take(npoints).Reverse().ToArray(),
                    y.Reverse().Take(npoints).Reverse().ToArray(),
                    order);
                double middlex = x.Skip((int)(xlength / 2)).First();
                return (x2 => (x2 <  middlex)?leftInterp(x2) : rightInterp(x2));
            }
            else if (mode == 5) {
                IInterpolation I = LinearSpline.Interpolate(x, y);
                return (x2 => I.Interpolate(x2));
            } else {
                if (InterpolationModeComboBox.SelectedIndex == 2)
                    bc = SplineBoundaryCondition.ParabolicallyTerminated;
                else
                    bc = SplineBoundaryCondition.Natural;

                IInterpolation I = CubicSpline.InterpolateBoundaries(
                    x, y,
                    bc, 0, bc, 0); // Values are unused for natural and parabolic termination
                return (x2 => I.Interpolate(x2));
            }
        }
        private void Readjust() {

            double truncateMin = double.NaN;
            double truncateMax = double.NaN;
            double extrapolateMax = double.NaN, extrapolateMin = double.NaN;
            double TFMinVal = double.NaN, TFMaxVal = double.NaN;
            double TFMinPhase = double.NaN, TFMaxPhase = double.NaN;
            TruncateErrorLabel.Text = "";
            ExtrapolateErrorLabel.Text = "";
            forcedValsErrorLabel.Text = "";
            bool error = false;
            int mini = 0;
            int maxi = TFSr.Count - 1;
            TFadjustedZ = null;
            TFadjustedSr = null;
            adjustmentScaleFactor = 1;

            // Parse Values
            if (TruncateMinTextBox.Text.Trim() != "" &&
                !Double.TryParse(TruncateMinTextBox.Text, out truncateMin)) {
                TruncateErrorLabel.Text = "<--- Parse error"; error = true;
            }
            if (TruncateMaxTextBox.Text.Trim() != "" &&
                !Double.TryParse(TruncateMaxTextBox.Text, out truncateMax)) {
                TruncateErrorLabel.Text = "<--- Parse error"; error = true;
            }

            if (ExtrapolateMaxTextBox.Text.Trim() != "" &&
                !Double.TryParse(ExtrapolateMaxTextBox.Text, out extrapolateMax)) {
                ExtrapolateErrorLabel.Text = "<--- Parse error"; error = true;
            }
            if (ExtrapolateMinTextBox.Text.Trim() != "" &&
                !Double.TryParse(ExtrapolateMinTextBox.Text, out extrapolateMin)) {
                ExtrapolateErrorLabel.Text = "<--- Parse error"; error = true;
            }

            if (!double.IsNaN(extrapolateMin) &&
                TFminvalueTextbox.Text.Trim() != "" &&
                !Double.TryParse(TFminvalueTextbox.Text, out TFMinVal)) {
                forcedValsErrorLabel.Text = "<--- Parse error"; error = true;
            }

            if (!double.IsNaN(extrapolateMax) &&
                TFmaxvalueTextbox.Text.Trim() != "" &&
                !Double.TryParse(TFmaxvalueTextbox.Text, out TFMaxVal)) {
                forcedValsErrorLabel.Text = "<--- Parse error"; error = true;
            }
            if (!double.IsNaN(extrapolateMin) &&
               TFPhaseMinTextBox.Text.Trim() != "" &&
               !Double.TryParse(TFPhaseMinTextBox.Text, out TFMinPhase)) {
                forcedValsErrorLabel.Text = "<--- Parse error"; error = true;
            }

            if (!double.IsNaN(extrapolateMax) &&
                TFPhaseMaxTextBox.Text.Trim() != "" &&
                !Double.TryParse(TFPhaseMaxTextBox.Text, out TFMaxPhase)) {
                forcedValsErrorLabel.Text = "<--- Parse error"; error = true;
            }

            if (error) {
                return;
            }

            // Truncation Setup
            if (!Double.IsNaN(truncateMin)) {
                var v = TFz.Find(x => (x + x * 1e-5 >= truncateMin));
                if (v != null)
                    mini = v.Item1;
                else {
                    TruncateErrorLabel.Text = "<--- No values remaining"; error = true;
                }
            }
            if(!Double.IsNaN(truncateMax)) {
                var v = TFz.Find(x => (x-x*1e-5> truncateMax));
                if (v == null)
                    maxi = TFz.Count -1;
                else if (v.Item1 == 0) {
                    TruncateErrorLabel.Text = "<--- No values remaining"; error = true;
                } else {
                    maxi = v.Item1 - 1;
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


            // Truncate
            TFadjustedZ = TFz.SubVector(mini, maxi - mini + 1);
            TFadjustedSr = TFSr.SubVector(mini, maxi - mini + 1);

            // Must only unwrap once, and must be done before truncation to be consistant with the plotted reference phase
            IEnumerable<double> phase = TFSr.Map(x => x.Phase).Unwrap();
            phase = phase.Skip(mini).Take(maxi - mini + 1);
            IEnumerable<double> phasez = TFadjustedZ;
            IEnumerable<double> magz = TFadjustedZ;
            IEnumerable<double> mag = TFadjustedSr.Map(x => x.Magnitude);

            // Extrapolation
            if (!double.IsNaN(extrapolateMax)) {
                double currentMax = TFadjustedZ.Last();
                if (TFz.Count < 3) {
                    ExtrapolateErrorLabel.Text = "<--- At least three datapoints required"; error = true;
                } else if (extrapolateMax > currentMax) {
                    double dx = TFadjustedZ[1] - TFadjustedZ[0];
                    int numextra = 1 + (int)((extrapolateMax - currentMax)/dx);
                    if (numextra > 300) {
                        ExtrapolateErrorLabel.Text = "<--- Only 300 points may be extrapolated"; error = true;
                    }else {
                        List<double> newx = new List<double>();
                        double xi = TFadjustedZ.Last();
                        while (xi - dx / 10 < extrapolateMax) {
                            newx.Add(xi);
                            xi = xi + dx;
                        }
                        newx.Add(extrapolateMax);

                        // append extra finish point, if existing
                        if(!double.IsNaN(TFMaxVal)) {
                            magz = magz.Concat(new double[] { extrapolateMax});
                            mag = mag.Concat(new double[] {TFMaxVal}) ;
                        }

                        // append extra phase point
                        if (!double.IsNaN(TFMaxPhase)) {
                            phasez = phasez.Concat(new double[] { extrapolateMax });
                            phase = phase.Concat(new double[] { TFMaxPhase });
                        }
                        // And interpolate!
                        try {
                            var magspline = MakeInterpolator(magz, mag); // use forced point, if any
                            var phasepline = MakeInterpolator(phasez, phase);
                            newx[numextra - 1] = extrapolateMax; // force last point to be the required point
                            var newy = newx.Select(x => Complex.FromPolarCoordinates(
                                magspline(x), phasepline(x)));
                            TFadjustedZ = Vector<double>.Build.DenseOfEnumerable(TFadjustedZ.Concat(newx));
                            TFadjustedSr = Vector<Complex>.Build.DenseOfEnumerable(TFadjustedSr.Concat(newy));
                        } catch (Exception e) {
                            ExtrapolateErrorLabel.Text = e.Message; error = true;
                            TFadjustedZ = null;
                            TFadjustedSr = null;
                            return;
                        }
                    }
                }
            }
            if(!double.IsNaN(extrapolateMin)) {
                double currentMin = TFadjustedZ[0];
                if (TFz.Count < 3) {
                    ExtrapolateErrorLabel.Text = "<--- At least three datapoints required"; error = true;
                }
                else if (extrapolateMin < currentMin) {
                    double dx = TFadjustedZ[1] - TFadjustedZ[0];
                    int numextra = 1 + (int)((currentMin - extrapolateMin) / dx);
                    if (numextra > 300) {
                        ExtrapolateErrorLabel.Text = "<--- Only 300 points may be extrapolated"; error = true;
                    }
                    else {
                        List<double> newx = new List<double>();
                        double xi = TFadjustedZ[0];
                        while (xi + dx / 10 > extrapolateMin) {
                            newx.Add(xi);
                            xi = xi - dx;
                        }
                        newx.Add(extrapolateMin);
                        newx.Reverse();
                        
                        // append extra finish point, if existing
                        if (!double.IsNaN(TFMinVal)) {
                            magz = (new double[] { extrapolateMin }).Concat(magz);
                            mag = (new double[] { TFMinVal }).Concat(mag);
                        }
                        
                        // append extra phase point
                        if (!double.IsNaN(TFMinPhase)) {
                            phasez = (new double[] { extrapolateMin }).Concat(phasez);
                            phase = (new double[] { TFMinPhase }).Concat(phase);
                        }
                        
                        try {
                            var magspline = MakeInterpolator(magz, mag);
                            var phasepline = MakeInterpolator(phasez, phase);
                            var newy = newx.Select(x => Complex.FromPolarCoordinates(
                                magspline(x), phasepline(x)));
                            TFadjustedZ = Vector<double>.Build.DenseOfEnumerable(newx.Concat(TFadjustedZ));
                            TFadjustedSr = Vector<Complex>.Build.DenseOfEnumerable(newy.Concat(TFadjustedSr));
                        }
                        catch (Exception e) {
                            ExtrapolateErrorLabel.Text = e.Message; error = true;
                            TFadjustedZ = null;
                            TFadjustedSr = null;
                            return;
                        }
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
                if (max > 0) {
                    adjustmentScaleFactor = 1 / max;
                    TFadjustedSr = TFadjustedSr.Divide(max);
                }
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

        private void InterpolationModeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            extrapolationPointsTextBox.Enabled = (InterpolationModeComboBox.SelectedIndex <= 1);
            Replot();
        }

        private void extrapolationPointsTextBox_TextChanged(object sender, EventArgs e) {
            Replot();
        }
    }
}
