using System;

class Program
{
    static void Main(string[] args)
    {
        int quit = 0;
        while(quit == 0) {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Sandbox Menu");
            Console.WriteLine("1. ICE Smart Home");
            Console.WriteLine("2. Test");
            Console.WriteLine("3. Eternal Quest Sword");
            Console.WriteLine("4. Test Form");
            Console.WriteLine("5. Quit");
            Console.Write("Please input the number of the option that you would like to select: ");
            string userInput = Console.ReadLine();

            if(userInput == "1") {
                ICESmartHome.SmartHome();
            }
            else if(userInput == "2") {
                Test.RunTimeTest();
            }
            else if(userInput == "3") {
                EternalQuestSword eternalQuestSword = new EternalQuestSword();
                eternalQuestSword.PrintSword();
                Console.WriteLine();
                Console.Write("Press any key to continue ...");
                Console.ReadKey();
                Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b");
                Console.Write("                              ");
                Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b");
                Thread.Sleep(5000);
                Console.Write("Test");
                Thread.Sleep(5000);
            }
            else if(userInput == "4") {
                Application.Run(new TestForm());
            }
            else if(userInput == "5") {
                quit = 1;
            }
            else {
                Console.WriteLine();
                Console.Write("I didn't understand that.");
                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }
    }
}