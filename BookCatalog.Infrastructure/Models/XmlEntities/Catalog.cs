#nullable disable

using System.Xml.Serialization;

namespace BookCatalog.Infrastructure.Models.XmlEntities
{
    [XmlRoot("Catalog")]
    public class Catalog<T> where T : Models.XmlEntities.Book
    {
        [XmlArray("Books")]
        [XmlArrayItem("Book")]
        public List<T> Books { get; set; }
    }
}
