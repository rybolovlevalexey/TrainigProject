using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] spisok = Console.ReadLine().Split();
		int cnt = 0;
		bool flag = false;
		for (int i = 0; i + 1 < n; i++){
			char a = spisok[i][0];
			char b = spisok[i + 1][0];
			if (a == b && b == '-'){
				flag = true;
			}
		}
		if (flag){
			Console.WriteLine("YES");
		} else {
			Console.WriteLine("NO");

		}
	}
}
