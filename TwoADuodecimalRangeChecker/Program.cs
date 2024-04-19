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
            // var duodecimalDigits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B' };
            var result = "";

            while (decimalNumber > 0)
            {
                var remainder = decimalNumber % 12;
                // result = duodecimalDigits[remainder] + result; 
                // switch-case lesser chance for bugs, since not using array and you cannot change the array's elements by mistake, not relying on accessing by index
                // + improved readability
                switch (remainder)
                {
                    case 0:
                        result = "0" + result; break;
                    case 1:
                        result = "1" + result; break;
                    case 2:
                        result = "2" + result; break;
                    case 3:
                        result = "3" + result; break;
                    case 4:
                        result = "4" + result; break;
                    case 5:
                        result = "5" + result; break;
                    case 6:
                        result = "6" + result; break;
                    case 7:
                        result = "7" + result; break;
                    case 8:
                        result = "8" + result; break;
                    case 9:
                        result = "9" + result; break;
                    case 10:
                        result = "A" + result; break;
                    case 11:
                        result = "B" + result; break;
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