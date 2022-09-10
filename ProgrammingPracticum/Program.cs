using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] spisok = Console.ReadLine().Split();
		int cnt = 0;
		bool flag = false;
		for (int i = 1; i * 2 < n; i++){
			string a = spisok[i];
			string b = spisok[n - i - 1];
			spisok[i] = b;
			spisok[n - i - 1] = a;
		}
		foreach (var el in spisok){
			Console.Write($"{el} ");
		}
	}
}
