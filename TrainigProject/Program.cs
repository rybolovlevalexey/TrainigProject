using System;

namespace TrainigProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите пройденное расстояние в метрах");
            int dist;
            dist = Convert.ToInt32(Console.ReadLine());
            int ans;
            ans = dist / 1000;
            Console.WriteLine($"{ans}");
        }
    }
}