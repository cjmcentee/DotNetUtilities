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
    public class TestPointExtension
    {
        [TestMethod]
        public void MapPoint_PointMapsFromDomainToRange()
        {
            Point pointInDomain = new Point(1, 1);
            Point pointOutDomain = new Point(-1, -1);

            Rectangle domain = new Rectangle(0, 0, 2, 2);
            Rectangle range = new Rectangle(2, 2, 4, 4);

            Point pointInDomain_range = pointInDomain.MapPoint(domain, range);
            Point pointOutDomain_range = pointOutDomain.MapPoint(domain, range);

            Assert.AreEqual(4, pointInDomain_range.X);
            Assert.AreEqual(4, pointInDomain_range.Y);
            Assert.AreEqual(0, pointOutDomain_range.X);
            Assert.AreEqual(0, pointOutDomain_range.Y);
        }

        [TestMethod]
        public void RelativeTo_PointsSubtractCorrectlyFromEachOther()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(0, -1);

            Direction point1_point2 = point1.RelativeTo(point2);
            Direction point2_point1 = point2.RelativeTo(point1);

            Assert.AreEqual(1, point1_point2.X);
            Assert.AreEqual(2, point1_point2.Y);
            Assert.AreEqual(-1, point2_point1.X);
            Assert.AreEqual(-2, point2_point1.Y);
        }
    }
}
