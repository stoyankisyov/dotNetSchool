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

            var catalog = new Catalog<EBook>();
            catalog.Add(new EBook("sadas", "asdsad", new HashSet<Author>(2), new List<string>() { "PDF" }));
            catalog.Add(new EBook("fgghfgh", "asddfghdfgsad", new HashSet<Author>(2), new List<string>() { "PDF", "JSON" }));
            catalog.Add(new EBook("saddghdghas", "asddghdfghsad", new HashSet<Author>(2), new List<string>() { "PDF", "KAHSDJKASD" }));

            var sad = new Library<EBook>(catalog);

            var catalog1 = new Catalog<PaperBook>();
            catalog1.Add(new PaperBook(new List<Isbn>() { new Isbn("1234567890123") }, "dasdsad", new DateOnly(2211, 2, 2), "Tosho", new HashSet<Author>()));
            catalog1.Add(new PaperBook(new List<Isbn>() { new Isbn("1232567890123") }, "dasdsad", new DateOnly(2211, 2, 2), "21", new HashSet<Author>()));
            catalog1.Add(new PaperBook(new List<Isbn>() { new Isbn("1255567890123") }, "dasdsad", new DateOnly(2211, 2, 2), "Tosho", new HashSet<Author>()));

            var sa1d = new Library<PaperBook>(catalog1);
            
        }

        //private static bool CheckCatalogIdentity(Catalog original, Catalog retrieved)
        //        => original.Books.Count == retrieved.Books.Count &&
        //                           retrieved.Books.All(book => original.Books.ContainsKey(book.Key) && BooksAreEqual(original.Books[book.Key], book.Value));

        //private static bool BooksAreEqual(Book original, Book retrieved)
        //        => original.Isbn == retrieved.Isbn &&
        //                           original.Title == retrieved.Title &&
        //                           original.PublicationDate == retrieved.PublicationDate &&
        //                           original.Authors.Count == retrieved.Authors.Count &&
        //                           original.Authors.All(author => retrieved.Authors.Any(a => a.Equals(author)));
    }
}
