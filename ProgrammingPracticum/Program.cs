using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] spisok = Console.ReadLine().Split();
		string[] ans = new string[n];
		int cnt = 0;
		bool flag = false;
		ans[0] = spisok[n - 1];
		for (int i = 0; i + 1 < n; i++){
			ans[i + 1] = spisok[i];
		}
		foreach (var el in ans){
			Console.Write($"{el} ");
		}
	}
}
