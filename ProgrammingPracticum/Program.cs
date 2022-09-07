using System;
	
class Program
{
	public static void Main(string[] args)
	{
		string st1 = Console.ReadLine();
		string st2 = Console.ReadLine();
		int n = 0;
		for (int i = 0; i < st1.Length; i++){
			if (Convert.ToInt32(st1[i]) == Convert.ToInt32(st2[i])){
				n++;
			}
		}
		Console.WriteLine($"Совпадение {n} элементов");
	}
}
