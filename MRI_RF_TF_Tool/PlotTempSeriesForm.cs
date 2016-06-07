using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace MRI_RF_TF_Tool
{
    public partial class PlotTempSeriesForm : Form
    {
        public PlotTempSeriesForm(string title, IEnumerable<double>[] data, IList<double> startvals,
            int startx2,
            int endx1, int endx2)
        {
            InitializeComponent();
            this.Text = title;
            GraphPane gp = tempSeriesGraphControl.GraphPane;
            gp.XAxis.Title.Text = "Sample number";
            gp.YAxis.Title.Text = "delta temperature";
            gp.Title.Text = title;

            gp.Title.FontSpec.Size = 10;
            for (int i=0; i<data.Length; i++)
            {
                double[] yvals = data[i].Select(x => x - startvals[i]).ToArray();
                double[] xvals = Enumerable.Range(0, yvals.Length).Select(x => (double)x).ToArray();
                PointPairList ppl = new PointPairList(xvals, yvals);
                var c = gp.AddCurve("Probe " + (i + 1).ToString(), xvals, yvals,
                    TFComparisonForm.colors[i%(TFComparisonForm.colors.Length)],SymbolType.XCross);
                
            }
            gp.AxisChange();
            gp.XAxis.Scale.Min = -1;
            foreach(double x in (new double[] { startx2+0.5, endx1-0.5, endx2+0.5 })) {
                var markerCurve = new LineItem("",
                    new PointPairList(
                         new double[] { x,x},
                         new double[] { 0, gp.YAxis.Scale.Max }
                         ),
                    Color.Black,
                    SymbolType.VDash
                    );
                markerCurve.Line.Width = markerCurve.Line.Width * 2.5f;
                gp.CurveList.Add(markerCurve);
            }
        }
    }
}
