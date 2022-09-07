using System;
	
class Program
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());
		int ans = 0;
		while (num != 1){
			if (num % 2 == 0){
				num /= 2;
			} else {
				num = num * 3 + 1;
			}
			ans++;
		}
		Console.WriteLine($"Количество необходимых действий над числом - {ans}");
	}
}
