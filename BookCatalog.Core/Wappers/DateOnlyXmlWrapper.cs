using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BookCatalog.Core.Wrappers
{
    public class DateOnlyXmlWrapper : IXmlSerializable
    {
        public DateOnly Date { get; set; }

        public DateOnlyXmlWrapper() { }

        public DateOnlyXmlWrapper(DateOnly date)
        {
            Date = date;
        }

        public XmlSchema? GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            Date = DateOnly.Parse(reader.ReadElementContentAsString());
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(Date.ToString("yyyy-MM-dd"));
        }

        public static implicit operator DateOnly(DateOnlyXmlWrapper wrapper) => wrapper.Date;

        public static implicit operator DateOnlyXmlWrapper(DateOnly date) => new DateOnlyXmlWrapper(date);
    }
}
