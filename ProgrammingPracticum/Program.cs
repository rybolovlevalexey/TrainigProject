using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] st = Console.ReadLine().Split();
            foreach (var elem in st)
            {
                bool flag = true;
                foreach (var letter in elem)
                {
                    if (Convert.ToString(letter) == "1")
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    Console.Write($"{elem} ");
                }
            }
        }
    }
}
