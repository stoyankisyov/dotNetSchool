using PlanetariumOnTheComputer;

namespace PlanetariumOnTheComputerTests
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void PointMassTestPositive()
        {
            var testPoint = new Point(1, 1, 1, 10);

            Assert.IsTrue(testPoint.Mass == 10);
        }

        [TestMethod]
        public void PointMassTestNegative()
        {
            var testPoint = new Point(1, 1, 1, -10);

            Assert.IsTrue(testPoint.Mass == 0);
        }

        [TestMethod]
        public void IsZeroPositive()
        {
            var testPoint = new Point(0, 0, 0, 10);

            Assert.IsTrue(testPoint.IsZero());
        }

        [TestMethod]
        public void IsZeroNegative()
        {
            var testPoint = new Point(0, 1, 0, 10);

            Assert.IsFalse(testPoint.IsZero());
        }

        [TestMethod]
        public void CalculateDistanceToSuccess()
        {
            var firstTestPoint = new Point(0, 0, 0, 10);
            var secondTestPoint = new Point(1, 2, 2, 10);

            Assert.AreEqual(3, firstTestPoint.CalculateDistanceTo(secondTestPoint));
        }

        [TestMethod]
        public void ToStringOverrideSuccess()
        {
            var testPoint = new Point(1, -2, 3, 10);

            Assert.AreEqual("CoordinateX: 1, CoordinateY: -2, CoordinateZ: 3, Mass: 10", testPoint.ToString());
        }
    }
}