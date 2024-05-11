namespace QueueCustomImplementation.Interfaces
{
    public interface IGenericQueue<T>
    {
        IGenericQueue<T> Clone();
        T Dequeue();
        int Count();
        void Enqueue(T item);
        bool IsEmpty();
    }
}
