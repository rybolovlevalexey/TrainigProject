using System;

class Program
{
	public static void Main(string[] args)
	{
		string[] st = Console.ReadLine().Split();
		int norm_x = Convert.ToInt32(Convert.ToDouble(st[0]) * Math.Pow(10, 5));
		int norm_y = Convert.ToInt32(Convert.ToDouble(st[1]) * Math.Pow(10, 5));
		int norm_z = Convert.ToInt32(Convert.ToDouble(st[2]) * Math.Pow(10, 5));
		int x = 0, y = 0, z = 0;
		int cnt = Convert.ToInt32(Console.ReadLine());
		for (int i = 0; i < cnt; i++){
			string[] st1 = Console.ReadLine().Split();
			int a = Convert.ToInt32(Convert.ToDouble(st1[0]) * Math.Pow(10, 5));
			int b = Convert.ToInt32(Convert.ToDouble(st1[1]) * Math.Pow(10, 5));
			int c = Convert.ToInt32(Convert.ToDouble(st1[2]) * Math.Pow(10, 5));
			int k = Convert.ToInt32(Convert.ToDouble(st1[3]));
			x += a * k;
			y += b * k;
			z += c * k;
		}
		Console.WriteLine($"{x}, {y}, {z}");
		Console.WriteLine($"{norm_x}, {norm_y}, {norm_z}");
		if (x >= norm_x && y >= norm_y && z >= norm_z){
			Console.WriteLine("YES");
		} else {
			Console.WriteLine("NO");
		}
	}
}
