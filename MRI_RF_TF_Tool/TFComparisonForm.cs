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
        public static Color[] colors = new Color[]
            {
                Color.Blue, Color.Green, Color.Red, Color.Black, Color.Purple
            };
        public TFComparisonForm(IList<string> names, List<Matrix<double>> ZList, List<Matrix<Complex>> SrList)
        {
            
            InitializeComponent();
            var MagGP = ZGCMag.GraphPane;
            MagGP.Title.Text = "TF Mag";
            MagGP.XAxis.Title.Text = "Distance from tip electrode (m)";
            MagGP.YAxis.Title.Text = "Magnitude (AU)";

            var PhaseGP = ZGCPhase.GraphPane;
            PhaseGP.Title.Text = "TF Phase";
            PhaseGP.XAxis.Title.Text = "Distance from tip electrode (m)";
            PhaseGP.YAxis.Title.Text = "Phase (rad)";
            PhaseGP.Legend.IsVisible = false;
            for (int i=0; i<ZList.Count; i++)
            {
                var z = ZList[i];
                var sr = SrList[i];
                var srmag = sr.Column(0).Map(c => c.Magnitude);
                var srphase = sr.Column(0).Map(c => c.Phase);
                string shortname = System.IO.Path.GetFileNameWithoutExtension(names[i]);
                srphase = srphase.Unwrap();
                PointPairList pplmag = new PointPairList(
                    z.Column(0).ToArray(),
                    srmag.ToArray()
                    );
                PointPairList pplphase = new PointPairList(
                    z.Column(0).ToArray(),
                    srphase.ToArray());

                MagGP.AddCurve(shortname, pplmag, colors[(i % colors.Length)]);
                PhaseGP.AddCurve(shortname, pplphase, colors[(i % colors.Length)]);
            }
            MagGP.AxisChange();
            PhaseGP.AxisChange();
        }
    }
}
