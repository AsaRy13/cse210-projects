using System;

class Program
{
    static void Main(string[] args)
    {
        EternalQuestSword eternalQuestSword = new EternalQuestSword();
        Quest quest = new Quest();
        Console.Clear();
        eternalQuestSword.PrintSword();
        Thread.Sleep(5000);

        Console.Clear();
        Console.WriteLine("Narrator: Welcome Adventurer to Eternal Quest!");
        if(quest.GetScore() == 0){
            Console.WriteLine($"Narrator: {quest.DisplayScore()}, but don't worry it won't be for long!");
        }
        else{
            Console.WriteLine($"Narrator: {quest.DisplayScore()}.");
        }
        Console.WriteLine("Narrator: Ah! Don't know where to get started I see. Here is a list to help get you started.");
        Console.WriteLine("You: Reads the options list that the voice gave you.");

        int quit = 0;
        while(quit == 0){
            Console.WriteLine("Options List:");
            Console.WriteLine("1. Display Quests");
            Console.WriteLine("2. Create New Quests");
            Console.WriteLine("3. Record a Quest as Complete or Partially Complete");
            Console.WriteLine("4. Save File");
            Console.WriteLine("5. Load File");
            Console.WriteLine("6. Quit");

            Console.Write("You: Picks option number ");
            string userInput = Console.ReadLine();

            if(userInput == "1"){
                quest.DisplayGoals();
            }
            else if(userInput == "2"){
                quest.CreateNewGoals();
            }
            else if(userInput == "3"){
                quest.RecordEvent();
            }
            else if(userInput == "4"){
                quest.SaveGoals();
            }
            else if(userInput == "5"){
                quest.LoadGoals();
            }
            else if(userInput == "6"){
                Console.Write("Narrator: Are you sure? (y/n): ");
                string quitInput = Console.ReadLine();
                if(quitInput.ToLower() == "y") {
                    quit = 1;
                }
            }
            else{
                Console.WriteLine("Narrator: That isn't in the list.");
                Thread.Sleep(1000);
            }

            Console.Clear();
            if(quest.GetScore() == 0){
                Console.WriteLine($"Narrator: {quest.DisplayScore()}, but don't worry it won't be for long!");
            }
            else{
                Console.WriteLine($"Narrator: {quest.DisplayScore()}.");
            }

            Console.WriteLine("You: Reads the Options List.");
        }
    }
}