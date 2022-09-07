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
		for (int i = 1; i < 8; i++){
			if (x1 + i == x2 && y1 + i == y2){
				flag = true;
			}
			if (x1 - i == x2 && y1 - i == y2){
				flag = true;
			}
			if (x1 + i == x2 && y1 - i == y2){
				flag = true;
			}
			if (x1 - i == x2 && y1 + i == y2){
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
