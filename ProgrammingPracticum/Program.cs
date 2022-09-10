using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] spisok = Console.ReadLine().Split();
		for (int i = 0; i < n; i += 2){
			Console.Write($"{spisok[i]}");
		}
	}
}
