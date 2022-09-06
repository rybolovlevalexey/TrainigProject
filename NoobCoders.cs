using System;

class Program
{
    public static void Main(string[] args)
    {
        string[] st = Console.ReadLine().Split();
		int a = Convert.ToInt32(st[0]);
		int b = Convert.ToInt32(st[1]);
		int c = Convert.ToInt32(st[2]);
		int d = Convert.ToInt32(st[3]);
		int[] ans = new int[2];
		if (a <= b && a <= c && a <= d){
			ans[0] = a;
		} else {
			if (b <= d && b <= a && b <= c){
				ans[0] = b;
			} else if (c <= d && c <= b && c <= a){
				ans[0] = c;
			} else {
				ans[0] = d;
			}
		}

		if (a >= b && a >= c && a >= d){
			ans[1] = a;
		} else {
			if (b >= d && b >= a && b >= c){
				ans[1] = b;
			} else if (c >= d && c >= b && c >= a){
				ans[1] = c;
			} else {
				ans[1] = d;
			}
		}
		Console.WriteLine($"Наименьшее число - {ans[0]}");
		Console.WriteLine($"Наибольшее число - {ans[1]}");
	}
}
