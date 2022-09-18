using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            List<int> res = new List<int>();
            res = GetList(num);
            foreach(var el in res)
            {
                Console.Write($"{el} ");
            }
        }

        static List<int> GetList(int n) {
            Random rnd = new Random();
            List<int> sp = new List<int>();
            for (int i = 0; i < n; i += 1)
            {
                sp.Add(rnd.Next(0, 100));
            }
            return sp;
        }
    }
}
