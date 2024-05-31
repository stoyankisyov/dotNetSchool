using BookCatalog.Core.Models;

namespace BookCatalogTests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullTitleExceptionSuccess()
        {
            var author1 = new Author("John", "Doe", new DateOnly(1970, 1, 1));

            var book = new Book("2234567894424", null!, new DateOnly(2000, 12, 12), [author1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyTitleExceptionSuccess()
        {
            var author1 = new Author("John", "Doe", new DateOnly(1970, 1, 1));

            var book = new Book("2234567894424", "", new DateOnly(2000, 12, 12), [author1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidIsbnExceptionSuccess()
        {
            var author1 = new Author("John", "Doe", new DateOnly(1970, 1, 1));

            var book = new Book("2-2-3", "A", new DateOnly(2000, 12, 12), [author1]);
        }
    }
}
