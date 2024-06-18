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
            var isbn = new Isbn("1234567890123");

            var catalog = new Catalog<PaperBook>();
            catalog.Add(new PaperBook([isbn], "title", null, "publiser", [author1, author2]));
            catalog.Add(new PaperBook([isbn], "title", null, "publiser", [author1, author2]));

            Assert.AreEqual(1, catalog.Count());
        }
    }
}