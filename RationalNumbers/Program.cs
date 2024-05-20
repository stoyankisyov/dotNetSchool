namespace RationalNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstRationalNumber = new RationalNumber(2, 4);
            var secondRationalNumber = new RationalNumber(3, 5);

            // Irreducible fraction check + ToString
            Console.WriteLine($"Original fraction 2/4 = {firstRationalNumber}");

            // Equals check
            var thirdRationalNumber = new RationalNumber(1, 2);
            Console.WriteLine($"Equals result: {thirdRationalNumber.Equals(firstRationalNumber)}");

            // CompareTo check
            Console.WriteLine($"Comparison result: {firstRationalNumber.CompareTo(secondRationalNumber)}");

            // + operator check
            Console.WriteLine($"{nameof(firstRationalNumber)} + {nameof(secondRationalNumber)} = {firstRationalNumber + secondRationalNumber}");
           
            // - operator check
            Console.WriteLine($"{nameof(firstRationalNumber)} - {nameof(secondRationalNumber)} = {firstRationalNumber - secondRationalNumber}");

            // * operator check
            Console.WriteLine($"{nameof(firstRationalNumber)} * {nameof(secondRationalNumber)} = {firstRationalNumber * secondRationalNumber}");

            // / operator check
            Console.WriteLine($"{nameof(firstRationalNumber)} / {nameof(secondRationalNumber)} = {firstRationalNumber / secondRationalNumber}");

            // Explicit casting to double
            Console.WriteLine($"(double){nameof(firstRationalNumber)} = {(double)firstRationalNumber}");

            // Implicit casting to RationalNumber
            int number = 2;
            RationalNumber implicitlyCastedFromInt = number;
            Console.WriteLine($"Implicit cast from int = {implicitlyCastedFromInt}");
        }
    }
}
