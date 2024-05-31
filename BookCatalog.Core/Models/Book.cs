#nullable disable

using System.Xml.Serialization;
using BookCatalog.Core.Helpers;
using BookCatalog.Core.Wrappers;

namespace BookCatalog.Core.Models
{
    public class Book
    {
        private string _title;

        [XmlElement("Isbn")]
        public string Isbn { get; set; }

        [XmlElement("Title")]
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title can't be null or empty");
                }

                _title = value;
            }
        }

        [XmlIgnore]
        public DateOnly? PublicationDate { get; set; }

        [XmlElement("PublicationDate")]
        public DateOnlyXmlWrapper PublicationDateXml
        {
            get => PublicationDate.HasValue ? new DateOnlyXmlWrapper(PublicationDate.Value) : null;
            set => PublicationDate = value?.Date;
        }

        [XmlArray("Authors")]
        [XmlArrayItem("Author")]
        public HashSet<Author> Authors { get; set; }

        public Book() { }

        public Book(string isbn, string title, DateOnly? publicationDate, HashSet<Author> authors)
        {
            if (!BookHelper.IsIsbnInCorrectFormat(isbn))
            {
                throw new ArgumentException("Invalid ISBN format.");
            }

            Isbn = BookHelper.UnifyIsbn(isbn);
            Title = title;
            PublicationDate = publicationDate;
            Authors = authors;
        }
    }
}
