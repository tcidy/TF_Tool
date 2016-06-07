﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearRegression;
using MathNet.Numerics.Data.Matlab;
using System.Windows.Forms;

namespace MRI_RF_TF_Tool {
    public partial class ScaleTFForm : Form {

        Vector<double> TFz= null;
        Vector<Complex> TFSr = null;
        MeasSummary meassum = null;
        string TFFileFullPath = null;
        public ScaleTFForm() {
            InitializeComponent();
        }

        private void BrowseTransferFunctionButton_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Neuro Orion MRI RF Heating TF Files";
            ofd.Filter = "Matlab MAT (*.mat)|*.mat|All Files (*.*)|*.*";
            ofd.Title = "Select TF files...";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            if (ofd.FileNames.Length == 0) {
                MessageBox.Show(this, "No files selected", "TF Reading Error");
                return;
            }
            try {
                var f = ofd.FileName;
                var shortfname = System.IO.Path.GetFileName(f);
                var mz = MatlabReader.Read<double>(f, "z");
                var msr = MatlabReader.Read<Complex>(f, "Sr");
                TFz = mz.Column(0);
                TFSr = msr.Column(0);
                TransferFunctionFilenameLabel.Text = shortfname;
                TFFileFullPath = ofd.FileName;
                ViewTFButton.Enabled = true;
            } catch (Exception ex) {
                MessageBox.Show(this, "TF File could not be opened!\n\n" + ex.Message,
                    "Error loading TF file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewTFButton_Click(object sender, EventArgs e) {
            var shortfname = TransferFunctionFilenameLabel.Text;
            TFComparisonForm tfcf = new TFComparisonForm(
                new string[] { shortfname },
                new Vector<double>[] { TFz },
                new Vector<Complex>[] { TFSr },
                shortfname
                );
            tfcf.Show(this);
        }

        private void AddEtanFilesButton_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Input Etan mat files";
            ofd.Filter = "Matlab MAT (*.mat)|*.mat|All Files (*.*)|*.*";
            ofd.Title = "Select Etan files...";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            if (ofd.FileNames.Length == 0) {
                MessageBox.Show(this, "No files selected", "TF Reading Error");
                return;
            }
            try {
                List<ETan> newETanData = new List<ETan>();
                foreach (string f in ofd.FileNames) {
                    ETan etan = new ETan(f);
                    newETanData.Add(etan);
                }
                foreach (ETan x in ETanFilesListBox.Items) {
                    newETanData.RemoveAll(y => y.filename == x.filename);
                }
                ETanFilesListBox.Items.AddRange(newETanData.ToArray());
                RefreshSummaryRows();
            }
            catch (Exception ex) {
                MessageBox.Show(this, "TF File could not be opened!\n\n" + ex.Message,
                    "Error loading TF file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e) {
            while (ETanFilesListBox.SelectedItems.Count > 0)
                ETanFilesListBox.Items.RemoveAt(ETanFilesListBox.SelectedIndices[0]);
        }

        private void summaryFileBrowseButton_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\" +
                    @"MRI_RF_TF_Tool_Project\Test Files for Python Utility\" +
                    @"Measurement Summary Input xlsx Files";
            ofd.Filter = "Excel Files (*.xls, *.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
            ofd.Title = "Select Summary files...";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            if (ofd.FileNames.Length == 0) {
                MessageBox.Show(this, "No file selected", "TF Reading Error");
                return;
            }
            MeasSummary sum = new MeasSummary();
            sum.Read(ofd.FileName);
            meassum = sum;
            RefreshSummaryRows();
            summaryFilenameLabel.Text = Path.GetFileName(ofd.FileName);
        }
        public void RefreshSummaryRows() {
            if (meassum == null) {
                foreach (ETan x in ETanFilesListBox.Items) {
                    x.summrow = null;
                }
            }
            else {
                for (int i = 0; i < ETanFilesListBox.Items.Count; i++) {
                    ETan x = (ETan)ETanFilesListBox.Items[i];
                    MeasSummary.SummaryRow row =
                        meassum.rows.Find(r => r.Pathway.ToLowerInvariant() == x.PathWay.ToLowerInvariant());
                    if (row != x.summrow) {
                        x.summrow = row;
                        ETanFilesListBox.Items[i] = x;
                    }
                }
            }
        }
        private bool VoltageMode {
            get { return voltageRadioButton.Checked; }
        }
        private void AnalyzeButton_Click(object sender, EventArgs e) {
            int numSkipped = 0;
            int numValid = 0;
            List<double> measuredVals = new List<double>();
            List<double> predictedVals = new List<double>();
            foreach(ETan etanRow in ETanFilesListBox.Items) {
                if (etanRow.summrow == null ||
                    (VoltageMode && Double.IsNaN(etanRow.summrow.PeakHeaderVoltage)) ||
                    (!VoltageMode && Double.IsNaN(etanRow.summrow.MeasuredTemperature))
                    ) {
                    numSkipped++;
                    continue;
                }
                var scaledEtanRms = etanRow.rms.Multiply(etanRow.summrow.ETanScalingFactor);
                if (etanRow.summrow.Conjugate)
                    scaledEtanRms = scaledEtanRms.Conjugate();

                if (VoltageMode && !Double.IsNaN(etanRow.summrow.CrestFactor))
                    scaledEtanRms = etanRow.rms.Multiply(etanRow.summrow.CrestFactor);

                double Z = DataProcessing.TFInt(
                    ETan_Z: etanRow.z, ETan_RMS: scaledEtanRms,
                    TF_Z: TFz, TF_Sr: TFSr);

                if (VoltageMode)
                    Z = Math.Sqrt(Z);
                if (VoltageMode)
                    predictedVals.Add(etanRow.summrow.PeakHeaderVoltage);
                else
                    predictedVals.Add(etanRow.summrow.MeasuredTemperature);
                measuredVals.Add(Z);
                numValid++;
            }

            if (numValid == 0) {
                MessageBox.Show(this, "No valid data was found.",
                    "No Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numSkipped > 0) {
                    MessageBox.Show(this, numSkipped.ToString() + " Etan files were skipped " +
                        "because a cooresponding row in the measurement summary file was not found.",
                        "Skipped ETan Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            double scaleFactor;
            // FIXME: Are these two things reversed?!
            var X = CreateMatrix.DenseOfColumns(new IEnumerable<double>[] { predictedVals });
            var Y = CreateVector.DenseOfEnumerable(measuredVals);

            var p = X.QR().Solve(Y);
            scaleFactor = p[0];
            
            TFFitPlotForm tffpf = new TFFitPlotForm();
            tffpf.AddData(
                predicted: predictedVals,
                measured: measuredVals,
                predictedSlope: scaleFactor,
                varName: VoltageMode ? "V" : "dT",
                title: TransferFunctionFilenameLabel.Text
                );
            tffpf.Show(this);

        }
    }
}
