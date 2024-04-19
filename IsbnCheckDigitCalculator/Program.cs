namespace IsbnCheckDigitCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first 9 digits: ");
            var userIsbnInput = Console.ReadLine();

            var digitsAsIntArray = ExtractDigitsAsIntArray(userIsbnInput);
            var checkDigit = CalculateCheckDigit(digitsAsIntArray);

            Console.WriteLine("Complete ISBN: " + CombineIsbn(userIsbnInput, checkDigit));
        }

        private static int[] ExtractDigitsAsIntArray(string input)
        {
            var digits = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                digits[i] = int.Parse(input[i].ToString());
            }

            return digits;
        }

        private static int CalculateCheckDigit(int[] digts)
        {
            int sum = 0;

            for (int i = 0; i < digts.Length; i++)
            {
                sum += digts[i] * (10 - i);
            }

            return (11 - (sum % 11)) % 11;
        }

        private static string CombineIsbn(string input, int checkDigitIntValue)
        {
            return input + (checkDigitIntValue == 10 ? "X" : checkDigitIntValue.ToString());
        }
    }
}
