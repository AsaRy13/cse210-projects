using System;

class Program
{
    static void Main(string[] args)
    {
        int quit = 0;
        while(quit == 0) {
            Console.Clear();
            Console.WriteLine("Sandbox Menu");
            Console.WriteLine("1. ICE Smart Home");
            Console.WriteLine("2. Test");
            Console.WriteLine("3. Quit");
            Console.Write("Please input the number of the option that you would like to select: ");
            string userInput = Console.ReadLine();

            if(userInput == "1") {
                ICESmartHome.SmartHome();
            }
            else if(userInput == "2") {
                Test.RunTimeTest();
            }
            else if(userInput == "3") {
                quit = 1;
            }
        }
    }
}