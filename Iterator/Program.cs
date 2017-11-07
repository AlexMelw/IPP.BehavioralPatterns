namespace Iterator
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var smartList = new SmartList<int>();

            smartList.Add(-5);
            smartList.Add(1);
            smartList.Add(3);
            smartList.Add(7);
            smartList.Add(8);
            smartList.Add(9);
            smartList.Add(-13);

            // Traditional Approach
            for (var it = smartList.GetEnumerator(); it.MoveNext();)
            {
                int item = it.Current;
                Console.Out.WriteLine("it = {0}", item);
            }

            // C# Fancy Approach
            foreach (int item in smartList)
            {
                Console.Out.WriteLine("i = {0}", item);
            }
        }
    }
}