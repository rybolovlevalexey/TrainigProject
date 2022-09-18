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
            res = GetSyracusaSequence(num);
            foreach(var el in res)
            {
                Console.Write($"{el} ");
            }
        }

        static List<int> GetSyracusaSequence(int num) {
            List<int> sp = new List<int>();
            sp.Add(num);
            while (num > 1)
            {
                if (num % 2 == 0)
                {
                    num = num / 2;
                } else
                {
                    num = num * 3 + 1;
                }
                sp.Add(num);
            }
            return sp;
        }
    }
}
