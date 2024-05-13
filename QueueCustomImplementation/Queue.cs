using QueueCustomImplementation.Interfaces;

namespace QueueCustomImplementation
{
    public class Queue<T> : IGenericQueue<T> where T : struct
    {
        private int _headPosition = 0;
        private int _elementCount = 0;
        private int _initialCapacity;
        private T[] _elements;

        public Queue(int initialCapacity)
        {
            _initialCapacity = initialCapacity;
            _elements = new T[_initialCapacity * 2];
        }

        private Queue(int queueElementsCapacity, int headIndex, int elementCount) : this(queueElementsCapacity)
        {
            _headPosition = headIndex;
            _elementCount = elementCount;
        }

        public T Dequeue()
        {
            var firstItem = _elements[_headPosition];

            Drop();

            return firstItem;
        }

        public void Enqueue(T item)
        {
            if (_elementCount == _initialCapacity)
            {
                throw new InvalidOperationException("The queue is full.");
            }

            if (_headPosition == _initialCapacity)
            {
                if (_initialCapacity + _elementCount < _initialCapacity * 2)
                {
                    _elements[_elementCount + _initialCapacity] = item;
                }
            }
            else
            {
                if (_elementCount < _initialCapacity)
                {
                    _elements[_elementCount] = item;
                }
            }

            _elementCount++;
        }

        public bool IsEmpty()
        {
            return _elementCount == 0;
        }

        public override string ToString()
        {
            var result = "";

            for(int i=_headPosition; i<_elementCount; i++)
            {
                result += _elements[i];
            }

            return result;
        }

        public IGenericQueue<T> Clone()
        {
            var clonedQueue = new Queue<T>(_initialCapacity, _headPosition, _elementCount);

            if (_headPosition == _initialCapacity)
            {
                for (int i = 0; i < _elementCount; i++)
                {
                    clonedQueue._elements[_initialCapacity + i] = _elements[_initialCapacity + i];
                }
            }
            else
            {
                for (int i = 0; i < _elementCount; i++)
                {
                    clonedQueue._elements[i] = _elements[i];
                }
            }

            return clonedQueue;
        }

        private void Drop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            if (_headPosition < _initialCapacity)
            {
                _elements[0] = default!;

                for (int i = 0; i < _elementCount - 1; i++)
                {
                    _elements[_initialCapacity + i] = _elements[i + 1];
                    _elements[i + 1] = default!;
                }

                _headPosition = _initialCapacity;
            }
            else
            {
                _elements[_initialCapacity] = default!;

                for (int i = 0; i < _elementCount - 1; i++)
                {
                    _elements[i] = _elements[_initialCapacity + 1 + i];
                    _elements[_initialCapacity + 1 + i] = default!;
                }

                _headPosition = 0;
            }

            _elementCount--;
        }
    }
}
