using System;
	
class Program
{
	public static void Main(string[] args)
	{
		string[] st = Console.ReadLine().Split();
		int summa = 0;
		for (int i = 0; i < st.Length; i++){
			if (Convert.ToInt32(st[i]) % 2 == 0){
				summa += Convert.ToInt32(st[i]);
			}
		}
		Console.WriteLine(summa);
	}
}
