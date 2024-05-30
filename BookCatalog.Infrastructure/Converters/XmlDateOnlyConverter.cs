using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BookCatalog.Infrastructure.Converters
{
    public class DateOnlyXmlConverter : IXmlSerializable
    {
        private DateOnly _date;

        public DateOnlyXmlConverter() { }

        public DateOnlyXmlConverter(DateOnly date)
        {
            _date = date;
        }

        public XmlSchema? GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            _date = DateOnly.Parse(reader.ReadElementContentAsString());
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(_date.ToString("yyyy-MM-dd"));
        }

        public static implicit operator DateOnly(DateOnlyXmlConverter converter)
        {
            return converter._date;
        }

        public static implicit operator DateOnlyXmlConverter(DateOnly date)
        {
            return new DateOnlyXmlConverter(date);
        }
    }
}