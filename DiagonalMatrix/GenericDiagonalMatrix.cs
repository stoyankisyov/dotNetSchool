namespace DiagonalMatrixNamespace
{
    public class GenericDiagonalMatrix<T>
    {
        private T[] _diagonalElements;
        private ArgumentOutOfRangeException invalidIndexesException = new ArgumentOutOfRangeException("Invalid indexes!");

        public int Size { get; }

        public event EventHandler<GenericMatrixElementChangedEventArgs<T>>? ElementChanged;

        public GenericDiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Size can't be a negative number!");
            }

            Size = size;
            _diagonalElements = new T[Size];
        }

        public T this[int i, int j]
        {
            get
            {
                if (!AreIndexesValid(i, j))
                {
                    throw invalidIndexesException;
                }

                return IsElementOnMainDiagonal(i, j) ? _diagonalElements[i] : default!;
            }
            set
            {
                if (!AreIndexesValid(i, j))
                {
                    throw invalidIndexesException;
                }

                if (IsElementOnMainDiagonal(i, j))
                {
                    if (!Equals(value, _diagonalElements[i]))
                    {
                        T oldValue = _diagonalElements[i];
                        _diagonalElements[i] = value;
                        ElementChanged?.Invoke(this, new GenericMatrixElementChangedEventArgs<T>(i, j, oldValue, value));
                    }
                }
            }
        }

        private bool AreIndexesValid(int i, int j)
        {
            return i >= 0 && j >= 0 && i < Size && j < Size;
        }

        private bool IsElementOnMainDiagonal(int i, int j)
        {
            return i == j;
        }
    }
}
