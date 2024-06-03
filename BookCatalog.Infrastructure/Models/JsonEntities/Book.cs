#nullable disable

namespace BookCatalog.Infrastructure.Models.JsonEntities
{
    public class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public DateOnly? PublicationDate { get; set; }
        public HashSet<JsonEntities.Author> Authors { get; set; }
    }
}
