#nullable disable

namespace BookCatalog.Core.Models
{
    public abstract class Book
    {
        private string _title;

        public string Id { get; set; }  // Url for Ebook, first isbn from the list for PaperBook
        public HashSet<Author> Authors { get; }
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

        protected Book(string id, string title, HashSet<Author> authors)
        {
            Id = id;
            Title = title;
            Authors = authors;
        }
    }
}
