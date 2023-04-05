using System;
using System.Threading;
using System.Diagnostics;

namespace дз_по_тетсированию_Двусвязных_списков
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static public void TestClonable()
        {
            MyList<int> ml = new MyList<int>();
            ml.Append(1);
            ml.Append(2);
            ml.AddFirst(3);
            MyList<int> ml1 = ml;
            var ml2 = (MyList<int>)ml.Clone();
            ml.Append(5);
            ml.Prints();
            ml1.Prints();
            ml2.Prints();
            ml2.Append(10);
            ml2.Prints();
            Console.WriteLine(ml2.Length());
            //MyList<string> ml2 = ml.Clone();
        }
        static public void StringTest()
        {
            MyList<string> str_ml = new MyList<string>();
            str_ml.Append("ok");
            str_ml.AddFirst("good");
            str_ml.Append("Nice");
            Console.WriteLine($"{Convert.ToString(str_ml)}{str_ml.Length()}");
        }
    }
}
