using QueueCustomImplementation.Interfaces;

namespace QueueCustomImplementation.Extensions
{
    public static class QueueExtentions
    {
        public static IGenericQueue<T> Tail<T>(this IGenericQueue<T> originalQueue)
        {
            var tailQueue = originalQueue.Clone();
            
            tailQueue.Dequeue();

            return tailQueue;
        }
    }
}
