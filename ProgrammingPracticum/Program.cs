using System;
	
class Program
{
	public static void Main(string[] args)
	{
		string[] st = Console.ReadLine().Split();
		int[] numbers = new int[st.Length];
		for (int i = 0; i < st.Length; i++){
			numbers[i] = Convert.ToInt32(st[i]);
		}
		int mn = 0, mx = 0;
		for (int i = 0; i < numbers.Length; i++){
			if (i == 0){
				mn = numbers[i];
				mx = numbers[i];
			} else {
				if (numbers[i] < mn){
					mn = numbers[i];
				}
				if (numbers[i] > mx){
					mx = numbers[i];
				}
			}
		}
		Console.WriteLine($"Наименьшее значение = {mn}");
		Console.WriteLine($"Наибольшее значение = {mx}");
	}
}
