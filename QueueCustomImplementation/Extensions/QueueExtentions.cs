using QueueCustomImplementation.Interfaces;

namespace QueueCustomImplementation.Extensions
{
    public static class QueueExtentions
    {
        public static IGenericQueue<T> Tail<T>(this IGenericQueue<T> originalQueue)
        {
            var clonedQueue = originalQueue.Clone();
            var tailQueue = new Queue<T>(clonedQueue.Count() - 1);

            if(clonedQueue.IsEmpty())
            {
                return tailQueue;
            }

            clonedQueue.Drop();

            while(!clonedQueue.IsEmpty())
            {
                tailQueue.Enqueue(clonedQueue.Dequeue());
            }

            return tailQueue;
        }
    }
}
