using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Data.Matlab;

namespace MRI_RF_TF_Tool {
    class ETan {
        public string filename;
        public string name;
        public Vector<double> z;
        public Vector<Complex> rms;
        public MeasSummary.SummaryRow summrow = null;
        public ETan() {

        }
        public string PathWay {
            get {
                Regex fn_re = new Regex(
                    @"^(?<pathway>[A-Z]+[0-9]+)_etan.mat$",RegexOptions.IgnoreCase);
                Match m = fn_re.Match(System.IO.Path.GetFileName(filename));

                if (!m.Success)
                    throw new FormatException("Filename is not in the proper format: " + filename);
                return m.Groups["pathway"].Value;
            }
        }
        public ETan(string filename) {
            z = MatlabReader.Read<double>(filename, "etan_z").Column(0);
            rms = MatlabReader.Read<Complex>(filename, "etan_rms").Column(0);
            this.filename = filename;
            name = System.IO.Path.GetFileName(filename);
        }
        public override string ToString() {
            return name + "(" + (
                    (summrow == null) ? 
                    ( PathWay ) :
                    (summrow.ToString())
                ) + ")";
        }
    }
}
