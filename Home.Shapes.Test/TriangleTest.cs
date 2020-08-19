using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Home.Shapes.Test
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void TriangleConstructorArguments()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(0, 7, 3));
            Assert.ThrowsException<ArgumentException>(() => new Triangle(2, 3, -1));
        }


        [TestMethod]
        public void TriangleConstructorType()
        {
            var t = new Triangle(3, 4, 5);
            Assert.IsInstanceOfType(t, typeof(IShape));
        }


        [TestMethod]
        public void TriangleArea()
        {
            var t = new Triangle(3, 4, 5);
            Assert.AreEqual(6, t.GetArea());
        }


        [TestMethod]
        public void TrianglePerimeter()
        {
            var t = new Triangle(1, 2, 3);
            Assert.AreEqual(6, t.Perimeter);

            var t2 = new Triangle(2, 3, 4);
            Assert.AreEqual(9, t2.Perimeter);
        }


        [TestMethod]
        public void TrianglePerimeterOverflow()
        {
            var maxTriangle = new Triangle(double.MaxValue, double.MaxValue, double.MaxValue);
            Assert.ThrowsException<OverflowException>(() => maxTriangle.Perimeter);
        }


        [TestMethod]
        public void TriangleAreaOverflow()
        {
            var maxTriangle = new Triangle(double.MaxValue, double.MaxValue, double.MaxValue);
            Assert.ThrowsException<OverflowException>(() => maxTriangle.GetArea());
        }


        [TestMethod]
        public void TriangleRect()
        {
            var t = new Triangle(2, 3, 4);
            Assert.IsFalse(t.IsRect);

            var tr = new Triangle(3, 4, 5);
            Assert.IsTrue(tr.IsRect);
        }
    }
}
