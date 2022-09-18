using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            string st = Console.ReadLine();
            Dictionary<string, int> letters = new Dictionary<string, int>();
            foreach (var elem in st)
            {
                bool flag = false;
                foreach (var key in letters.Keys)
                {
                    if (Convert.ToString(elem) == Convert.ToString(key))
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    letters[Convert.ToString(elem)] = letters[Convert.ToString(elem)] + 1;
                } else
                {
                    letters[Convert.ToString(elem)] = 1;
                }
            }
            List<string> keys = new List<string>();
            foreach (var key in letters.Keys)
            {
                keys.Add(key);
            }
            keys.Sort();
            foreach (var key in keys)
            {
                Console.Write($"{key} {letters[key]} ");
            }
        }
    }
}
