using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] spisok = Console.ReadLine().Split();
		string[] ans = new string[n];
		int cnt = 0, mx = 0;
		bool flag = false;
		for (int i = 0; i < n; i++){
			if (i == 0){
				mx = Convert.ToInt32(spisok[i]);
			} else {
				if (mx < Convert.ToInt32(spisok[i])){
					mx = Convert.ToInt32(spisok[i]);
				}
			}
		}
		Console.WriteLine(mx);
		//foreach (var el in ans){
		//	Console.Write($"{el} ");
		//}
	}
}
