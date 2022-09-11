using System;
using System.Collections.Generic;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		List<int> spisok = new List<int>();
		int dlina = 0;
		for (int k = 0; k < n; k++){
			string[] st = Console.ReadLine().Split();
			if (st[0] == "ADD"){
				int num = Convert.ToInt32(st[1]);
				bool flag = true;
				foreach (var elem in spisok){
					if (elem == num){
						flag = false;
					}
				}
				if (flag){
					spisok.Add(num);
					dlina += 1;
				}	
			}
			
			if (st[0] == "COUNT"){
				Console.WriteLine(dlina);
			}

			if (st[0] == "PRESENT"){
				int num = Convert.ToInt32(st[1]);
				bool flag = false;
				foreach (var elem in spisok){
					if (num == elem){
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
	}
}
