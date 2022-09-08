using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		int cnt = 0, num = 1;
		while (num <= n){
			string st1 = Convert.ToString(num), st2 = "";
			int rnum = num;
			while (rnum > 0){
				st2 = st2 + Convert.ToString(rnum % 10);
				rnum /= 10;
			}
			num += 1;
			if (st1 == st2){
				cnt += 1;
			}
		}
		Console.WriteLine(cnt);
	}
}
