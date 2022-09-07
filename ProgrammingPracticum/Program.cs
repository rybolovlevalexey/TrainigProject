using System;
	
class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		int summa = 0;
		int i = 0;
		while (true){
			if (summa + i >= n){
				break;
			}
			Console.WriteLine(i);
			summa += i;
			i++;
		}
	}
}
