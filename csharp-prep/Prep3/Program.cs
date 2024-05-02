using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes") {
            Random randomNumber = new Random();
            int magicNumber = randomNumber.Next(1, 100);

            int magicGuess = 0;

            int guessNumber = 0;
            
            while (magicGuess != magicNumber) {
                Console.Write("What do you guess the magic number is?: ");
                magicGuess = int.Parse(Console.ReadLine());

                if (magicNumber == magicGuess) {
                    Console.WriteLine("Your guess was spot on!");
                    Console.WriteLine($"The number of times you inputed a guess is {guessNumber}.");
                }
                else if (magicGuess > magicNumber) {
                    Console.WriteLine("Your guess was too high.");
                }
                else if (magicGuess < magicNumber) {
                    Console.WriteLine("Your guess was too low.");
                }
                else {
                    Console.WriteLine("Your number was neither less than, greater than, nor equal to the correct number!");
                    Console.WriteLine("What did you do?!");
                }

                Console.WriteLine();

                guessNumber++;
            }

            Console.Write("Would you like to play again (yes or no)?: ");
            playAgain = Console.ReadLine();
        }
    }
}