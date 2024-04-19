﻿namespace IsbnCheckDigitCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first 9 digits: ");
            var input = Console.ReadLine();

            var digitsIntArray = ExtractDigitsAsInt(input);
            var checkDigit = CalculateCheckDigit(digitsIntArray);
            Console.WriteLine("Final ISBN: " + CombineIsbn(input, checkDigit));
        }

        private static int[] ExtractDigitsAsInt(string input)
        {
            var digits = new int[input.Length];
            for (int i = 0; i < digits.Length; i++)
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

            return (11 - (sum % 11)) % 11;  //check digit calculation
        }

        private static string CombineIsbn(string input, int checkDigitIntValue)
        {
            //if (checkDigitIntValue == 10)
            //{
            //    return input + "X";
            //}

            //return input + checkDigitIntValue.ToString();
            return input + (checkDigitIntValue == 10 ? "X" : checkDigitIntValue.ToString()); // not sure if im allowed to use this expression for the current task
        }
    }
}
