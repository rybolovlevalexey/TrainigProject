using System;

namespace Консольное_приложение
{
    class Program
    {
        static void Main(string[] args)
        {
            string st = Console.ReadLine();
            string ans_st = "";
            if (st.Length <= 1)
            {
                ans_st = st;
            }
            if (st.Length < 4 && st.Length > 1)
            {
                string first = "", last = "";
                int i = 0;
                foreach (var elem in st)
                {
                   if (i == 0)
                    {
                        first = Convert.ToString(elem);
                    }
                   if (i == st.Length - 1)
                    {
                        last = Convert.ToString(elem);
                    }
                   if (i != st.Length - 1 && i != 0)
                    {
                        ans_st = ans_st + Convert.ToString(elem);
                    }
                    i += 1;
                }
                ans_st = last + ans_st + first;
            }
            if (st.Length >= 4)
            {
                string first = "", fourth = "";
                int i = 0;
                foreach (var elem in st)
                {
                    if (i == 0)
                    {
                        first = Convert.ToString(elem);
                    }
                    if (i == 3)
                    {
                        fourth = Convert.ToString(elem);
                        ans_st += first;
                    }
                    if (i != 0 && i != 3)
                    {
                        ans_st += Convert.ToString(elem);
                    }
                    i += 1;
                }
                ans_st = fourth + ans_st;
            }
            Console.WriteLine(ans_st);
        }
    }
}
