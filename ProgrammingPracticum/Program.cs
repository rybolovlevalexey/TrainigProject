using System;
using System.Collections.Generic;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] st = Console.ReadLine().Split();
		int[] sp = new int[n];
		for (int i = 0; i < n; i++){
			sp[i] = Convert.ToInt32(st[i]);
		}
		int x = Convert.ToInt32(Console.ReadLine());
		int ans = 0, delta = 0;
		for (int i = 0; i < n; i++){
			if (i == 0){
				ans = sp[i];
				delta = Math.Abs(sp[i] - x);
			} else {
				if (delta > Math.Abs(sp[i] - x)){
					ans = sp[i];
					delta = Math.Abs(sp[i] - x);
				}
			}
		}
		Console.WriteLine(ans);
	}
}
