using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] spisok = Console.ReadLine().Split();
		int cnt = 0;
		for (int i = 0; i + 1 < n; i++){
			int a = Convert.ToInt32(spisok[i]);
			int b = Convert.ToInt32(spisok[i + 1]);
			if (a < b){
				cnt += 1;
			}
		}
		Console.WriteLine(cnt);
	}
}
