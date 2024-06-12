using BookCatalog.Core.Interfaces;

namespace BookCatalog.Core.Models
{
    public static class CatalogExtensions
    {
        public static Catalog<T> ToTypedCatalog<T>(this ICatalog catalog) where T : Book
        {
            var typedCatalog = new Catalog<T>();

            foreach (var book in catalog.Books.Values)
            {
                if (book is T typedBook)
                {
                    typedCatalog.Add(typedBook);
                }
                else
                {
                    throw new InvalidCastException($"Cannot convert book of type {book.GetType()} to {typeof(T)}.");
                }
            }

            return typedCatalog;
        }
    }
}
