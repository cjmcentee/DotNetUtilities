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
        public PointF TopRight      { get { return TopLeft + RotateTransform(HorizontalSize, AngleRadians); } }
        public PointF BottomRight   { get { return TopLeft + RotateTransform(LocalSize,      AngleRadians); } }
        public PointF BottomLeft    { get { return TopLeft + RotateTransform(VerticalSize,   AngleRadians); } }

        public readonly double AngleRadians;
        public double AngleDegrees  { get { return AngleRadians * 360 / Math.PI; } }


        ////////////////////////////////////////////////
        //                  Constructors
        ////////////////////////////////////////////////
        public RotatedRectangle(PointF topLeftPoint, SizeF localSize, double angleRadians) {
            this.TopLeft = topLeftPoint;
            this.LocalSize = localSize;
            this.AngleRadians = angleRadians;
        }


        ////////////////////////////////////////////////
        //                  Methods
        ////////////////////////////////////////////////
        private static SizeF RotateTransform(SizeF direction, double angle) {
            return new SizeF(
                (float) (direction.Width * Math.Cos(angle) - direction.Height * Math.Sin(angle)),
                (float) (direction.Width * Math.Sin(angle) + direction.Height * Math.Cos(angle))
            );
        }
    }
}
