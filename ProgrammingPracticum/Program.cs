using System;
	
class Program
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());
		if (num > 0){
			Console.WriteLine(1);
		} else if (num == 0){
			Console. WriteLine(0);
		} else {
			Console.WriteLine(-1);
		}
	}
}
