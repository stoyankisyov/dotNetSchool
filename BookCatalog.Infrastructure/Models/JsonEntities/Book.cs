#nullable disable

namespace BookCatalog.Infrastructure.Models.JsonEntities
{
    public class Book
    {
        public string Title { get; set; }
        public HashSet<JsonEntities.Author> Authors { get; set; }
    }
}
