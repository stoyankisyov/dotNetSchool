#nullable disable

namespace BookCatalog.Infrastructure.Models.JsonEntities
{
    public class Catalog
    {
        public Dictionary<string, Book> Books { get; set; }
    }
}
