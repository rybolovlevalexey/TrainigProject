using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] sp = Console.ReadLine().Split();
		int lst = 0;
		int ans = 0;
		for (int i = 0; i < n; i++){
			if (i == 0){
				ans += 1;
				lst = Convert.ToInt32(sp[i]);
			} else {
				if (lst != Convert.ToInt32(sp[i])){
					ans += 1;
					lst = Convert.ToInt32(sp[i]);
				}
			}
		}
		Console.WriteLine(ans);
	}
}
