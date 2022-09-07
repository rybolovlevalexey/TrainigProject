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
		for (int i = 0; i < numbers.Length; i++){
			for (int j = i; j < numbers.Length - 1; j++){
				int a = numbers[j];
				int b = numbers[j + 1];
				if (a > b){
					numbers[j] = b;
					numbers[j + 1] = a;
				}
			}
		}
		foreach (var num in numbers){
			Console.Write($"{num} ");
		}
	}
}
