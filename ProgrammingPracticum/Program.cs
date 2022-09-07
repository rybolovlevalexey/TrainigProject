using System;
	
class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		int fak = 1;
		for (int i = 1; i <= n; i++){
			fak *= i;
		}
		Console.WriteLine(fak);
	}
}
