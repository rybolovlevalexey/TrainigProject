using System;

class Program
{
    public static void Main(string[] args)
    {
        int num = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine(Convert.ToInt32(num % 10 == num / 1000 && num / 10 % 10 == num / 100 % 10));
	}
}
