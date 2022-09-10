using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] spisok = Console.ReadLine().Split();
		int cnt = 0;
		bool flag = false;
		for (int i = 0; i + 1 < n; i += 2){
			string a = spisok[i];
			string b = spisok[i + 1];
			spisok[i] = b;
			spisok[i + 1] = a;
		}
		foreach (var el in spisok){
			Console.Write($"{el} ");
		}
	}
}
