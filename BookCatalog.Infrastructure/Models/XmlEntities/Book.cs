#nullable disable

using BookCatalog.Core.Wrappers;
using System.Xml.Serialization;

namespace BookCatalog.Infrastructure.Models.XmlEntities
{
    public class Book
    {
        [XmlElement("Isbn")]
        public string Isbn { get; set; }

        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlArray("Authors")]
        [XmlArrayItem("Author")]
        public HashSet<XmlEntities.Author> Authors { get; set; }

        [XmlElement("PublicationDate")]
        public DateOnlyXmlWrapper PublicationDate { get; set; }

        public Book() { }
    }
}
