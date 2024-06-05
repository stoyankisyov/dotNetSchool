using System.Text.RegularExpressions;

namespace BookCatalog.Core.Helpers
{
    public class BookHelper
    {
        private static readonly List<string> _isbnVariants = [@"\d{3}-\d-\d{2}-\d{6}-\d", @"\d{13}"];

        public static string UnifyIsbn(string isbn)
        {
            return IsIsbnInCorrectFormat(isbn) ? isbn.Replace("-", "") : throw new ArgumentException("Invalid Isbn");
        }

        public static bool IsIsbnInCorrectFormat(string isbn)
        {
            foreach (string variant in _isbnVariants)
            {
                var regex = new Regex(variant);
                var match = regex.Match(isbn);

                if (match.Success)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
