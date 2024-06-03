#nullable disable

namespace BookCatalog.Infrastructure.Models.JsonEntities
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
