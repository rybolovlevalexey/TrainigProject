using System;
using System.Collections.Generic;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Dictionary<int, List<int>> all_dots = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i += 1)
            {
                string[] st = Console.ReadLine().Split();
                int x = Convert.ToInt32(st[0]);
                int y = Convert.ToInt32(st[1]);
                List<int> xy = new List<int>();
                xy.Add(x);
                xy.Add(y);
                all_dots[i] = xy;
            }
            double radius = 0;
            for (int i = 0; i < n - 1; i += 1)
            {
                for (int j = i + 1; j < n; j += 1)
                {
                    int dx = all_dots[i][0] - all_dots[j][0];
                    int dy = all_dots[i][1] - all_dots[j][1];
                    double dist = (Math.Pow(Math.Pow(dx, 2) + Math.Pow(dy, 2), 0.5));
                    string stdist = Convert.ToString(dist);
                    string ansst = "";
                    int cnt_numbs = 0;
                    bool comma_flag = false;
                    foreach (var el in stdist)
                    {
                        if (el == ',')
                        {
                            comma_flag = true;
                            ansst += el;
                        }
                        if (!comma_flag)
                        {
                            ansst += el;
                        }
                        if (comma_flag && cnt_numbs < 10 && el != ',')
                        {
                            cnt_numbs += 1;
                            ansst += el;
                        }
                    }
                    double ans = Convert.ToDouble(ansst);
                    if (radius == 0 || ans > radius)
                    {
                        radius = ans;
                    }
                }
            }
            Console.WriteLine(radius);
        }
    }
}
