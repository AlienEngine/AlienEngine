// Implemention from Joe Duffy's blog:
// http://www.bluebytesoftware.com/blog/2008/08/12/BuildingACustomThreadPoolSeriesPart2AWorkStealingQueue.aspx

using System.Threading;

namespace AlienEngine.Core.Threading
{
    public class Deque<T>
    {
        private const int INITIAL_SIZE = 32;
        private T[] _array = new T[INITIAL_SIZE];
        private int _mask = INITIAL_SIZE - 1;
        private volatile int _headIndex = 0;
        private volatile int _tailIndex = 0;
        private object _foreignLock = new object();

        public bool IsEmpty => _headIndex >= _tailIndex;

        public int Count => _tailIndex - _headIndex;

        public void LocalPush(T obj)
        {
            int tail = _tailIndex;
            if (tail < _headIndex + _mask)
            {
                _array[tail & _mask] = obj;
                _tailIndex = tail + 1;
            }
            else
            {
                lock (_foreignLock)
                {
                    int head = _headIndex;
                    int count = _tailIndex - _headIndex;

                    if (count >= _mask)
                    {
                        T[] newArray = new T[_array.Length << 1];
                        for (int i = 0; i < count; i++)
                            newArray[i] = _array[(i + head) & _mask];

                        // Reset the field values, incl. the mask.
                        _array = newArray;
                        _headIndex = 0;
                        _tailIndex = tail = count;
                        _mask = (_mask << 1) | 1;
                    }
                    _array[tail & _mask] = obj;
                    _tailIndex = tail + 1;
                }
            }
        }

        public bool LocalPop(ref T obj)
        {
            int tail = _tailIndex;
            if (_headIndex >= tail)
                return false;

            tail -= 1;
            Interlocked.Exchange(ref _tailIndex, tail);

            if (_headIndex <= tail)
            {
                obj = _array[tail & _mask];
                return true;
            }
            else
            {
                lock (_foreignLock)
                {
                    if (_headIndex <= tail)
                    {
                        // Element still available. Take it.
                        obj = _array[tail & _mask];
                        return true;
                    }
                    else
                    {
                        // We lost the race, element was stolen, restore the tail.
                        _tailIndex = tail + 1;
                        return false;
                    }
                }
            }
        }

        public bool TrySteal(ref T obj)
        {
            bool taken = false;
            try
            {
                taken = System.Threading.Monitor.TryEnter(_foreignLock);
                if (taken)
                {
                    int head = _headIndex;
                    Interlocked.Exchange(ref _headIndex, head + 1);
                    if (head < _tailIndex)
                    {
                        obj = _array[head & _mask];
                        return true;
                    }
                    else
                    {
                        _headIndex = head;
                        return false;
                    }
                }
            }
            finally
            {
                if (taken)
                    System.Threading.Monitor.Exit(_foreignLock);
            }

            return false;
        }
    }
}