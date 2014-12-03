using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensions
{
    public static class PointExtension
    {
        public static Point MapPoint(this Point point, Rectangle domain, Rectangle range)
        {
            double x_scaled = (double) (point.X - domain.Left) / (double)domain.Width;
            double y_scaled = (double) (point.Y - domain.Top) / (double)domain.Height;

            int x_range = (int) Math.Round(x_scaled*range.Width) + range.Left;
            int y_range = (int) Math.Round(y_scaled*range.Height) + range.Top;

            return new Point(x_range, y_range);
        }

        public static Direction RelativeTo(this Point point1, Point point2)
        {
            return new Direction(point1.X - point2.X, point1.Y - point2.Y);
        }
    }
}
