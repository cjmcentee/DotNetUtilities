using System;
using System.Drawing;

namespace MathExtensions
{
    public static class PointExtension
    {
public static Point MapPoint(this Point self, Rectangle domain, Rectangle range)
        {
            double x_scaled = (double) (self.X - domain.Left) / domain.Width;
            double y_scaled = (double) (self.Y - domain.Top) / domain.Height;

            int x_range = (int) Math.Round(x_scaled*range.Width) + range.Left;
            int y_range = (int) Math.Round(y_scaled*range.Height) + range.Top;

            return new Point(x_range, y_range);
        }

        public static Point RelativeTo(this Point self, Point point)
        {
            return new Point(self.X - point.X, self.Y - point.Y);
        }

        public static Point OffsetBy(this Point self, Point offset) {
            return new Point(self.X + offset.X, self.Y + offset.Y);
        }

        public static Point MultiplyBy(this Point self, float scalar) {
            return new Point((int)(self.X * scalar), (int)(self.Y * scalar));
        }

        public static Point Negate(this Point point) {
            return new Point(-point.X, -point.Y);
        }
    }
}
