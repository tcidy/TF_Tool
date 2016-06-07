using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

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
    }
}
