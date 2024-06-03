#nullable disable

using System.Xml.Serialization;

namespace BookCatalog.Infrastructure.Models.XmlEntities
{
    public class Catalog
    {
        [XmlArray("Books")]
        [XmlArrayItem("Book")]
        public List<XmlEntities.Book> Books { get; set; }
    }
}
