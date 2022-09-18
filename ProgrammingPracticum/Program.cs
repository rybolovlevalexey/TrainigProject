using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] st = Console.ReadLine().Split();
            int flag = 1;
            List<int> sp = new List<int>();
            foreach (var elem in st)
            {
                if (elem == "0")
                {
                    flag = flag * (-1);
                }
                if (flag == -1 && elem != "0")
                {
                    sp.Add(Convert.ToInt32(elem));
                }
            }
            sp.Sort();
            sp.Reverse();
            foreach (var el in sp)
            {
                Console.Write($"{el} ");
            }
        }
    }
}
