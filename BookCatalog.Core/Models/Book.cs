#nullable disable

using BookCatalog.Core.Helpers;

namespace BookCatalog.Core.Models
{
    public class Book
    {
        private string _title;

        public string Isbn { get; set; }
        public DateOnly? PublicationDate { get; set; }
        public HashSet<Author> Authors { get; set; }
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title can't be null or empty");
                }

                _title = value;
            }
        }

        public Book(string isbn, string title, DateOnly? publicationDate, HashSet<Author> authors)
        {
            if (!BookHelper.IsIsbnInCorrectFormat(isbn))
            {
                throw new ArgumentException("Invalid ISBN format.");
            }

            Isbn = BookHelper.UnifyIsbn(isbn);
            Title = title;
            PublicationDate = publicationDate;
            Authors = authors;
        }
    }
}
