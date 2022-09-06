using System;

class Program
{
    public static void Main(string[] args)
    {
        string glasnye = "уеэоаыяиюё";
		string letter = Console.ReadLine();
		for (int i = 0; i < glasnye.Length; i++){
			if (Convert.ToString(letter) == Convert.ToString(glasnye[i])){
				Console.WriteLine("гласная");
			}
		}
	}
}
