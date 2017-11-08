namespace IteratorPattern.Manual
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class SmartList<T> : IEnumerable<T>
    {
        private static int DefaultSmartListSize = 4;
        protected T[] Container;
        private int _count = 0;

        public int Count => _count;

        #region CONSTRUCTORS

        public SmartList() : this(new T[DefaultSmartListSize]) { }

        protected SmartList(T[] container) => Container = container;

        #endregion

        public void Add(T item)
        {
            _count += 1;

            if (_count > Container.Length)
            {
                T[] newContainer = new T[_count * 2];

                Array.Copy(Container, newContainer, Container.Length);

                Container = newContainer;
            }

            Container[_count - 1] = item;
        }

        public void Clear() => Container = new T[DefaultSmartListSize];

        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Container[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        private class SmartListEnumerator : IEnumerator<T>
        {
            private readonly SmartList<T> _smartList;

            private int _currentPosition = -1;

            #region CONSTRUCTORS

            public SmartListEnumerator(SmartList<T> smartList)
            {
                _smartList = smartList;
            }

            #endregion

            public void Dispose() => Reset();

            public bool MoveNext()
            {
                _currentPosition += 1;

                return _currentPosition < _smartList.Count;
            }

            public void Reset()
            {
                _currentPosition = -1;
            }

            public T Current => _smartList.Container[_currentPosition];

            object IEnumerator.Current => Current;
        }

        #region IEnumerable<T> Implementation

        public IEnumerator<T> GetEnumerator()
        {
            return new SmartListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}