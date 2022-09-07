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
		int[] numbers = {-1, 0, 1};
		foreach (var i in numbers){
			foreach (var j in numbers){
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
