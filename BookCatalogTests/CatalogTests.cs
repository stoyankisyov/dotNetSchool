using BookCatalog;

namespace BookCatalogTests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void AddSkipExistingBookSuccess()
        {
            var catalog = new Catalog();
            catalog.Add(new Book("123-4-56-789123-4", "A", new DateOnly(2000, 1, 1), ["John", "Jim", "Peter", "Kate"]));
            catalog.Add(new Book("123-4-56-789123-4", "A", new DateOnly(2000, 1, 1), ["John", "Jim", "Peter", "Kate"]));
            catalog.Add(new Book("2234567894424", "B", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"]));

            Assert.AreEqual(2, catalog.Count());
        }

        [TestMethod]
        public void IndexerGetSuccess()
        {
            var catalog = new Catalog();
            catalog.Add(new Book("2234567894424", "B", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"]));
            catalog.Add(new Book("123-4-56-789123-4", "A", new DateOnly(2000, 1, 1), ["John", "Jim", "Peter", "Kate"]));

            Assert.AreEqual("A", catalog["123-4-56-789123-4"].Title);
            Assert.AreEqual("1234567891234", catalog["123-4-56-789123-4"].Isbn);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexerGetFail()
        {
            var catalog = new Catalog();
            catalog.Add(new Book("2234567894424", "B", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"]));
            catalog.Add(new Book("123-4-56-789123-4", "A", new DateOnly(2000, 1, 1), ["John", "Jim", "Peter", "Kate"]));

            var book = catalog["Invalid ISBN"];
        }

        [TestMethod]
        public void GetSortedBooksSuccess()
        {
            var catalog = new Catalog();
            catalog.Add(new Book("2234567894424", "B", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"]));
            catalog.Add(new Book("123-4-56-789123-4", "A", new DateOnly(2000, 1, 1), ["John", "Jim", "Peter", "Kate"]));

            var expectedResult = new List<Book>()
            {
                new Book("123-4-56-789123-4", "A", new DateOnly(2000, 1, 1), ["John", "Jim", "Peter", "Kate"]),
                new Book("2234567894424", "B", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"])
            };

            var actualResult = catalog.GetSortedBooks();

            // Using ISBN since it is unique for every book in the dictionaly
            Assert.AreEqual(expectedResult[0].Isbn, actualResult[0].Isbn);
            Assert.AreEqual(expectedResult[1].Isbn, actualResult[1].Isbn);
        }

        [TestMethod]
        public void GetBooksByAuthorSuccess()
        {
            var catalog = new Catalog();
            catalog.Add(new Book("123-4-56-789123-4", "A", new DateOnly(2000, 1, 1), ["John", "Jim", "Peter", "Kate"]));
            catalog.Add(new Book("2234567894424", "B", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"]));

            var expectedResultJohn = new List<Book>()
            {
                new Book("123-4-56-789123-4", "A", new DateOnly(2000, 1, 1), ["John", "Jim", "Peter", "Kate"]),
                new Book("2234567894424", "B", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"])
            };

            var actualResultJohn = catalog.GetBooksByAuthor("John");

            Assert.AreEqual(expectedResultJohn.Count, actualResultJohn.Count);
            Assert.AreEqual(expectedResultJohn[0].Isbn, actualResultJohn[0].Isbn);
            Assert.AreEqual(expectedResultJohn[1].Isbn, actualResultJohn[1].Isbn);

            // Additional check with author who has only one book
            var expectedResultMike = new List<Book>()
            {
                new Book("2234567894424", "B", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"])
            };

            var actualResultMike = catalog.GetBooksByAuthor("Mike");

            Assert.AreEqual(1, actualResultMike.Count);
            Assert.AreEqual(expectedResultMike[0].Isbn, actualResultMike[0].Isbn);
        }

        [TestMethod]
        public void GetAllAuthorsBookCountSuccess()
        {
            var catalog = new Catalog();
            catalog.Add(new Book("123-4-56-789123-4", "A", new DateOnly(2000, 1, 1), ["John"]));
            catalog.Add(new Book("2234567894424", "B", new DateOnly(2000, 12, 12), ["Mike", "John"]));

            var expectedResult = new List<(string, int)>
            {
                ("John", 2),
                ("Mike", 1)
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