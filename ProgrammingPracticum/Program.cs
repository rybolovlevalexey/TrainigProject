using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] spisok = Console.ReadLine().Split();
		for (int i = 0; i < n; i++){
			if (Convert.ToInt32(spisok[i]) % 2 == 0){
				Console.Write($"{spisok[i]} ");	
			} 
			
		}
	}
}
