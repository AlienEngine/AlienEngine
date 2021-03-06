﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace AlienEngine.Core.Game
{
    public class GameElementCollection : IEnumerable<GameElement>, IEnumerator<GameElement>
    {
        private int _key;
        private List<GameElement> _list;

        public int Length => _list.Count;

        public GameElement Current => _list[_key];

        object IEnumerator.Current => _list[_key];

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

        public bool Remove(GameElement gameElement)
        {
            return _list.Remove(gameElement);
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

        public void Clear()
        {
            _list.Clear();
        }

        public void BeforeUpdate()
        {
            GameElement[] arrayGameElements = ToArray();

            for (int i = 0, l = arrayGameElements.Length; i < l; i++)
                arrayGameElements[i].BeforeUpdate();

            arrayGameElements = null;
        }

        public void Start()
        {
            GameElement[] arrayGameElements = ToArray();

            for (int i = 0, l = arrayGameElements.Length; i < l; i++)
                arrayGameElements[i].Start();

            arrayGameElements = null;
        }
        
        public void Update()
        {
            GameElement[] arrayGameElements = ToArray();

            for (int i = 0, l = arrayGameElements.Length; i < l; i++)
                arrayGameElements[i].Update();

            arrayGameElements = null;
        }

        public void AfterUpdate()
        {
            GameElement[] arrayGameElements = ToArray();

            for (int i = 0, l = arrayGameElements.Length; i < l; i++)
                arrayGameElements[i].AfterUpdate();

            arrayGameElements = null;
        }


        public void Stop()
        {
            GameElement[] arrayGameElements = ToArray();

            for (int i = 0, l = arrayGameElements.Length; i < l; i++)
                arrayGameElements[i].Stop();

            arrayGameElements = null;
        }
        
        public GameElement[] ToArray()
        {
            return _list.ToArray();
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            if (disposing)
            {
                _list.Clear();
                _list = null;
            }

            _disposedValue = true;
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