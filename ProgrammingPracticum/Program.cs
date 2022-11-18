using System;

namespace Урок18._11._22
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList ml = new MyList("a");
            string st = "bcdef";
            foreach (var el in st)
            {
                ml.Append(Convert.ToString(el));
            }
            ml.Prints();
        }
    }
}
