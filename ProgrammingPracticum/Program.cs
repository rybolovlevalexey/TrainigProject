using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] st = Console.ReadLine().Split();
            int n = Convert.ToInt32(st[0]), m = Convert.ToInt32(st[1]), k = Convert.ToInt32(st[2]);
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i += 1)
            {
                string[] line = Console.ReadLine().Split();
                for (int j = 0; j < m; j += 1)
                {
                    matrix[i, j] = Convert.ToInt32(line[j]);
                }
            }
            for (int i = 0; i < k; i++)
            {
                int summa = 0;
                string[] coords = Console.ReadLine().Split();
                int x1 = Convert.ToInt32(coords[0]) - 1, y1 = Convert.ToInt32(coords[1]) - 1;
                int x2 = Convert.ToInt32(coords[2]) - 1, y2 = Convert.ToInt32(coords[3]) - 1;
                int x = x1;
                while (y1 <= y2)
                {
                    while (x1 <= x2)
                    {
                        summa += matrix[x1, y1];
                        x1 += 1;
                    }
                    y1 += 1;
                    x1 = x;
                }
                Console.WriteLine(summa);
            }
        }
    }
}
