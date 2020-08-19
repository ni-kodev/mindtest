using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Home.Shapes.Test
{
    //тесты достаточно натянутые в силу примитивности тестируемого
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void CircleConstructorArguments()
        {
            Assert.ThrowsException<ArgumentException>(() => new Circle(0));
            Assert.ThrowsException<ArgumentException>(() => new Circle(-1));
        }


        [TestMethod]
        public void CircleConstructorType()
        {
            Assert.IsInstanceOfType(new Circle(3), typeof(IShape));
        }


        [TestMethod]
        public void CircleAreaRange()
        {
            var area = new Circle(100).GetArea();
            Assert.IsTrue(area > 0);
        }


        [TestMethod]
        public void CircleAreaOverflow()
        {
            var maxCircle = new Circle(double.MaxValue);
            Assert.ThrowsException<OverflowException>(() => maxCircle.GetArea());
        }
    }
}
