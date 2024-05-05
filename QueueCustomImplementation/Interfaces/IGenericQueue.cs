namespace QueueCustomImplementation.Interfaces
{
    public interface IGenericQueue<T>
    {
        IGenericQueue<T> Clone();
        T Dequeue();
        void Drop();
        int Count();
        void Enqueue(T item);
        bool IsEmpty();
    }
}
