using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите номер операции: 1.Сложение 2.Вычитание 3.Умножение");
		string[] st = Console.ReadLine().Split();
		int oper = Convert.ToInt32(st[0]);
		double first = Convert.ToDouble(st[1]);
		double second = Convert.ToDouble(st[2]);
		switch(oper){
			case 1:
				Console.WriteLine($"Результат операции {first + second}");
				break;
			case 2:
				Console.WriteLine($"Результат операции {first - second}");
				break;
			case 3:
				Console.WriteLine($"Результат операции {first * second}");
				break;
			default:
				Console.WriteLine("Неизвестная операция!");
				break;
		}
	}
}
