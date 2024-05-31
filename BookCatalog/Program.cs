using BookCatalog.Core.Models;
using BookCatalog.Infrastructure.Repositories;

namespace BookCatalog
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var author1 = new Author("John", "Doe", new DateOnly(1970, 1, 1));
            var author2 = new Author("Jane", "Smith", new DateOnly(1980, 2, 2));
            var author3 = new Author("Emily", "Johnson", new DateOnly(1990, 3, 3));
            var author4 = new Author("Michael", "Brown", new DateOnly(1985, 4, 4));
            var author5 = new Author("Chris", "Davis", new DateOnly(1975, 5, 5));

            var books = new List<Book>
            {
                new Book("1234567890123", "The Great Adventure", new DateOnly(2000, 1, 1), [author1, author2]),
                new Book("2345678901234", "Mystery of the Lost City", new DateOnly(2001, 2, 2), [author1]),
                new Book("3456789012345", "Journey to the Unknown", new DateOnly(2002, 3, 3), [author2, author3]),
                new Book("4567890123456", "Secrets of the Ancient World", new DateOnly(2003, 4, 4), [author3]),
                new Book("5678901234567", "The Haunted Manor", new DateOnly(2004, 5, 5), [author4, author5]),
                new Book("6789012345678", "Quest for the Hidden Treasure", new DateOnly(2005, 6, 6), [author4]),
                new Book("7890123456789", "The Time Traveler's Diary", new DateOnly(2006, 7, 7), [author5]),
                new Book("8901234567890", "Tales from the Future", new DateOnly(2007, 8, 8), [author1, author3]),
                new Book("9012345678901", "Legends of the Forgotten Realm", new DateOnly(2008, 9, 9), [author2, author4]),
                new Book("0123456789012", "Echoes of the Past", new DateOnly(2009, 10, 10), [author1, author5])
            };

            var catalog = new Catalog();
            catalog.AddRange(books);

            var xmlRepository = new XmlCatalogRepository();
            await xmlRepository.AddAsync(catalog);

            var retrievedCatalogFromXml = await xmlRepository.GetAsync();

            var xmlRetrieveSuccessful = CheckCatalogIdentity(catalog, retrievedCatalogFromXml);

            var jsonRepository = new JsonCatalogRepository();
            await jsonRepository.AddAsync(retrievedCatalogFromXml);

            var retrievedCatalogFromJson = await jsonRepository.GetAsync();

            var jsonRetrieveCheck = CheckCatalogIdentity(catalog, retrievedCatalogFromJson);
        }

        private static bool CheckCatalogIdentity(Catalog original, Catalog retrieved)
                => original.Books.Count == retrieved.Books.Count &&
                                   retrieved.Books.All(book => original.Books.ContainsKey(book.Key) && BooksAreEqual(original.Books[book.Key], book.Value));

        private static bool BooksAreEqual(Book original, Book retrieved)
                => original.Isbn == retrieved.Isbn &&
                                   original.Title == retrieved.Title &&
                                   original.PublicationDate == retrieved.PublicationDate &&
                                   original.Authors.Count == retrieved.Authors.Count &&
                                   original.Authors.All(author => retrieved.Authors.Any(a => a.Equals(author)));
    }
}
