using System;
using System.Collections.Generic;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		int[] ans = new int[2];
		double ans_dl = 0;
		for (int k = 0; k < n; k++){
			string[] st = Console.ReadLine().Split();
			int x = Convert.ToInt32(st[0]);
			int y = Convert.ToInt32(st[1]);
			double s = Math.Pow(x*x + y*y, 0.5);
			if (k == 0){
				ans_dl = s;
				ans[0] = x;
				ans[1] = y;
			} else {
				if (s > ans_dl){
					ans_dl = s;
					ans[0] = x;
					ans[1] = y;
				}
			}
		}
		Console.Write($"{ans[0]} {ans[1]}");
	}
}
