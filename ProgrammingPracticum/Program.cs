using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] st = Console.ReadLine().Split();
            List<int> spisok = new List<int>();
            foreach (var el in st)
            {
                spisok.Add(Convert.ToInt32(el));
            }
            int first = spisok[0], last = spisok[st.Length - 1];
            for (int i = first; i <= last; i += 1)
            {
                bool flag = false;
                foreach (var elem in spisok)
                {
                    if (elem == i)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
