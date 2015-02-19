using System;
using System.Drawing;

namespace MathExtensions
{
    public static class PointFExtensions
    {
        public static float DistanceFrom(this PointF point1, PointF point2) {
           return (float) Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        public static PointF RelativeTo(this PointF point1, PointF point2) {
            return new PointF(point1.X - point2.X, point1.Y - point2.Y);
        }

        public static float Length(this PointF point) {
            return point.DistanceFrom(new PointF(0, 0));
        }

        public static PointF MultiplyBy(this PointF point, float scalar) {
            return new PointF(point.X * scalar, point.Y * scalar);
        }

        public static Point ToPoint(this PointF self) {
            return new Point((int) self.X, (int) self.Y);
        }
    }
}
