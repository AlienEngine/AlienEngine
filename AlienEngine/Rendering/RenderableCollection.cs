using System;
using System.Collections;
using System.Collections.Generic;

namespace AlienEngine.Core.Rendering
{
    public class RenderableCollection : IEnumerable<IRenderable>, IEnumerator<IRenderable>, IDisposable
    {
        #region Fields

        #region Private
        /// <summary>
        /// The internal list of <see cref="IRenderable"/>s in this collection.
        /// </summary>
        private List<IRenderable> _list;

        /// <summary>
        /// The internal item pointer of the collection.
        /// </summary>
        private int _key;
        #endregion

        #endregion

        #region Properties

        #region Public
        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        public int Length
        {
            get { return _list.Count; }
        }

        /// <summary>
        /// Gets the current element of the iterator.
        /// </summary>
        public IRenderable Current
        {
            get
            {
                return _list[_key];
            }
        }

        /// <summary>
        /// Gets the current element of the iterator.
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return _list[_key];
            }
        }
        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new collection of <see cref="IRenderable"/>s.
        /// </summary>
        public RenderableCollection()
        {
            _list = new List<IRenderable>();
            _key = 0;
        }

        #endregion

        #region Methods

        public bool MoveNext()
        {
            if (_key < _list.Count - 1)
            {
                _key++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _key = 0;
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _list.Clear();
                    _list = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        #region IEnumerator implementation

        public IEnumerator<IRenderable> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion

        #region IEnumarable implementation

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion
    }
}
