namespace IteratorPattern.Generic
{
    interface IEnumerator<T>
    {
        T Current { get; }

        void Dispose();
        bool MoveNext();
        void Reset();
    }
}