namespace TwoADuodecimalRangeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = EnterValue("a");
            var b = EnterValue("b");

            if (a < b)
            {
                PrintNumbers(a, b);
            }
            else
            {
                PrintNumbers(b, a);
            }
        }

        private static int EnterValue(string variableName)
        {
            Console.Write($"Enter value for {variableName}: ");
            return int.Parse(Console.ReadLine());
        }

        private static string ConvertDecimalToDuodecimal(int decimalNumber)
        {
            if (decimalNumber == 0)
            {
                return "0";
            }

            var result = "";
            var isNegative = decimalNumber < 0;
            decimalNumber = Math.Abs(decimalNumber);

            while (decimalNumber > 0)
            {
                var remainder = decimalNumber % 12;

                if (remainder <= 9)
                {
                    result = remainder.ToString() + result;
                }

                else
                {
                    switch (remainder)
                    {
                        case 10:
                            result = "A" + result; break;
                        case 11:
                            result = "B" + result; break;
                    }
                }
                decimalNumber /= 12;
            }

            if (isNegative)
            {
                return "-" + result;
            }

            return result;
        }

        private static bool HasTwoAs(string duodecimalNumber)
        {
            var count = 0;

            foreach (var digint in duodecimalNumber)
            {
                if (digint == 'A')
                {
                    count++;
                }
            }

            return count == 2;
        }

        private static void PrintNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                var duodecimalNumber = ConvertDecimalToDuodecimal(i);

                if (HasTwoAs(duodecimalNumber))
                {
                    Console.WriteLine($"{i} - {duodecimalNumber}");
                }
            }
        }
    }
}