using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());  // размеры матрицы
            // создание матрицы из случайных чисел
            int[,] matrix = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i += 1)
            {
                for (int j = 0; j < n; j += 1)
                {
                    int value = rnd.Next(n*n);
                    matrix[i, j] = value;
                    Console.Write($"{value} ");
                }
                Console.WriteLine();
            }
            // вычисление определителя

            static int Determinant(int[,] sp){
                if (Convert.ToInt32(Math.Pow(sp.Length, 0.5)) == 1)
                {
                    return (sp[0, 0]);
                }
                if (Convert.ToInt32(Math.Pow(sp.Length, 0.5)) == 2)
                {
                    return (sp[0, 0] * sp[1, 1] - sp[0, 1] * sp[1, 0]);
                }
                int ans = 0;
                for (int i = 0; i < Convert.ToInt32(Math.Pow(sp.Length, 0.5)); i += 1)
                {
                    int[,] sp1 = new int[Convert.ToInt32(Math.Pow(sp.Length, 0.5)) - 1, Convert.ToInt32(Math.Pow(sp.Length, 0.5)) - 1];
                    //Console.WriteLine(sp.Length);
                    for (int j = 1; j < Convert.ToInt32(Math.Pow(sp.Length, 0.5)); j += 1) { 
                        for (int k = 0; k < Convert.ToInt32(Math.Pow(sp.Length, 0.5)); k += 1)
                        {
                            if (i == k)
                            {
                                continue;
                            }
                            if (i > k)
                            {
                                sp1[j - 1, k] = sp[j, k];
                            } else
                            {
                                sp1[j - 1, k - 1] = sp[j, k];
                            }
                            
                        }
                    }
                    ans += Convert.ToInt32(Math.Pow((-1), i)) * sp[0, i] * Determinant(sp1);
                }
                return ans;
            }

            Console.WriteLine(Determinant(matrix));
        }
    }
}
