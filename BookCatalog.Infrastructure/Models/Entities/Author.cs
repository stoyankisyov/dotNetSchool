#nullable disable

namespace BookCatalog.Infrastructure.Models.Entities
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? BirthDate { get; set; }
    }
}
