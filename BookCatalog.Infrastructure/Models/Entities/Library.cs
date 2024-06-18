#nullable disable

namespace BookCatalog.Infrastructure.Models.Entities
{
    public class Library<T> where T : Book
    {
        public Catalog<T> Catalog { get; set; }

        public Library()
        {
            Catalog = new Catalog<T>();
        }
    }
}
