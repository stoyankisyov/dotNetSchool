using BookCatalog.Core.Helpers;

namespace BookCatalog.Core.Models
{
    public class Isbn
    {
        public string Value { get; }

        public Isbn(string value)
        {
            Value = BookHelper.UnifyIsbn(value);
        }
    }
}
