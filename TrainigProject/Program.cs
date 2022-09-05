using System;

namespace TrainigProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите два целых числа через пробел");
            string[] st = Console.ReadLine().Split(' ');
            int a = int.Parse(st[0]), b = int.Parse(st[1]);
            int res1 = a + b;
            int res2 = a - b;
            int res3 = a * b;
            Console.WriteLine($"{res1} {res2} {res3}");
        }
    }
}