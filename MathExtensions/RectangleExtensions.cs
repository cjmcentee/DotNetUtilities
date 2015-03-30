using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MathExtensions
{
    public static class RectangleExtensions
    {
        // The rectangle structure is copied on method invocation, these extension methods cannot modify the source rectangle

        public static Rectangle NewByCenterSize(Point center, Size size) {
            Size extents = size.Divide(2);
            Point topLeft = center - extents;
            return new Rectangle(topLeft, size);
        }

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

        public static Rectangle InflateToContain(this Rectangle self, params Point[] points)
        {
            foreach (Point point in points) {

                if (point.X < self.Left) {
                    self.Width = self.Right - point.X;
                    self.X = point.X;
                }
                else if (point.X > self.Right)
                    self.Width = self.Width + point.X - self.Right;

                if (point.Y < self.Top) {
                    self.Height = self.Bottom - point.Y;
                    self.Y = point.Y;
                }
                else if (point.Y > self.Bottom)
                    self.Height = self.Height + point.Y - self.Bottom;
            }

            return self;
        }

        public static Rectangle InflateToContain(this Rectangle self, Rectangle containedRectangle) {
            self = self.InflateToContain(containedRectangle.TopLeft(), containedRectangle.TopRight(), containedRectangle.BottomRight(), containedRectangle.BottomLeft());
            return self;
        }

        public static Rectangle InflateToContain(this Rectangle self, IEnumerable<Rectangle> containedRectangles) {
            foreach (Rectangle containedRectangle in containedRectangles) {
                self = self.InflateToContain(containedRectangle);
            }

            return self;
        }

        public static Rectangle IntersectWith(this Rectangle rect1, Rectangle rect) {
            rect.Intersect(rect1);
            return rect;
        }


        public static Rectangle SetLeftSide(this Rectangle rectangle, int newLeft)
        {
            int newWidth = rectangle.Right - newLeft;
            
            rectangle.X = newLeft;
            rectangle.Width = newWidth;

            return rectangle;
        }

        public static Rectangle SetRightSide(this Rectangle rectangle, int newRight)
        {
            int newWidth = newRight - rectangle.Left;

            rectangle.Width = newWidth;

            return rectangle;
        }

        public static Rectangle SetTopSide(this Rectangle rectangle, int newTop)
        {
            int newHeight = rectangle.Bottom - newTop;

            rectangle.Y = newTop;
            rectangle.Height = newHeight;

            return rectangle;
        }

        public static Rectangle SetBottomSide(this Rectangle rectangle, int newBottom)
        {
            int newHeight = newBottom - rectangle.Top;

            rectangle.Height = newHeight;

            return rectangle;
        }

        public static Rectangle MoveLeftSide(this Rectangle rectangle, int moveDistance)
        {
            return rectangle.SetLeftSide(rectangle.Left + moveDistance);
        }

        public static Rectangle MoveRightSide(this Rectangle rectangle, int moveDistance)
        {
            return rectangle.SetRightSide(rectangle.Right + moveDistance);
        }

        public static Rectangle MoveTopSide(this Rectangle rectangle, int moveDistance)
        {
            return rectangle.SetTopSide(rectangle.Top + moveDistance);
        }

        public static Rectangle MoveBottomSide(this Rectangle rectangle, int moveDistance)
        {
            return rectangle.SetBottomSide(rectangle.Bottom + moveDistance);
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

        public static Rectangle OffsetBy(this Rectangle rectangle, Point offset) {
            return new Rectangle(
                new Point(rectangle.X + offset.X, rectangle.Y + offset.Y),
                rectangle.Size);
        }

        public static Point Center(this Rectangle rectangle)
        {
            return new Point(
                rectangle.X + rectangle.Width / 2,
                rectangle.Y + rectangle.Height / 2);
        }

        public static PointF CenterF(this Rectangle rectangle)
        {
            return new PointF(
                rectangle.X + (float)rectangle.Width / 2,
                rectangle.Y + (float)rectangle.Height / 2);
        }

        public static Rectangle Copy(this Rectangle rectangle)
        {
            // value type semantics means the copy was made at the function call
            return rectangle;
        }

        public static RectangleF SelectSubRectangleF(this Rectangle rectangle, int numberRows, int numberColumns, int row, int column) {
            float subRectWidth  = (float) rectangle.Width / numberColumns;
            float subRectHeight = (float) rectangle.Height / numberRows;

            PointF subRectTopLeft = new PointF(
                rectangle.TopLeft().X + column * subRectWidth,
                rectangle.TopLeft().Y +    row * subRectHeight
            );
            SizeF subRectSize = new SizeF(subRectWidth, subRectHeight);
            return new RectangleF(subRectTopLeft, subRectSize);
        }

        public static RectangleF SelectSubRectangleF(this Rectangle rectangle, GridLocation gridLoc) {
            return rectangle.SelectSubRectangleF(gridLoc.NumberRows, gridLoc.NumberColumns, gridLoc.CurrentRow, gridLoc.CurrentColumn);
        }

        public static Rectangle SelectSubRectangle(this Rectangle rectangle, int numberRows, int numberColumns, int row, int column) {
            int subRectWidth  = rectangle.Width / numberColumns;
            int subRectHeight = rectangle.Height / numberRows;

            Point subRectTopLeft = new Point(
                rectangle.TopLeft().X + column * subRectWidth,
                rectangle.TopLeft().Y +    row * subRectHeight
            );
            Size subRectSize = new Size(subRectWidth, subRectHeight);
            return new Rectangle(subRectTopLeft, subRectSize);
        }

        public static Rectangle SelectSubRectangle(this Rectangle rectangle, GridLocation gridLoc) {
            return rectangle.SelectSubRectangle(gridLoc.NumberRows, gridLoc.NumberColumns, gridLoc.CurrentRow, gridLoc.CurrentColumn);
        }
    }
}
