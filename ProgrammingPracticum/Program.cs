using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] spisok = Console.ReadLine().Split();
		int cnt = 0;
		bool flag = false;
		for (int i = 1; i + 1 < n; i++){
			int a = Convert.ToInt32(spisok[i - 1]);
			int b = Convert.ToInt32(spisok[i]);
			int c = Convert.ToInt32(spisok[i + 1]);
			if (b > a && b > c){
				cnt++;
			}
		}
		Console.WriteLine(cnt);
	}
}
