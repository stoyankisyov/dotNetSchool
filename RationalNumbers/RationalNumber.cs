namespace RationalNumbers
{
    public sealed class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public RationalNumber(int numerator, int denumerator)
        {
            if (denumerator == 0)
            {
                throw new ArgumentException("Denumerator can't be 0!");
            }
            var rationalNumberHelper = new RationalNumberHelper();
            int greatestCommonDivisor = rationalNumberHelper.GetGreatestCommonDivisor(numerator, denumerator);
            Numerator = numerator / greatestCommonDivisor;
            Denominator = denumerator / greatestCommonDivisor;

            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is RationalNumber otherNumber)
            {
                return Numerator == otherNumber.Numerator && Denominator == otherNumber.Denominator;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public int CompareTo(RationalNumber? other)
        {
            if (other is null)
            {
                throw new InvalidOperationException("Object is null.");
            }

            return (Numerator * other.Denominator).CompareTo(Denominator * other.Numerator);
        }

        public static RationalNumber operator +(RationalNumber left, RationalNumber right)
        {
            return new RationalNumber(left.Numerator * right.Denominator + right.Numerator * left.Denominator, left.Denominator * right.Denominator);
        }

        public static RationalNumber operator -(RationalNumber left, RationalNumber right)
        {
            return new RationalNumber(left.Numerator * right.Denominator - right.Numerator * left.Denominator, left.Denominator * right.Denominator);
        }

        public static RationalNumber operator *(RationalNumber left, RationalNumber right)
        {
            return new RationalNumber(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
        }

        public static RationalNumber operator /(RationalNumber left, RationalNumber right)
        {
            if (right.Numerator == 0)
            {
                throw new DivideByZeroException("Can't divide by 0!");
            }

            return new RationalNumber(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
        }

        public static explicit operator double(RationalNumber number)
        {
            return (double)number.Numerator / number.Denominator;
        }

        public static implicit operator RationalNumber(int number)
        {
            return new RationalNumber(number, 1);
        }
    }
}
