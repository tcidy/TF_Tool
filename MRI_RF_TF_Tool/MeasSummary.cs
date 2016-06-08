using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Excel;
using System.Threading.Tasks;

namespace MRI_RF_TF_Tool {
    public class MeasSummary {
        public List<SummaryRow> rows;
        public class SummaryRow {
            public string Pathway;
            public double MeasuredTemperature = double.NaN;
            public double PeakHeaderVoltage = double.NaN;
            public double CrestFactor = double.NaN;
            public bool Conjugate = false;
            public double ETanScalingFactor = 1.0;
            public override string ToString() {
                string s = Pathway + ": (";
                if (!Double.IsNaN(MeasuredTemperature))
                    s += "temp=" + MeasuredTemperature.ToString() + ", ";
                if (!Double.IsNaN(PeakHeaderVoltage))
                    s += "volt=" + PeakHeaderVoltage.ToString() + ", ";

                 s = s + "conj=" + Conjugate.ToString() + 
                    ", etan_scale=" + ETanScalingFactor.ToString() +")";
                return s;
            }
        }
        public static double ConvertColumnToDouble(object x, string colname) {
            if (x is double) {
                return (double)x;
            }
            else if (x is string) {
                double value;
                if (!Double.TryParse((string)x, out value))
                    throw new FormatException("\"" + colname + "\" column with unknown data: "
                        + x.ToString());
                return value;
            }
            throw new FormatException("\"" + colname + "\" column with non-numeric data: "
                + x.ToString());
        }
        public void Read(string filename) {
            Stream sr = File.OpenRead(filename);
            IExcelDataReader excelReader;
            // Default to xlsx
            if (filename.EndsWith(".xls")) {
                excelReader = ExcelReaderFactory.CreateBinaryReader(sr);
            }
            else {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(sr);
            }
            var data = excelReader.AsDataSet();
            var table = data.Tables[0];
            var headerRow = table.Rows[0];
            int pathway_col=-1, temp_col=-1, conj_col=-1, etanScalingFactor_col=-1,
                peakHeaderVoltage_col = -1, crestFactor_col = -1;
            for(int i=0; i<headerRow.ItemArray.Length; i++) {
                if (headerRow.ItemArray[i] is DBNull)
                    continue;
                string colname = (string)headerRow.ItemArray[i];
                switch (colname.ToLowerInvariant()) {
                    case "": break;
                    case "pathway": pathway_col = i; break;
                    case "measured temperature": temp_col = i; break;
                    case "conjugate": conj_col = i; break;
                    case "etan scaling factor": etanScalingFactor_col = i; break;
                    case "measured peak header voltage": peakHeaderVoltage_col = i; break;
                    case "crest factor": crestFactor_col = i; break;
                    default: throw new FormatException("Summary file contains an unknown column: " + colname);
                }
            }
            if (pathway_col == -1)
                throw new FormatException("Pathway column not discovered in summary file.");
            rows = new List<SummaryRow>();
            for(int i=1; i<table.Rows.Count; i++) {
                // skip row if pathway is blank
                if (table.Rows[i].ItemArray[pathway_col] is DBNull || 
                    (string)table.Rows[i].ItemArray[pathway_col] == "")
                    continue;
                var sumrow = new SummaryRow();
                sumrow.Pathway = table.Rows[i].ItemArray[pathway_col].ToString();
                if (temp_col != -1) {
                    var x = table.Rows[i].ItemArray[temp_col];
                    sumrow.MeasuredTemperature =
                        ConvertColumnToDouble( x,headerRow.ItemArray[temp_col].ToString());
                }
                if (peakHeaderVoltage_col != -1) {
                    var x = table.Rows[i].ItemArray[peakHeaderVoltage_col];
                    sumrow.PeakHeaderVoltage =
                         ConvertColumnToDouble(x, headerRow.ItemArray[peakHeaderVoltage_col].ToString());
                }
                if (crestFactor_col != -1) {
                    var x = table.Rows[i].ItemArray[crestFactor_col];
                    sumrow.CrestFactor =
                         ConvertColumnToDouble(x, headerRow.ItemArray[crestFactor_col].ToString());
                }
                if (conj_col != -1) {
                    object x = table.Rows[i].ItemArray[conj_col];
                    if(!(x is string))
                        throw new FormatException("Conjugate column with non-string data: "
                            + x.ToString());

                    switch ((string)(x)) {
                        case "n":
                        case "N":
                        case "":
                            sumrow.Conjugate = false; break;
                        case "y":
                        case "Y":
                            sumrow.Conjugate = true; break;
                        default:
                            throw new FormatException("Conjugate column with unknown data: "
                                + table.Rows[i].ItemArray[conj_col].ToString());
                    }
                }
                if (etanScalingFactor_col != -1) {

                    var x = table.Rows[i].ItemArray[etanScalingFactor_col];
                    sumrow.ETanScalingFactor =
                         ConvertColumnToDouble(x, headerRow.ItemArray[etanScalingFactor_col].ToString());
                }
                rows.Add(sumrow);
            }
            excelReader.Close();
        }
    }
}
