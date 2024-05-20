using System.Reflection.Metadata;

namespace RationalNumbers
{
    public class RationalNumberHelper
    {
        public int GetGreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            return secondNumber == 0 ? Math.Abs(firstNumber) : GetGreatestCommonDivisor(secondNumber, firstNumber % secondNumber);
        }
    }
}
