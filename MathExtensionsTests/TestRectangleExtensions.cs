using System.Drawing;
using MathExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathExtensionTests
{
    [TestClass]
    public class TestRectangleExtensions
    {
        [TestMethod]
        public void SurroundPoints_AllPointsContainedInSmallestPossibleRectangle()
        {
            Point[] points = new Point[] {
                new Point(0, 0),
                new Point(1, 1),
                new Point(0, 1) };

            Rectangle oneByOneSquare = RectangleExtensions.SurroundPoints(points);
            Assert.AreEqual(oneByOneSquare.Left, 0);
            Assert.AreEqual(oneByOneSquare.Right, 1);

            Assert.AreEqual(oneByOneSquare.Top, 0);
            Assert.AreEqual(oneByOneSquare.Bottom, 1);
        }

        [TestMethod]
        public void SurroundPoints_NoPointsGivesEmptyRectangle()
        {
            Point[] points = new Point[] { };

            Rectangle originPointRectangle = RectangleExtensions.SurroundPoints(points);
            Assert.AreEqual(originPointRectangle.Left, 0);
            Assert.AreEqual(originPointRectangle.Right, 0);

            Assert.AreEqual(originPointRectangle.Top, 0);
            Assert.AreEqual(originPointRectangle.Bottom, 0);
        }

        [TestMethod]
        public void ClosedContains_RectangleContainsBoundaryPoints()
        {
            Rectangle rect = new Rectangle(0, 0, 100, 100);
            Assert.IsTrue(rect.ClosedContains(0, 0));
            Assert.IsTrue(rect.ClosedContains(0, 100));
            Assert.IsTrue(rect.ClosedContains(100, 0));
            Assert.IsTrue(rect.ClosedContains(100, 100));

            Assert.IsFalse(rect.ClosedContains(-1, 0));
            Assert.IsFalse(rect.ClosedContains(0, -1));
            Assert.IsFalse(rect.ClosedContains(0, 101));
            Assert.IsFalse(rect.ClosedContains(-1, 100));
            Assert.IsFalse(rect.ClosedContains(101, 0));
            Assert.IsFalse(rect.ClosedContains(100, -1));
            Assert.IsFalse(rect.ClosedContains(101, 101));
        }

        [TestMethod]
        public void InflateToContain_RectangleModifiesSizeToContainPoint()
        {
            // 1x2 rectangle with top left at (1, 1)
            Rectangle rectangle = new Rectangle(1, 1, 1, 2);
            Point pointOutsideOfRectangle = new Point(3, 4);

            // top left at (1, 1), bottom right at (3, 4)
            Rectangle inflatedRectangle = rectangle.InflateToContain(pointOutsideOfRectangle);

            Assert.IsTrue(inflatedRectangle.ClosedContains(pointOutsideOfRectangle));
            Assert.AreEqual(inflatedRectangle.Left, 1);
            Assert.AreEqual(inflatedRectangle.Right, 3);

            Assert.AreEqual(inflatedRectangle.Top, 1);
            Assert.AreEqual(inflatedRectangle.Bottom, 4);
        }

        [TestMethod]
        public void InflateToContain_RectangleMovesOriginAndModifiesSizeToContainPoint()
        {
            // top left at (1, 1), bottom right at (2, 3)
            Rectangle rectangle = new Rectangle(1, 1, 1, 2);
            Point pointOutsideOfRectangle = new Point(0, 0);

            // NEW: top left at (0, 0), bottom right at (2, 3)
            Rectangle inflatedRectangle = rectangle.InflateToContain(pointOutsideOfRectangle);

            Assert.IsTrue(inflatedRectangle.ClosedContains(pointOutsideOfRectangle));
            Assert.AreEqual(inflatedRectangle.Left, 0);
            Assert.AreEqual(inflatedRectangle.Right, 2);

            Assert.AreEqual(inflatedRectangle.Top, 0);
            Assert.AreEqual(inflatedRectangle.Bottom, 3);
        }

        [TestMethod]
        public void InflateToContain_RectangleDoesntChangeForPointItContains()
        {
            // top left at (1, 1), bottom right at (2, 3)
            Rectangle rectangle = new Rectangle(1, 1, 1, 2);
            Point pointAlreadyInRectangle = new Point(1, 1);

            // NEW: no change
            Rectangle unchangingRectangle = rectangle.InflateToContain(pointAlreadyInRectangle);

            Assert.IsTrue(unchangingRectangle.ClosedContains(pointAlreadyInRectangle));
            Assert.AreEqual(unchangingRectangle.Left, 1);
            Assert.AreEqual(unchangingRectangle.Right, 2);

            Assert.AreEqual(unchangingRectangle.Top, 1);
            Assert.AreEqual(unchangingRectangle.Bottom, 3);
        }

        [TestMethod]
        public void SetLeft_RectangleChangesLeft()
        {
            // top left at (1, 1), bottom right at (2, 3)
            Rectangle rectangle = new Rectangle(1, 1, 1, 2);

            // NEW: top left at (0, 0), bottom right at (2, 3)
            Rectangle newLeftRectangle = rectangle.SetLeftSide(-1);

            Assert.AreEqual(newLeftRectangle.Left, -1);
            Assert.AreEqual(newLeftRectangle.Right, 2);

            Assert.AreEqual(newLeftRectangle.Top, 1);
            Assert.AreEqual(newLeftRectangle.Bottom, 3);
        }

        [TestMethod]
        public void SetRight_RectangleChangesRight()
        {
            // top left at (1, 1), bottom right at (2, 3)
            Rectangle rectangle = new Rectangle(1, 1, 1, 2);

            // NEW: top left at (0, 0), bottom right at (2, 3)
            Rectangle newRightRectangle = rectangle.SetRightSide(4);

            Assert.AreEqual(newRightRectangle.Left, 1);
            Assert.AreEqual(newRightRectangle.Right, 4);

            Assert.AreEqual(newRightRectangle.Top, 1);
            Assert.AreEqual(newRightRectangle.Bottom, 3);
        }

        [TestMethod]
        public void SetTop_RectangleChangesTop()
        {
            // top left at (1, 1), bottom right at (2, 3)
            Rectangle rectangle = new Rectangle(1, 1, 1, 2);

            // NEW: top left at (0, 0), bottom right at (2, 3)
            Rectangle newTopRectangle = rectangle.SetTopSide(-1);

            Assert.AreEqual(newTopRectangle.Left, 1);
            Assert.AreEqual(newTopRectangle.Right, 2);

            Assert.AreEqual(newTopRectangle.Top, -1);
            Assert.AreEqual(newTopRectangle.Bottom, 3);
        }

        [TestMethod]
        public void SetBottom_RectangleChangesBottom()
        {
            // top left at (1, 1), bottom right at (2, 3)
            Rectangle rectangle = new Rectangle(1, 1, 1, 2);

            // NEW: top left at (0, 0), bottom right at (2, 3)
            Rectangle newBottomRectangle = rectangle.SetBottomSide(6);

            Assert.AreEqual(newBottomRectangle.Left, 1);
            Assert.AreEqual(newBottomRectangle.Right, 2);

            Assert.AreEqual(newBottomRectangle.Top, 1);
            Assert.AreEqual(newBottomRectangle.Bottom, 6);
        }

        [TestMethod]
        public void Copy_RectangleMakesDeepCopy()
        {
            Rectangle rectangle = new Rectangle(1, 2, 3, 4);
            Rectangle equalRectangle = rectangle.Copy();

            Assert.AreNotSame(rectangle, equalRectangle);
            Assert.AreEqual(rectangle, equalRectangle);
        }
    }
}
