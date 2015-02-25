using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MathExtensions
{
    public static class RectangleFExtensions
    {
        public static Rectangle ToRectangle(this RectangleF self) {
            return new Rectangle(self.TopLeft().ToPoint(), self.Size.ToSize());
        }

        public static RectangleF NewByCenterSize(PointF center, SizeF size) {
            SizeF extents = size.Divide(2);
            PointF topLeft = center - extents;
            return new RectangleF(topLeft, size);
        }

        public static bool ClosedContains(this RectangleF rectangle, float x, float y)
        {
            return x <= rectangle.Right
                && x >= rectangle.Left
                && y <= rectangle.Bottom
                && y >= rectangle.Top;
        }

        public static bool ClosedContains(this RectangleF rectangle, PointF point)
        {
            return rectangle.ClosedContains(point.X, point.Y);
        }

        public static bool ClosedContains(this RectangleF rectangle, params PointF[] points)
        {
            foreach (PointF point in points)
                if (!rectangle.ClosedContains(point))
                    return false;

            return true;
        }

        public static bool ClosedContains(this RectangleF rectangle, RectangleF subRectangle)
        {
            return rectangle.ClosedContains(new PointF[] {
                subRectangle.TopLeft(),
                subRectangle.TopRight(),
                subRectangle.BottomLeft(),
                subRectangle.BottomRight() });
        }

        public static RectangleF SurroundPoints(IEnumerable<PointF> points)
        {
            if (!points.Any())
                return new RectangleF();

            RectangleF containingRectangle = new RectangleF(points.First(), new SizeF());

            foreach (PointF point in points)
                containingRectangle = containingRectangle.InflateToContain(point);

            return containingRectangle;
        }

        public static RectangleF InflateToContain(this RectangleF rectangle, PointF point)
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

        public static RectangleF InflateToContain(this RectangleF rectangle, RectangleF containedRectangle)
        {
            if (rectangle.ClosedContains(containedRectangle))
                return rectangle;

            else {
                // The rectangle that contains each corner of another rectangle, contains the whole of that other rectangle
                PointF topLeft = new PointF(containedRectangle.Left, containedRectangle.Top);
                PointF topRight = new PointF(containedRectangle.Right, containedRectangle.Top);
                PointF bottomRight = new PointF(containedRectangle.Right, containedRectangle.Bottom);
                PointF bottomLeft = new PointF(containedRectangle.Left, containedRectangle.Bottom);

                rectangle = rectangle.InflateToContain(topLeft);
                rectangle = rectangle.InflateToContain(topRight);
                rectangle = rectangle.InflateToContain(bottomRight);
                rectangle = rectangle.InflateToContain(bottomLeft);

                return rectangle;
            }
        }

        public static RectangleF IntersectWith(this RectangleF rect1, RectangleF rect) {
            rect.Intersect(rect1);
            return rect;
        }


        public static RectangleF SetLeftSide(this RectangleF rectangle, float newLeft)
        {
            float newWidth = rectangle.Right - newLeft;
            
            rectangle.X = newLeft;
            rectangle.Width = newWidth;

            return rectangle;
        }

        public static RectangleF SetRightSide(this RectangleF rectangle, float newRight)
        {
            float newWidth = newRight - rectangle.Left;

            rectangle.Width = newWidth;

            return rectangle;
        }

        public static RectangleF SetTopSide(this RectangleF rectangle, float newTop)
        {
            float newHeight = rectangle.Bottom - newTop;

            rectangle.Y = newTop;
            rectangle.Height = newHeight;

            return rectangle;
        }

        public static RectangleF SetBottomSide(this RectangleF rectangle, float newBottom)
        {
            float newHeight = newBottom - rectangle.Top;

            rectangle.Height = newHeight;

            return rectangle;
        }

        public static RectangleF MoveLeftSide(this RectangleF rectangle, float moveDistance)
        {
            return rectangle.SetLeftSide(rectangle.Left + moveDistance);
        }

        public static RectangleF MoveRightSide(this RectangleF rectangle, float moveDistance)
        {
            return rectangle.SetRightSide(rectangle.Right + moveDistance);
        }

        public static RectangleF MoveTopSide(this RectangleF rectangle, float moveDistance)
        {
            return rectangle.SetTopSide(rectangle.Top + moveDistance);
        }

        public static RectangleF MoveBottomSide(this RectangleF rectangle, float moveDistance)
        {
            return rectangle.SetBottomSide(rectangle.Bottom + moveDistance);
        }

        public static PointF TopLeft(this RectangleF rectangle)
        {
            return new PointF(rectangle.Left, rectangle.Top);
        }

        public static PointF TopRight(this RectangleF rectangle)
        {
            return new PointF(rectangle.Right, rectangle.Top);
        }

        public static PointF BottomLeft(this RectangleF rectangle)
        {
            return new PointF(rectangle.Left, rectangle.Bottom);
        }

        public static PointF BottomRight(this RectangleF rectangle)
        {
            return new PointF(rectangle.Right, rectangle.Bottom);
        }

        public static RectangleF OffsetBy(this RectangleF rectangle, PointF offset) {
            return new RectangleF(
                new PointF(rectangle.X + offset.X, rectangle.Y + offset.Y),
                rectangle.Size);
        }

        public static PointF Center(this RectangleF rectangle)
        {
            return new PointF(
                rectangle.X + rectangle.Width / 2,
                rectangle.Y + rectangle.Height / 2);
        }

        public static PointF CenterF(this RectangleF rectangle)
        {
            return new PointF(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2);
        }

        public static RectangleF Copy(this RectangleF rectangle)
        {
            // value type semantics means the copy was made at the function call
            return rectangle;
        }

        public static RectangleF SelectSubRectangleF(this RectangleF rectangle, int numberRows, int numberColumns, int row, int column) {
            float subRectWidth  = rectangle.Width / numberColumns;
            float subRectHeight = rectangle.Height / numberRows;

            PointF subRectTopLeft = new PointF(
                rectangle.TopLeft().X + column * subRectWidth,
                rectangle.TopLeft().Y +    row * subRectHeight
            );
            SizeF subRectSize = new SizeF(subRectWidth, subRectHeight);
            return new RectangleF(subRectTopLeft, subRectSize);
        }

        public static RectangleF SelectSubRectangleF(this RectangleF rectangle, GridLocation gridLoc) {
            return rectangle.SelectSubRectangleF(gridLoc.NumberRows, gridLoc.NumberColumns, gridLoc.CurrentRow, gridLoc.CurrentColumn);
        }

        public static RectangleF SelectSubRectangle(this RectangleF rectangle, int numberRows, int numberColumns, int row, int column) {
            float subRectWidth  = rectangle.Width / numberColumns;
            float subRectHeight = rectangle.Height / numberRows;

            PointF subRectTopLeft = new PointF(
                rectangle.TopLeft().X + column * subRectWidth,
                rectangle.TopLeft().Y +    row * subRectHeight
            );
            SizeF subRectSize = new SizeF(subRectWidth, subRectHeight);
            return new RectangleF(subRectTopLeft, subRectSize);
        }

        public static RectangleF SelectSubRectangle(this RectangleF rectangle, GridLocation gridLoc) {
            return rectangle.SelectSubRectangle(gridLoc.NumberRows, gridLoc.NumberColumns, gridLoc.CurrentRow, gridLoc.CurrentColumn);
        }
    }
}
