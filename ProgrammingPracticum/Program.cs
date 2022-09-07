using System;
	
class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		int m = Convert.ToInt32(Console.ReadLine());
		int summa = 0;
		for(int i = n; i <= m; i++){
			bool flag = true;
			if (i == 1){
				flag = false;
			} else {
				for (int d = 2; d < i/2+1; d++){
					if (i % d == 0 && i != d){
						flag = false;
						break;
					}
				}
			}
			if (flag && i > 0){
				summa += i;
			}
		}
		Console.WriteLine($"Сумма простых чисел = {summa}");
	}
}
