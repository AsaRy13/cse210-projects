using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");

        Person fred = new Person("Fred", "Fintstone");

        Person steve = new Person("Steve", "Minecraft");

        fred.EasternStyleName();
        steve.WesternStyleName();
    }
}