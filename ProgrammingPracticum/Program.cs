using System;
	
class Program
{
	public static void Main(string[] args)
	{
		string st1 = Console.ReadLine();
		string st2 = Console.ReadLine();
		string ans = "";
		string newst1 = "";
		for (int i = 0; i < st1.Length; i++){
			bool flag = true;
			for (int j = 0; j < st1.Length; j++){
				if (i == j){
					continue;
				}
				if (st1[i] == st1[j]){
					flag = false;
				}
			}
			if (flag){
				newst1 = newst1 + st1[i];
			}
		}
		foreach (var letter in newst1){
			bool flag1 = true;
			foreach (var bykv in st2){
				if (letter == bykv){
					flag1 = false;
				}
			}
			if (flag1){
				ans = ans + Convert.ToString(letter) + " ";
			}
		}
		Console.WriteLine($"Уникально число {ans}");
	}
}
