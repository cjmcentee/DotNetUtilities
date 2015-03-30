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
    public class TestDirectionExtension
    {
        [TestMethod]
        public void MapPoint_DirectionMapsFromDomainToRange()
        {
            Direction directionInDomain = new Direction(1, 1);
            Direction directionOutDomain = new Direction(-1, -1);

            Rectangle domain = new Rectangle(0, 0, 2, 2);
            Rectangle range = new Rectangle(2, 2, 4, 4);

            Direction directionInDomain_range = directionInDomain.MapPoint(domain, range);
            Direction directionOutDomain_range = directionOutDomain.MapPoint(domain, range);

            Assert.AreEqual(4, directionInDomain_range.X);
            Assert.AreEqual(4, directionInDomain_range.Y);
            Assert.AreEqual(0, directionOutDomain_range.X);
            Assert.AreEqual(0, directionOutDomain_range.Y);
        }

        [TestMethod]
        public void Median_EmptyListReturnsDefaultDirection()
        {
            List<Direction> emptyList = new List<Direction>();

            Assert.AreEqual(new Direction(), emptyList.Median());
        }

        [TestMethod]
        public void Median_OneElementListReturnsThatElement()
        {
            Direction element1by1 = new Direction(1, 1);

            List<Direction> singleElementList = new List<Direction>();
            singleElementList.Add(element1by1);

            Assert.AreEqual(element1by1, singleElementList.Median());
        }

        [TestMethod]
        public void Median_TwoElementListReturnsShortestElement()
        {
            Direction element2by2 = new Direction(2, 2);
            Direction element1by1 = new Direction(1, 1);

            List<Direction> twoElementList = new List<Direction>();
            twoElementList.Add(element2by2);
            twoElementList.Add(element1by1);

            Assert.AreEqual(element2by2, twoElementList.Median());
        }

        [TestMethod]
        public void Median_OddElementListReturnsMiddleLengthElement()
        {
            Direction element2by2 = new Direction(2, 2);
            Direction element4by4 = new Direction(4, 4);
            Direction element1by1 = new Direction(1, 1);
            Direction element5by5 = new Direction(5, 5);
            Direction element3by3 = new Direction(3, 3);
            
            List<Direction> oddElementList = new List<Direction>();
            oddElementList.Add(element2by2);
            oddElementList.Add(element4by4);
            oddElementList.Add(element1by1);
            oddElementList.Add(element5by5);
            oddElementList.Add(element3by3);

            Assert.AreEqual(element3by3, oddElementList.Median());
        }

        [TestMethod]
        public void Median_EvenElementListReturnsOneAboveMiddleLengthElement()
        {
            Direction element2by2 = new Direction(2, 2);
            Direction element4by4 = new Direction(4, 4);
            Direction element1by1 = new Direction(1, 1);
            Direction element5by5 = new Direction(5, 5);
            Direction element3by3 = new Direction(3, 3);
            Direction element6by6 = new Direction(6, 6);

            List<Direction> evenElementList = new List<Direction>();
            evenElementList.Add(element2by2);
            evenElementList.Add(element4by4);
            evenElementList.Add(element1by1);
            evenElementList.Add(element5by5);
            evenElementList.Add(element3by3);
            evenElementList.Add(element6by6);
            
            Assert.AreEqual(element4by4, evenElementList.Median());
        }

    }
}
