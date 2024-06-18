#nullable disable

using System.Xml.Serialization;

namespace BookCatalog.Infrastructure.Models.XmlEntities
{
    public class Book
    {
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlArray("Authors")]
        [XmlArrayItem("Author")]
        public HashSet<XmlEntities.Author> Authors { get; set; }
    }
}
