using System;
using System.Collections.Generic;
using System.Linq;

namespace MathExtensions
{
    public static class MathF
    {
        public const float EPSILON = 1e6F;

        public static bool NearlyEqual(float f1, float f2, float maxRelativeDifference=EPSILON) {
            float difference = Math.Abs(f1 - f2);
            float f1Abs = Math.Abs(f1);
            float f2Abs = Math.Abs(f2);
            float largest = Math.Max(f1Abs, f2Abs);

            if (difference <= maxRelativeDifference * largest)
                return true;
            else
                return false;
        }

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
