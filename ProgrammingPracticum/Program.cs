using System;
using System.Collections.Generic;

class Program
{
	public static void Main(string[] args)
	{
		//int n = Convert.ToInt32(Console.ReadLine());
		string[] st1 = Console.ReadLine().Split();
		string[] st2 = Console.ReadLine().Split();
		int[] sp1 = new int[st1.Length];
		int[] sp2 = new int[st2.Length];
		List<int> sp = new List<int>();
		for (int i = 0; i < st1.Length; i++){
			sp1[i] = Convert.ToInt32(st1[i]);
		}
		for (int i = 0; i < st2.Length; i++){
			sp2[i] = Convert.ToInt32(st2[i]);
		}
		int ans = 0;
		foreach (var el1 in sp1){
			bool flag1 = false, flag2 = true;
			foreach (var el2 in sp2){
				if (el1 == el2){
					flag1 = true;
					break;
				}
			}
			foreach (var a in sp){
				if (a == el1){
					flag2 = false;
				}
			}
			if (flag1 && flag2){
				ans += 1;
			}
		}
		Console.WriteLine(ans);
	}
}
