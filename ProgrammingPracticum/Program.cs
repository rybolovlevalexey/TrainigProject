using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            string st = Console.ReadLine();
            Dictionary<char, List<int>> letters = new Dictionary<char, List<int>>();
            int ind = 0;
            foreach (var elem in st)
            {
                bool flag = true;
                foreach (var key in letters.Keys)
                {
                    if (key == elem)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    List<int> sp = new List<int>();
                    sp.Add(ind);
                    letters[elem] = sp;
                } else
                {
                    List<int> sp = new List<int>();
                    sp = letters[elem];
                    sp.Add(ind);
                    letters[elem] = sp;
                }
                ind += 1;
            }
            List<char> keys = new List<char>();
            foreach (var el in letters.Keys)
            {
                keys.Add(el);
            }
            keys.Sort();
            foreach (var key in keys)
            {
                Console.Write($"{key} ");
                foreach (var index in letters[key])
                {
                    Console.Write($"{index} ");
                }
            }
        }
    }
}
