namespace BookCatalog
{
    public class Book
    {
        public string Isbn { get; }
        public string Title { get; }
        public DateOnly? PublicationDate { get; }
        public HashSet<string> Authors { get; }

        public Book(string isbn, string title, DateOnly? publicationDate, HashSet<string> authors)
        {
            var bookHelper = new BookHelper();

            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title can't be null or empty");
            }

            if (!bookHelper.IsIsbnInCorrectFormat(isbn))
            {
                throw new ArgumentException("Invalid ISBN format.");
            }

            Isbn = bookHelper.UnifyIsbn(isbn);
            Title = title;
            PublicationDate = publicationDate;
            Authors = authors;
        }
    }
}
