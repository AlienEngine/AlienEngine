using System.Collections.Generic;

namespace AlienEngine.Core.Threading
{
    public partial class Hashtable<TKey, TData>
    {
        class Enumerator : IEnumerator<KeyValuePair<TKey, TData>>
        {
            private int _currentIndex = -1;
            private Hashtable<TKey, TData> _table;

            public Enumerator(Hashtable<TKey, TData> table)
            {
                _table = table;
            }

            public KeyValuePair<TKey, TData> Current { get; private set; }

            public void Dispose()
            {
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                Node node;
                do
                {
                    _currentIndex++;
                    if (_table._array.Length <= _currentIndex)
                        return false;

                    node = _table._array[_currentIndex];
                } while (node.Token != Hashtable<TKey, TData>.Token.Used);

                Current = new KeyValuePair<TKey, TData>(node.Key, node.Data);
                return true;
            }

            public void Reset()
            {
                _currentIndex = -1;
            }
        }
    }
}