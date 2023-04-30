using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace дз_по_тетсированию_Двусвязных_списков
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMethodSort();
        }

        static public void TestMethodSort()
        {
            MyList<int> ml = new MyList<int>(1);
            ml.Add(0);
            ml.Add(2);
            ml.Add(5);
            ml.Add(3);
            ml.Add(1);
            ml.Prints();
            ml.Sort(new MyComp<int>());
            ml.Prints();
        }
        static public void TestIComparable()
        {
            MyList<int> ml = new MyList<int>(1);
            MyList<int> ml1 = new MyList<int>(1);
            ml1.Add(2);
            ml1.Add(3);
            ml1.Add(4);
            MyList<int> ml2 = new MyList<int>(1);
            ml2.Add(5);
            List<MyList<int>> ml_sp = new List<MyList<int>>();
            ml_sp.Add(ml); ml_sp.Add(ml1); ml_sp.Add(ml2);
            ml_sp.Sort();
            foreach(var elem in ml_sp)
            {
                elem.Prints();
            }
        }
        static public void TestICollection()
        {
            MyList<int> ml = new MyList<int>(10);
            ml.Add(1);
            ml.Add(2);
            ml.Prints();
            Console.WriteLine(ml.Count);
            int[] sp = new int[ml.Count];
            ml.CopyTo(sp);
            foreach (var el in sp)
                Console.Write($"{el} ");
        }
        static public void TestInterfaceIEnumerable()
        {
            MyList<int> ml = new MyList<int>();
            ml.Add(1);
            ml.Add(2);
            ml.Add(3);
            foreach (var elem in ml)
            {
                Console.WriteLine(elem);
            }
            ml.Prints();
        }
        static public void TestICloneable()
        {
            MyList<int> ml = new MyList<int>();
            ml.Add(1);
            ml.Add(2);
            ml.AddFirst(3);
            MyList<int> ml1 = ml;
            var ml2 = (MyList<int>)ml.Clone();
            ml.Add(5);
            ml.Prints();
            ml1.Prints();
            ml2.Prints();
            ml2.Add(10);
            ml2.Prints();
            Console.WriteLine(ml2.Count);
        }
        static public void StringTest()
        {
            MyList<string> str_ml = new MyList<string>();
            str_ml.Add("ok");
            str_ml.AddFirst("good");
            str_ml.Add("Nice");
            Console.WriteLine($"{Convert.ToString(str_ml)}\n{str_ml.Contains("5")}\n{str_ml.Contains("ok")}");
        }
    }
}
