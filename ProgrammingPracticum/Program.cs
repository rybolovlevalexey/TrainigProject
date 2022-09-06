using System;
	
class Program
{
	public static void Main(string[] args)
	{
		int ans1, ans2;
		ans1 = Convert.ToInt32(Console.ReadLine());
		ans2 = Convert.ToInt32(Console.ReadLine());
		if ((ans1 == ans2 && ans1 == 1) || (ans1 != 1 && ans2 != 1)){
			Console.WriteLine("YES");
		} else {
			Console.WriteLine("NO");
		}
	}
}
