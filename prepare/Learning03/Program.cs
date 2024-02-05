using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning03 World!");
        Fraction f = new Fraction();
        Fraction f1 = new Fraction(5);
        Fraction f2 = new Fraction(5, 10);


        Console.WriteLine(f.GetTop());
        Console.WriteLine(f.GetBottom());
        f.SetTop(3);
        f.SetBottom(9);
        Console.WriteLine();

        Console.WriteLine(f.GetFraction());
        Console.WriteLine(f.GetDecimal());

        Console.WriteLine(f1.GetFraction());
        Console.WriteLine(f1.GetDecimal());

        Console.WriteLine(f2.GetFraction());
        Console.WriteLine(f2.GetDecimal());
    }
}