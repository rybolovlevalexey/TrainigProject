using System;
using System.Collections.Generic;

class Program
{
	public static void Main(string[] args)
	{
		int num = 0, last = 999, ans = 0;
		while (num <= last){
			string st = Convert.ToString(num);
			int cnt = 0;
			foreach (var elem in st){
				if (elem == '7'){
					cnt += 1;
				}
			}
			if (cnt == 1){
				ans += 1;
			}
			num += 1;
		}
		Console.WriteLine(ans);
	}
}
