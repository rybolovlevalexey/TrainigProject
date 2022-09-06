using System;

class Program
{
    public static void Main(string[] args)
    {
        string[] st = Console.ReadLine().Split();
		int a = Convert.ToInt32(st[0]);
		int b = Convert.ToInt32(st[1]);
		int c = Convert.ToInt32(st[2]);

		if (a <= b && a <= c){
			Console.WriteLine(a);
		} else if (b <= a && b <= c){
			Console.WriteLine(b);
		} else {
			Console.WriteLine(c);
		}
	}
}
