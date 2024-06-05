namespace BookCatalog.Core.Models
{
    public class PaperBook : Book
    {
        public DateOnly? PublicationDate { get; }
        public List<Isbn> Isbns { get; }
        public string Publisher { get; }

        public PaperBook(List<Isbn> isbns, string title, DateOnly? publicationDate, string publisher, HashSet<Author> authors)
            : base(isbns[0].Value, title, authors)
        {
            Isbns = isbns;
            PublicationDate = publicationDate;
            Publisher = publisher;
        }
    }
}
