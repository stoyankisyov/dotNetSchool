using BookCatalog;

namespace BookCatalogTests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullTitleExceptionSuccess()
        {
            var book = new Book("2234567894424", null!, new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyTitleExceptionSuccess()
        {
            var book = new Book("2234567894424", "", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidIsbnExceptionSuccess()
        {
            var book = new Book("2-2-3", "A", new DateOnly(2000, 12, 12), ["Mike", "Nike", "John"]);
        }
    }
}
