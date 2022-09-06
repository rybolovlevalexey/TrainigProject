using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите номер операции: 1.Сложение 2.Вычитание 3.Умножение");
		int n = Convert.ToInt32(Console.ReadLine());
		switch(n){
			case 1:
				Console.WriteLine("Сложение");
				break;
			case 2:
				Console.WriteLine("Вычитание");
				break;
			case 3:
				Console.WriteLine("Умножение");
				break;
			default:
				Console.WriteLine("Неизвестная операция!");
				break;
		}
	}
}
