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
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearRegression;
using MathNet.Numerics.Data.Matlab;
using System.Windows.Forms;
using OfficeOpenXml;
using Excel;
using MathNet.Numerics;
using MathNet.Numerics.Interpolation;

namespace MRI_RF_TF_Tool {
    public partial class ValidateTFForm : Form
    {
        
        Vector<double> TFz = null;
        Vector<Complex> TFSr = null;
        MeasSummary meassum = null;
        string TFFileFullPath = null;
        public ValidateTFForm()
        {
            InitializeComponent();
            if (Manual_V.Checked)
            {
                EtanFileListForScaling.Enabled = false;
                AddEtanFilesForScale.Enabled = false;
                Remove2.Enabled = false;
                saveOptFileCheckbox.Checked = false;
                saveOptFileCheckbox.Enabled = false;
                saveOPTTFcheckBox.Checked = false;
                saveOPTTFcheckBox.Enabled = false;
                radioK1Rate.Enabled = false;
                radioScaleFactor.Enabled = false;
                radioTrendSlope.Enabled = false;
                clearScaleEtanButton.Enabled = false;
                TFAdjPanel.Enabled = false;
            }
        }

        private void BrowseTransferFunctionButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Neuro Orion MRI RF Heating TF Files";
            ofd.Filter = "Matlab MAT (*.mat)|*.mat|All Files (*.*)|*.*";
            ofd.Title = "Select TF files...";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            if (ofd.FileNames.Length == 0)
            {
                MessageBox.Show(this, "No files selected", "TF Reading Error");
                return;
            }
            try
            {
                var f = ofd.FileName;
                var shortfname = System.IO.Path.GetFileName(f);
                var mz = MatlabReader.Read<double>(f, "z");
                var msr = MatlabReader.Read<Complex>(f, "Sr");
                // Take either first row or column....
                if (mz.ColumnCount == 1 && mz.RowCount > 1)
                    TFz = mz.Column(0);
                else if (mz.RowCount == 1 && mz.ColumnCount > 1)
                    TFz = mz.Row(0);
                else
                {
                    throw new FormatException("Input matrix must be 1xN or Nx1, with N>=2");
                }
                if (msr.ColumnCount == 1 && msr.RowCount > 1)
                    TFSr = msr.Column(0);
                else if (mz.RowCount == 1 && msr.ColumnCount > 1)
                    TFSr = msr.Row(0);
                else
                    throw new FormatException("Input matrix must be 1xN or Nx1, with N>=2");
                if (TFz.Count != TFSr.Count)
                    throw new FormatException("Input matrices must be of equal dimensions");

                TransferFunctionFilenameLabel.Text = shortfname;
                TFFileFullPath = ofd.FileName;
                ViewTFButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "TF File could not be opened!\n\n" + ex.Message,
                    "Error loading TF file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewTFButton_Click(object sender, EventArgs e)
        {
            var shortfname = TransferFunctionFilenameLabel.Text;
            TFComparisonForm tfcf = new TFComparisonForm(
                new string[] { shortfname },
                new Vector<double>[] { TFz },
                new Vector<Complex>[] { TFSr },
                shortfname
                );
            tfcf.Show(this);
        }

        private void AddEtanFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Input Etan mat files";
            ofd.Filter = "Matlab MAT (*.mat)|*.mat|All Files (*.*)|*.*";
            ofd.Title = "Select Etan files...";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            if (ofd.FileNames.Length == 0)
            {
                MessageBox.Show(this, "No files selected", "TF Reading Error");
                return;
            }
            try
            {
                List<ETan> newETanData = new List<ETan>();
                foreach (string f in ofd.FileNames)
                {
                    ETan etan = new ETan(f);
                    newETanData.Add(etan);
                }
                foreach (ETan x in ETanFilesListBox.Items)
                {
                    newETanData.RemoveAll(y => y.filename == x.filename);
                }
                ETanFilesListBox.Items.AddRange(newETanData.ToArray());
                RefreshSummaryRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "TF File could not be opened!\n\n" + ex.Message,
                    "Error loading TF file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            while (ETanFilesListBox.SelectedItems.Count > 0)
                ETanFilesListBox.Items.RemoveAt(ETanFilesListBox.SelectedIndices[0]);
        }

        private void summaryFileBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\" +
                    @"MRI_RF_TF_Tool_Project\Test Files for Python Utility\" +
                    @"Measurement Summary Input xlsx Files";
            ofd.Filter = "Excel Files (*.xls, *.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
            ofd.Title = "Select Summary files...";
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            if (ofd.FileNames.Length == 0)
            {
                MessageBox.Show(this, "No file selected", "TF Reading Error");
                return;
            }
            try
            {
                MeasSummary sum = new MeasSummary();
                sum.Read(ofd.FileName);
                meassum = sum;
                RefreshSummaryRows();
                summaryFilenameLabel.Text = Path.GetFileName(ofd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Erorr reading summary file.\n\n" +
                    ex.Message, "Summary file reading error");
            }
        }
        public void RefreshSummaryRows()
        {
            if (meassum == null)
            {
                foreach (ETan x in ETanFilesListBox.Items)
                {
                    x.summrow = null;
                }
                foreach (ETan x in EtanFileListForScaling.Items)
                {
                    x.summrow = null;
                }
            }
            else
            {
                int num_of_etans = ETanFilesListBox.Items.Count;
                for (int i = 0; i < num_of_etans; i++)
                {
                    ETan x = (ETan)ETanFilesListBox.Items[i];
                    List<MeasSummary.SummaryRow> row =
                        meassum.rows.FindAll(r => r.Pathway.ToLowerInvariant() == x.PathWay.ToLowerInvariant());
                    if (row != x.summrow)
                    {
                        x.summrow = row;
                        ETanFilesListBox.Items[i] = x;
                    }
                    
                    
                }
                for (int i = 0; i < EtanFileListForScaling.Items.Count; i++)
                {
                    ETan x = (ETan)EtanFileListForScaling.Items[i];
                    List<MeasSummary.SummaryRow> row =
                        meassum.rows.FindAll(r => r.Pathway.ToLowerInvariant() == x.PathWay.ToLowerInvariant());
                    if (row != x.summrow)
                    {
                        x.summrow = row;
                        EtanFileListForScaling.Items[i] = x;
                    }
                }
            }
        }
        private bool VoltageMode
        {
            get { return voltageRadioButton.Checked; }
        }
        public bool IsWithinUncertainty(
            double uncFactor,
            double uncOffset,
            double measured,
            double predicted
            )
        {
            double lowerBound = predicted * (1.0 - uncFactor) - uncOffset;
            double upperBound = predicted * (1.0 + uncFactor) + uncOffset;
            return (measured > lowerBound) && (measured < upperBound);
        }
        public struct opt
        {
            public string index_opt;
            public double k1_opt;
            public double k2_opt;
            public bool pass_opt;
            public double trend_opt;
            public bool valid_scale_opt;
            public double scale_fac_opt;
            public double slope_error;
            public int TF_i;
        }
        public struct opt_sort
        {
            public String pathway;
            public int order;
        }
        public struct TF_pack
        {
            public Vector<double> zz;
            public Vector<Complex> Srr;
        }
        private void ValidateButton_Click(object sender, EventArgs e)
        {
            int numSkipped = 0;
            int numValid = 0;
            List<ETan> ETans = new List<ETan>();
            List<ETan> ETans4Scaling = new List<ETan>();
            List<double> measuredVals = new List<double>();
            List<double> predictedVals = new List<double>();
            List<double> etanScaleFac = new List<double>();
            List<double> measuredVals4Scaling = new List<double>();
            List<double> predictedVals4Scaling = new List<double>();
            List<bool> validVals_k1 = new List<bool>();
            List<bool> validVals_k2 = new List<bool>();
            List<string> pathwayVals = new List<string>();
            List<string> pathwayVals4Scaling = new List<string>();
            List<string> index = new List<string>();
            List<double> rate_k1 = new List<double>();
            List<double> rate_k2 = new List<double>();
            List<bool> pass = new List<bool>();
            List<double> trend = new List<double>();
            List<double> scalingFac = new List<double>();
            List<bool> valid_scale = new List<bool>();
            List<double> slope_error = new List<double>();
            List<opt> opt_output = new List<opt>();
            List<TF_pack> TFs = new List<TF_pack>();
            List<int> TF_index = new List<int>();

            double uncFactor, uncOffset;
            if (!Double.TryParse(pcentUncTextBox.Text, out uncFactor) ||
                !Double.TryParse(uncOffsetTextBox.Text, out uncOffset))
            {
                MessageBox.Show(this, "Uncertainty must be a valid number.",
                    "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            uncFactor = uncFactor / 100.0; // Convert from percentage
            if(TFAutoAdj.Checked)
            {
                //Adjust TF Sweep
                ///Truncate TF
                int mini = 0;
                int maxi = TFSr.Count - 1;
                double truncateMin = TFz.First()+double.Parse(truncateLengthBegin.Text);
                double truncateMax = TFz.Last()- double.Parse(truncateLengthEnd.Text);
                var v = TFz.Find(x => (x + x * 1e-5 >= truncateMin));
                mini = v.Item1;
                var w = TFz.Find(x => (x - x * 1e-5 > truncateMax));
                if (w == null)
                    maxi = TFz.Count - 1;
                else
                {
                    maxi = w.Item1 - 1;
                }
                Vector<double> TFadjustedZ_origin = TFz.SubVector(mini, maxi - mini + 1);
                Vector<Complex> TFadjustedSr_origin = TFSr.SubVector(mini, maxi - mini + 1);
                ///initial values for extrapolate
                IEnumerable<double> phase_origin = TFSr.Map(x => x.Phase).Unwrap();
                phase_origin = phase_origin.Skip(mini).Take(maxi - mini + 1);
                IEnumerable<double> phasez_origin = TFadjustedZ_origin;
                IEnumerable<double> magz_origin = TFadjustedZ_origin;
                IEnumerable<double> mag_origin = TFadjustedSr_origin.Map(x => x.Magnitude);
                double extrapolateMin = TFz.First();
                double extrapolateMax = TFz.Last();
                var leftInterp = Fit.PolynomialFunc(magz_origin.Take(2).ToArray(), mag_origin.Take(2).ToArray(), 1);
                var rightInterp = Fit.PolynomialFunc(magz_origin.Reverse().Take(2).Reverse().ToArray(),
                        mag_origin.Reverse().Take(2).Reverse().ToArray(),
                        1);
                var leftInterph = Fit.PolynomialFunc(phasez_origin.Take(2).ToArray(), phase_origin.Take(2).ToArray(), 1);
                var rightInterph = Fit.PolynomialFunc(phasez_origin.Reverse().Take(2).Reverse().ToArray(),
                        phase_origin.Reverse().Take(2).Reverse().ToArray(),
                        1);
                double TFMinVal_origin = leftInterp(TFz.First());
                double TFMaxVal_origin = rightInterp(TFz.Last());
                double TFMinPhase_origin = leftInterph(TFz.First());
                double TFMaxPhase_origin = rightInterph(TFz.Last());
                double TFmag_mean = mag_origin.Average();
                double TFphase_mean = phase_origin.Average();
                int step = int.Parse(offsetP.Text);
                double offset_rate = double.Parse(offsetR.Text);
                for (int i1 = -step; i1 <= step; i1++)
                {
                    for (int i2 = -step; i2 <= step; i2++)
                    {
                        for (int i3 = -step; i3 <= step; i3++)
                        {
                            for (int i4 = -step; i4 <= step; i4++)
                            {
                                Vector<double> TFadjustedZ = TFadjustedZ_origin;
                                Vector<Complex> TFadjustedSr = TFadjustedSr_origin;
                                double TFMaxVal = TFMaxVal_origin + i1 * offset_rate * mag_origin.Last(); ;
                                double TFMaxPhase = TFMaxPhase_origin + i3 * offset_rate * phase_origin.Last();
                                double TFMinVal = TFMinVal_origin + i2 * offset_rate * mag_origin.First();
                                double TFMinPhase = TFMinPhase_origin + i4 * offset_rate * phase_origin.First();
                                double currentMax = TFadjustedZ.Last();
                                double dx = TFadjustedZ[1] - TFadjustedZ[0];
                                int numextra = (int)((extrapolateMax - currentMax) / dx);
                                List<double> newx = new List<double>();
                                double xi = TFadjustedZ.Last() + dx;
                                while (xi - dx / 10 < extrapolateMax)
                                {
                                    newx.Add(xi);
                                    xi = xi + dx;
                                }
                                IEnumerable<double> magz = magz_origin.Concat(new double[] { extrapolateMax });
                                IEnumerable<double> mag = mag_origin.Concat(new double[] { TFMaxVal });
                                IEnumerable<double> phasez = phasez_origin.Concat(new double[] { extrapolateMax });
                                IEnumerable<double> phase = phase_origin.Concat(new double[] { TFMaxPhase });
                                var magspline = MakeInterpolator(magz, mag); // use forced point, if any
                                var phasepline = MakeInterpolator(phasez, phase);
                                var newy = newx.Select(x => Complex.FromPolarCoordinates(
                                magspline(x), phasepline(x)));
                                TFadjustedZ = Vector<double>.Build.DenseOfEnumerable(TFadjustedZ.Concat(newx));
                                TFadjustedSr = Vector<Complex>.Build.DenseOfEnumerable(TFadjustedSr.Concat(newy));
                                newx.Clear();
                                double currentMin = TFadjustedZ[0];
                                dx = TFadjustedZ[1] - TFadjustedZ[0];
                                numextra = 1 + (int)((currentMin - extrapolateMin) / dx);

                                xi = TFadjustedZ[0] - dx;
                                while (xi + dx / 10 > extrapolateMin)
                                {
                                    newx.Add(xi);
                                    xi = xi - dx;
                                }
                                newx.Reverse();
                                magz = (new double[] { extrapolateMin }).Concat(magz);
                                mag = (new double[] { TFMinVal }).Concat(mag);
                                phasez = (new double[] { extrapolateMin }).Concat(phasez);
                                phase = (new double[] { TFMinPhase }).Concat(phase);
                                magspline = MakeInterpolator(magz, mag);
                                phasepline = MakeInterpolator(phasez, phase);
                                newy = newx.Select(x => Complex.FromPolarCoordinates(
                                    magspline(x), phasepline(x)));
                                TFadjustedZ = Vector<double>.Build.DenseOfEnumerable(newx.Concat(TFadjustedZ));
                                TFadjustedSr = Vector<Complex>.Build.DenseOfEnumerable(newy.Concat(TFadjustedSr));

                                TF_pack TFtemp = new TF_pack();
                                TFtemp.zz = TFadjustedZ;
                                TFtemp.Srr = TFadjustedSr;
                                TFs.Add(TFtemp);

                                //plot
                                //TFComparisonForm tfTestPlot = new TFComparisonForm(
                                //    new string[] { "test" },
                                //    new Vector<double>[] { TFs.Last().zz },
                                //    new Vector<Complex>[] { TFs.Last().Srr },
                                //   "test"
                                //    );
                                //tfTestPlot.Show(this);
                            }
                        }
                    }
                }
            }
            else
            {
                TF_pack TFtemp = new TF_pack();
                TFtemp.zz = TFz;
                TFtemp.Srr = TFSr;
                TFs.Add(TFtemp);
            }


            //go through all TFs
            //foreach (TF_pack TF_part in TFs)
            for (int TFi = 0; TFi < TFs.Count; TFi++)
            {
                //process data for scaling
                TF_pack TF_part = TFs[TFi];
                predictedVals4Scaling.Clear();
                measuredVals4Scaling.Clear();
                pathwayVals4Scaling.Clear();
                pathwayVals.Clear();
                predictedVals.Clear();
                measuredVals.Clear();
                etanScaleFac.Clear();
                numValid = 0;
                validVals_k1.Clear();
                validVals_k2.Clear();
                ETans4Scaling.Clear();
                ETans.Clear();
                //process data for scaling
                foreach (ETan etanRow in EtanFileListForScaling.Items)
                {
                    foreach (MeasSummary.SummaryRow sumrow in etanRow.summrow)
                    {
                        if (etanRow.summrow == null ||
                        (VoltageMode && Double.IsNaN(sumrow.PeakHeaderVoltage)) ||
                        (!VoltageMode && Double.IsNaN(sumrow.MeasuredTemperature))
                        )
                        {
                            numSkipped++;
                            continue;
                        }
                        var scaledEtanRms = etanRow.rms.Multiply(sumrow.ETanScalingFactor);
                        if (sumrow.Conjugate)
                            scaledEtanRms = scaledEtanRms.Conjugate();

                        if (VoltageMode && !Double.IsNaN(sumrow.CrestFactor))
                            scaledEtanRms = scaledEtanRms.Multiply(sumrow.CrestFactor);

                        double Z = DataProcessing.TFInt(
                            ETan_Z: etanRow.z, ETan_RMS: scaledEtanRms,
                            TF_Z: TF_part.zz, TF_Sr: TF_part.Srr);

                        if (VoltageMode)
                            Z = Math.Sqrt(Z);

                        ETans4Scaling.Add(etanRow);
                        double measuredVal;
                        if (VoltageMode)
                            measuredVal = sumrow.PeakHeaderVoltage;
                        else
                            measuredVal = sumrow.MeasuredTemperature;
                        //double etanScaleFacRow = etanRow.summrow.ETanScalingFactor;
                        measuredVals4Scaling.Add(measuredVal);
                        //etanScaleFac.Add(etanScaleFacRow);
                        predictedVals4Scaling.Add(Z);
                        pathwayVals4Scaling.Add(etanRow.PathWay);
                    }

                }

                //process data for validation
                foreach (ETan etanRow in ETanFilesListBox.Items)
                {
                    foreach (MeasSummary.SummaryRow sumrow in etanRow.summrow)
                    {
                        if (etanRow.summrow == null ||
                        (VoltageMode && Double.IsNaN(sumrow.PeakHeaderVoltage)) ||
                        (!VoltageMode && Double.IsNaN(sumrow.MeasuredTemperature))
                        )
                        {
                            numSkipped++;
                            continue;
                        }
                        var scaledEtanRms = etanRow.rms.Multiply(sumrow.ETanScalingFactor);
                        if (sumrow.Conjugate)
                            scaledEtanRms = scaledEtanRms.Conjugate();


                        if (VoltageMode && !Double.IsNaN(sumrow.CrestFactor))
                            scaledEtanRms = scaledEtanRms.Multiply(sumrow.CrestFactor);

                        double Z = DataProcessing.TFInt(
                            ETan_Z: etanRow.z, ETan_RMS: scaledEtanRms,
                            TF_Z: TF_part.zz, TF_Sr: TF_part.Srr);

                        if (VoltageMode)
                            Z = Math.Sqrt(Z);

                        ETans.Add(etanRow);
                        double measuredVal;
                        if (VoltageMode)
                            measuredVal = sumrow.PeakHeaderVoltage;
                        else
                            measuredVal = sumrow.MeasuredTemperature;
                        double etanScaleFacRow = sumrow.ETanScalingFactor;
                        measuredVals.Add(measuredVal);
                        predictedVals.Add(Z);
                        etanScaleFac.Add(etanScaleFacRow);
                        pathwayVals.Add(etanRow.PathWay);
                        validVals_k1.Add(IsWithinUncertainty(
                            uncFactor: uncFactor,
                            uncOffset: uncOffset,
                            measured: measuredVal,
                            predicted: Z
                            ));
                        validVals_k2.Add(IsWithinUncertainty(
                            uncFactor: uncFactor * 2,
                            uncOffset: uncOffset,
                            measured: measuredVal,
                            predicted: Z
                            ));
                        numValid++;

                    }

                }
                //
                if (numValid == 0)
                {
                    MessageBox.Show(this, "No valid data was found.",
                        "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (numSkipped > 0)
                {
                    MessageBox.Show(this, numSkipped.ToString() + " Etan files were skipped " +
                        "because a cooresponding row in the measurement summary file was not found.",
                        "Skipped ETan Files", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //scale optimize
                int n = measuredVals4Scaling.Count();


                if (Auto_V.Checked)
                {

                    int num4scale;
                    if (!int.TryParse(numPathways.Text, out num4scale))
                    {
                        MessageBox.Show(this, "number of pathways for scaling must be an int",
                            "Invalid input",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (num4scale < 1 || num4scale > n)
                    {
                        MessageBox.Show(this, "invalid number of pathways for scaling",
                            "Invalid input",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //creat a scale pathway list
                    List<int[]> comList = new List<int[]>();
                    foreach (int[] c in Combinations(num4scale, pathwayVals4Scaling.Count()))
                    {
                        //int[] comb = c.ToArray();
                        comList.Add(c.ToArray());
                    }

                    for (int k = 0; k < comList.Count(); k++)
                    {
                        List<double> mtt = new List<double>();
                        List<double> ptt = new List<double>();
                        List<double> spt = new List<double>();
                        List<bool> valid_k1 = new List<bool>();
                        List<bool> valid_k2 = new List<bool>();
                        StringBuilder pathwayName = new StringBuilder();
                        for (int j = 0; j < num4scale; j++)
                        {
                            mtt.Add(measuredVals4Scaling[comList[k][j] - 1]);
                            ptt.Add(predictedVals4Scaling[comList[k][j] - 1]);
                            pathwayName.Append(ETans4Scaling[comList[k][j] - 1].PathWay);
                            pathwayName.Append(" ");
                        }
                        //int l = 1;
                        //int m = 1;


                        double cline;
                        var A = CreateMatrix.DenseOfColumns(new IEnumerable<double>[] { ptt });
                        var B = CreateVector.DenseOfEnumerable(mtt);
                        var X = A.QR().Solve(B); // A*X = B
                        cline = X[0];
                        scalingFac.Add(cline);
                        for (int i = 0; i < measuredVals.Count(); i++)
                        {
                            spt.Add(predictedVals[i] * cline);
                        }

                        List<bool> single_validate = new List<bool>();
                        for (int i = 0; i < mtt.Count(); i++)
                        {
                            single_validate.Add(IsWithinUncertainty(uncFactor: uncFactor, uncOffset: uncOffset, measured: mtt[i], predicted: ptt[i] * cline));
                        }
                        valid_scale.Add(single_validate.All(c => c == true));

                        List<double> measuredVals4Validation = measuredVals.ToList();
                        List<double> predictedVals4Validation = spt.ToList();
                        List<string> pathwayVals4Validation = pathwayVals.ToList();


                        //int kk = pathwayVals.IndexOf(pathwayVals4Scaling[k]);
                        for (int i = mtt.Count() - 1; i >= 0; i--)
                        {
                            if (pathwayVals4Validation.Contains(pathwayVals4Scaling[comList[k][i] - 1]))
                            {
                                var jj = Enumerable.Range(0, pathwayVals4Validation.Count).Where(ii => pathwayVals4Validation[ii] == pathwayVals4Scaling[comList[k][i] - 1]).ToList();
                                jj.Reverse();
                                foreach (int j in jj)
                                {
                                    measuredVals4Validation.RemoveAt(j);
                                    predictedVals4Validation.RemoveAt(j);
                                    pathwayVals4Validation.RemoveAt(j);
                                }
                            }
                        }
                        if (pathwayVals4Validation.Count < 3)
                        {

                            continue;
                        }
                        index.Add(pathwayName.ToString());

                        for (int i = 0; i < measuredVals4Validation.Count(); i++)
                        {
                            valid_k1.Add(IsWithinUncertainty(
                            uncFactor: uncFactor,
                            uncOffset: uncOffset,
                            measured: measuredVals4Validation[i],
                            predicted: predictedVals4Validation[i]
                            ));
                        }
                        for (int i = 0; i < measuredVals4Validation.Count(); i++)
                        {
                            valid_k2.Add(IsWithinUncertainty(
                            uncFactor: uncFactor * 2,
                            uncOffset: uncOffset,
                            measured: measuredVals4Validation[i],
                            predicted: predictedVals4Validation[i]
                            ));
                        }
                        TF_index.Add(TFi);
                        rate_k1.Add(Convert.ToDouble(valid_k1.Where(c => c).Count()) / valid_k1.Count());
                        rate_k2.Add(Convert.ToDouble(valid_k2.Where(c => c).Count()) / valid_k2.Count());
                        pass.Add(Convert.ToDouble(valid_k1.Where(c => c).Count()) / valid_k1.Count() >= 0.68 && Convert.ToDouble(valid_k2.Where(c => c).Count()) / valid_k2.Count() >= 0.95);
                        //calculate the overall slope of trendline
                        var As = CreateMatrix.DenseOfColumns(new IEnumerable<double>[] { predictedVals4Validation });
                        var Bs = CreateVector.DenseOfEnumerable(measuredVals4Validation);
                        var Xs = As.QR().Solve(Bs); // As*Xs = Bs
                        trend.Add(Xs[0]);
                        //calculate slope error
                        double error = 0;
                        double denom = 0;
                        int num4valid = predictedVals4Validation.Count();
                        for (int i = 0; i < num4valid; i++)
                        {
                            error += Math.Pow(measuredVals4Validation[i] - predictedVals4Validation[i] * Xs[0], 2);
                            denom += Math.Pow(predictedVals4Validation.Average() - predictedVals4Validation[i], 2);
                        }
                        slope_error.Add(Math.Sqrt(error / denom / (num4valid - 2)));
                        ;
                    }
                }
            }





            //
            

            
            if(Auto_V.Checked)
            {
                //built the struct for opt file outputing
                for (int i = 0; i < index.Count(); i++)
                {
                    var cd = new opt();
                    cd.index_opt = index[i];
                    cd.k1_opt = rate_k1[i];
                    cd.k2_opt = rate_k2[i];
                    cd.pass_opt = pass[i];
                    cd.trend_opt = trend[i];
                    cd.valid_scale_opt = valid_scale[i];
                    cd.scale_fac_opt = scalingFac[i];
                    cd.slope_error = slope_error[i];
                    cd.TF_i = TF_index[i];
                    opt_output.Add(cd);
                }
                ///filt k1
                for (int i = opt_output.Count() - 1; i >= 0; i--)
                {
                    if (!opt_output[i].pass_opt)
                    {
                        opt_output.RemoveAt(i);
                    }
                }
                if (opt_output.Count == 0)
                {
                    MessageBox.Show(this, "TF cannot be validated with the selected pathways",
                    "No solution",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var opt_sort = opt_output;

                if (radioK1Rate.Checked)
                {
                    opt_sort = opt_output.OrderByDescending(s => s.k1_opt).ToList();
                }
                else if (radioScaleFactor.Checked)
                {
                    opt_sort = opt_output.OrderBy(s => s.scale_fac_opt).ToList();
                }
                else if (radioTrendSlope.Checked)
                {
                    opt_sort = opt_output.OrderBy(s => Math.Abs(s.trend_opt - 1)).ToList();
                }
                double opt_slope = opt_sort[0].scale_fac_opt;
                string[] pathwaysScale = opt_sort[0].index_opt.Split();
                List<string> pathwayOut = pathwayVals.ToList();

                //++++++++++++++++++++++++++++++++++++++++++++++++++++++
                List<double> predictedValsOpt = new List<double>();
                ETans.Clear();
                measuredVals.Clear();
                foreach (ETan etanRow in ETanFilesListBox.Items)
                {
                    foreach (MeasSummary.SummaryRow sumrow in etanRow.summrow)
                    {
                        if (etanRow.summrow == null ||
                        (VoltageMode && Double.IsNaN(sumrow.PeakHeaderVoltage)) ||
                        (!VoltageMode && Double.IsNaN(sumrow.MeasuredTemperature))
                        )
                        {
                            numSkipped++;
                            continue;
                        }
                        var scaledEtanRms = etanRow.rms.Multiply(sumrow.ETanScalingFactor);
                        if (sumrow.Conjugate)
                            scaledEtanRms = scaledEtanRms.Conjugate();


                        if (VoltageMode && !Double.IsNaN(sumrow.CrestFactor))
                            scaledEtanRms = scaledEtanRms.Multiply(sumrow.CrestFactor);

                        double Z = DataProcessing.TFInt(
                            ETan_Z: etanRow.z, ETan_RMS: scaledEtanRms,
                            TF_Z: TFs[opt_sort[0].TF_i].zz, TF_Sr: TFs[opt_sort[0].TF_i].Srr);

                        if (VoltageMode)
                            Z = Math.Sqrt(Z);

                        ETans.Add(etanRow);
                        double measuredVal;
                        if (VoltageMode)
                            measuredVal = sumrow.PeakHeaderVoltage;
                        else
                            measuredVal = sumrow.MeasuredTemperature;
                        double etanScaleFacRow = sumrow.ETanScalingFactor;
                        measuredVals.Add(measuredVal);
                        predictedValsOpt.Add(Z);
                    }

                }
                List<double> predictOut = predictedValsOpt.ToList();
                for (int i = 0; i < predictOut.Count(); i++)
                {
                    predictOut[i] = predictOut[i] * opt_slope;
                }
                List<double> measureOut = measuredVals.ToList();
                List<double> etanScaleOut = etanScaleFac.ToList();
                List<bool> validVals_k1_out = new List<bool>();
                List<bool> validVals_k2_out = new List<bool>();
                List<ETan> EtansOut = ETans.ToList();

                //sort pathways for scale
                List<String> pathwaysScaleSort = pathwaysScale.ToList();
                pathwaysScaleSort.RemoveAt(pathwaysScaleSort.Count - 1);
                //List<int> order = new List<int>();
                List<opt_sort> optsort = new List<opt_sort>();
                foreach (string path in pathwaysScaleSort)
                {
                    var cd = new opt_sort();
                    cd.pathway = path;
                    cd.order = pathwayVals.FindIndex(x => x.Equals(path));
                    //order.Add(pathwayVals.FindIndex(x => x.Equals(path)));
                    optsort.Add(cd);
                }
                optsort = optsort.OrderBy(s => s.order).ToList();
                for (int i = 0; i < optsort.Count; i++)
                {
                    pathwaysScaleSort[i] = optsort[i].pathway;
                }
                for (int i = pathwaysScale.Count() - 2; i >= 0; i--)
                {
                    //int k = pathwayVals.FindIndex(x => x.Equals(pathwaysScaleSort[i]));
                    var kk = Enumerable.Range(0, pathwayVals.Count).Where(ii => pathwayVals[ii] == pathwaysScaleSort[i]).ToList();
                    kk.Reverse();
                    foreach (int k in kk)
                    {
                        if (k > 0)
                        {
                            pathwayOut.RemoveAt(k);
                            predictOut.RemoveAt(k);
                            measureOut.RemoveAt(k);
                            etanScaleOut.RemoveAt(k);
                            EtansOut.RemoveAt(k);
                        }
                    }


                }
                for (int i = 0; i < pathwayOut.Count(); i++)
                {
                    validVals_k1_out.Add(IsWithinUncertainty(
                    uncFactor: uncFactor,
                    uncOffset: uncOffset,
                    measured: measureOut[i],
                    predicted: predictOut[i]
                    ));
                    validVals_k2_out.Add(IsWithinUncertainty(
                    uncFactor: uncFactor * 2,
                    uncOffset: uncOffset,
                    measured: measureOut[i],
                    predicted: predictOut[i]
                    ));
                }

                if (saveOptFileCheckbox.Checked)
                    //SaveScaleOptTable(index, rate_k1,rate_k2, pass, trend, valid_scale,scalingFac);
                    SaveScaleOptTable(opt_sort);
                if (saveOPTTFcheckBox.Checked)
                    SaveScaledTF(TFs[opt_sort[0].TF_i],opt_sort[0], VoltageMode);

                if (saveSummaryFileCheckbox.Checked)
                    SaveSummaryTable(EtansOut, predictOut, measureOut, etanScaleOut, validVals_k1_out, validVals_k2_out);
                bool overallValid = Convert.ToSingle(validVals_k1_out.Where(c => c).Count()) / validVals_k1_out.Count() >= 0.68 && Convert.ToSingle(validVals_k2_out.Where(c => c).Count()) / validVals_k2_out.Count() >= 0.95;
                TFFitPlotForm tffpf = new TFFitPlotForm();

                tffpf.AddData(
                    predicted: predictOut,
                    measured: measureOut,
                    varName: VoltageMode ? "V" : "dT",
                    title: TransferFunctionFilenameLabel.Text + " scaled with " +
                    opt_sort[0].index_opt + ": " +
                    (overallValid ? "VALID" : "NOT VALID")
                    );
                tffpf.AddFit(1 + uncFactor, uncOffset, overallValid ? Color.Blue : Color.Red);
                tffpf.AddFit(1 - uncFactor, -uncOffset, overallValid ? Color.Blue : Color.Red);
                tffpf.AddFit(1 + uncFactor * 2, uncOffset, overallValid ? Color.Blue : Color.Red);
                tffpf.AddFit(1 - uncFactor * 2, -uncOffset, overallValid ? Color.Blue : Color.Red);



                tffpf.Show(this);
                //normalize phase plot?
                //plot
                TFComparisonForm tfTestPlot = new TFComparisonForm(
                    new string[] { "Adjusted TF"+" "+ opt_sort[0].TF_i.ToString(), "original TF" },
                    new Vector<double>[] { TFs[opt_sort[0].TF_i].zz,TFz },
                    new Vector<Complex>[] { TFs[opt_sort[0].TF_i].Srr,TFSr }
                   
                    );
                tfTestPlot.Show(this);
            }
                
                
                
            
            else {
                // Save things
                
                if (saveSummaryFileCheckbox.Checked)
                    SaveSummaryTable(ETans, predictedVals, measuredVals, etanScaleFac, validVals_k1, validVals_k2);
                //bool overallValid = !validVals.Contains(false);
                //validVals.Where(c => c).Count()
                //modify the validation criteria - JiangR02
                bool overallValid = Convert.ToSingle(validVals_k1.Where(c => c).Count()) / validVals_k1.Count() >= 0.68 && Convert.ToSingle(validVals_k2.Where(c => c).Count()) / validVals_k2.Count() >= 0.95;
                TFFitPlotForm tffpf = new TFFitPlotForm();

                tffpf.AddData(
                    predicted: predictedVals,
                    measured: measuredVals,
                    varName: VoltageMode ? "V" : "dT",
                    title: TransferFunctionFilenameLabel.Text + ": " +
                    (overallValid ? "VALID" : "NOT VALID")
                    );
                tffpf.AddFit(1 + uncFactor, uncOffset, overallValid ? Color.Blue : Color.Red);
                tffpf.AddFit(1 - uncFactor, -uncOffset, overallValid ? Color.Blue : Color.Red);
                tffpf.AddFit(1 + uncFactor * 2, uncOffset, overallValid ? Color.Blue : Color.Red);
                tffpf.AddFit(1 - uncFactor * 2, -uncOffset, overallValid ? Color.Blue : Color.Red);


                
                tffpf.Show(this);

                // Series plot
                //     First sort data
                var pairs = predictedVals.Zip(measuredVals);
                var pathwayList = pathwayVals.Zip(pairs);
                pathwayList = pathwayList.OrderBy(x => x.Item1, new NaturalSortComparer<string>());
                //     And then plot
                tffpf = new TFFitPlotForm();
                tffpf.ConfigurePathwaySeries(TransferFunctionFilenameLabel.Text,
                    xaxisLabel: "Pathway",
                    yaxisLabel: VoltageMode ? "V" : "dT",
                    xaxisText: pathwayList.Select(x => x.Item1).ToArray()
                    );
                tffpf.AddPathwaySeries(
                    "Predicted", pathwayList.Select(x => x.Item2.Item1).ToArray(), Color.Black);
                tffpf.AddPathwaySeries(
                                "Measured", pathwayList.Select(x => x.Item2.Item2).ToArray(), Color.Red);
                tffpf.Show();

                
            }


        }
        protected void SaveSummaryTable(
            List<ETan> etanRows,
            List<double> predictedVals,
            List<double> measuredVals,
            List<double> etanScaleFac,
            List<bool> validVals_k1,
            List<bool> validVals_k2
            )
        {
            string[] headers = new string[] {
                "", // iterator column
                "Pathway",
                "TF Predicted " + (VoltageMode? "Peak Header Voltage" : "Temperature"),
                "Measured " + (VoltageMode? "Peak Header Voltage" : "Temperature"),
                "Etan Scaling Factor",
                "Validation_k1",
                "Validation_k2",
                "% Error"
            };
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Raw Neuro Header Voltage Data Files";
            sfd.Filter = "XLSX (*.xlsx)|*.xlsx|CSV (*.csv)|*.csv|All Files (*.*)|*.*";
            sfd.Title = "Select output scaling calculation summaryfile...";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (sfd.FileName.EndsWith(".csv"))
            {
                using (var sw = new StreamWriter(sfd.OpenFile()))
                {
                    int i = 0;
                    sw.WriteLineAsync(String.Join(",", headers));
                    foreach (var row in etanRows.Zip(predictedVals).Zip(validVals_k1))
                    {
                        foreach (MeasSummary.SummaryRow sumrow in row.Item1.Item1.summrow)
                        {
                            sw.WriteLineAsync(String.Join(",", new string[] {
                            i.ToString(), // iterator
                            row.Item1.Item1.PathWay, // pathway
                            row.Item1.Item2.ToString(), // predicted voltage
                            (VoltageMode?
                            sumrow.PeakHeaderVoltage :
                            sumrow.MeasuredTemperature).ToString(),
                            sumrow.ETanScalingFactor.ToString(),
                            row.Item2 ? "Yes" : "No"
                        }));
                            i++;

                        }
                            
                    }
                }
            }
            else
            {
                FileInfo newFile = new FileInfo(sfd.FileName);
                
                if (newFile.Exists)
                {
                    FileStream stream = null;
                    try
                    {
                        stream = newFile.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("file is in use, cannot save summary file");
                        return;
                    }
                    stream.Close();
                    newFile.Delete();
                    newFile = new FileInfo(sfd.FileName);
                }
                using (ExcelPackage package = new ExcelPackage())
                {
                    var ws = package.Workbook.Worksheets.Add("Sheet1");
                    for (int i = 0; i < headers.Length; i++)
                    {
                        ws.Cells[1, i + 1].Value = headers[i];
                        ws.Cells[1, i + 1].Style.Font.Bold = true;
                    }
                    for (int i = 0; i < etanRows.Count; i++)
                    {
                        ws.Cells[i + 2, 1].Value = i; // iterator
                        ws.Cells[i + 2, 1].Style.Font.Bold = true;
                        ws.Cells[i + 2, 2].Value = etanRows[i].PathWay;

                        ws.Cells[i + 2, 3].Value = predictedVals[i];
                        //ws.Cells[i + 2, 4].Value = VoltageMode ?
                        //    etanRows[i].summrow.PeakHeaderVoltage :
                        //    etanRows[i].summrow.MeasuredTemperature;
                        ws.Cells[i + 2, 4].Value = measuredVals[i];
                        //ws.Cells[i + 2, 5].Value = etanRows[i].summrow.ETanScalingFactor;
                        ws.Cells[i + 2, 5].Value = etanScaleFac[i];
                        ws.Cells[i + 2, 6].Value = validVals_k1[i] ? "Yes" : "No";
                        ws.Cells[i + 2, 7].Value = validVals_k2[i] ? "Yes" : "No";
                        //ws.Cells[i + 2, 8].Value = (measuredVals[i] - predictedVals[i]) / predictedVals[i] * 100;
                        ws.Cells[i + 2, 8].Formula = "=(C" + (i + 2).ToString() + "-D" + (i + 2).ToString() + ")/C" + (i + 2).ToString();
                        ws.Cells[i + 2, 8].Style.Numberformat.Format= "0.00%";
                    }
                    ws.Cells[ws.Dimension.Address].AutoFitColumns();
                    package.SaveAs(newFile);
                }

            }
        }

        protected void SaveScaleOptTable(List<opt> opt_output)
        {
            string[] headers = new string[] {
                "", // iterator column
                "Pathways",
                "K1 Validate rate",
                "K2 Validate rate",
                "Validation",
                "Trendline Slope",
                "Valid Scale Process",
                "Scale Factor",
                "Slope error"
            };
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XLSX (*.xlsx)|*.xlsx|CSV (*.csv)|*.csv|All Files (*.*)|*.*";
            sfd.Title = "Select output scaling optimization summaryfile...";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            FileInfo newFile = new FileInfo(sfd.FileName);
            
            if (newFile.Exists)
            {
                FileStream stream = null;
                try
                {
                    stream = newFile.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                }
                catch (IOException)
                {
                    MessageBox.Show("file is in use, cannot save summary file");
                    return;
                }
                stream.Close();
                newFile.Delete();
                newFile = new FileInfo(sfd.FileName);
            }
            using (ExcelPackage package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Sheet1");
                for (int i = 0; i < headers.Length; i++)
                {
                    ws.Cells[1, i + 1].Value = headers[i];
                    ws.Cells[1, i + 1].Style.Font.Bold = true;
                }
                for (int i = 0; i < opt_output.Count; i++)
                {
                    ws.Cells[i + 2, 1].Value = i+1; // iterator
                    ws.Cells[i + 2, 1].Style.Font.Bold = true;
                    ws.Cells[i + 2, 2].Value = opt_output[i].index_opt.ToString()+"TF"+" "+opt_output[i].TF_i.ToString();
                    
                    ws.Cells[i + 2, 3].Value = opt_output[i].k1_opt;
                    ws.Cells[i + 2, 4].Value = opt_output[i].k2_opt;
                    ws.Cells[i + 2, 5].Value = opt_output[i].pass_opt;
                    ws.Cells[i + 2, 6].Value = opt_output[i].trend_opt;
                    ws.Cells[i + 2, 7].Value = opt_output[i].valid_scale_opt;
                    ws.Cells[i + 2, 8].Value = opt_output[i].scale_fac_opt;
                    ws.Cells[i + 2, 9].Value = opt_output[i].slope_error*100;
                    
                    ws.Cells[i + 2, 9].Style.Numberformat.Format = "#0\\.00%";
                }
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                package.SaveAs(newFile);
            }
        }

        public static IEnumerable<int[]> Combinations(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < n)
                {
                    result[index++] = ++value;
                    stack.Push(value);

                    if (index == m)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }

        private void ETanFilesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddEtanFilesForScale_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Input Etan mat files";
            ofd.Filter = "Matlab MAT (*.mat)|*.mat|All Files (*.*)|*.*";
            ofd.Title = "Select Etan files...";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() != DialogResult.OK)
                return;
            if (ofd.FileNames.Length == 0)
            {
                MessageBox.Show(this, "No files selected", "TF Reading Error");
                return;
            }
            try
            {
                List<ETan> newETanData = new List<ETan>();
                foreach (string f in ofd.FileNames)
                {
                    ETan etan = new ETan(f);
                    newETanData.Add(etan);
                }
                foreach (ETan x in EtanFileListForScaling.Items)
                {
                    newETanData.RemoveAll(y => y.filename == x.filename);
                }
                EtanFileListForScaling.Items.AddRange(newETanData.ToArray());
                RefreshSummaryRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "TF File could not be opened!\n\n" + ex.Message,
                    "Error loading TF file",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            label4.Text="out of "+ EtanFileListForScaling.Items.Count.ToString() + " pathways for scaling";
            
        }

        private void Remove2_Click(object sender, EventArgs e)
        {
            while (EtanFileListForScaling.SelectedItems.Count > 0)
                EtanFileListForScaling.Items.RemoveAt(EtanFileListForScaling.SelectedIndices[0]);
            label4.Text = "out of " + EtanFileListForScaling.Items.Count.ToString() + " pathways for scaling";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Manual_V_CheckedChanged(object sender, EventArgs e)
        {
            if (Manual_V.Checked)
            {
                EtanFileListForScaling.Enabled = false;
                AddEtanFilesForScale.Enabled = false;
                Remove2.Enabled = false;
                saveOptFileCheckbox.Checked = false;
                saveOptFileCheckbox.Enabled = false;
                saveOPTTFcheckBox.Checked = false;
                saveOPTTFcheckBox.Enabled = false;
                label4.Enabled = false;
                numPathways.Enabled = false;
                radioK1Rate.Enabled = false;
                radioScaleFactor.Enabled = false;
                radioTrendSlope.Enabled = false;
                clearScaleEtanButton.Enabled = false;
            }
            else
            {
                EtanFileListForScaling.Enabled = true;
                AddEtanFilesForScale.Enabled = true;
                Remove2.Enabled = true;
                saveOptFileCheckbox.Checked = true;
                saveOptFileCheckbox.Enabled = true;
                saveOPTTFcheckBox.Checked = true;
                saveOPTTFcheckBox.Enabled = true;
                label4.Enabled = true;
                numPathways.Enabled = true;
                radioK1Rate.Enabled = true;
                radioScaleFactor.Enabled = true;
                radioTrendSlope.Enabled = true;
                clearScaleEtanButton.Enabled = true;
            }
        }

        private void Auto_V_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        protected void SaveScaledTF(TF_pack TFs,opt opt_sort, bool Vmode)
        {
            double TFScaleFactor = Vmode ? opt_sort.scale_fac_opt : Math.Sqrt(opt_sort.scale_fac_opt);
            //var TFSrScaled = TFSr.Multiply(TFScaleFactor);
            var TFSrScaled = TFs.Srr.Multiply(TFScaleFactor);
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.InitialDirectory = @"C:\Users\ConraN01\Documents\Spyder_WS\MRI_RF_TF_Tool_Project\Test Files for Python Utility\Raw Neuro Header Voltage Data Files";
            sfd.Filter = "MAT (*.mat)|*.mat|All Files (*.*)|*.*";
            sfd.Title = "Select output scaled TF file...";
            sfd.FileName = Path.GetFileNameWithoutExtension(TFFileFullPath) + "_scaledBy_"+opt_sort.index_opt.Replace(" ","")+".mat";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var Z = CreateMatrix.DenseOfColumns(new IEnumerable<double>[] { TFz });
            var Sr = CreateMatrix.DenseOfColumnVectors(new Vector<Complex>[] { TFSrScaled });

            var matrices = new List<MatlabMatrix>();
            matrices.Add(MatlabWriter.Pack(Z, "z"));
            matrices.Add(MatlabWriter.Pack(Sr, "Sr"));
            MatlabWriter.Store(sfd.FileName, matrices);
        }

        private void clearEtanButton_Click(object sender, EventArgs e)
        {
            ETanFilesListBox.Items.Clear();
        }

        private void clearScaleEtanButton_Click(object sender, EventArgs e)
        {
            EtanFileListForScaling.Items.Clear();
        }

        private void voltageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            meassum = null;
            summaryFilenameLabel.Text = "";
        }
        public Func<double, double> MakeInterpolator(IEnumerable<double> x, IEnumerable<double> y)
        {

            SplineBoundaryCondition bc;
            int xlength = x.Count();
            int mode = 2;
            
                int order;
                order = mode * 2 + 1; // linear => 1; cubic => 3
                int npoints=8;
                var leftInterp = Fit.PolynomialFunc(x.Take(npoints).ToArray(), y.Take(npoints).ToArray(),
                    order);
                var rightInterp = Fit.PolynomialFunc(x.Reverse().Take(npoints).Reverse().ToArray(),
                    y.Reverse().Take(npoints).Reverse().ToArray(),
                    order);
                double middlex = x.Skip((int)(xlength / 2)).First();
                return (x2 => (x2 < middlex) ? leftInterp(x2) : rightInterp(x2));
            
        }

        private void offsetP_TextChanged(object sender, EventArgs e)
        {

        }

        private void TFAutoAdj_CheckedChanged(object sender, EventArgs e)
        {
            if(TFAutoAdj.Checked)
            {
                Manual_V.Checked = false;
                Auto_V.Checked = true;
                Manual_V.Enabled = false;
                TFAdjPanel.Enabled=true;
            }
            else
            {
                Manual_V.Enabled = true;
                TFAdjPanel.Enabled = false;
            }
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
    
}
