#nullable disable

namespace BookCatalog.Infrastructure.Models.Entities
{
    public class Catalog<T> where T : Models.Entities.Book
    {
        public Dictionary<string, T> Books { get; set; }

        public Catalog()
        {
            Books = new Dictionary<string, T>();
        }
    }
}
