using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Statistics;

namespace MRI_RF_TF_Tool
{
    public static class MathUtils
    {

        public static IEnumerable<Tuple<TFirst, TSecond>> Zip<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second) {
            return first.Zip(second, (a, b) => Tuple.Create(a, b));
        }
        public static Vector<double> Unwrap(this Vector<double> v)
        {
            var r = v.Clone();
            double offset = 0;
            for (int i = 1; i < v.Count; i++)
            {
                if (v[i] > v[i - 1] + Math.PI)
                    offset = offset - 2 * Math.PI;
                if (v[i] < v[i - 1] - Math.PI)
                    offset = offset + 2 * Math.PI;
                r[i] += offset;
            }
            return r;
        }
        public static double SlopeUncertainty(double slope, IEnumerable<double> predicted, IEnumerable<double>  measured) {
            var meanvar = Statistics.MeanVariance(predicted);
            int count = predicted.Count();
            double mean = meanvar.Item1;
            double MSDpredicted = meanvar.Item2 * (count-1);
            var errorsSQ = measured.Zip(predicted).Select(x => x.Item1 - slope * x.Item2)
                .Select(x => x*x);
            var slopeUncertainty = Math.Sqrt(
                ((count / (count - 2) * Statistics.Mean(errorsSQ)) / (MSDpredicted))
                );
            return slopeUncertainty;
        }
    }
}
