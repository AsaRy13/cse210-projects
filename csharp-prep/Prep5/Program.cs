using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string uName = PromptUserName();
        int uNumber = PromptUserNumber();
        int squared = SquareNumber(uNumber);
        DisplayResult(uName, squared);

    }
    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName() {
        Console.Write("What is your name?: ");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber() {
        Console.Write("What is your favorite number?: ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }
    static int SquareNumber(int baseNumber) {
        int squaredNumber = Convert.ToInt32(Math.Pow(baseNumber, 2));
        return squaredNumber;
    }
    static void DisplayResult(string theName, int theSquared) {
        Console.WriteLine($"{theName}, the square of your number is {theSquared}.");
    }
}