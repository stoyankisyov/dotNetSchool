using SparseMatrixApplication;

namespace SparseMatrixTests
{
    [TestClass]
    public class SparseMatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidRowColumnCountExceptionSuccess()
        {
            var sparseMatrix = new SparseMatrix(-1, 0);
        }

        [TestMethod]
        public void IndexerGetSetSuccess()
        {
            var sparseMatrix = new SparseMatrix(2, 2);
            sparseMatrix[0, 0] = 1L;
            sparseMatrix[1, 1] = 2L;

            Assert.AreEqual(1L, sparseMatrix[0, 0]);
            Assert.AreEqual(2L, sparseMatrix[1, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexerGetSetFail()
        {
            var sparseMatrix = new SparseMatrix(2, 2);
            sparseMatrix[3, 3] = 1L;
        }

        [TestMethod]
        public void IndexerSetZeroSuccess()
        {
            var sparseMatrix = new SparseMatrix(2, 2);
            sparseMatrix[0, 0] = 1L;

            Assert.AreEqual(1L, sparseMatrix[0, 0]);

            sparseMatrix[0, 0] = 0;

            Assert.AreEqual(0, sparseMatrix[0, 0]);
        }

        [TestMethod]
        public void ToStringOverrideSuccess()
        {
            var sparseMatrix = new SparseMatrix(2, 2);
            sparseMatrix[0, 0] = 1L;

            Assert.AreEqual("1 0 \n0 0 \n", sparseMatrix.ToString());
        }

        [TestMethod]
        public void GetNonzeroElementsSuccess()
        {
            var sparseMatrix = new SparseMatrix(2, 5);
            sparseMatrix[0, 0] = 1L;
            sparseMatrix[0, 1] = 1L;
            sparseMatrix[0, 2] = 1L;
            sparseMatrix[1, 0] = 2L;

            var expectedResult = new List<(int, int, long)>
            {
               (0, 0, 1L),
               (1, 0, 2L),
               (0, 1, 1L),
               (0, 2, 1L)
            };

            var actualResult = sparseMatrix.GetNonzeroElements().ToList();

            Assert.AreEqual(expectedResult[0], actualResult[0]);
            Assert.AreEqual(expectedResult[1], actualResult[1]);
            Assert.AreEqual(expectedResult[2], actualResult[2]);
            Assert.AreEqual(expectedResult[3], actualResult[3]);
        }

        [TestMethod]
        public void GetCountElementZeroSuccess()
        {
            var sparseMatrix = new SparseMatrix(3, 2);
            sparseMatrix[0, 0] = 1L;
            sparseMatrix[1, 1] = 2L;

            Assert.AreEqual(4, sparseMatrix.GetCount(0));
        }

        [TestMethod]
        public void GetCountElementNotZeroSuccess()
        {
            var sparseMatrix = new SparseMatrix(3, 2);
            sparseMatrix[0, 0] = 1L;
            sparseMatrix[1, 0] = 2L;
            sparseMatrix[1, 1] = 1L;

            Assert.AreEqual(2, sparseMatrix.GetCount(1L));
        }
    }
}