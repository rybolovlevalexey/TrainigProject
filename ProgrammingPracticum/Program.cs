using System;

namespace ConsoleApp1
{
    class Program
    {
        class Answer
        {
            public int dlina = -1;
            public string stroka = "";
        }
        static void Main(string[] args)
        {
            string alphabet = "zxcvbnmlkjhgfdsaqwertyuiop";
            int k = Convert.ToInt32(Console.ReadLine());
            string st = Console.ReadLine();
            Answer ans = new Answer();

            foreach (var letter in alphabet)
            {
                int end = 0;
                int cnt = k;
                for (int beg = 0; beg < st.Length; beg += 1)
                {
                    if (st[beg] != letter && cnt > 0)
                        cnt -= 1;
                    if (beg != 0 && st[beg - 1] != letter)
                        cnt += 1;

                    while (end < st.Length)
                    {
                        if (end > beg)
                        {
                            if (st[end] == letter && cnt == 0)
                            {
                                int dl = end - beg + 1;
                                if (ans.dlina == -1 || dl > ans.dlina)
                                {
                                    ans.dlina = dl;
                                    ans.stroka = st[beg..(end + 1)];
                                }
                            }
                            if (st[end] != letter && cnt == 0)
                                break;
                            if (st[end] != letter && cnt > 0)
                            {
                                cnt -= 1;
                                int dl = end - beg + 1;
                                if (ans.dlina == 0 || dl > ans.dlina)
                                {
                                    ans.dlina = dl;
                                    ans.stroka = st[beg..(end + 1)];
                                }
                            }
                            if (st[end] == letter && cnt > 0)
                            {
                                int dl = end - beg + 1;
                                if (ans.dlina == 0 || dl > ans.dlina)
                                {
                                    ans.dlina = dl;
                                    ans.stroka = st[beg..(end + 1)];
                                }
                            }
                        }
                        end += 1;

                    }
                }
            }
            Console.WriteLine(ans.dlina);
        }
    }
}
