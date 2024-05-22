using System.Collections;

namespace SparseMatrixApplication
{
    public class SparseMatrix : IEnumerable<long>
    {
        private readonly int _rowCount;
        private readonly int _columnCount;
        private readonly Dictionary<(int, int), long> _elements;
        private readonly IndexOutOfRangeException _indexOutOfRangeException = new IndexOutOfRangeException("Invalid indexes.");

        public SparseMatrix(int rowCount, int columnCount)
        {
            if (rowCount <= 0 || columnCount <= 0)
            {
                throw new ArgumentException("Invalid number of rows or columns.");
            }

            _rowCount = rowCount;
            _columnCount = columnCount;
            _elements = new Dictionary<(int, int), long>();
        }

        public long this[int i, int j]
        {
            get
            {
                if (!AreIndexesValid(i, j))
                {
                    throw _indexOutOfRangeException;
                }

                return _elements.TryGetValue((i, j), out long value) ? value : 0;
            }
            set
            {
                if (!AreIndexesValid(i, j))
                {
                    throw _indexOutOfRangeException;
                }

                if (value != 0)
                {
                    _elements[(i, j)] = value;
                }
                else
                {
                    _elements.Remove((i, j));
                }
            }
        }

        public override string ToString()
        {
            var result = "";

            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    result += this[i, j] + " ";
                }

                result += "\n";
            }

            return result;
        }

        public IEnumerator<long> GetEnumerator()
        {
            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<(int, int, long)> GetNonzeroElements()
        {
            var sortedElementsByColumn = _elements
                .OrderBy(x => x.Key.Item2)
                    .ThenBy(x => x.Key.Item1)
                .ToDictionary();

            foreach (var keyValuePair in sortedElementsByColumn)
            {
                yield return (keyValuePair.Key.Item1, keyValuePair.Key.Item2, keyValuePair.Value);
            }
        }

        public int GetCount(long element)
        {
            if (element != 0)
            {
                return _elements.Where(x => x.Value == element).Count();
            }

            return (_rowCount * _columnCount) - _elements.Count;
        }

        private bool AreIndexesValid(int row, int column)
        {
            return row >= 0 && row < _rowCount && column >= 0 && column < _columnCount;
        }
    }
}
