#nullable disable

using BookCatalog.Core.Wrappers;
using System.Xml.Serialization;

namespace BookCatalog.Core.Models
{
    public class Author
    {
        private const int nameMaxSymbolCount = 200;
        private string _firstName;
        private string _lastName;

        [XmlElement("FirstName")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length > nameMaxSymbolCount)
                {
                    throw new ArgumentException("First name exceeds 200 symbols.");
                }

                _firstName = value;
            }
        }

        [XmlElement("LastName")]
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length > nameMaxSymbolCount)
                {
                    throw new ArgumentException("Last name exceeds 200 symbols.");
                }

                _lastName = value;
            }
        }

        [XmlIgnore]
        public DateOnly BirthDate { get; set; }

        [XmlElement("BirthDate")]
        public DateOnlyXmlWrapper BirthDateXml
        {
            get => new DateOnlyXmlWrapper(BirthDate);
            set => BirthDate = value.Date;
        }

        public Author() { }

        public Author(string firstName, string lastName, DateOnly birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        // -> overriden for the JsonRepository logic, upon recieving from xml same authors are different objects /in each book/
        // which causes problems with saving in the json files /one file - one author -> different author objects/
        public override bool Equals(object obj)     
            => obj is Author other ? FirstName == other.FirstName && LastName == other.LastName && BirthDate == other.BirthDate : false;

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, BirthDate);
        }
    }
}
