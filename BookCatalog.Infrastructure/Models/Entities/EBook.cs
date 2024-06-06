#nullable disable

namespace BookCatalog.Infrastructure.Models.Entities
{
    public class EBook : Book
    {
        public List<string> AvailableFormats { get; set; }

        public EBook()
        {
            AvailableFormats = new List<string>();
        }
    }
}
