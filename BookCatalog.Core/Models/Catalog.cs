using System.Collections;
using BookCatalog.Core.Helpers;

namespace BookCatalog.Core.Models
{
    public class Catalog<T> : IEnumerable<T> where T : Book
    {
        public Dictionary<string, T> Books { get; private set; }
        
        public Catalog()
        {
            Books = [];
        }

        public void Add(T book)
        {
            if (!Books.ContainsKey(book.Id))
            {
                Books.Add(book.Id, book);
            }
        }

        public void AddRange(IEnumerable<T> books)
        {
            foreach (var book in books)
            {
                Add(book);
            }
        }

        public Book this[string isbn]
        {
            get => !BookHelper.IsIsbnInCorrectFormat(isbn) ? throw new ArgumentException("Invalid ISBN format.") : Books[BookHelper.UnifyIsbn(isbn)];
        }

        public IEnumerator<T> GetEnumerator()
            => Books.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public List<Book> GetSortedBooks()
            => [.. Books.Values.OrderBy(x => x.Title)];

        public List<Book> GetBooksByAuthor(Author author)
            => [.. Books.Values.Where(x => x.Authors.Any(a => a.FirstName.Equals(author.FirstName) && a.LastName.Equals(author.LastName)))];

        public List<(string, int)> GetAllAuthorsBookCount()
            => [.. Books.Values.SelectMany(book => book.Authors)
                           .GroupBy(author => author.FirstName + author.LastName)
                           .Select(group => (group.Key, group.Count()))];
    }
}
