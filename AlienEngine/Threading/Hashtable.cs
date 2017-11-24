using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AlienEngine.Core.Threading
{
    /// <summary>
    /// A thread safe hashtable.
    /// </summary>
    /// <typeparam name="TKey">The type of item to use as keys.</typeparam>
    /// <typeparam name="TData">The type of data stored.</typeparam>
    public partial class Hashtable<TKey, TData> : IEnumerable<KeyValuePair<TKey, TData>>
    {
        // MartinG@DigitalRune: Use EqualityComparer.Equals() instead of object.Equals(). 
        // object.Equals() casts value types to object and can therefore create "garbage".
        private static readonly EqualityComparer<TKey> KeyComparer = EqualityComparer<TKey>.Default;

        private volatile Node[] _array;
        private SpinLock _writeLock;

        private static readonly Node DeletedNode = new Node() {Key = default(TKey), Data = default(TData), Token = Token.Deleted};

        /// <summary>
        /// Initializes a new instance of the <see cref="Hashtable&lt;Key, Data&gt;"/> class.
        /// </summary>
        /// <param name="initialCapacity">The initial capacity of the table.</param>
        public Hashtable(int initialCapacity)
        {
            if (initialCapacity < 1)
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), "cannot be < 1");
            _array = new Node[initialCapacity];
            _writeLock = new SpinLock();
        }

        /// <summary>
        /// Adds an item to this hashtable.
        /// </summary>
        /// <param name="key">The key at which to add the item.</param>
        /// <param name="data">The data to add.</param>
        public void Add(TKey key, TData data)
        {
            try
            {
                _writeLock.Enter();
                bool inserted = Insert(_array, key, data);

                if (!inserted)
                {
                    Resize();
                    Insert(_array, key, data);
                }
            }
            finally
            {
                _writeLock.Exit();
            }
        }

        private void Resize()
        {
            var newArray = new Node[_array.Length * 2];
            for (int i = 0; i < _array.Length; i++)
            {
                var item = _array[i];
                if (item.Token == Token.Used)
                    Insert(newArray, item.Key, item.Data);
            }

            _array = newArray;
        }

        private bool Insert(Node[] table, TKey key, TData data)
        {
            var initialHash = Math.Abs(key.GetHashCode()) % table.Length;
            var hash = initialHash;
            bool inserted = false;
            do
            {
                var node = table[hash];
                // if node is empty, or marked with a tombstone
                if (node.Token == Token.Empty || node.Token == Token.Deleted || KeyComparer.Equals(key, node.Key))
                {
                    table[hash] = new Node()
                    {
                        Key = key,
                        Data = data,
                        Token = Token.Used
                    };
                    inserted = true;
                    break;
                }
                else
                    hash = (hash + 1) % table.Length;
            } while (hash != initialHash);

            return inserted;
        }

        /// <summary>
        /// Sets the value of the item at the specified key location.
        /// This is only guaranteed to work correctly if no other thread is modifying the same key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The new value.</param>
        public void UnsafeSet(TKey key, TData value)
        {
            Node[] table;
            bool inserted = false;

            do
            {
                table = _array;
                var initialHash = Math.Abs(key.GetHashCode()) % table.Length;
                var hash = initialHash;

                do
                {
                    var node = table[hash];
                    if (KeyComparer.Equals(key, node.Key))
                    {
                        table[hash] = new Node()
                        {
                            Key = key,
                            Data = value,
                            Token = Token.Used
                        };
                        inserted = true;
                        break;
                    }
                    else
                        hash = (hash + 1) % table.Length;
                } while (hash != initialHash);
            } while (table != _array);

            // MartinG@DigitalRune: I have moved the Add() outside the loop because it uses a 
            // write-lock and the loop above should run without locks.
            if (!inserted)
                Add(key, value);
        }

        private bool Find(TKey key, out Node node)
        {
            node = new Hashtable<TKey, TData>.Node();
            var table = _array;
            var initialHash = Math.Abs(key.GetHashCode()) % table.Length;
            var hash = initialHash;

            do
            {
                Node n = table[hash];
                if (n.Token == Token.Empty)
                    return false;
                if (n.Token == Token.Deleted || !KeyComparer.Equals(key, n.Key))
                    hash = (hash + 1) % table.Length;
                else
                {
                    node = n;
                    return true;
                }
            } while (hash != initialHash);

            return false;
        }

        /// <summary>
        /// Tries to get the data at the specified key location.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <param name="data">The data at the key location.</param>
        /// <returns><c>true</c> if the data was found; else <c>false</c>.</returns>
        public bool TryGet(TKey key, out TData data)
        {
            Node n;
            if (Find(key, out n))
            {
                data = n.Data;
                return true;
            }
            else
            {
                data = default(TData);
                return false;
            }
        }

        /// <summary>
        /// Removes the data at the specified key location.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(TKey key)
        {
            try
            {
                _writeLock.Enter();


                Node[] table = _array;
                var initialHash = Math.Abs(key.GetHashCode()) % table.Length;
                var hash = initialHash;

                do
                {
                    Node n = table[hash];
                    if (n.Token == Token.Empty)
                        return;
                    if (n.Token == Token.Deleted || !KeyComparer.Equals(key, n.Key))
                        hash = (hash + 1) % table.Length;
                    else
                        table[hash] = DeletedNode;
                } while (hash != initialHash); // MartinG@DigitalRune: Stop when all entries are checked!
            }
            finally
            {
                _writeLock.Exit();
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<TKey, TData>> GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}