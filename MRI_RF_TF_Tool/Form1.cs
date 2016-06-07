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
using MathNet.Numerics.Statistics;

namespace MRI_RF_TF_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Reset enabled of the temperature interval input
            ModeRadioButtonChecked(null,null);
        }

        private void CompareTFButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            List<Vector<double>> ZList = new List<Vector<double>>();
            List<Vector<Complex>> SrList = new List<Vector<Complex>>();

            ofd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Neuro Orion MRI RF Heating TF Files";
            ofd.Multiselect = true;
            ofd.Filter = "Matlab MAT (*.mat)|*.mat|All Files (*.*)|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            if (ofd.FileNames.Length == 0) {
                MessageBox.Show(this, "No files selected", "TF Reading Error");
            }

            try
            {
                foreach(string f in ofd.FileNames)
                {
                    ZList.Add(MatlabReader.Read<double>(f, "z").Column(0));
                    SrList.Add(MatlabReader.Read<Complex>(f, "Sr").Column(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "TF Reading Error");
                return;
            }
            TFComparisonForm tfcf = new TFComparisonForm(ofd.FileNames, ZList, SrList);
            tfcf.Show();
        }

        private void ProcessTempDataButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select input data files...";
            ofd.Multiselect = true;
            double interval = 0.0;
            if (TemperatureModeRadioButton.Checked) {
                if (!Double.TryParse(TempMeasIntervalTextBox.Text, out interval))
                {
                    MessageBox.Show(this, "The entered time interval is not a valid number.",
                        "Data Processing Error");
                    return;
                }
            }
            if (VoltageModeRadioButton.Checked && CRMRadioButton.Checked)
                ofd.Filter = "Text (*.txt)|*.txt|All Files (*.*)|*.*";
            else
                ofd.Filter = "CSV (*.csv)|*.csv|All Files (*.*)|*.*";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string sourcedir = Path.GetDirectoryName(ofd.FileNames[0]);
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Raw Neuro Header Voltage Data Files";
            sfd.Filter = "CSV (*.csv)|*.csv|All Files (*.*)|*.*";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                if (VoltageModeRadioButton.Checked)
                {
                    if (NeuroRadioButton.Checked)
                        DataProcessing.ProcessNeuroHeaderVoltage(ofd.FileNames, sfd.FileName);
                    else
                        DataProcessing.ProcessCRMHeaderVoltage(ofd.FileNames, sfd.FileName);
                } else
                {
                    if (NeuroRadioButton.Checked)
                    { // Neuro Temp Data
                        DataProcessing.ProcessNeuroTempData(ofd.FileNames, sfd.FileName,interval,
                            doPlots: DoDataProcessingPlotsCheckBox.Checked );
                    } else
                    {
                        DataProcessing.ProcessCRMTempData(ofd.FileNames, sfd.FileName, interval,
                            doPlots: DoDataProcessingPlotsCheckBox.Checked);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Data Processing Error");
                return;
            }
            MessageBox.Show(this,"Done");
        }
        private void ModeRadioButtonChecked(object sender, EventArgs e)
        {
            TempMeasIntervalLabel.Enabled = TemperatureModeRadioButton.Checked;
            TempMeasIntervalTextBox.Enabled = TemperatureModeRadioButton.Checked;
            DoDataProcessingPlotsCheckBox.Enabled = TemperatureModeRadioButton.Checked;
        }

        private void ScaleTFButton_Click(object sender, EventArgs e) {
            ScaleTFForm stff = new ScaleTFForm();
            stff.ShowDialog();
        }
    }
}
