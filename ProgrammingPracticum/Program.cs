using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            string st = Console.ReadLine();
            int i = 0;
            foreach (var elem in st)
            {
                if (Convert.ToString(elem) == "O")
                {
                    Console.WriteLine(i);
                }
                i += 1;
            }
        }
    }
}
