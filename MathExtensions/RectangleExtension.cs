using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensions
{
    public static class RectangleExtension
    {
        public static bool ClosedContains(this Rectangle rectangle, int x, int y)
        {
            return x <= rectangle.Right
                && x >= rectangle.Left
                && y <= rectangle.Bottom
                && y >= rectangle.Top;
        }

        public static bool ClosedContains(this Rectangle rectangle, Point point)
        {
            return rectangle.ClosedContains(point.X, point.Y);
        }

        public static bool ClosedContains(this Rectangle rectangle, params Point[] points)
        {
            foreach (Point point in points)
                if (!rectangle.ClosedContains(point))
                    return false;

            return true;
        }

        public static bool ClosedContains(this Rectangle rectangle, Rectangle subRectangle)
        {
            return rectangle.ClosedContains(new Point[] {
                subRectangle.TopLeft(),
                subRectangle.TopRight(),
                subRectangle.BottomLeft(),
                subRectangle.BottomRight() });
        }

        public static Rectangle SurroundPoints(IEnumerable<Point> points)
        {
            if (points.Count() == 0)
                return new Rectangle();

            Rectangle containingRectangle = new Rectangle(points.First(), new Size());

            foreach (Point point in points)
                containingRectangle = containingRectangle.InflateToContain(point);

            return containingRectangle;
        }

        public static Rectangle InflateToContain(this Rectangle rectangle, Point point)
        {
            if (point.X < rectangle.Left) {
                rectangle.Width = rectangle.Right - point.X;
                rectangle.X = point.X;
            }
            else if (point.X > rectangle.Right)
                rectangle.Width = rectangle.Width + point.X - rectangle.Right;

            if (point.Y < rectangle.Top) {
                rectangle.Height = rectangle.Bottom - point.Y;
                rectangle.Y = point.Y;
            }
            else if (point.Y > rectangle.Bottom)
                rectangle.Height = rectangle.Height + point.Y - rectangle.Bottom;

            return rectangle;
        }

        public static Rectangle InflateToContain(this Rectangle rectangle, Rectangle containedRectangle)
        {
            if (rectangle.ClosedContains(containedRectangle))
                return rectangle;

            else {
                // The rectangle that contains each corner of another rectangle, contains the whole of that other rectangle
                Point topLeft = new Point(containedRectangle.Left, containedRectangle.Top);
                Point topRight = new Point(containedRectangle.Right, containedRectangle.Top);
                Point bottomRight = new Point(containedRectangle.Right, containedRectangle.Bottom);
                Point bottomLeft = new Point(containedRectangle.Left, containedRectangle.Bottom);

                rectangle = rectangle.InflateToContain(topLeft);
                rectangle = rectangle.InflateToContain(topRight);
                rectangle = rectangle.InflateToContain(bottomRight);
                rectangle = rectangle.InflateToContain(bottomLeft);

                return rectangle;
            }
        }


        public static Rectangle SetLeft(this Rectangle rectangle, int newLeft)
        {
            int newWidth = rectangle.Right - newLeft;
            
            rectangle.X = newLeft;
            rectangle.Width = newWidth;

            return rectangle;
        }

        public static Rectangle SetRight(this Rectangle rectangle, int newRight)
        {
            int newWidth = newRight - rectangle.Left;

            rectangle.Width = newWidth;

            return rectangle;
        }

        public static Rectangle SetTop(this Rectangle rectangle, int newTop)
        {
            int newHeight = rectangle.Bottom - newTop;

            rectangle.Y = newTop;
            rectangle.Height = newHeight;

            return rectangle;
        }

        public static Rectangle SetBottom(this Rectangle rectangle, int newBottom)
        {
            int newHeight = newBottom - rectangle.Top;

            rectangle.Height = newHeight;

            return rectangle;
        }

        public static Rectangle MoveLeft(this Rectangle rectangle, int moveDistance)
        {
            return rectangle.SetLeft(rectangle.Left + moveDistance);
        }

        public static Rectangle MoveRight(this Rectangle rectangle, int moveDistance)
        {
            return rectangle.SetRight(rectangle.Right + moveDistance);
        }

        public static Rectangle MoveTop(this Rectangle rectangle, int moveDistance)
        {
            return rectangle.SetTop(rectangle.Top + moveDistance);
        }

        public static Rectangle MoveBottom(this Rectangle rectangle, int moveDistance)
        {
            return rectangle.SetBottom(rectangle.Bottom + moveDistance);
        }

        public static Point TopLeft(this Rectangle rectangle)
        {
            return new Point(rectangle.Left, rectangle.Top);
        }

        public static Point TopRight(this Rectangle rectangle)
        {
            return new Point(rectangle.Right, rectangle.Top);
        }

        public static Point BottomLeft(this Rectangle rectangle)
        {
            return new Point(rectangle.Left, rectangle.Bottom);
        }

        public static Point BottomRight(this Rectangle rectangle)
        {
            return new Point(rectangle.Right, rectangle.Bottom);
        }

        public static Point Center(this Rectangle rectangle)
        {
            return new Point(
                rectangle.X + rectangle.Width / 2,
                rectangle.Y + rectangle.Height / 2);
        }

        public static Rectangle Copy(this Rectangle rectangle)
        {
            // value type semantics means the copy was made at the function call
            return rectangle;
        }
    }
}
