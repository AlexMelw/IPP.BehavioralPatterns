namespace IteratorPattern
{
    using System;
    using Automatic;
    using Manual;

    class Program
    {
        static void Main(string[] args)
        {
            var smartList = new SmartList<int>();

            smartList.Add(6);
            smartList.Add(1);
            smartList.Add(3);
            smartList.Add(4);
            smartList.Add(8);
            smartList.Add(4);
            smartList.Add(7);


            Console.Out.WriteLine("Traditional Approach");
            for (var it = smartList.GetEnumerator(); it.MoveNext();)
            {
                int item = it.Current;
                Console.Out.WriteLine("item = {0}", item);
            }

            Console.Out.WriteLine("C# Manual Approach");
            foreach (int item in smartList)
            {
                Console.Out.WriteLine("item = {0}", item);
            }

            // =============== C# YIELD MAGIC WORD =================

            var fancyList = new FancyList<int> { 6, 1, 3, 4, 8, 4, 7 };

            Console.Out.WriteLine("C# Automatic Approach");
            foreach (int item in fancyList)
            {
                Console.Out.WriteLine("item = {0}", item);
            }

            Console.ReadKey();
        }
    }
}