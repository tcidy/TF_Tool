using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Data.Text;
using MathNet.Numerics.Data.Matlab;
using MathNet.Numerics.Statistics;

namespace MRI_RF_TF_Tool
{
    class DataProcessing
    {
        public static void ProcessNeuroHeaderVoltage(string[] infiles, string outfile)
        {
            using (StreamWriter tw = new StreamWriter(outfile))
            {
                string[] headers = new string[] {
                    "" /* line number */,
                    "File Name", "Date", "Measurement Pathway", "Lead State",
                    "Lead Type", "Odd Channel", "Odd Channel Voltage", "Even Channel",
                    "Even Channel Voltage" };
                tw.WriteLine(String.Join(",", headers));
                int i = 0;
                foreach (string fn in infiles)
                {
                    StreamReader sr = new StreamReader(fn);
                    string namepart = Path.GetFileNameWithoutExtension(fn);
                    string line;
                    Regex fn_re = new Regex(
                        @"^(?<date>[0-9\-]+)_CH(?<ch1num>[0-9]*)-(?<ch2num>[0-9]*)_(?<label>[a-zA-Z0-9]+)_(?<lead_state>[a-zA-Z0-9]+)_(?<lead_path>[a-zA-Z0-9]+)");
                    Match m = fn_re.Match(namepart);

                    if (!m.Success)
                        throw new FormatException("Filename is not in the proper format: " + fn);

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
                        fn, // filename
                        m.Groups["date"].Value,
                        m.Groups["lead_path"].Value,
                        m.Groups["lead_state"].Value,
                        "CH" + m.Groups["ch1num"].Value + "-" + m.Groups["ch2num"].Value,
                        "CH" + m.Groups["ch1num"].Value,
                        oddvoltage.ToString(),
                        m.Groups["ch2num"].Value,
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

        // FIXME: Why is data so cyclical??
        // FIXME: The time interval in the GUI seems unused?
        // FIXME: The 0.2 constant threshold for RF on seems perhaps too low
        // FIXME: Assumption that the sample rate is exactly 1 Hz
        // FIXME: Perhaps the python code averaged 11 elements instead of 10.
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
                string[] headers = new string[] {
                    "" /* line number */,
                    "Filename",
                    String.Join(",",
                        Enumerable.Range(1,20).Select(x => "Probe " + x.ToString())
                    )};
                tw.WriteLine(String.Join(",", headers));
                int i = 0;
                foreach (string fn in infiles)
                {
                    StreamReader sr = new StreamReader(fn);
                    string namepart = Path.GetFileName(fn);
                    string line;
                    List<double>[] values = new List<double>[20];
                    for (int j = 0; j < 20; j++)
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
                        if (parts.Length != 42)
                            throw new FormatException("Wrong number of element in data row of: " + fn);
                        for (int j = 1; j <= 20; j++) // skip first element
                            values[j - 1].Add(Double.Parse(parts[j * 2]));

                    };
                    if (values[0].Count == 0)
                        throw new FormatException("Data file is too short. No data samples" + fn);
                    var startvals = values.Select(
                        v => v.GetRange(0, 30).Mean()
                      ).ToArray();
                    int start_elem_ix = values[0].FindIndex(x => x > startvals[0] + 0.2);
                    if (start_elem_ix < 20 || start_elem_ix == -1)
                        throw new FormatException("Start element was found to be invalid, ix=" +
                            start_elem_ix.ToString() + ", in file " +
                            fn);
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
                        if (ix2 >= 0 && (start_elem_ix == -1 || start_elem_ix > ix2))
                            start_elem_ix = ix2;
                    }
                    if (start_elem_ix < 6 || start_elem_ix == -1)
                        throw new FormatException("Start element was found to be invalid [<=10 || not found], ix=" +
                            start_elem_ix.ToString() + ", in file " +
                            fn);
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
