using System;
using System.Collections;
using System.Collections.Generic;

namespace AlienEngine.Core.Game
{
    public class GameElementCollection : IEnumerable<GameElement>, IEnumerator<GameElement>, IDisposable
    {
        private int _key;
        private List<GameElement> _list;

        public int Length
        {
            get { return _list.Count; }
        }

        public GameElement Current
        {
            get
            {
                return _list[_key];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return _list[_key];
            }
        }

        public GameElement this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        public GameElementCollection()
        {
            _key = 0;
            _list = new List<GameElement>();
        }

        public GameElementCollection(List<GameElement> list) : this()
        {
            _list = list;
        }

        public GameElementCollection(GameElement[] list) : this()
        {
            _list = new List<GameElement>(list);
        }

        public void Add(GameElement gameElement)
        {
            _list.Add(gameElement);
        }

        public void Remove(GameElement gameElement)
        {
            _list.Remove(gameElement);
        }

        public bool Contains(GameElement gameElement)
        {
            return _list.Contains(gameElement);
        }

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

        public IEnumerator<GameElement> GetEnumerator()
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
