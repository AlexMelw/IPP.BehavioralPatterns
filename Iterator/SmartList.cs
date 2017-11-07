namespace Iterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class SmartList<T> : IEnumerable<T>, ICollection<T>
    {
        protected T[] Container;
        private int _count = 0;
        private static int DefaultSmartListSize = 4;

        #region CONSTRUCTORS

        protected SmartList(T[] container)
        {
            this.Container = container;
        }

        public SmartList() : this(new T[DefaultSmartListSize]) { }

        #endregion

        #region IEnumerable<T> Implementation

        public IEnumerator<T> GetEnumerator()
        {
            return new SmartListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        private class SmartListEnumerator : IEnumerator<T>
        {
            private readonly SmartList<T> _smartList;

            private int _currentPosition = -1;

            public SmartListEnumerator(SmartList<T> smartList)
            {
                _smartList = smartList;
            }

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

            object IEnumerator.Current => this.Current;
        }

        #region ICollection<T> Implementation

        public void Add(T item)
        {
            ++_count;

            if (_count > Container.Length)
            {
                T[] newContainer = new T[_count * 2];

                Array.Copy(Container, newContainer, Container.Length);

                Container = newContainer;
            }

            Container[_count - 1] = item;
        }

        public void Clear()
        {
            Container = new T[DefaultSmartListSize];
        }

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

        public void CopyTo(T[] array, int arrayIndex) => throw new NotImplementedException();

        public bool Remove(T item) => throw new NotImplementedException();

        public int Count => _count;

        public bool IsReadOnly { get; } = false;

        #endregion
    }
}