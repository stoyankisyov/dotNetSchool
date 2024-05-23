using System.Collections;
using System.Text;

namespace SparseMatrixApplication
{
    public class SparseMatrix : IEnumerable<long>
    {
        private readonly IndexOutOfRangeException _invalidIndexesException = new IndexOutOfRangeException("Invalid indexes.");

        public int RowCount { get; }
        private int ColumnCount { get; }
        private Dictionary<(int, int), long> Elements { get; }

        public SparseMatrix(int rowCount, int columnCount)
        {
            if (rowCount <= 0 || columnCount <= 0)
            {
                throw new ArgumentException("Invalid number of rows or columns.");
            }

            RowCount = rowCount;
            ColumnCount = columnCount;
            Elements = [];
        }

        public long this[int i, int j]
        {
            get
            {
                if (!AreIndexesValid(i, j))
                {
                    throw _invalidIndexesException;
                }

                return Elements.TryGetValue((i, j), out long value) ? value : 0;
            }
            set
            {
                if (!AreIndexesValid(i, j))
                {
                    throw _invalidIndexesException;
                }

                if (value != 0)
                {
                    Elements[(i, j)] = value;
                }
                else
                {
                    Elements.Remove((i, j));
                }
            }
        }

        public override string ToString()
        {
            var stringBuilderResult = new StringBuilder();

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    stringBuilderResult.Append(this[i, j] + " ");
                }

                stringBuilderResult.Append("\n");
            }

            return stringBuilderResult.ToString();
        }

        public IEnumerator<long> GetEnumerator()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
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
            => Elements.OrderBy(x => x.Key.Item2).ThenBy(x => x.Key.Item1).Select(x => (x.Key.Item1, x.Key.Item2, x.Value));

        public int GetCount(long element)
            => element != 0 ? Elements.Where(x => x.Value == element).Count() : (RowCount * ColumnCount) - Elements.Count;

        private bool AreIndexesValid(int row, int column)
            => row >= 0 && row < RowCount && column >= 0 && column < ColumnCount;
    }
}
