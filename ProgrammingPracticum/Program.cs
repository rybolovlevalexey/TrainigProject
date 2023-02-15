using System;

namespace Длинная_арифметика
{
    class Program
    {
        public static string Summa(string x, string y)
        {
            string ans = "";
            int max_len = 0;
            string rx = "", ry = "";
            foreach (var el in x)
            {
                rx = el + rx;
            }
            foreach (var el in y)
            {
                ry = el + ry;
            }
            if (x.Length >= y.Length)
            {
                max_len = x.Length;
            }
            else
            {
                max_len = y.Length;
            }
            int mem = 0;
            for (int i = 0; i < max_len; i += 1)
            {
                int res = 0;
                res += mem;
                if (i < x.Length && i < y.Length)
                {
                    res += (Convert.ToInt32(Convert.ToString(rx[i])) + Convert.ToInt32(Convert.ToString(ry[i])));
                }
                else
                {
                    if (i < x.Length)
                    {
                        res += Convert.ToInt32(Convert.ToString(rx[i]));
                    }
                    if (i < y.Length)
                    {
                        res += Convert.ToInt32(Convert.ToString(ry[i]));
                    }
                }
                mem = 0;
                ans = Convert.ToString(res % 10) + ans;
                mem = res / 10;
            }
            if (mem != 0)
            {
                ans = mem + ans;
            }
            return ans;
        }
        public static string Minus(string x, string y)
        {
            string ans = "";
            int max_len = 0;
            string rx = "", ry = "";
            foreach (var el in x)
            {
                rx = el + rx;
            }
            foreach (var el in y)
            {
                ry = el + ry;
            }
            if (x.Length >= y.Length)
            {
                max_len = x.Length;
            }
            else
            {
                max_len = y.Length;
            }
            bool flag_mem = false;
            for (int i = 0; i < max_len; i += 1)
            {
                int one = Convert.ToInt32(Convert.ToString(rx[i]));
                if (i >= y.Length && flag_mem && one != 0)
                {
                    one -= 1;
                    flag_mem = false;
                }
                int two = 0;
                if (i < y.Length)
                {
                    two = Convert.ToInt32(Convert.ToString(ry[i]));
                }

                if (one > two)
                {
                    if (flag_mem)
                        ans = Convert.ToString(one - two - 1) + ans;
                    else
                        ans = Convert.ToString(one - two) + ans;
                    flag_mem = false;
                }

                if (one == two)
                {
                    if (!flag_mem)
                    {
                        ans = Convert.ToString(one - two) + ans;
                        flag_mem = false;
                    }
                    else
                    {
                        ans = Convert.ToString(one - two - 1 + 10) + ans;
                        flag_mem = true;
                    }
                }

                if (one < two)
                {
                    if (flag_mem)
                        ans = Convert.ToString(one - two + 9) + ans;
                    else
                        ans = Convert.ToString(one - two + 10) + ans;
                    flag_mem = true;
                }
            }
            return ans;
        }
        public static bool IsBiggerThan(string x, string y)
        {
            if (x.Length > y.Length)
                return true;
            if (x.Length < y.Length)
                return false;
            
            for (int i = 0; i < x.Length; i += 1)
            {
                if (Convert.ToInt32(Convert.ToString(x[i])) > Convert.ToInt32(Convert.ToString(y[i])))
                    return true;
                if (Convert.ToInt32(Convert.ToString(x[i])) < Convert.ToInt32(Convert.ToString(y[i])))
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string deyst = Console.ReadLine();
            string second = Console.ReadLine();
            switch (deyst)
            {
                case "+":
                    string sum_result = "";
                    if (first[0] != '-' && second[0] != '-')
                        sum_result = Summa(first, second);
                    if (first[0] == '-' && second[0] == '-')
                        sum_result = Summa(first, second);
                    Console.WriteLine(sum_result);
                    break;
                case "-":
                    string minus_result = "";
                    if (IsBiggerThan(first, second))
                        minus_result = Minus(first, second);
                    else
                        minus_result = "-" + Minus(second, first);
                    Console.WriteLine(minus_result);
                    break;
            }
        }
    }
}
