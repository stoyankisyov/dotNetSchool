using BookCatalog;

namespace BookCatalogTests
{
    [TestClass]
    public class BookHelperTests
    {
        [TestMethod]
        public void UnifyIsbnSuccess()
        {
            var bookHelper = new BookHelper();

            Assert.AreEqual("1234567891234", bookHelper.UnifyIsbn("123-4-56-789123-4"));
        }

        [TestMethod]
        public void IsIsbnCorrectFormatSuccess()
        {
            var bookHelper = new BookHelper();

            Assert.IsTrue(bookHelper.IsIsbnInCorrectFormat("123-4-56-789123-4"));
            Assert.IsTrue(bookHelper.IsIsbnInCorrectFormat("1234567891234"));
        }

        [TestMethod]
        public void IsIsbnCorrectFormatFail()
        {
            var bookHelper = new BookHelper();

            Assert.IsFalse(bookHelper.IsIsbnInCorrectFormat("123-4"));
            Assert.IsFalse(bookHelper.IsIsbnInCorrectFormat("1-2-3-4-5-6-7-8-9-1-2-3-4"));
            Assert.IsFalse(bookHelper.IsIsbnInCorrectFormat("1#2-3-4@5-6-7-8A1-2-B-4"));
            Assert.IsFalse(bookHelper.IsIsbnInCorrectFormat("  "));
        }
    }
}
