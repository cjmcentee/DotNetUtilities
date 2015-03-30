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

        public static int Rotate(int min, int max, int value)
        {
            int value_min = value - min;
            int max_min = max - min;

            int value_range = value_min % max_min;
            if (value_range < 0)
                value_range += max_min;
            return value_range + min;
        }

        public static int Clamp(int min, int max, int value)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;

            return value;
        }
    }
}
