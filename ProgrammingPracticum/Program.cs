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
		int x = 0, ind = 0;
		for (int i = 0; i < n; i++){
			if (i == 0 || x > sp[i]){
				x = sp[i];
				ind = i;
			}
		}
		Console.Write($"{x} ");
		for (int i = 0; i < n; i++){
			if ((i == 0 || x > sp[i]) && ind != i){
				x = sp[i];
			}
		}
		Console.Write(x);
	}
}
