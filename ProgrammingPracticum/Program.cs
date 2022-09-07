using System;

class Program
{
	public static void Main(string[] args)
	{
		double x1 = Convert.ToDouble(Console.ReadLine());
		double y1 = Convert.ToDouble(Console.ReadLine());
		double x2 = Convert.ToDouble(Console.ReadLine());
		double y2 = Convert.ToDouble(Console.ReadLine());
		bool flag = false;
		int[] numb1 = {-1, 1};
		int[] numb2 = {-2, 2};
		foreach (var i in numb1){
			foreach (var j in numb2){
				if (x1 + i == x2 && y1 + j == y2){
					flag = true;
				}
			}
		}
		foreach (var i in numb2){
			foreach (var j in numb1){
				if (x1 + i == x2 && y1 + j == y2){
					flag = true;
				}
			}
		}
		if (flag){
			Console.WriteLine("YES");
		} else {
			Console.WriteLine("NO");
		}
	}
}
