using System;
using cAlgo.LList;
using cAlgo.DLList;

namespace cAlgoUnitTest
{
    class Program
    {
        static void Main()
        {
            DList<int> listed = new DList<int>();
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
