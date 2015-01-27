using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensions
{
    public static class MathI
    {
        public static int Median(this IList<int> intValues) {
            if (intValues.Count == 0)
                throw new ArgumentException("Supplied list is empty, median is not defined.");

            List<int> sortedValues = intValues.OrderBy(v => v).ToList();
            int median = sortedValues[intValues.Count/2];
            return median;
        }
    }
}
