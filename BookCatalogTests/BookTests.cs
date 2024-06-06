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

            var book = new EBook(null, "Google.com", [author1], new List<string>() { "JPEG", "Docx"});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyTitleExceptionSuccess()
        {
            var author1 = new Author("John", "Doe", new DateOnly(1970, 1, 1));

            var book = new EBook("", "Google.com", [author1], new List<string>() { "JPEG", "Docx" });
        }
    }
}
