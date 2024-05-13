namespace QueueCustomImplementation.Interfaces
{
    public interface IGenericQueue<T> where T : struct
    {
        IGenericQueue<T> Clone();
        T Dequeue();
        void Enqueue(T item);
        bool IsEmpty();
    }
}
