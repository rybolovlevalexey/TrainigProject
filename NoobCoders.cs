using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите два числа через пробел: длина и ширина стола");
		double a, b;
		string[] st = Console.ReadLine().Split(" ");
		a = Convert.ToDouble(st[0]) - 0.2;
		b = Convert.ToDouble(st[1]) - 0.2;
		Console.WriteLine($"Площадь стола: {a * b}");
    }
}
