#nullable disable

using BookCatalog.Infrastructure.Wrappers;
using System.Xml.Serialization;

namespace BookCatalog.Infrastructure.Models.XmlEntities
{
    public class Author
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("BirthDate")]
        public DateOnlyXmlWrapper BirthDate { get; set; }
    }
}
