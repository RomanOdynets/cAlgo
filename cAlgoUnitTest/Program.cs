using System;
using cAlgo.LList;
using cAlgo.DLList;

namespace cAlgoUnitTest
{
    class Program
    {
        static void Main()
        {
            DLList<int> listed = new DLList<int>();
            for (int i = 0; i < 5000; i++)
            {
                listed.Add(i);
            }

            listed.Remove(4000);

            foreach (var item in listed.BackEnumerator())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
