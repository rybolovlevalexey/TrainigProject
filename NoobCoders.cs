using System;

class Program
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
		switch(n % 7){
			case 1:
				Console.WriteLine("Понедельник");
				break;
			case 2:
				Console.WriteLine("Вторник");
				break;
			case 3:
				Console.WriteLine("Среда");
				break;
			case 4:
				Console.WriteLine("Четверг");
				break;
			case 5:
				Console.WriteLine("Пятница");
				break;
			case 6:
				Console.WriteLine("Суббота");
				break;
			case 0:
				Console.WriteLine("Воскресенье");
				break;
		}
	}
}
