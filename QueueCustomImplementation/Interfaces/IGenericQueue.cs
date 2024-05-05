namespace QueueCustomImplementation.Interfaces
{
    public interface IGenericQueue<T>
    {
        IGenericQueue<T> Clone();   // Used to work with cloned queue in Tail() so the original queue will stay intact
        T Dequeue();    // Wasn't sure if when removing an element /as in build-in Queue/, it should be returned, or just removed. So this method returns and removes the element 
        void Drop();    // Just removes the first item /as explained in the task/
        int Count();     // Used for creating new Queue<T> in Tail() with one less element, since we work with abstraction and can't access [Queue].Elements.Lenght, or _elementCount
        void Enqueue(T item);
        bool IsEmpty();
    }
}
