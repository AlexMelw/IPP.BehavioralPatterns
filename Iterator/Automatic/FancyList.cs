namespace IteratorPattern.Automatic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class FancyList<T> : IEnumerable<T>
    {
        private static int DefaultSmartListSize = 4;
        protected T[] Container;
        private int _count = 0;

        public int Count => _count;

        #region CONSTRUCTORS

        public FancyList() : this(new T[DefaultSmartListSize]) { }

        protected FancyList(T[] container) => Container = container;

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

        #region IEnumerable<T> Implementation

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return Container[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}