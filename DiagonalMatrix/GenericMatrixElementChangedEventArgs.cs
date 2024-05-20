namespace DiagonalMatrixNamespace
{
    public class GenericMatrixElementChangedEventArgs<T> : EventArgs
    {
        public int I { get; }
        public int J { get; }
        public T OldValue { get; }
        public T NewValue { get; }

        public GenericMatrixElementChangedEventArgs(int i, int j, T oldValue, T newValue)
        {
            I = i;
            J = j;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
