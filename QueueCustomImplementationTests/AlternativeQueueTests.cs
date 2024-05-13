using QueueCustomImplementation;
using QueueCustomImplementation.Extensions;

namespace QueueCustomImplementationTests
{
    [TestClass]
    public class AlternativeQueueTests
    {
        [TestMethod]
        public void EnqueueDequeueSuccess()
        {
            var queue = new AlternativeQueue<char>(3);
            queue.Enqueue('a');
            queue.Enqueue('b');
            queue.Enqueue('c');

            Assert.AreEqual('a', queue.Dequeue());
            Assert.AreEqual('b', queue.Dequeue());
            Assert.AreEqual('c', queue.Dequeue());
        }

        [TestMethod]
        public void EnqueueFailure()
        {
            var queue = new AlternativeQueue<int>(2);
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.ThrowsException<InvalidOperationException>(() => queue.Enqueue(3));
        }

        [TestMethod]
        public void DequeueFailure()
        {
            var queue = new AlternativeQueue<int>(1);

            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        }

        [TestMethod]
        public void IsEmptyPossitive()
        {
            var queue = new AlternativeQueue<int>(2);

            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyNegative()
        {
            var queue = new AlternativeQueue<int>(2);
            queue.Enqueue(1);

            Assert.IsFalse(queue.IsEmpty());
        }

        [TestMethod]
        public void CloneSuccess()
        {
            var originalQueue = new AlternativeQueue<int>(2);
            originalQueue.Enqueue(1);
            originalQueue.Enqueue(2);

            var cloned = originalQueue.Clone();

            Assert.IsNotNull(cloned);
            Assert.AreNotSame(cloned, originalQueue);

            while (!cloned.IsEmpty())
            {
                Assert.AreEqual(cloned.Dequeue(), originalQueue.Dequeue());
            }
        }

        [TestMethod]
        public void TailSuccess()
        {
            var originalQueue = new AlternativeQueue<int>(2);
            originalQueue.Enqueue(1);
            originalQueue.Enqueue(2);

            var tailQueue = originalQueue.Tail();

            Assert.IsNotNull(tailQueue);
            Assert.AreNotSame(tailQueue, originalQueue);

            originalQueue.Dequeue();

            while (!tailQueue.IsEmpty())
            {
                Assert.AreEqual(tailQueue.Dequeue(), originalQueue.Dequeue());
            }
        }
    }
}
