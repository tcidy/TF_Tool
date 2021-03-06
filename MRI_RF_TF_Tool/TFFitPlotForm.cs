﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace MRI_RF_TF_Tool {
    public partial class TFFitPlotForm : Form {
        public TFFitPlotForm() {
            InitializeComponent();
        }
        public void AddData(
            IList<double> predicted,
            IList<double> measured,
            string varName = "",
            string title = "Predicted vs Measured"
        ) {
            var gp = fitPlotGraphControl.GraphPane;
            var dataPoints = gp.AddCurve("",
                predicted.ToArray(), measured.ToArray(), Color.Black,SymbolType.Circle);
            dataPoints.Line.IsVisible = false;
            gp.Title.Text = title;
            gp.XAxis.Title.Text = "Predicted " + varName;
            gp.YAxis.Title.Text = "Measured " + varName;
            gp.AxisChange();
        }
        public void AddFit(double m, double b, Color color) {
            var gp = fitPlotGraphControl.GraphPane;
            //var xmin = gp.XAxis.Scale.Min;
            var xmin = 0;
            var xmax = gp.XAxis.Scale.Max;
            gp.AddCurve("",
                new double[] { xmin,  xmax},
                new double[] { m * xmin + b, m*xmax+b },
                color, SymbolType.None);
            gp.AxisChange();
        }
        public void ConfigurePathwaySeries(string title, string xaxisLabel, string yaxisLabel,
            string[] xaxisText) {
            var gp = fitPlotGraphControl.GraphPane;
            this.Text = title;
            gp.Title.Text = title;
            gp.XAxis.Title.Text = xaxisLabel;
            gp.YAxis.Title.Text = yaxisLabel;
            gp.XAxis.MajorTic.IsBetweenLabels = true;
            gp.XAxis.Scale.TextLabels = xaxisText;
            gp.XAxis.Type = AxisType.Text;
        }
        public void AddPathwaySeries(string name, double[] data, Color color) {
            var gp = fitPlotGraphControl.GraphPane;
            BarItem bar = gp.AddBar(name, null, data, color);
            //bar.Bar.Fill = new Fill(color);
            gp.AxisChange();
        }
    }
}
