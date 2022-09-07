using System;
	
class Program
{
	public static void Main(string[] args)
	{
		string[] st = Console.ReadLine().Split(", ");
		int[] numbers = new int[st.Length];
		int summa = 0;
		for (int i = 0; i < st.Length; i++){
			numbers[i] = Convert.ToInt32(st[i]);
			summa += Convert.ToInt32(st[i]);
		}
		if (summa == 20){
			Console.WriteLine("О, отличник появился! На олимпиаду пойдешь");
		} else {
			bool flag2 = false, flag3 = false;
			foreach (var num in numbers){
				if (num == 2){
					flag2 = true;
				}
				if (num == 3){
					flag3 = true;
				}
			}
			if (flag2){
				Console.WriteLine("Ну что, студент, пора долг Родине отдать");
			} else if (flag3){
				Console.WriteLine("Прощай стипендия!");
			} else {
				Console.WriteLine("Живи пока, через полгода увидимся");
			}
		}
	}
}
