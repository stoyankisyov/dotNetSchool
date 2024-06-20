namespace BookCatalog.Core.Models
{
    public class EBook : Book
    {
        public string Url { get; }
        public List<string> AvailableFormats { get; }
        public int Pages { get; set; }

        public EBook(string title, string url, HashSet<Author> authors, List<string> availableFormats) 
            : base(url, title, authors)
        {
            Url = url;
            AvailableFormats = availableFormats;
        }
    }
}
