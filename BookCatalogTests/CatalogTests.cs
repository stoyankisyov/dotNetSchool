using BookCatalog.Core.Models;

namespace BookCatalogTests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void AddSkipExistingBookSuccess()
        {
            var author1 = new Author("John", "Doe", new DateOnly(1970, 1, 1));
            var author2 = new Author("Jane", "Smith", new DateOnly(1980, 2, 2));

            var catalog = new Catalog();
            catalog.Add(new Book("1234567890123", "The Great Adventure", new DateOnly(2000, 1, 1), [author1, author2]));
            catalog.Add(new Book("1234567890123", "The Great Adventure", new DateOnly(2000, 1, 1), [author1, author2]));
            catalog.Add(new Book("2345678901234", "Mystery of the Lost City", new DateOnly(2001, 2, 2), [author1]));

            Assert.AreEqual(2, catalog.Count());
        }

        [TestMethod]
        public void IndexerGetSuccess()
        {
            var author1 = new Author("John", "Doe", new DateOnly(1970, 1, 1));
            var author2 = new Author("Jane", "Smith", new DateOnly(1980, 2, 2));

            var catalog = new Catalog();
            catalog.Add(new Book("1234567890123", "The Great Adventure", new DateOnly(2000, 1, 1), [author1, author2]));
            catalog.Add(new Book("2345678901234", "Mystery of the Lost City", new DateOnly(2001, 2, 2), [author1]));

            Assert.AreEqual("The Great Adventure", catalog["1234567890123"].Title);
            Assert.AreEqual("1234567890123", catalog["123-4-56-789012-3"].Isbn);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexerGetFail()
        {
            var author1 = new Author("John", "Doe", new DateOnly(1970, 1, 1));
            var author2 = new Author("Jane", "Smith", new DateOnly(1980, 2, 2));

            var catalog = new Catalog();
            catalog.Add(new Book("1234567890123", "The Great Adventure", new DateOnly(2000, 1, 1), [author1, author2]));

            var book = catalog["Invalid ISBN"];
        }

        [TestMethod]
        public void GetSortedBooksSuccess()
        {
            var author1 = new Author("John", "Doe", new DateOnly(1970, 1, 1));
            var author2 = new Author("Jane", "Smith", new DateOnly(1980, 2, 2));

            var catalog = new Catalog();
            catalog.Add(new Book("1234567890123", "The Great Adventure", new DateOnly(2000, 1, 1), [author1, author2]));
            catalog.Add(new Book("2345678901234", "Mystery of the Lost City", new DateOnly(2001, 2, 2), [author1]));

            var expectedResult = new List<Book>()
            {
                new Book("2345678901234", "Mystery of the Lost City", new DateOnly(2001, 2, 2), [author1]),
                new Book("1234567890123", "The Great Adventure", new DateOnly(2000, 1, 1), [author1, author2])
            };

            var actualResult = catalog.GetSortedBooks();

            // Using ISBN since it is unique for every book in the dictionaly
            Assert.AreEqual(expectedResult[0].Isbn, actualResult[0].Isbn);
            Assert.AreEqual(expectedResult[1].Isbn, actualResult[1].Isbn);
        }

        [TestMethod]
        public void GetBooksByAuthorSuccess()
        {
            var author1 = new Author("John", "Doe", new DateOnly(1970, 1, 1));
            var author2 = new Author("Jane", "Smith", new DateOnly(1980, 2, 2));

            var catalog = new Catalog();
            catalog.Add(new Book("1234567890123", "The Great Adventure", new DateOnly(2000, 1, 1), [author1, author2]));
            catalog.Add(new Book("2345678901234", "Mystery of the Lost City", new DateOnly(2001, 2, 2), [author1]));

            var expectedResultJohn = new List<Book>()
            {
                new Book("1234567890123", "The Great Adventure", new DateOnly(2000, 1, 1), [author1, author2])
            };

            var actualResultJohn = catalog.GetBooksByAuthor(author2);

            Assert.AreEqual(expectedResultJohn.Count, actualResultJohn.Count);
            Assert.AreEqual(expectedResultJohn[0].Isbn, actualResultJohn[0].Isbn);
        }

        [TestMethod]
        public void GetAllAuthorsBookCountSuccess()
        {
            var author1 = new Author("John", "Doe", new DateOnly(1970, 1, 1));
            var author2 = new Author("Jane", "Smith", new DateOnly(1980, 2, 2));

            var catalog = new Catalog();
            catalog.Add(new Book("1234567890123", "The Great Adventure", new DateOnly(2000, 1, 1), [author1, author2]));
            catalog.Add(new Book("2345678901234", "Mystery of the Lost City", new DateOnly(2001, 2, 2), [author1]));

            var expectedResult = new List<(string, int)>
            {
                ("JohnDoe", 2),
                ("JaneSmith", 1)
            };

            var actualResult = catalog.GetAllAuthorsBookCount();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            Assert.AreEqual(expectedResult[0].Item1, actualResult[0].Item1);
            Assert.AreEqual(expectedResult[0].Item2, actualResult[0].Item2);
            Assert.AreEqual(expectedResult[1].Item1, actualResult[1].Item1);
            Assert.AreEqual(expectedResult[1].Item2, actualResult[1].Item2);
        }
    }
}