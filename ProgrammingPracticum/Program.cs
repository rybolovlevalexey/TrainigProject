using System;

class Program
{
    public static void Main(string[] args)
    {
        int n, m;
		n = Convert.ToInt32(Console.ReadLine());
		m = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine(Convert.ToInt32(n % m == 0 || m % n == 0));
	}
}
