using System;

class Program
{
    public static void Main(string[] args)
    {
        int num = Convert.ToInt32(Console.ReadLine());
		if (num % 2 == 0){
			Console.WriteLine("EVEN");
		} else {
			Console.WriteLine("ODD");
		}
	}
}
