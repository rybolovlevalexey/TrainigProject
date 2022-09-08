using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		int summa = 0;
		int mx = -1, mn = -1;
		while (n > 0){
			if (mx == -1){
				mx = n % 10;
				mn = n % 10;
			} else {
				if (mx < n % 10){
					mx = n % 10;
				}
				if (mn > n % 10){
					mn = n % 10;
				}
			}
			n /= 10;
		}
		Console.WriteLine($"{mn} {mx}");
	}
}
