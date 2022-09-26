using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int stepen = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Recursion(number, stepen));
            Console.WriteLine(Math.Pow(number, stepen));
        }

        static int Recursion(int num, int step)
        {
            if (step == 1)
            {
                return num;
            } else
            {
                if (step % 2 == 1)
                {
                    return num * Recursion(num, step - 1);
                } else
                {
                    return Recursion(num, step / 2) * Recursion(num, step / 2);
                }
            }
        }
    }
}
