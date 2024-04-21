namespace TwoADuodecimalRangeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Enter value for a: ");
            var a = int.Parse(Console.ReadLine());

            Console.Write($"Enter value for b: ");
            var b = int.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                var duodecimalNumber = ConvertDecimalToDuodecimal(i);

                if (HasTwoAs(duodecimalNumber))
                {
                    Console.WriteLine($"{i} - {duodecimalNumber}");
                }
            }
        }

        private static string ConvertDecimalToDuodecimal(int decimalNumber)
        {
            var result = "";

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
    }
}