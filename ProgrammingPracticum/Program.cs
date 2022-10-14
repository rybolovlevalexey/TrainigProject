using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Быстрое_возведение_в_степень__Сортировки__Бинарный_поиск
{
    class Program
    {
        static void Main(string[] args)
        {
            //FastStepen(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));

            //Sortirovky();

            //Console.WriteLine(BinarySearch(Convert.ToInt32(Console.ReadLine())));
        }

        static int BinarySearch(int number)
        {
            int left = 0, rigth = number, mid = -1;
            while (rigth - left > 1)
            {
                mid = (rigth + left) / 2;
                if (mid * mid == number)
                {
                    return mid;
                }
                if (mid * mid < number)
                {
                    left = mid;
                } else
                {
                    rigth = mid;
                }
                //Console.WriteLine($"{left}, {rigth}");
            }
            if (mid * mid == number)
            {
                return mid;
            }
            if (left * left == number)
            {
                return left;
            }
            if (rigth * rigth == number)
            {
                return rigth;
            }
            return -1;
        }

        static void Sortirovky()
        {
            List<int> sp = new List<int>();
            try
            {
                string strLine;
                StreamReader file = File.OpenText("C:/Visual Studio Projects/data.txt");    
                while (null != (strLine = file.ReadLine()))
                {
                    sp.Add(Convert.ToInt32(strLine));
                }
            } catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            int[] sp1 = new int[sp.Count];
            int[] sp2 = new int[sp.Count];
            for (int i = 0; i < sp.Count; i += 1)
            {
                sp1[i] = sp[i];
                sp2[i] = sp[i];
            }
            
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start(); // запуск секундомера первой сортировки
            foreach (var elem in sp1)
            {
                Console.Write($"{elem} ");
            }
            Console.WriteLine();
            for (int i = 0; i < sp1.Length; i += 1)
            {
                for (int j = 0; j < sp1.Length - 1; j += 1)
                {
                    if (sp1[j] > sp1[j + 1])
                    {
                        int a = sp1[j], b = sp1[j + 1];
                        sp1[j] = b;
                        sp1[j + 1] = a;
                    }
                }
            }
            foreach (var elem in sp1)
            {
                Console.Write($"{elem} ");
            }
            Console.WriteLine();
            stopwatch1.Stop();  // сортировка выполнена, секундомер остановлен
            Console.WriteLine($"Time: {stopwatch1.ElapsedMilliseconds}");
            
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();   // старт второй сортировки
            static int[] MergeSort(int[] spisok)
            {
                if (spisok.Length > 1)
                {
                    int mid = spisok.Length / 2;
                    int[] left = new int[mid];
                    int[] rigth = new int[spisok.Length - mid];
                    for (int ind = 0; ind < spisok.Length; ind += 1)
                    {
                        if (ind < mid)
                        {
                            left[ind] = spisok[ind];
                        } else
                        {
                            rigth[ind - mid] = spisok[ind];
                        }
                    }
                    MergeSort(left);
                    MergeSort(rigth);
                    int i = 0, j = 0, k = 0;

                    while (i < left.Length && j < rigth.Length)
                    {
                        if (left[i] < rigth[j])
                        {
                            spisok[k] = left[i];
                            i += 1;
                        } else
                        {
                            spisok[k] = rigth[j];
                            j += 1;
                        }
                        k += 1;
                    }
                    while (i < left.Length)
                    {
                        spisok[k] = left[i];
                        i += 1;
                        k += 1;
                    }
                    while (j < rigth.Length)
                    {
                        spisok[k] = rigth[j];
                        j += 1;
                        k += 1;
                    }
                }
                return spisok;
            }
            foreach (var elem in sp2)
            {
                Console.Write($"{elem} ");
            }
            sp2 = MergeSort(sp2);
            Console.WriteLine();
            foreach (var elem in sp2)
            {
                Console.Write($"{elem} ");
            }
            stopwatch2.Stop();  // конец второй сортировки
            Console.WriteLine($"Time: {stopwatch2.ElapsedMilliseconds}");
        }

        static int FastStepen(int num, int step)
        {
            if (step == 1)
            {
                return num;
            }
            else
            {
                if (step % 2 == 1)
                {
                    return num * FastStepen(num, step - 1);
                }
                else
                {
                    return FastStepen(num, step / 2) * FastStepen(num, step / 2);
                }
            }
        }
    }
}
