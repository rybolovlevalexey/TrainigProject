using System;
using System.Collections.Generic;

class Program
{
	public static void Main(string[] args)
	{
		int num = 0, last = 999999, ans = 0;
		while (num <= last){
			bool flag = true;
			string st = Convert.ToString(num);
			for (int i = 0; i < st.Length - 1; i++){
				if (st[i] == st[i + 1]){
					flag = false;
					break;
				}
			}
			if (flag){
				ans += 1;
			}
			num += 1;
		}
		Console.WriteLine(ans);
	}
}
