using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction one = new Fraction();
        Fraction two = new Fraction(5);
        Fraction three = new Fraction(3, 4);
        Fraction four = new Fraction(1, 3);

        Console.WriteLine(one.GetFractionString());
        Console.WriteLine(one.GetDecimalValue());
        Console.WriteLine(two.GetFractionString());
        Console.WriteLine(two.GetDecimalValue());
        Console.WriteLine(three.GetFractionString());
        Console.WriteLine(three.GetDecimalValue());
        Console.WriteLine(four.GetFractionString());
        Console.WriteLine(four.GetDecimalValue());
    }
}