﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;
using MathNet.Numerics;
using MathNet.Numerics.Interpolation;
using MathNet.Numerics.Integration;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Data.Text;
using MathNet.Numerics.Data.Matlab;
using MathNet.Numerics.Statistics;
using System.Windows.Forms;
using Excel;

namespace MRI_RF_TF_Tool
{
    class DataProcessing
    {
        public static double Integrate(IEnumerable<double> x, IEnumerable<double> y) {
            var spline = CubicSpline.InterpolateBoundaries(x, y,
                SplineBoundaryCondition.ParabolicallyTerminated, 0, SplineBoundaryCondition.ParabolicallyTerminated, 0);
            return spline.Integrate(x.Minimum(), x.Maximum());
        }
        // This evaluates the SQUARED intergral of (S*Etan)
        public static double TFInt(
            Vector<Double> ETan_Z,
            Vector<Complex> ETan_RMS,
            Vector<Double> TF_Z,
            Vector<Complex> TF_Sr
            ) {

            int num_points = 5000;
            double zmin = Math.Max(TF_Z.Minimum(), ETan_Z.Minimum());
            double zmax = Math.Min(TF_Z.Maximum(), ETan_Z.Maximum());

            LinearSpline etansinterpR = LinearSpline.Interpolate(
                ETan_Z, ETan_RMS.Real());
            LinearSpline etansinterpI = LinearSpline.Interpolate(
                ETan_Z, ETan_RMS.Imaginary());
            LinearSpline TF_SrInterpR = LinearSpline.Interpolate(
                TF_Z, TF_Sr.Real());
            LinearSpline TF_SrInterpI = LinearSpline.Interpolate(
                TF_Z, TF_Sr.Imaginary());

            /*var ETanGridded = CreateVector.DenseOfEnumerable(
                zvals.Select(z => new Complex(
                   etansinterpR.Interpolate(z), etansinterpI.Interpolate(z)))
                   );
            var SrGridded = CreateVector.DenseOfEnumerable(
                zvals.Select(z => new Complex(
               TF_SrInterpR.Interpolate(z), TF_SrInterpI.Interpolate(z)))
               );*/
            //var Z = SrGridded.PointwiseMultiply(ETanGridded);
            // This is the integrand, SR*Etan
            Func<double,Complex> SrEtan = (z) =>
            {
                var s = new Complex(
               TF_SrInterpR.Interpolate(z), TF_SrInterpI.Interpolate(z));
                var e = new Complex(
                   etansinterpR.Interpolate(z), etansinterpI.Interpolate(z));
                return s * e;
            };
            // And to integrate it, the real and imaginary components must be
            // separately computed.
            Complex sum =
                new Complex(
                    NewtonCotesTrapeziumRule.IntegrateComposite(
                      (z => SrEtan(z).Real), zmin, zmax, num_points),
                    NewtonCotesTrapeziumRule.IntegrateComposite(
                      (z => SrEtan(z).Imaginary), zmin, zmax, num_points)
                      );
            // Usually we need the magnitude squared (for the temperature calculations)
            // But, the caller may find the square root, if needed, for example for voltages
            double dT = sum.MagnitudeSquared();
            return dT;
        }
        public static void ProcessHeaderToolVoltage(string[] infiles, string outfile)
        {
            using (StreamWriter tw = new StreamWriter(outfile))
            {
                string[] channel = new string[] { "", "File Name","ARing", "LVRing3", "SVC", "LVRing2", "RV", "ATip", "RVRing", "LVRing1", "RVTip", "LVTip" };
                //string[] headers = new string[] { "", "File Name" };
                tw.WriteLine(String.Join(",", channel));
                int i = 0;
                foreach (string fn in infiles)
                {
                    
                    Stream sr = File.OpenRead(fn);
                    IExcelDataReader excelReader;
                    if (fn.EndsWith(".xls"))
                    {
                        excelReader = ExcelReaderFactory.CreateBinaryReader(sr);
                    }
                    else
                    {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(sr);
                    }
                    var data = excelReader.AsDataSet();
                    var table = data.Tables[0];
                    int rrow = 0;
                    do rrow++;
                    while (table.Rows[rrow].ItemArray[0].ToString() != "Channel");
                    rrow++;
                    string[] maxvp = new string[10];
                    while (rrow < table.Rows.Count)
                    {
                        var HVRow = table.Rows[rrow];
                        int index = Array.IndexOf(channel, HVRow.ItemArray[0])-2;
                        var voltage = HVRow.ItemArray[1];
                        maxvp[index] = Convert.ToString(voltage);
                        rrow++;
                    }
                    var lineparts = new string[]
                    {
                        i.ToString(), // line number
                        Path.GetFileName(fn), // filename
                    };
                    lineparts = lineparts.Concat(maxvp).ToArray();
                    tw.WriteLine(
                       String.Join(",", lineparts)
                       );
                    i++;
                    ;
                }
            }
        } 
        public static void ProcessNeuroHeaderVoltage(string[] infiles, string outfile)
        {
            using (StreamWriter tw = new StreamWriter(outfile))
            {
                string[] headers = new string[] {
                    "" /* line number */,
                    //"File Name", "Date", "Measurement Pathway", "Lead State",
                    //"Lead Type", "Odd Channel", "Odd Channel Voltage", "Even Channel",
                    //"Even Channel Voltage" };
                        "File Name", "Voltage 1", "Voltage 2" };
                tw.WriteLine(String.Join(",", headers));
                int i = 0;
                foreach (string fn in infiles)
                {
                    StreamReader sr = new StreamReader(fn);
                    string namepart = Path.GetFileNameWithoutExtension(fn);
                    string line;
                   /* Regex fn_re = new Regex(
                        @"^(?<date>[0-9\-]+)_CH(?<ch1num>[0-9]*)-(?<ch2num>[0-9]*)_(?<label>[a-zA-Z0-9]+)_(?<lead_state>[a-zA-Z0-9]+)_(?<lead_path>[a-zA-Z0-9]+)");
                    Match m = fn_re.Match(namepart);
                   */
                    //if (!m.Success)
                    //    throw new FormatException("Filename is not in the proper format: " + fn);

                    double oddvoltage, evenvoltage;
                    do
                    {
                        line = sr.ReadLine();
                    } while (line != null && !line.StartsWith("average", StringComparison.InvariantCultureIgnoreCase));
                    if (line == null)
                        throw new FormatException("Average line not found in file " + fn);
                    string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.None);
                    if (parts.Length < 6) throw new FormatException("Not enough columns in file " + fn);
                    if (!Double.TryParse(parts[4], out oddvoltage))
                        throw new FormatException("Odd voltage is not a number in file " + fn);
                    if (!Double.TryParse(parts[5], out evenvoltage))
                        throw new FormatException("Even voltage is not a number in file " + fn);

                    var lineparts = new string[]
                    {
                        i.ToString(), // line number
                        Path.GetFileName(fn), // filename
                        //m.Groups["date"].Value,
                        //m.Groups["lead_path"].Value,
                        //m.Groups["lead_state"].Value,
                       // "CH" + m.Groups["ch1num"].Value + "-" + m.Groups["ch2num"].Value,
                        //"CH" + m.Groups["ch1num"].Value,
                        oddvoltage.ToString(),
                        //m.Groups["ch2num"].Value,
                        evenvoltage.ToString()
                    };
                    tw.WriteLine(
                       String.Join(",", lineparts)
                       );
                    i++;
                }
            }

        }

