using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensions
{
    public static class SizeExtensions
    {
        public static Size Divide(this Size s, int dividend) {
            Size quotient = new Size(s.Width/dividend, s.Height/dividend);
            return quotient;
        }

        public static Size Multiply(this Size s, int multiplicand) {
            Size product = new Size(s.Width * multiplicand, s.Height * multiplicand);
            return product;
        }

        public static Size Multiply(this Size s, float multiplicand) {
            Size product = new Size((int)(s.Width * multiplicand), (int)(s.Height * multiplicand));
            return product;
        }

        public static float Length(this Size s) {
            float length = (float) Math.Sqrt(Math.Pow(s.Width, 2) + Math.Pow(s.Height, 2));
            return length;
        }

        public static Size Average(params Size[] directions) {
            return Average(directions.ToList());
        }

        public static Size Average(IEnumerable<Size> directions) {
            int numberElements = 0;
            Size sum = new Size();

            foreach (var direction in directions) {
                sum += direction;
                numberElements += 1;
            }
            
            Size average = sum.Divide(numberElements);
            return average;
        }
    }
}
