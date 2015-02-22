using System;
using System.Drawing;

namespace MathExtensions
{
    public class RotatedRectangle
    {
        ////////////////////////////////////////////////
        //                 Properties
        ////////////////////////////////////////////////
        public float LocalWidth     { get { return LocalSize.Width; } }
        public float LocalHeight    { get { return LocalSize.Height; } }
        
        public readonly SizeF  LocalSize;
        public SizeF VerticalSize   { get { return RotateTransform(new SizeF(0, LocalHeight), AngleRadians); } }
        public SizeF HorizontalSize { get { return RotateTransform(new SizeF(LocalWidth, 0),  AngleRadians); } }

        public readonly PointF TopLeft;
        /// Note: Does not generate the top right point correctly unless set by the top right point constructor
        /// I don't know why, but since right now I'm only using the top right point constructor, this will have to do
        /// Don't feel like troubleshooting the trig problems
        private PointF? topRight;
        public PointF TopRight      { get { return topRight.HasValue ? topRight.Value : TopLeft + RotateTransform(HorizontalSize, AngleRadians); } }
        public PointF BottomRight   { get { return TopLeft + RotateTransform(LocalSize,      AngleRadians); } }
        public PointF BottomLeft    { get { return TopLeft + RotateTransform(VerticalSize,   AngleRadians); } }

        public readonly double AngleRadians;
        public double AngleDegrees  { get { return AngleRadians * 180 / Math.PI; } }


        ////////////////////////////////////////////////
        //                  Constructors
        ////////////////////////////////////////////////
        public RotatedRectangle(PointF topLeftPoint, SizeF localSize, double angleRadians) {
            this.TopLeft = topLeftPoint;
            this.topRight = null;
            this.LocalSize = localSize;
            this.AngleRadians = angleRadians;
        }

        public RotatedRectangle(PointF topLeftPoint, PointF topRightPoint, float height_local) {
            this.TopLeft = topLeftPoint;
            this.topRight = topRightPoint;

            PointF topRight_topLeft = topRightPoint.RelativeTo(topLeftPoint);
            this.AngleRadians = Math.Atan2(topRight_topLeft.Y, topRight_topLeft.X);

            float width_local = topRight_topLeft.Length();
            this.LocalSize = new SizeF(width_local, height_local);
        }


        ////////////////////////////////////////////////
        //                  Methods
        ////////////////////////////////////////////////
        public PointF GetGridPoint(GridLocation location) {
            // Grid point relative to this rectangle
            float gridXPoint_this = this.LocalWidth  * location.CurrentColumn / (location.NumberColumns - 1); // numberX indexed from 1
            float gridYPoint_this = this.LocalHeight * location.CurrentRow    / (location.NumberRows - 1);    // currentX indexed from 0

            // Grid point relative to the space this rectangle is located in
            SizeF gridPoint_rotated = RotateTransform(new SizeF(gridXPoint_this, gridYPoint_this), this.AngleRadians);
            PointF gridPoint_world  = TopLeft + gridPoint_rotated;

            return gridPoint_world;
        }

        private static SizeF RotateTransform(SizeF direction, double angle) {
            return new SizeF(
                (float) (direction.Width * Math.Cos(angle) - direction.Height * Math.Sin(angle)),
                (float) (direction.Width * Math.Sin(angle) + direction.Height * Math.Cos(angle))
            );
        }
    }
}
