#nullable disable

using System.Xml.Serialization;
using BookCatalog.Core.Helpers;

namespace BookCatalog.Core.Models
{
    public class Book
    {
        [XmlElement("Isbn")]
        public string Isbn { get; set; }

        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("PublicationDate")]
        public DateOnly? PublicationDate { get; set; }

        [XmlArray("Authors")]
        [XmlArrayItem("Author")]
        public HashSet<Author> Authors { get; set; }

        public Book() { }

        public Book(string isbn, string title, DateOnly? publicationDate, HashSet<Author> authors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title can't be null or empty");
            }

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
