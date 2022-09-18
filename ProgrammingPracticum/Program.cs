using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sp = new List<int>();
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= num / 2 + 1; i += 1) {
                bool flag = true;
                if (num % i == 0)
                {
                    int d = num / i;
                    foreach (var elem in sp)
                    {
                        if (elem == i || elem == d)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine($"{num} = {i} * {d}");
                        sp.Add(i);
                        sp.Add(d);
                    }
                }
            }
        }
    }
}
