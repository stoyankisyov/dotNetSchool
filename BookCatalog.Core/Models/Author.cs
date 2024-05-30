#nullable disable

using System.Xml.Serialization;

namespace BookCatalog.Core.Models
{
    public class Author
    {
        private const int nameMaxSymbolCount = 200;

        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("BirthDate")]
        public DateOnly BirthDate { get; set; }

        public Author() { }

        public Author(string firstName, string lastName, DateOnly birthDate)
        {
            if (!IsNameLenghtValid(firstName, lastName))
            {
                throw new ArgumentException("Name more than 200 symbols.");
            }

            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        private bool IsNameLenghtValid(string firstName, string lastName)
            => firstName.Length + lastName.Length < nameMaxSymbolCount;
    }
}
