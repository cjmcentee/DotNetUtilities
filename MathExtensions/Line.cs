using System;
using System.Drawing;

namespace MathExtensions
{
    public class Line
    {
        private PointF point;
        public float Slope      { get; private set; }
        public float yIntercept { get; private set; }

        public SizeF NormalizedDirection {
            get {
                if (this.LineIsVertical())
                    return new SizeF(0, 1);
                else {
                    SizeF direction = new SizeF(1, Slope);
                    return direction.Normalized();
                }
            }
        }

        public Line(PointF point, float slope) {
            this.point = point;
            this.Slope = slope;
            yIntercept = CalculateYIntercept(point, slope);
        }

        private static float CalculateYIntercept(PointF point, float slope) {
            return point.Y - slope*point.X;
        }

        public bool Intersects(Line line) {
            return ! MathF.NearlyEqual(this.Slope, line.Slope);
        }

        public PointF IntersectWith(Line line) {
            if ( ! this.Intersects(line))
                throw new ArgumentException("Lines with same slopes do not intersect");
            
            float x, y;

            if (this.LineIsVertical()) {
                x = this.point.X;
                y = line.YAt(x);
            }
            else if (line.LineIsVertical()) {
                x = line.point.X;
                y = this.YAt(x);
            }
            else {
                x = (line.yIntercept - this.yIntercept) / (this.Slope - line.Slope);
                y = this.Slope*x + this.yIntercept;
            }

            return new PointF(x, y);
        }

        public bool LineIsVertical() {
            return Single.IsInfinity(this.Slope);
        }

        public float YAt(float xCoordinate) {
            return Slope*xCoordinate + yIntercept;
        }

        public float XAt(float yCoordinate) {
            return (yCoordinate-Slope) / yIntercept;
        }
    }
}
