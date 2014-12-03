using MathExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensionTests
{
    [TestClass]
    public class TestDirection
    {
        [TestMethod]
        public void CONSTANTS_ConstantsHaveCorrectValues()
        {
            Assert.AreEqual(0, Direction.ZERO.X);
            Assert.AreEqual(0, Direction.ZERO.Y);
            Assert.AreEqual(1, Direction.ONE.X);
            Assert.AreEqual(1, Direction.ONE.Y);
            Assert.AreEqual(1, Direction.X_AXIS.X);
            Assert.AreEqual(0, Direction.X_AXIS.Y);
            Assert.AreEqual(0, Direction.Y_AXIS.X);
            Assert.AreEqual(1, Direction.Y_AXIS.Y);
        }

        [TestMethod]
        public void Direction_ConstructorInitializesCorrectly()
        {
            Direction direction = new Direction(2, 3);

            Assert.AreEqual(2, direction.X);
            Assert.AreEqual(3, direction.Y);
        }

        [TestMethod]
        public void Direction_ConstructorAllowsNegativeValues()
        {
            Direction direction = new Direction(-2, -3);

            Assert.AreEqual(-2, direction.X);
            Assert.AreEqual(-3, direction.Y);
        }

        [TestMethod]
        public void Length_IsSqrtOfSumOfSquaredXY()
        {
            Direction lengthRoot8Direction = new Direction(2, 2);

            Assert.AreEqual(Math.Sqrt(8), lengthRoot8Direction.Length);
        }

        [TestMethod]
        public void LengthSquared_IsSumOfSquaredXY()
        {
            Direction direction = new Direction(2, 2);

            Assert.AreEqual(8, direction.LengthSquared);
        }

        [TestMethod]
        public void Equals_SameDirectionsAreEqual()
        {
            Direction direction = new Direction();
            Direction sameDirection = direction;

            Assert.IsTrue(direction.Equals(sameDirection));
        }

        [TestMethod]
        public void Equals_SameXYDirectionsAreEqual()
        {
            int x = 2;
            int y = 3;

            Direction direction = new Direction(x, y);
            Direction equalDirection = new Direction(x, y);

            Assert.IsTrue(direction.Equals(equalDirection));
        }

        [TestMethod]
        public void Equals_DifferentXYDirectionsAreNotEqual()
        {
            Direction direction = new Direction(0, 1);
            Direction notEqualDirection = new Direction(2, 3);

            Assert.IsFalse(direction.Equals(notEqualDirection));
        }

        [TestMethod]
        public void Equals_DifferentObjectTypesAreNotEqual()
        {
            Direction direction = new Direction(0, 1);
            Rectangle wrongObjectType = new Rectangle();

            Assert.IsFalse(direction.Equals(wrongObjectType));
        }

        [TestMethod]
        public void Equals_NullObjectsAreNotEqual()
        {
            Direction direction = new Direction(0, 1);
            Object nullObject = null;

            Assert.IsFalse(direction.Equals(nullObject));
        }

        [TestMethod]
        public void GetHashCode_HashCodeIsXorOnXY()
        {
            Direction direction = new Direction(4, 5);

            Assert.AreEqual(4 ^ 5, direction.GetHashCode());
        }

        [TestMethod]
        public void Negate_ChangesSignOfXY()
        {
            Direction direction = new Direction(2, -3);
            direction.Negate();

            Assert.AreEqual(-2, direction.X);
            Assert.AreEqual( 3, direction.Y);
        }

        [TestMethod]
        public void Negate_DoesNotChangeZero()
        {
            Direction direction = new Direction(0, 0);
            direction.Negate();

            Assert.AreEqual(0, direction.X);
            Assert.AreEqual(0, direction.Y);
        }

        [TestMethod]
        public void Copy_CreatesNewDirectionObject()
        {
            Direction originalDirection = new Direction(2, 3);
            Direction copyDirection = originalDirection.Copy();

            Assert.AreNotSame(originalDirection, copyDirection);
        }

        [TestMethod]
        public void Copy_CreatesEqualDirectionObject()
        {
            Direction originalDirection = new Direction(2, 3);
            Direction copyDirection = originalDirection.Copy();

            Assert.AreEqual(originalDirection, copyDirection);
        }

        [TestMethod]
        public void Add_ComponentwiseSumsXY()
        {
            Direction summand = new Direction(0, 1);
            Direction addend = new Direction(2, 3);

            Direction sum = Direction.Add(summand, addend);

            Assert.AreEqual(2, sum.X);
            Assert.AreEqual(4, sum.Y);
        }

        [TestMethod]
        public void Subtract_ComponentwiseSubtractsXY()
        {
            Direction minuend = new Direction(0, 1);
            Direction subtrahend = new Direction(2, 3);

            Direction difference = Direction.Subtract(minuend, subtrahend);

            Assert.AreEqual(-2, difference.X);
            Assert.AreEqual(-2, difference.Y);
        }

        [TestMethod]
        public void Multiply_ComponentwiseMultiplicationOfXYAgainstScalar()
        {
            Direction multiplicand = new Direction(0, 1);
            double scalar = 4;

            Direction product = Direction.Multiply(multiplicand, scalar);

            Assert.AreEqual(0, product.X);
            Assert.AreEqual(4, product.Y);
        }

        [TestMethod]
        public void Divide_ComponentwiseDivisionOfXYAgainstScalar()
        {
            Direction dividend = new Direction(0, 4);
            double scalar = 4;

            Direction product = Direction.Divide(dividend, scalar);

            Assert.AreEqual(0, product.X);
            Assert.AreEqual(1, product.Y);
        }

        [TestMethod]
        public void Divide_ComponentwiseDivisionOfXYAgainstScalarWithIntegerTruncation()
        {
            Direction dividend = new Direction(0, 1);
            double scalar = 4;

            Direction product = Direction.Divide(dividend, scalar);

            Assert.AreEqual(0, product.X);
            Assert.AreEqual(0, product.Y); // 1/4 dobule -> 0 integer
        }

        [TestMethod]
        public void ImplicitPoint_DirectionXYConvertToPointXY()
        {
            Direction direction = new Direction(2, -3);
            Point point = direction;

            Assert.AreEqual( 2, point.X);
            Assert.AreEqual(-3, point.Y);
        }

        [TestMethod]
        public void ImplicitPoint_PointXYConvertToDirectionXY()
        {
            Point point = new Point(2, -3);
            Direction direction = point;

            Assert.AreEqual( 2, direction.X);
            Assert.AreEqual(-3, direction.Y);
        }
    }
}
