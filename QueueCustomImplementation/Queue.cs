using QueueCustomImplementation.Interfaces;

namespace QueueCustomImplementation
{
    public class Queue<T> : IGenericQueue<T>
    {
        private int _elementCount;
        private int _maxCapacity;
        private T[] _elements;

        public Queue(int queueElementsCapacity)
        {
            _maxCapacity = queueElementsCapacity;
            _elements = new T[_maxCapacity];
            _elementCount = 0;
        }

        public T Dequeue()
        {
            var firstItem = _elements[0];

            Drop();

            return firstItem;
        }

        public void Drop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var newElements = new T[_elementCount - 1];
            Array.Copy(_elements, 1, newElements, 0, _elementCount - 1);
            _elements = newElements;
            _elementCount--;
        }

        public void Enqueue(T item)
        {
            if (_elementCount == _maxCapacity)
            {
                throw new InvalidOperationException("The queue is full.");
            }

            IncreaseArraySize();
            _elements[_elementCount++] = item;
        }

        public int Count()
        {
            return _elementCount;
        }

        public bool IsEmpty()
        {
            return _elementCount == 0;
        }

        public override string ToString()
        {
            var result = "";

            foreach (var item in _elements)
            {
                result += item is not null ? item.ToString() : "";
            }

            return result;
        }

        public IGenericQueue<T> Clone()
        {
            var clonedQueue = new Queue<T>(_maxCapacity);

            foreach (var item in _elements)
            {
                clonedQueue.Enqueue(item);
            }

            return clonedQueue;
        }

        private void IncreaseArraySize()
        {
            var newArray = new T[_elementCount + 1];
            Array.Copy(_elements, newArray, _elementCount);
            _elements = newArray;
        }
    }
}
