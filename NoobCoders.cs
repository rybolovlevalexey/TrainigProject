using System;

class Program
{
    public static void Main(string[] args)
    {
        int num;
		num = Convert.ToInt32(Console.ReadLine());
		string ans = "";
		if (num == 0){
			Console.WriteLine(0);
		} else {
			while (num > 0){
				int ost = num % 16;
				num = num / 16;
				//Console.WriteLine(num);
				if (ost < 10){
					ans = Convert.ToString(ost) + ans;
				} else {
					switch(ost){
						case 10:
							ans = "a" + ans;
							break;
						case 11:
							ans = "b" + ans;
							break;
						case 12:
							ans = "c" + ans;
							break;
						case 13:
							ans = "d" + ans;
							break;
						case 14:
							ans = "e" + ans;
							break;
						case 15:
							ans = "f" + ans;
							break;
					}
				}
			}
			Console.WriteLine(ans);
	    }
	}
}
