using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Excel;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Data.Matlab;
using System.Windows.Forms;

namespace MRI_RF_TF_Tool {
    public partial class ScaleTFForm : Form {

        Vector<double> TFz= null;
        Vector<Complex> TFSr = null;

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
            Stream sr = File.OpenRead(ofd.FileName);
            IExcelDataReader excelReader;
            // Default to xlsx
            if (ofd.FileName.EndsWith(".xls")) {
                excelReader = ExcelReaderFactory.CreateBinaryReader(sr);
            } else {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(sr);
            }
            var data = excelReader.AsDataSet();
            var table = data.Tables[0];
            var headerRow = 
            excelReader.Close();
        }
    }
}
