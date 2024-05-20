namespace DiagonalMatrixNamespace
{
    public class MatrixTracker<T>
    {
        private GenericDiagonalMatrix<T> _matrix;
        private Stack<GenericMatrixElementChangedEventArgs<T>> _changesDone = new Stack<GenericMatrixElementChangedEventArgs<T>>();

        public MatrixTracker(GenericDiagonalMatrix<T> matrix)
        {
            _matrix = matrix;
            Subscribe();
        }

        public void Unsubscribe()
        {
            _matrix.ElementChanged -= HandleElementChanged;
        }

        private void Subscribe()
        {
            _matrix.ElementChanged += HandleElementChanged;
        }

        private void HandleElementChanged (object? sender, GenericMatrixElementChangedEventArgs<T> e)
        {
            _changesDone.Push(e);
        }

        public void Undo()
        {
            if(_changesDone.Count > 0 )
            {
                var lastChange = _changesDone.Pop();
                _matrix[lastChange.I, lastChange.J] = lastChange.OldValue;
            }
        }
    }
}
