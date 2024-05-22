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
                var bookHelper = new BookHelper();

                if (!bookHelper.IsIsbnInCorrectFormat(isbn))
                {
                    throw new ArgumentException("Invalid ISBN format.");
                }

                return _books[bookHelper.UnifyIsbn(isbn)];
            }
        }

        public void Add(Book book)
        {
            var bookHelper = new BookHelper();

            if (!_books.ContainsKey(bookHelper.UnifyIsbn(book.Isbn)))
            {
                _books.Add(book.Isbn, book);
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in _books)
            {
                yield return book.Value;
            }
        }

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
