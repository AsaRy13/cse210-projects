using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("red", 3));
        shapes.Add(new Rectangle("green", 2, 4));
        shapes.Add(new Circle("blue", 5));

        for (int i = 0; i < shapes.Count(); i++) {
            Console.WriteLine($"The color is {shapes[i].GetColor()} and the area is {shapes[i].GetArea()}");
        }
    }
}