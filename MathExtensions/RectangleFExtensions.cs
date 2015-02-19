using System.Drawing;

namespace MathExtensions
{
    public static class RectangleFExtensions
    {
        public static Rectangle ToRectangle(this RectangleF rectF) {
            return new Rectangle(
                new Point((int)rectF.Left,  (int)rectF.Top),
                new Size ((int)rectF.Width, (int)rectF.Height));
        }
    }
}
