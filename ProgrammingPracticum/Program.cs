using System;

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
		int rost = Convert.ToInt32(Console.ReadLine());
		int j = 0;
		while (j + 1 < n){
			if (rost > sp[0]){
				Console.WriteLine(1);
				break;
			}
			if (rost <= sp[j] && rost > sp[j + 1]){
				Console.WriteLine(j + 2);
				break;
			}
			if (rost < sp[j] && rost < sp[j + 1] && j + 2 == n){
				Console.WriteLine(n + 1);
			}
			j += 1;
		}
	}
}
