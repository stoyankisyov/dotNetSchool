namespace DiagonalMatrixNamespace
{
    public static class GenericDiagonalMatrixExtentions
    {
        public static GenericDiagonalMatrix<T> Addition<T>(this GenericDiagonalMatrix<T> firstMatrix, GenericDiagonalMatrix<T> secondMatrix, Func<T, T, T> AddFunction)
        {
            var greaterSize = Math.Max(firstMatrix.Size, secondMatrix.Size);
            var resultMatrix = new GenericDiagonalMatrix<T>(greaterSize);

            for (int i = 0; i < greaterSize; i++)
            {
                resultMatrix[i, i] = AddFunction(firstMatrix[i, i], secondMatrix[i, i]);
            }

            return resultMatrix;
        }
    }
}
