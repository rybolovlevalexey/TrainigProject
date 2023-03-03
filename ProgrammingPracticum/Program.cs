using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine(0);
                Console.WriteLine(1);
            } else
            {
                long[] dp = new long[n + 1];
                dp[1] = 1;
                long[] oper_num = new long[n + 1];
                oper_num[0] = 0;
                oper_num[1] = 0;
                long[] prev_num = new long[n + 1];
                prev_num[0] = 0;
                prev_num[1] = 0;

                for (int i = 2; i < n + 1; i += 1)
                {
                    dp[i] += dp[i - 1];
                    if (i % 2 != 0 && i % 3 != 0)
                    {
                        oper_num[i] = oper_num[i - 1] + 1;
                        prev_num[i] = i - 1;
                    }

                    if (i % 2 == 0 && i % 3 != 0)
                    {
                        dp[i] += dp[i / 2];
                        if (oper_num[i - 1] < oper_num[i / 2])
                        {
                            oper_num[i] = oper_num[i - 1] + 1;
                            prev_num[i] = i - 1;
                        }
                        else
                        {
                            oper_num[i] = oper_num[i / 2] + 1;
                            prev_num[i] = i / 2;
                        }
                    }

                    if (i % 2 != 0 && i % 3 == 0)
                    {
                        dp[i] += dp[i / 3];
                        if (oper_num[i - 1] < oper_num[i / 3])
                        {
                            oper_num[i] = oper_num[i - 1] + 1;
                            prev_num[i] = i - 1;
                        }
                        else
                        {
                            oper_num[i] = oper_num[i / 3] + 1;
                            prev_num[i] = i / 3;
                        }
                    }

                    if (i % 2 == 0 && i % 3 == 0)
                    {
                        dp[i] += dp[i / 2];
                        dp[i] += dp[i / 3];
                        if (oper_num[i - 1] < oper_num[i / 3] && oper_num[i - 1] < oper_num[i / 2])
                        {
                            oper_num[i] = oper_num[i - 1] + 1;
                            prev_num[i] = i - 1;
                        }
                        else if (oper_num[i / 3] < oper_num[i / 2])
                        {
                            oper_num[i] = oper_num[i / 3] + 1;
                            prev_num[i] = i / 3;
                        }
                        else
                        {
                            oper_num[i] = oper_num[i / 2] + 1;
                            prev_num[i] = i / 2;
                        }
                    }
                }
                
                Console.WriteLine(oper_num[n]);
                string ans = "";
                long k = n;
                while (k > 0)
                {
                    ans = Convert.ToString(k) + " " + ans;
                    k = prev_num[k];
                }
                Console.WriteLine(ans);
            }
            
        }
    }
}
