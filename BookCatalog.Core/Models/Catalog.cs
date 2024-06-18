using System.Collections;
using BookCatalog.Core.Helpers;
using BookCatalog.Core.Interfaces;

namespace BookCatalog.Core.Models
{
    public class Catalog<T> : IEnumerable<T>, ICatalog where T : Book
    {
        private Dictionary<string, T> _books;

        public Dictionary<string, Book> Books 
        {
            get => _books.ToDictionary(kvp => kvp.Key, kvp => (Book)kvp.Value);
            set
            {
                _books = value.ToDictionary(kvp => kvp.Key, kvp => (T)kvp.Value);
            }
        }

        public Catalog()
        {
            _books = [];
        }

        public void Add(Book book)
        {
            if (!_books.ContainsKey(book.Id) && book is T suitableBook)
            {
                _books.Add(book.Id, suitableBook);
            }
        }

        public void AddRange(IEnumerable<Book> books)
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

        public IEnumerator<T> GetEnumerator() => _books.Values.GetEnumerator();

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
