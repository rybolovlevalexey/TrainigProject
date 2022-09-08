using System;

class Program
{
	public static void Main(string[] args)
	{
		string[] st = Console.ReadLine().Split();
		double x = Convert.ToDouble(st[0]);
		double y = Convert.ToDouble(st[1]);
		int n = 1;
		double summa = 0;
		summa += x;
		while (summa <= y){
			x = x * 1.7;
			summa += x;
			n++;
		}
		Console.WriteLine(n);
	}
}
