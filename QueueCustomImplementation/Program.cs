﻿using QueueCustomImplementation.Extensions;

namespace QueueCustomImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine($"Original queue: {queue}");

            Console.WriteLine($"Head element value after Dequeue(): {queue.Dequeue()}");

            Console.WriteLine($"The queue is empty: {queue.IsEmpty()}");

            queue.Enqueue(5);
            queue.Enqueue(6);

            Console.WriteLine($"After Increasing size to maximum: {queue}");

            var tailQueue = queue.Tail();
            Console.WriteLine($"Queue after Tail(): {tailQueue}");
            Console.WriteLine($"Original unchanged queue: {queue}");

            Console.WriteLine("Going above max capacity, exception is thrown: ");
            queue.Enqueue(8);

            Console.Write("Dequeue from empty queue, exception is thrown: ");
            var emptyQueue = new Queue<char>(1);
            emptyQueue.Dequeue();

            var alternativeQueue = new AlternativeQueue<int>(5);
            alternativeQueue.Enqueue(1);
            alternativeQueue.Enqueue(2);
            alternativeQueue.Enqueue(3);
            alternativeQueue.Enqueue(4);
            alternativeQueue.Enqueue(5);
            alternativeQueue.Dequeue();
            alternativeQueue.Enqueue(5);
            var tail = alternativeQueue.Tail();
        }
    }
}
