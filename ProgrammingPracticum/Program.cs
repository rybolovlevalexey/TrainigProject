using System;
using System.Collections.Generic;

namespace Задачи_со_Stepika
{
    class Program
    {
        public static void Main()
        {
            int cnt = 1, kvadr = 1, cube = 1, cur_num = -1;
            List<int> numbers = new List<int>();
            int x = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < x; i += 1)
            {
                while (numbers.Contains(kvadr * kvadr) || numbers.Contains(cube * cube * cube))
                {
                    if (numbers.Contains(kvadr * kvadr))
                        kvadr += 1;
                    if (numbers.Contains(cube * cube * cube))
                        cube += 1;
                }
                if (kvadr * kvadr < cube * cube * cube)
                {
                    Console.WriteLine($"{kvadr}**2 = {kvadr * kvadr}");
                    cur_num = kvadr * kvadr;
                    kvadr += 1;
                } else
                {
                    Console.WriteLine($"{cube}**3 = {cube * cube * cube}");
                    cur_num = cube * cube * cube;
                    cube += 1;
                }
                numbers.Add(cur_num);
            }
            Console.WriteLine($"Ответ: {cur_num}");
        }
    }
}

