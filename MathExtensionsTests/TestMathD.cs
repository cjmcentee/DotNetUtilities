using MathExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensionTests
{
    [TestClass]
    public class TestMathD
    {
        [TestMethod]
        public void Clamp_ReturnsSameValueIfWithinMinMax()
        {
            Assert.AreEqual(0,  MathD.Clamp(0,  0, 10));
            Assert.AreEqual(5,  MathD.Clamp(5,  0, 10));
            Assert.AreEqual(10, MathD.Clamp(10, 0, 10));
        }

        [TestMethod]
        public void Clamp_ClampsToMinMax()
        {
            Assert.AreEqual(0,  MathD.Clamp(-10, 0, 10));
            Assert.AreEqual(10, MathD.Clamp( 20, 0, 10));
        }
    }
}
