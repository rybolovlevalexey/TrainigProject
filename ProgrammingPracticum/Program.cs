using System;
	
class Program
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());
		int mxcnt = num * 2 - 1;
		string st = "";
		int i = 1;
		while (i <= num){
			st = "";
			for (int j = 0; j < num - i; j++){
				st = st + " ";
			}
			for (int j = 0; j < i * 2 - 1; j++){
				st = st + "*";
			}
			Console.WriteLine(st);
			i++;
		}
	}
}
