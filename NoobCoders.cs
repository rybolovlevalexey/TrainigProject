using System;

class Program
{
    public static void Main(string[] args)
    {
        double money = Convert.ToDouble(Console.ReadLine());
		if (0 < money && money < 100){
			Console.WriteLine($"Сумма вклада после начисления процентов: {money * 1.05}");
		} else if (money >= 100 && money <= 200){
			Console.WriteLine($"Сумма вклада после начисления процентов: {money * 1.07}");
		} else {
			Console.WriteLine($"Сумма вклада после начисления процентов: {money * 1.1}");
		}
	}
}
