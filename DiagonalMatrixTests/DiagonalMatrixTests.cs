using DiagonalMatrixNamespace;

namespace DiagonalMatrixTests
{
    [TestClass]
    public class DiagonalMatrixTests
    {
        [TestMethod]
        public void DiagonalMatrixSizeTestPossitive()
        {
            var diagonalMatrix = new DiagonalMatrix(1, 2, 3);
            Assert.AreEqual(3, diagonalMatrix.Size);
        }

        [TestMethod]
        public void DiagonalMatrixSizeTestNegative()
        {
            var diagonalMatrix = new DiagonalMatrix();
            Assert.AreEqual(0, diagonalMatrix.Size);
        }

        [TestMethod]
        public void IndexerGetterTestPossitive()
        {
            var diagonalMatrix = new DiagonalMatrix(1);
            Assert.AreEqual(1, diagonalMatrix[0, 0]);
        }

        [TestMethod]
        public void IndexerGetterTestNegative()
        {
            var diagonalMatrix = new DiagonalMatrix(1);
            Assert.AreEqual(0, diagonalMatrix[1, -2]);
        }

        [TestMethod]
        public void IndexerSetterTestSuccess()
        {
            var diagonalMatrix = new DiagonalMatrix(1);
            diagonalMatrix[0, 0] = 5;
            Assert.AreEqual(5, diagonalMatrix[0, 0]);
        }

        [TestMethod]
        public void IndexerSetterTestFail()
        {
            var diagonalMatrix = new DiagonalMatrix(1);
            diagonalMatrix[1, 2] = 5;
            Assert.AreEqual(1, diagonalMatrix[0, 0]);
        }

        [TestMethod]
        public void TrackSuccess()
        {
            var diagonalMatrix = new DiagonalMatrix(1, 2, 3);
            Assert.AreEqual(6, diagonalMatrix.Track());
        }

        [TestMethod]
        public void EqualsOverrideSuccess()
        {
            var firstDiagonalMatrix = new DiagonalMatrix(1, 2, 3);
            var secondDiagonalMatrix = new DiagonalMatrix(1, 2, 3);
            Assert.IsTrue(firstDiagonalMatrix.Equals(secondDiagonalMatrix));
        }

        [TestMethod]
        public void EqualsOverrideFail()
        {
            var firstDiagonalMatrix = new DiagonalMatrix(1, 2, 3);
            var secondDiagonalMatrix = new DiagonalMatrix(4, 5, 6);
            Assert.IsFalse(firstDiagonalMatrix.Equals(secondDiagonalMatrix));
        }

        [TestMethod]
       public void ToStringOverrideSuccess()
        {
            var diagonalMatrix = new DiagonalMatrix(1, 2);
            Assert.AreEqual("1 0 \n0 2 \n", diagonalMatrix.ToString());
        }

        [TestMethod]
        public void AdditionExtentionMethodSuccess()
        {
            var firstDiagonalMatrix = new DiagonalMatrix(1, 2, 3);
            var secondDiagonalMatrix = new DiagonalMatrix(1, 2, 3);
            var resultDiagonalMatrix = new DiagonalMatrix(2, 4, 6);
            Assert.AreEqual(resultDiagonalMatrix, firstDiagonalMatrix.Addition(secondDiagonalMatrix));
        }

        [TestMethod]
        public void AdditionExtentionMethodFail()
        {
            var firstDiagonalMatrix = new DiagonalMatrix(1, 2, 3);
            var secondDiagonalMatrix = new DiagonalMatrix(1, 2, 3);
            var resultDiagonalMatrix = new DiagonalMatrix(1, 2, 3);
            Assert.AreNotEqual(resultDiagonalMatrix, firstDiagonalMatrix.Addition(secondDiagonalMatrix));
        }
    }
}