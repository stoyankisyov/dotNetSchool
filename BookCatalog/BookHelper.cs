using System.Text.RegularExpressions;

namespace BookCatalog
{
    public class BookHelper
    {
        private readonly List<string> _isbnVariants = [@"\d{3}-\d-\d{2}-\d{6}-\d", @"\d{13}"];

        public string UnifyIsbn(string isbn)
        {
            return isbn.Replace("-", "");
        }

        public bool IsIsbnInCorrectFormat(string isbn)
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
