using System.Collections.Generic;
using System.Linq;

namespace MathExtensions
{
    public static class MathF
    {
        public static float Average(params float[] values) {
            return Average(values.ToList());
        }

        public static float Average(IEnumerable<float> values) {
            int numberElements = 0;
            float sum = 0;

            foreach (var value in values) {
                sum += value;
                numberElements += 1;
            }
            
            float average = sum / numberElements;
            return average;
        }
    }
}
