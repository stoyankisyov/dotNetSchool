using QueueCustomImplementation.Interfaces;

namespace QueueCustomImplementation.Extensions
{
    public static class QueueExtentions
    {
        public static IGenericQueue<T> Tail<T>(this IGenericQueue<T> originalQueue) where T : struct
        {
            var tailQueue = originalQueue.Clone();
            
            tailQueue.Dequeue();

            return tailQueue;
        }
    }
}
