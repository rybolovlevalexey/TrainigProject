using System;

class Program {
  public static void Main (string[] args) {
      Console.WriteLine ("Введите значение радиуса круга");
      double r;
      r = Convert.ToDouble(Console.ReadLine());
      double p, s;
      p = 2 * r * Math.PI;
      s = Math.PI * r * r;
      Console.WriteLine($"Периметр: {p}, площадь: {s}");
  }
}
