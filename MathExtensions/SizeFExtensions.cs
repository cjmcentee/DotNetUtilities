using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MathExtensions
{
    public static class SizeFExtensions
    {
        public static SizeF Divide(this SizeF s, float dividend) {
            SizeF quotient = new SizeF(s.Width/dividend, s.Height/dividend);
            return quotient;
        }

        public static SizeF Multiply(this SizeF s, float multiplicand) {
            SizeF product = new SizeF(s.Width * multiplicand, s.Height * multiplicand);
            return product;
        }

        public static float Length(this SizeF s) {
            float length = (float) Math.Sqrt(Math.Pow(s.Width, 2) + Math.Pow(s.Height, 2));
            return length;
        }

        public static SizeF Average(params SizeF[] directions) {
            return Average(directions.ToList());
        }

        public static SizeF Average(IEnumerable<SizeF> directions) {
            int numberElements = 0;
            SizeF sum = new SizeF();

            foreach (var direction in directions) {
                sum += direction;
                numberElements += 1;
            }
            
            SizeF average = sum.Divide(numberElements);
            return average;
        }
    }
}
