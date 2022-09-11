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
		for (int i = 0; i < n; i++){
			if (sp[i] == x){
				Console.Write($"{i + 1} ");
			}
		}
	}
}
