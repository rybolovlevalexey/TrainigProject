using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            char st = Convert.ToChar(Console.ReadLine());
            string num = "0123456789";
            bool flag = false;
            foreach (var el in num)
            {
                if (el == st)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                Console.WriteLine("yes");
            } else
            {
                Console.WriteLine("no");
            }
        }
    }
}
