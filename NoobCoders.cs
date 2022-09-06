using System;

class Program
{
    public static void Main(string[] args)
    {
        int a, b;
		string[] st = Console.ReadLine().Split();
		a = Convert.ToInt32(st[0]);
		b = Convert.ToInt32(st[1]);
		if (a == b){
			Console.WriteLine("a = b");
		} else if (a < b){
			Console.WriteLine("a < b");
		} else {
			Console.WriteLine("a > b");
		}
	}
}
