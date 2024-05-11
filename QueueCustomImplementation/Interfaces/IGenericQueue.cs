namespace QueueCustomImplementation.Interfaces
{
    public interface IGenericQueue<T>
    {
        IGenericQueue<T> Clone();
        T Dequeue();
        void Enqueue(T item);
        bool IsEmpty();
    }
}
