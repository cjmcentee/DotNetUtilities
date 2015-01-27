using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensions
{
    public static class PointFExtensions
    {
        public static double DistanceFrom(this PointF point1, PointF point2) {
           return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        public static PointF RelativeTo(this PointF point1, PointF point2) {
            return new PointF(point1.X - point2.X, point1.Y - point2.Y);
        }
    }
}
