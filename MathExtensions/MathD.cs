using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensions
{
    public static class MathD
    {
        public static double Clamp(double value, double min, double max)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            else
                return value;
        }

        public static double Average(params double[] values) {
            double average = 0;
            foreach (double value in values)
                average += value;
            return average / values.Length;
        }
    }
}
