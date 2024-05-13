using RationalNumbers;

namespace RationalNumbersTests
{
    [TestClass]
    public class RationalNumberTests
    {
        [TestMethod]
        public void ConstructorPositive()
        {
            var rationalNumberWithReducibleFraction = new RationalNumber(2, 4);
            var rationalNumberWithNegativeDenumerator = new RationalNumber(1, -2);
            var rationalNumberWithNegativeDenumeratorReducibleFraction = new RationalNumber(2, -4);

            Assert.AreEqual(1, rationalNumberWithReducibleFraction.Numerator);
            Assert.AreEqual(2, rationalNumberWithReducibleFraction.Denominator);

            Assert.AreEqual(-1, rationalNumberWithNegativeDenumerator.Numerator);
            Assert.AreEqual(2, rationalNumberWithNegativeDenumerator.Denominator);

            Assert.AreEqual(-1, rationalNumberWithNegativeDenumeratorReducibleFraction.Numerator);
            Assert.AreEqual(2, rationalNumberWithNegativeDenumeratorReducibleFraction.Denominator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Denominator can't be 0!")]
        public void ConstructorNegative()
        {
            var rationalNumber = new RationalNumber(1, 0);
        }

        [TestMethod]
        public void ToStringOverrideSuccess()
        {
            var rationalNumber = new RationalNumber(1, 2);

            Assert.AreEqual("1/2", rationalNumber.ToString());
        }

        [TestMethod]
        public void EqualsOverrideSuccess()
        {
            var firstRationalNumber = new RationalNumber(1, 2);
            var secondRationalNumber = new RationalNumber(1, 2);

            Assert.IsTrue(firstRationalNumber.Equals(secondRationalNumber));
        }

        [TestMethod]
        public void CompareToSuccess()
        {
            var firstRationalNumber = new RationalNumber(1, 2);
            var greaterThanFirstRationalNumber = new RationalNumber(3, 2);
            var sameAsFirstRationalNumber = new RationalNumber(1, 2);
            RationalNumber? nullRationalNumber = null;

            Assert.AreEqual(1, greaterThanFirstRationalNumber.CompareTo(firstRationalNumber));
            Assert.AreEqual(1, firstRationalNumber.CompareTo(nullRationalNumber));
            Assert.AreEqual(0, firstRationalNumber.CompareTo(sameAsFirstRationalNumber));
            Assert.AreEqual(-1, firstRationalNumber.CompareTo(greaterThanFirstRationalNumber));
        }

        [TestMethod]
        public void GetHashCodeOverrideSuccess()
        {
            var numeratorValue = 1;
            var denominatorValue = 2;

            var rationalNumber = new RationalNumber(1, 2);

            Assert.AreEqual(HashCode.Combine(numeratorValue, denominatorValue), rationalNumber.GetHashCode());
        }

        [TestMethod]
        public void AdditionOperatorOverrideSuccess()
        {
            var firstRationalNumber = new RationalNumber(1, 2);
            var secondRationalNumber = new RationalNumber(3, 5);

            var expectedResultRationalNumber = new RationalNumber(11, 10);

            Assert.AreEqual(expectedResultRationalNumber, firstRationalNumber + secondRationalNumber);
        }

        [TestMethod]
        public void SubtractionOperatorOverrideSuccess()
        {
            var firstRationalNumber = new RationalNumber(1, 2);
            var secondRationalNumber = new RationalNumber(3, 5);

            var expectedResultRationalNumber = new RationalNumber(-1, 10);

            Assert.AreEqual(expectedResultRationalNumber, firstRationalNumber - secondRationalNumber);
        }

        [TestMethod]
        public void MultiplicationOperatorOverrideSuccess()
        {
            var firstRationalNumber = new RationalNumber(1, 2);
            var secondRationalNumber = new RationalNumber(3, 5);

            var expectedResultRationalNumber = new RationalNumber(3, 10);

            Assert.AreEqual(expectedResultRationalNumber, firstRationalNumber * secondRationalNumber);
        }

        [TestMethod]
        public void DivisionOperatorOverrideSuccess()
        {
            var firstRationalNumber = new RationalNumber(1, 2);
            var secondRationalNumber = new RationalNumber(3, 5);

            var expectedResultRationalNumber = new RationalNumber(5, 6);

            Assert.AreEqual(expectedResultRationalNumber, firstRationalNumber / secondRationalNumber);
        }

        [TestMethod]
        public void ExplicitCastToDoubleSuccess()
        {
            var rationalNumber = new RationalNumber(1, 2);

            Assert.AreEqual(0.5d, (double)rationalNumber);
        }

        [TestMethod]
        public void ImplicitCastIntToRationalNumberSuccess()
        {
            var number = 2;
            RationalNumber rationalNumber = number;
            var expectedRationalNumber = new RationalNumber(2, 1);

            Assert.AreEqual(expectedRationalNumber, rationalNumber);
        }
    }
}