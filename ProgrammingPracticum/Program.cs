using System;

class Program
{
	public static void Main(string[] args)
	{
		int n, a, b, c, d;
		string[] st = Console.ReadLine().Split();
		n = Convert.ToInt32(st[0]);
		a = Convert.ToInt32(st[1]) - 1;
		b = Convert.ToInt32(st[2]) - 1;
		c = Convert.ToInt32(st[3]) - 1;
		d = Convert.ToInt32(st[4]) - 1;
		int[] sp = new int[n];
		for (int k = 0; k < n; k++){
			sp[k] = k + 1;
		}
		int i = 0;
		while (a + 2 * i <= b){
			int x1 = sp[a + i], x2 = sp[b - i];
			sp[a + i] = x2;
			sp[b - i] = x1;
			i += 1;
		}
		i = 0;
		while (c + i * 2 <= d){
			int y1 = sp[c + i];
			int y2 = sp[d - i];
			sp[c + i] = y2;
			sp[d - i] = y1;
			i += 1;
		}
		foreach (var elem in sp){
			Console.Write($"{elem} ");
		}
	}
}
