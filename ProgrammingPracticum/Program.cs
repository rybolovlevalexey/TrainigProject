using System;
	
class Program
{
	public static void Main(string[] args)
	{
		int first = Convert.ToInt32(Console.ReadLine());
		int second = Convert.ToInt32(Console.ReadLine());
		int n = first, m = second;
		int ans = -1;
		while (n > 0){
			m = second;
			while (m > 0){
				if (m % 10 == n % 10){
					ans = m % 10;
					break;
				}
				m = m / 10;
			}
			n = n / 10;
			if (ans != - 1){
				break;
			}
		}
		while (first > 0){
			if (first % 10 == ans){
				Console.Write($"{ans} ");
			}
			first = first / 10;
		}
	}
}
