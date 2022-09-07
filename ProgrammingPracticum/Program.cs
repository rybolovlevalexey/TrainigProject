using System;
	
class Program
{
	public static void Main(string[] args)
	{
		string st = Console.ReadLine();
		int[] numbers = new int[st.Length];
		int mn = 0, mx = 0;
		for (int i = 0; i < st.Length; i++){
			int elem = Convert.ToInt32(Convert.ToString(st[i]));
			numbers[i] = elem;
			if (i == 0){
				mx = elem;
				mn = elem;
			} else {
				if (mx < elem){
					mx = elem;
				}
				if (mn > elem){
					mn = elem;
				}
			}
		}
		for (int i = numbers.Length - 1; i > -1; i--){
			Console.Write(numbers[i]);
		}
		Console.Write(mx);
		Console.Write(mn);
	}
}
