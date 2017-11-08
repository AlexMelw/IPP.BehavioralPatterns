namespace IteratorPattern.NonGeneric
{
    using System.Collections;

    interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }
}