namespace DiagonalMatrixNamespace
{
    public class DiagonalMatrix
    {
        public int[] DiagonalElements { get; set; }
        public int Size { get; }

        public DiagonalMatrix(params int[] matrixElements)
        {
            if (matrixElements is null)
            {
                DiagonalElements = [];
                Size = 0;
            }
            else
            {
                Size = matrixElements.Length;
                DiagonalElements = new int[Size];
                Array.Copy(matrixElements, DiagonalElements, Size);
            }
        }

        public int this[int i, int j]
        {
            get => IsElementOnMainDiagonal(i, j) ? DiagonalElements[i] : 0;
            set
            {
                if (IsElementOnMainDiagonal(i, j) && AreIndexesCorrect(i, j))
                {
                    DiagonalElements[i] = value;
                }
            }
        }

        public int Track()
        {
            var diagonalMatrixElementsSum = 0;

            foreach (var element in DiagonalElements)
            {
                diagonalMatrixElementsSum += element;
            }

            return diagonalMatrixElementsSum;
        }

        public override bool Equals(object? obj)
        {
            if (obj is DiagonalMatrix matrixToCompare && matrixToCompare.Size == Size)
            {
                for (int i = 0; i < Size; i++)
                {
                    if (DiagonalElements[i] != matrixToCompare.DiagonalElements[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
                int hash = 13;

                foreach (var element in DiagonalElements)
                {
                    hash = hash * 7 + element;
                }

                return hash;
        }

        public override string ToString()
        {
            var result = string.Empty;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result += this[i, j].ToString() + " ";
                }
                result += "\n";
            }

            return result;
        }

        private bool IsElementOnMainDiagonal(int i, int j)
        {
            return i == j;
        }

        private bool AreIndexesCorrect(int i, int j)
        {
            return i >= 0 && j < Size;
        }
    }
}
