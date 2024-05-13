using DiagonalMatrixNamespace;

namespace DiagonalMatrixTests
{
    [TestClass]
    public class GenericDiagonalMatrixTests
    {
        [TestMethod]
        public void GenericDiagonalMatrixSizeTestPositive()
        {
            var matrix = new GenericDiagonalMatrix<int>(3);

            Assert.AreEqual(3, matrix.Size);
        }

        [TestMethod]
        public void GenericDiagonalMatrixSizeTestNegative()
        {
            try
            {
                var matrix = new GenericDiagonalMatrix<int>(-3);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size can't be a negative number!", ex.Message);
            }
        }

        [TestMethod]
        public void IndexerValidIndexesOnMainDiagonalGetterSetterTestPositive()     // -> Element inside the matrix, on the main diagonal
        {
            var matrix = new GenericDiagonalMatrix<int>(2);
            matrix[0, 0] = 1;
            matrix[1, 1] = 2;

            Assert.AreEqual(2, matrix[1, 1]);
        }

        [TestMethod]
        public void IndexerValidIndexesOnMainDiagonalGetterTestNegative()    // -> Element inside the matrix, not on the main diagonal
        {
            var matrix = new GenericDiagonalMatrix<int>(2);
            matrix[0, 0] = 1;

            Assert.AreEqual(default, matrix[0, 1]);
        }

        [TestMethod]
        public void IndexerInvalidIndexesGetterExcepitonTestSuccess()
        {
            try
            {
                var matrix = new GenericDiagonalMatrix<int>(2);
                matrix[0, 0] = 1;
                
                var element = matrix[0, 5];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Specified argument was out of the range of valid values. (Parameter 'Invalid indexes!')", ex.Message);
            }
        }

        [TestMethod]
        public void IndexerInvalidIndexesSetterExcepitonTestSuccess()
        {
            try
            {
                var matrix = new GenericDiagonalMatrix<int>(2);
                matrix[5, 5] = 1;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("Specified argument was out of the range of valid values. (Parameter 'Invalid indexes!')", ex.Message);
            }
        }

        [TestMethod]
        public void AdditionExtentionMethodSuccess()
        {
            var firstMatrix = new GenericDiagonalMatrix<int>(2);
            firstMatrix[0, 0] = 1;
            firstMatrix[1, 1] = 2;

            var secondMatrix = new GenericDiagonalMatrix<int>(2);
            secondMatrix[0, 0] = 3;
            secondMatrix[1, 1] = 5;

            var expectedResultMatrix = new GenericDiagonalMatrix<int>(2);
            expectedResultMatrix[0, 0] = firstMatrix[0, 0] + secondMatrix[0, 0];
            expectedResultMatrix[1, 1] = firstMatrix[1, 1] + secondMatrix[1, 1];

            var additionMatrix = firstMatrix.Addition(secondMatrix, (x, y) => x + y);

            Assert.AreEqual(expectedResultMatrix[0, 0], additionMatrix[0, 0]);
            Assert.AreEqual(expectedResultMatrix[1, 1], additionMatrix[1, 1]);
        }

        [TestMethod]
        public void MatrixTrackedUndoSuccess()
        {
            var matrix = new GenericDiagonalMatrix<int>(2);
            matrix[0, 0] = 1;
            matrix[1, 1] = 2;

            var tracker = new MatrixTracker<int>(matrix);

            matrix[0, 0] = 5;
            Assert.AreEqual(5, matrix[0, 0]);

            tracker.Undo();
            Assert.AreEqual(1, matrix[0, 0]);
        }
    }
}
