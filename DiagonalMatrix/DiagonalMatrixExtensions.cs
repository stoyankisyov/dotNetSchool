namespace DiagonalMatrixNamespace
{
    public static class DiagonalMatrixExtensions
    {
        public static DiagonalMatrix Addition(this DiagonalMatrix firstDiagonalMatrix, DiagonalMatrix secondDiagonalMatrix)
        {
            var greaterSize = Math.Max(firstDiagonalMatrix.Size, secondDiagonalMatrix.Size);
            var newDiagonalMatrix = new int[greaterSize];

            for(int i = 0; i < greaterSize; i++)
            {
                var firstDiagonalMatrixValue = i < firstDiagonalMatrix.Size ? firstDiagonalMatrix.DiagonalElements[i] : 0;
                var secondDiagonalMatrixValue = i < secondDiagonalMatrix.Size ? secondDiagonalMatrix.DiagonalElements[i] : 0;

                newDiagonalMatrix[i] = firstDiagonalMatrixValue + secondDiagonalMatrixValue;
            }

            return new DiagonalMatrix(newDiagonalMatrix);
        }
    }
}
