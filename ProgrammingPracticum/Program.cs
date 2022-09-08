using System;

class Program
{
	public static void Main(string[] args)
	{
		int n, m;
		string[] st = Console.ReadLine().Split();
		n = Convert.ToInt32(st[0]);
		m = Convert.ToInt32(st[1]);
		if (m % n == 0){
			Console.WriteLine(m / n);
		} else {
			Console.WriteLine(m / n + 1);
		}
	}
}
