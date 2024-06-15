using System;
using System.Security.Cryptography;

public class ListingActivity : Activity {
    private Random rand = new Random();
    public ListingActivity() {
        this.activityName = "Listing Activity";

        this.prompts.Add("Who are people that you appreciate?");
        this.prompts.Add("What are personal strengths of yours?");
        this.prompts.Add("Who are people that you have helped this week?");
        this.prompts.Add("When have you felt the Holy Ghost this month?");
        this.prompts.Add("Who are some of your personal heroes?");
    }

    public override void RunActivity() {
        this.PrintDescription();
        this.time = int.Parse(Console.ReadLine());
        this.DelayAnimation();
        int randPrompt = this.rand.Next(0, prompts.Count());
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {this.prompts[randPrompt]} ---");
        Console.Write("You may begin in: ");
        for(int i = 5; i > 0; i--) {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
        int entries = 0;
        while(this.time > 0) {
            Console.Write("> ");

            //From Stackoverflow:
            string readline = "?";
            ThreadPool.QueueUserWorkItem(
                delegate
                {
                    readline = Console.ReadLine();
                }
            );
            do
            {
                Thread.Sleep(1000);
                this.time --;

            } while (readline == "?");
            entries ++;
        }

        Console.Clear();
        Console.WriteLine($"You wrote {entries} items.");
        Console.WriteLine();
        this.CongradulateUser();
    }
    public override void PrintDescription() {
        Console.Clear();
        Console.WriteLine("Welcome to the Listing Activity.");
        Console.WriteLine();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine();
        Console.Write("How long in seconds would you like your session?: ");
    }
}