        public static void ProcessCRMHeaderVoltage(string[] infiles, string outfile)
        {
            using (StreamWriter tw = new StreamWriter(outfile))
            {
                string[] headers = new string[] {
                    "" /* line number */,
                    "Measurement Filename","ADC Count Value" };
                tw.WriteLine(String.Join(",", headers));
                int i = 0;
                foreach (string fn in infiles)
                {
                    StreamReader sr = new StreamReader(fn);
                    string namepart = Path.GetFileNameWithoutExtension(fn);
                    string line;
                    line = sr.ReadLine(); // Skip header line
                    if (line == null)
                        throw new FormatException("Data file is too short. No data samples" + fn);
                    List<double> values = new List<double>();
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim();
                        string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 1; j < parts.Length; j++) // skip first element
                            values.Add((double)Convert.ToUInt32(parts[j], 16));

                    };
                    if (values.Count == 0)
                        throw new FormatException("Data file is too short. No data samples" + fn);
                    double median = Statistics.Median(values);
                    var filteredData = values.FindAll(x => x > (0.9 * median));

                    var lineparts = new string[]
                    {
                        i.ToString(), // line number
                        fn, // filename
                        Statistics.Mean(filteredData).ToString()
                    };
                    tw.WriteLine(
                       String.Join(",", lineparts)
                       );
                    i++;
                }
            }
        }

      
        // FIXME: The 0.2 constant threshold for RF on seems perhaps too low
        // FIXME: Assumption that the sample rate is exactly 1 Hz
        // 
        // Neuro Temp Data Processing:
        // Look for the time series of data, Starting after a line that starts with 'Scan,'
        // For each time series (in odd columns):
        //    start_val = mean(first 30 elements)           [ or maybe it should be 30???]
        // start_elem_ix = index of first element of probe 1 that is its start_val+0.2
        // stop_elem_ix = start_elem_ix+interval
        // analysis_range = [stop_elem_ix-10:stop_elem_ix-1]         // This is 10 elements!
        // output_value = mean(analysis_range) - start_val

        public static void ProcessNeuroTempData(string[] infiles, string outfile, double interval,
            bool doPlots = true)
        {
            using (StreamWriter tw = new StreamWriter(outfile))
            {
                
                int i = 0;
                foreach (string fn in infiles)
                {
                    StreamReader sr = new StreamReader(fn);
                    string namepart = Path.GetFileName(fn);
                    string line;
                    int number_channels;
                    do
                    {
                        line = sr.ReadLine();
                    } while (line != null && !line.StartsWith("Total Channels", StringComparison.InvariantCultureIgnoreCase));
                    string[] line_break = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    number_channels = Int32.Parse(line_break[1]);
                    List<double>[] values = new List<double>[number_channels];
                    for (int j = 0; j < number_channels; j++)
                        values[j] = new List<double>();
                    do
                    {
                        line = sr.ReadLine();
                    } while (line != null && !line.StartsWith("scan,", StringComparison.InvariantCultureIgnoreCase));

                    // Skip header line
                    if (line == null)
                        throw new FormatException("Data file is too short. No data samples" + fn);

                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line == "")
                            continue;
                        string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 2*(number_channels+1))
                            throw new FormatException("Wrong number of element in data row of: " + fn);
                        for (int j = 1; j <= number_channels; j++) // skip first element
                            values[j - 1].Add(Double.Parse(parts[j * 2]));

                    };
                    if (values[0].Count == 0)
                        throw new FormatException("Data file is too short. No data samples" + fn);
                    var startvals = values.Select(
                        v => v.GetRange(0, 30).Mean()
                      ).ToArray();

                    //int start_elem_ix = values[0].Skip(30).ToList().FindIndex(x => x > startvals[0] + 0.2) + 30; // Ignore the first 30 elements
                    int start_elem_ix = -1;

                    for (int j = 0; j < number_channels; j++)
                    {
                        int ix2 = values[j].FindIndex(x => x > startvals[j] + 0.3);
                        if (ix2 >= 30 && (start_elem_ix == -1 || start_elem_ix > ix2))
                            start_elem_ix = ix2;
                    }
                    if (start_elem_ix == -1)
                    {
                        MessageBox.Show("Start element was found to be invalid [<=10 || not found], ix=" +
                            start_elem_ix.ToString() + ", in file " +
                            fn);
                        continue;
                    }
                        //throw new FormatException("Start element was found to be invalid, ix=" +
                        //    start_elem_ix.ToString() + ", in file " +
                        //    fn);
                    int end_elem_ix = start_elem_ix + ((int)interval);
                    if (end_elem_ix >= values[0].Count)
                    {
                        MessageBox.Show("In file " + fn + ", the RF pulse start + interval position was past the end of the data");
                        continue;
                    }
                        //throw new FormatException("In file " + fn + ", the RF pulse start + interval position was past the end of the data");
                    var endvals = values.Select(
                        v => v.GetRange(end_elem_ix - 10, 10).Mean()
                      ).ToArray();
                    var deltaT = startvals.Zip(endvals, (x1, x2) => (x2 - x1));
                    var lineparts = new string[]
                    {
                        i.ToString(), // line number
                        namepart, // filename
                        String.Join(",",deltaT.Select(x => x.ToString()))
                    };
                    string[] headers = new string[] {
                    "" /* line number */,
                    "Filename",
                    String.Join(",",
                        Enumerable.Range(1,number_channels).Select(x => "Probe " + x.ToString())
                    )};
                    if(i==0)
                        tw.WriteLine(String.Join(",", headers));
                    tw.WriteLine(
                       String.Join(",", lineparts)
                       );
                    if (doPlots)
                    {
                        PlotTempSeriesForm ptsf = new PlotTempSeriesForm(
                            title: namepart, data: values, startvals: startvals,
                            startx2: start_elem_ix,
                            endx1: end_elem_ix - 10, endx2: end_elem_ix - 1
                            );
                        ptsf.Show();
                    }
                    i++;
                }
            }
        }
        
        // 
        // Neuro Temp Data Processing:
        // Look for the time series of data, Starting after a line that starts with 'Scan,'
        // For each time series (in odd columns):
        //    start_val = mean(first 5 elements)
        // start_elem_ix = index of ANY channel that is 0.2 higher than the start_val
        // stop_elem_ix = start_elem_ix+interval
        // analysis_range = [stop_elem_ix-10:stop_elem_ix-1]         // This is 10 elements!
        // output_value = mean(analysis_range) - start_val

        public static void ProcessCRMTempData(string[] infiles, string outfile, double interval,
            bool doPlots = true)
        {
            using (StreamWriter tw = new StreamWriter(outfile))
            {
                string[] headers = new string[] {
                    "" /* line number */,
                    "Measurement Filename",
                    String.Join(",",
                        Enumerable.Range(1,4).Select(x => "Probe " + x.ToString())
                    )};
                tw.WriteLine(String.Join(",", headers));
                int i = 0;

                foreach (string fn in infiles)
                {
                    StreamReader sr = new StreamReader(fn);
                    string namepart = Path.GetFileName(fn);
                    string line;
                    List<double>[] values = new List<double>[4];
                    for (int j = 0; j < 4; j++)
                        values[j] = new List<double>();
                    // Skip header line
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line == "")
                            continue;
                        string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 5)
                            throw new FormatException("Wrong number of element in data row of: " + fn);
                        for (int j = 1; j <= 4; j++) // skip first element
                            values[j - 1].Add(Double.Parse(parts[j]));
                    };
                    if (values[0].Count == 0)
                        throw new FormatException("Data file is too short. No data samples" + fn);
                    var startvals = values.Select(
                        v => v.GetRange(0, 5).Mean()
                      ).ToArray();
                    int start_elem_ix = -1;
                    for (int j = 0; j < 4; j++)
                    {
                        int ix2 = values[j].FindIndex(x => x > startvals[j] + 0.2);
                        
                        if (ix2 < values[j].Count)
                        {
                            if (ix2 >= 0 && (start_elem_ix == -1 || start_elem_ix > ix2) && values[j][ix2 + 1] > values[j][ix2] + 0.2)
                                start_elem_ix = ix2;
                        }
                    }
                    if (start_elem_ix < 6 || start_elem_ix == -1)
                    {
                        MessageBox.Show("Start element was found to be invalid [<=10 || not found], ix=" +
                            start_elem_ix.ToString() + ", in file " +
                            fn);
                        continue;
                    }
                        //throw new FormatException("Start element was found to be invalid [<=10 || not found], ix=" +
                        //    start_elem_ix.ToString() + ", in file " +
                        //    fn);
                    int end_elem_ix = start_elem_ix + ((int)interval);
                    var endvals = values.Select(
                        v => v.GetRange(end_elem_ix - 10, 10).Mean()
                      ).ToArray();
                    var deltaT = startvals.Zip(endvals, (x1, x2) => (x2 - x1));
                    var lineparts = new string[]
                    {
                        i.ToString(), // line number
                        namepart, // filename
                        String.Join(",",deltaT.Select(x => x.ToString()))
                    };
                    tw.WriteLine(
                       String.Join(",", lineparts)
                       );
                    if (doPlots) {
                        PlotTempSeriesForm ptsf = new PlotTempSeriesForm(
                            title: namepart, data: values, startvals: startvals,
                            startx2: start_elem_ix,
                            endx1: end_elem_ix - 10, endx2: end_elem_ix - 1
                            );
                        ptsf.Show();
                        i++;
                    }
                }
            }
        }
    }
}
