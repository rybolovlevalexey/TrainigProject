using System;
using System.Collections.Generic;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] st = Console.ReadLine().Split();
		List<int> sp = new List<int>();
		for (int i = 0; i < n; i++){
			sp.Add(Convert.ToInt32(st[i]));
		}
		sp.Sort();
		int ans = 0, lst = -1;
		for (int i = 0; i < n; i++){
			if (i == 0){
				ans += 1;
				lst = sp[i];
			} else {
				if (sp[i] != lst){
					lst = sp[i];
					ans += 1;
				}
			}
		}
		Console.WriteLine(ans);
	}
}
