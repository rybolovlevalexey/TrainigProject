using System;
	
class Program
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());
		int x = Convert.ToInt32(Console.ReadLine());
		if (num > x){
			Console.WriteLine(1);
		} else if (num == x){
			Console. WriteLine(0);
		} else {
			Console.WriteLine(2);
		}
	}
}
