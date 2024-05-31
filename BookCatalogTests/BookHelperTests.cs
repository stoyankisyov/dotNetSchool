using BookCatalog.Core.Helpers;

namespace BookCatalogTests
{
    [TestClass]
    public class BookHelperTests
    {
        [TestMethod]
        public void UnifyIsbnSuccess()
        {
            Assert.AreEqual("1234567891234", BookHelper.UnifyIsbn("123-4-56-789123-4"));
        }

        [TestMethod]
        public void IsIsbnCorrectFormatSuccess()
        {
            Assert.IsTrue(BookHelper.IsIsbnInCorrectFormat("123-4-56-789123-4"));
            Assert.IsTrue(BookHelper.IsIsbnInCorrectFormat("1234567891234"));
        }

        [TestMethod]
        public void IsIsbnCorrectFormatFail()
        {
            Assert.IsFalse(BookHelper.IsIsbnInCorrectFormat("123-4"));
            Assert.IsFalse(BookHelper.IsIsbnInCorrectFormat("1-2-3-4-5-6-7-8-9-1-2-3-4"));
            Assert.IsFalse(BookHelper.IsIsbnInCorrectFormat("1#2-3-4@5-6-7-8A1-2-B-4"));
            Assert.IsFalse(BookHelper.IsIsbnInCorrectFormat("  "));
        }
    }
}
