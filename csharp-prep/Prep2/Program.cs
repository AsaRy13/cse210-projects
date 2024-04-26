using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage in your class?: ");
        string userInput = Console.ReadLine();
        int gradePercentage = int.Parse(userInput);

        string letter;
        int remainder = gradePercentage % 10;

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (remainder >= 7 && letter != "A" && letter != "F")
        {
            letter = letter + "+";
        }
        else if (remainder < 3 && letter != "F" && gradePercentage < 100)
        {
            letter = letter + "-";
        }

        Console.WriteLine(letter);

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Sorry, but you did not pass. Just keep learning and eventually you will pass.");
        }
    }
}