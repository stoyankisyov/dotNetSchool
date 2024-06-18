#nullable disable

namespace BookCatalog.Infrastructure.Models.Entities
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public HashSet<Entities.Author> Authors { get; set; }

        public Book()
        {
            Authors = new HashSet<Entities.Author>();
        }
    }
}
