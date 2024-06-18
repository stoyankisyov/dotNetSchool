#nullable disable

namespace BookCatalog.Infrastructure.Models.Entities
{
    public class PaperBook : Book
    {
        public DateOnly? PublicationDate { get; set; }
        public List<string> Isbns { get; set; }
        public string Publisher { get; set; }

        public PaperBook()
        {
            Isbns = new List<string>();
        }
    }
}
