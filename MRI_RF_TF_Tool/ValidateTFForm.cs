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
using OfficeOpenXml;

namespace MRI_RF_TF_Tool {
    public partial class ValidateTFForm : Form {

        Vector<double> TFz= null;
        Vector<Complex> TFSr = null;
        MeasSummary meassum = null;
        string TFFileFullPath = null;
        public ValidateTFForm() {
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
                // Take either first row or column....
                if (mz.ColumnCount == 1 && mz.RowCount > 1)
                    TFz = mz.Column(0);
                else if (mz.RowCount == 1 && mz.ColumnCount > 1)
                    TFz = mz.Row(0);
                else {
                    throw new FormatException("Input matrix must be 1xN or Nx1, with N>=2");
                }
                if (msr.ColumnCount == 1 && msr.RowCount > 1)
                    TFSr = msr.Column(0);
                else if (mz.RowCount == 1 && msr.ColumnCount > 1)
                    TFSr = msr.Row(0);
                else
                    throw new FormatException("Input matrix must be 1xN or Nx1, with N>=2");
                if(TFz.Count != TFSr.Count)
                    throw new FormatException("Input matrices must be of equal dimensions");

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
        public bool IsWithinUncertainty(
            double uncFactor,
            double uncOffset,
            double measured,
            double predicted
            ) {
            double lowerBound = predicted * (1.0 - uncFactor) - uncOffset;
            double upperBound = predicted * (1.0 + uncFactor) + uncOffset;
            return (measured > lowerBound) && (measured < upperBound);
        }
        private void ValidateButton_Click(object sender, EventArgs e) {
            int numSkipped = 0;
            int numValid = 0;
            List<ETan> ETans = new List<ETan>();
            List<double> measuredVals = new List<double>();
            List<double> predictedVals = new List<double>();
            List<bool> validVals = new List<bool>();

            double uncFactor, uncOffset;
            if(!Double.TryParse(pcentUncTextBox.Text,out uncFactor) ||
                !Double.TryParse(uncOffsetTextBox.Text,out uncOffset)) {
                MessageBox.Show(this, "Uncertainty must be a valid number.",
                    "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            uncFactor = uncFactor / 100.0; // Convert from percentage

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
                // FIXME: Should this use the crest factor?
                /*
                if (VoltageMode && !Double.IsNaN(etanRow.summrow.CrestFactor))
                    scaledEtanRms = etanRow.rms.Multiply(etanRow.summrow.CrestFactor);
                */
                double Z = DataProcessing.TFInt(
                    ETan_Z: etanRow.z, ETan_RMS: scaledEtanRms,
                    TF_Z: TFz, TF_Sr: TFSr);

                if (VoltageMode)
                    Z = Math.Sqrt(Z);

                ETans.Add(etanRow);
                double measuredVal;
                if (VoltageMode)
                    measuredVal = etanRow.summrow.PeakHeaderVoltage;
                else
                    measuredVal = etanRow.summrow.MeasuredTemperature;
                measuredVals.Add(measuredVal);
                predictedVals.Add(Z);
                validVals.Add(IsWithinUncertainty(
                    uncFactor: uncFactor,
                    uncOffset: uncOffset,
                    measured: measuredVal,
                    predicted: Z
                    ));
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

            // Save things
            if (saveSummaryFileCheckbox.Checked)
                SaveSummaryTable(ETans, predictedVals,validVals);
            bool overallValid = !validVals.Contains(false);
            TFFitPlotForm tffpf = new TFFitPlotForm();
            tffpf.AddData(
                predicted: predictedVals,
                measured: measuredVals,
                varName: VoltageMode ? "V" : "dT",
                title: TransferFunctionFilenameLabel.Text + ": " +
                (overallValid? "VALID" : "NOT VALID")
                );
            tffpf.AddFit(1 + uncFactor, uncOffset, overallValid? Color.Blue: Color.Red);
            tffpf.AddFit(1 - uncFactor, -uncOffset, overallValid ? Color.Blue : Color.Red);

            tffpf.Show(this);
        }
        protected void SaveSummaryTable(
            List<ETan> etanRows,
            List<double> predictedVals,
            List<bool> validVals
            ) {
            string[] headers = new string[] {
                "", // iterator column
                "Pathway",
                "TF Predicted " + (VoltageMode? "Peak Header Voltage" : "Temperature"),
                "Measured " + (VoltageMode? "Peak Header Voltage" : "Temperature"),
                "Etan Scaling Factor",
                "Validation"
            };
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Raw Neuro Header Voltage Data Files";
            sfd.Filter = "XLSX (*.xlsx)|*.xlsx|CSV (*.csv)|*.csv|All Files (*.*)|*.*";
            sfd.Title = "Select output scaling calculation summaryfile...";
            if (sfd.ShowDialog() != DialogResult.OK) {
                return;
            }
            if(sfd.FileName.EndsWith(".csv")) {
                using (var sw = new StreamWriter(sfd.OpenFile())) {
                    int i = 0;
                    sw.WriteLineAsync(String.Join(",", headers));
                    foreach (var row in etanRows.Zip(predictedVals).Zip(validVals)) {
                        sw.WriteLineAsync(String.Join(",", new string[] {
                            i.ToString(), // iterator
                            row.Item1.Item1.PathWay, // pathway
                            row.Item1.Item2.ToString(), // predicted voltage
                            (VoltageMode?
                            row.Item1.Item1.summrow.PeakHeaderVoltage :
                            row.Item1.Item1.summrow.MeasuredTemperature).ToString(),
                            row.Item1.Item1.summrow.ETanScalingFactor.ToString(),
                            row.Item2 ? "Yes" : "No"
                        }));
                        i++;
                    }
                }
            } else {
                FileInfo newFile = new FileInfo(sfd.FileName);
                if(newFile.Exists) {
                    newFile.Delete();
                    newFile = new FileInfo(sfd.FileName);
                }
                using (ExcelPackage package = new ExcelPackage()) {
                    var ws = package.Workbook.Worksheets.Add("Sheet1");
                    for (int i = 0; i < headers.Length; i++) {
                        ws.Cells[1, i + 1].Value = headers[i];
                        ws.Cells[1, i + 1].Style.Font.Bold = true;
                    }
                    for(int i=0; i<etanRows.Count; i++) {
                        ws.Cells[i + 2, 1].Value = i; // iterator
                        ws.Cells[i + 2, 1].Style.Font.Bold = true;
                        ws.Cells[i + 2, 2].Value = etanRows[i].PathWay;

                        ws.Cells[i + 2, 3].Value = predictedVals[i];
                        ws.Cells[i + 2, 4].Value = VoltageMode ?
                            etanRows[i].summrow.PeakHeaderVoltage :
                            etanRows[i].summrow.MeasuredTemperature;
                        ws.Cells[i + 2, 5].Value = etanRows[i].summrow.ETanScalingFactor;
                        ws.Cells[i + 2, 6].Value = validVals[i] ? "Yes" : "No";
                    }
                    ws.Cells[ws.Dimension.Address].AutoFitColumns();
                    package.SaveAs(newFile);
                }

            }
        }
        
    }
}
