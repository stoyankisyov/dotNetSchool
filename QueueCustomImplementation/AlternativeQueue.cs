using QueueCustomImplementation.Interfaces;

namespace QueueCustomImplementation
{
    public class AlternativeQueue<T> : IGenericQueue<T> where T : struct
    {
        private int _elementCount = 0;
        private int _maxCapacity;
        private T[] _elements;

        public AlternativeQueue(int initialCapacity)
        {
            _maxCapacity = initialCapacity;
            _elements = new T[initialCapacity];
        }

        public IGenericQueue<T> Clone()
        {
            var clonnedQueue = new AlternativeQueue<T>(_maxCapacity);
            clonnedQueue._elementCount = _elementCount;

            for (int i = 0; i < _maxCapacity; i++)
            {
                clonnedQueue._elements[i] = _elements[i];
            }

            return clonnedQueue;
        }

        public T Dequeue()
        {
            if(_elementCount == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var headValue = _elements[0];

            for (int i = 0; i < _elementCount - 1; i++)
            {
                _elements[i] = _elements[i + 1];
            }

            _elements[_maxCapacity - 1] = default!;
            _elementCount--;

            return headValue;
        }

        public void Enqueue(T item)
        {
            if (_elementCount == _maxCapacity)
            {
                throw new InvalidOperationException("The queue is full.");
            }

            _elements[_elementCount] = item;
            _elementCount++;
        }

        public bool IsEmpty()
        {
            return _elementCount == 0;
        }
    }
}
