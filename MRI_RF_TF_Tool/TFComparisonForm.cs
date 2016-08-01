using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System.Windows.Forms;
using ZedGraph;
namespace MRI_RF_TF_Tool
{
    public partial class TFComparisonForm : Form
    {
        IList<string> names;
        IList<Vector<double>> ZList;
        IList<Vector<Complex>> SrList;
        public static Color[] colors = new Color[]
            {
                Color.Blue, Color.Green, Color.Red, Color.Black, Color.Purple
            };
        public TFComparisonForm(IList<string> names, IList<Vector<double>> ZList, IList<Vector<Complex>> SrList, string title = null)
        {
            
            InitializeComponent();
            this.names = names;
            this.ZList = ZList;
            this.SrList = SrList;

            if (title != null)
                this.Text = title;
            var MagGP = ZGCMag.GraphPane;
            MagGP.Title.Text = "TF Mag";
            MagGP.XAxis.Title.Text = "Distance from tip electrode (m)";
            MagGP.YAxis.Title.Text = "Magnitude (AU)";

            var PhaseGP = ZGCPhase.GraphPane;
            PhaseGP.Title.Text = "TF Phase";
            PhaseGP.XAxis.Title.Text = "Distance from tip electrode (m)";
            PhaseGP.YAxis.Title.Text = "Phase (rad)";
            PhaseGP.Legend.IsVisible = false;
            PopulateData();
        }
        private void PopulateData() {
            var MagGP = ZGCMag.GraphPane;
            var PhaseGP = ZGCPhase.GraphPane;
            MagGP.CurveList.Clear();
            PhaseGP.CurveList.Clear();

            for (int i = 0; i < ZList.Count; i++) {
                var z = ZList[i];
                var sr = SrList[i];

                var srmag = sr.Map(c => c.Magnitude);
                var srphase = sr.Map(c => c.Phase);
                srphase = srphase.Unwrap();
                if (AlignPhasesCheckBox.Checked)
                    srphase = srphase.Subtract(srphase[0]);
                if (MaximumNormalizationRadioButton.Checked) {
                    double max = srmag.Maximum();
                    if (max > 0)
                        srmag = srmag.Divide(max);
                }
                if (MeanNormalizationRadioButton.Checked) {
                    double mean = srmag.Average();
                    if (mean > 0)
                        srmag = srmag.Divide(mean);
                }
                string shortname = System.IO.Path.GetFileNameWithoutExtension(names[i]);
                PointPairList pplmag = new PointPairList(
                    z.ToArray(),
                    srmag.ToArray()
                    );
                PointPairList pplphase = new PointPairList(
                    z.ToArray(),
                    srphase.ToArray());

                MagGP.AddCurve(shortname, pplmag, colors[(i % colors.Length)]);
                PhaseGP.AddCurve(shortname, pplphase, colors[(i % colors.Length)]);
            }
            MagGP.AxisChange();
            PhaseGP.AxisChange();
            if (AlignPhasesCheckBox.Checked) {
                // I like forcing a few minor steps past zero, so that full symbols
                // are drawn on the plot.
                if (PhaseGP.YAxis.Scale.Min <= 0 &&
                    PhaseGP.YAxis.Scale.Min > -PhaseGP.YAxis.Scale.MajorStep)
                    PhaseGP.YAxis.Scale.Min = -PhaseGP.YAxis.Scale.MinorStep * 3;
                if (PhaseGP.YAxis.Scale.Max >= 0 &&
                    PhaseGP.YAxis.Scale.Max < PhaseGP.YAxis.Scale.MajorStep)
                    PhaseGP.YAxis.Scale.Max = PhaseGP.YAxis.Scale.MinorStep * 3;
            }
            ZGCMag.Invalidate();
            ZGCPhase.Invalidate();
        }
        private void AlignPhasesCheckBox_CheckedChanged(object sender, EventArgs e) {
            PopulateData();
        }

        private void NormalizationRadioButton_CheckedChanged(object sender, EventArgs e) {
            if(((RadioButton)sender).Checked)
                PopulateData();
        }
    }
}
