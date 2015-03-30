using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensions
{
    public static class DirectionExtensions
    {
        public static Direction MapPoint(this Direction point, Rectangle domain, Rectangle range)
        {
            double x_scaled = (double)(point.X - domain.Left) / (double)domain.Width;
            double y_scaled = (double)(point.Y - domain.Top) / (double)domain.Height;

            int x_range = (int)Math.Round(x_scaled * range.Width) + range.Left;
            int y_range = (int)Math.Round(y_scaled * range.Height) + range.Top;

            return new Direction(x_range, y_range);
        }

        public static Direction Median(this List<Direction> directions)
        {
            if (directions.Count == 0)
                return new Direction();

            List<Tuple<Direction, double>> directionLengths = (
                from direction in directions
                orderby direction.Length ascending
                select new Tuple<Direction, double>(direction, direction.Length)).ToList();

            return directionLengths[directionLengths.Count / 2].Item1;
        }
    }
}
