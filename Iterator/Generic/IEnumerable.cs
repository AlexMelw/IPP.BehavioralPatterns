namespace IteratorPattern.Generic
{
    using System.Collections.Generic;

    interface IEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }
}