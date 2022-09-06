using System;

namespace ProgrammingPracticum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n, k;
            n = Convert.ToInt32(Console.ReadLine());
            k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine((n - k % n) % n);
        }
    }
}