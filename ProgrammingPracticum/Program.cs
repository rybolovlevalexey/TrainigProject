using System;

class Program
{
	public static void Main(string[] args)
	{
		int n = Convert.ToInt32(Console.ReadLine());
		string[] spisok = Console.ReadLine().Split();
		int cnt = 0;
		for (int i = 0; i < n; i++){
			Console.WriteLine(Convert.ToInt32(spisok[i]));
			if (Convert.ToInt32(spisok[i]) > 0){
				cnt += 1;	
			} 
			
		}
		Console.WriteLine(cnt);
	}
}
