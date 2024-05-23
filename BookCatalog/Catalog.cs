using System.Collections;

namespace BookCatalog
{
    public class Catalog : IEnumerable<Book>
    {
        private Dictionary<string, Book> _books;

        public Catalog()
        {
            _books = [];
        }

        public Book this[string isbn]
        {
            get
            {
                if (!BookHelper.IsIsbnInCorrectFormat(isbn))
                {
                    throw new ArgumentException("Invalid ISBN format.");
                }

                return _books[BookHelper.UnifyIsbn(isbn)];
            }
        }

        public void Add(Book book)
        {
            if (!_books.ContainsKey(BookHelper.UnifyIsbn(book.Isbn)))
            {
                _books.Add(book.Isbn, book);
            }
        }

        public IEnumerator<Book> GetEnumerator() 
            => _books.Select(x => x.Value).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public List<Book> GetSortedBooks()
            => [.. this.OrderBy(x => x.Title)];

        public List<Book> GetBooksByAuthor(string author)
            => [.. this.Where(x => x.Authors.Contains(author)).OrderBy(x => x.PublicationDate)];

        public List<(string, int)> GetAllAuthorsBookCount()
            => [.. this.SelectMany(book => book.Authors)
                .GroupBy(author => author)
                .Select(group => (group.Key, group.Count()))];
    }
}
