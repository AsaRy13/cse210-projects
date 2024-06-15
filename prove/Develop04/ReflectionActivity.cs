using System;

public class ReflectionActivity : Activity {
    private List<string> followupQuestions = new List<string>();

    public ReflectionActivity() {
        this.activityName = "Reflection Activity";

        this.prompts.Add("Think of a time when you did something really difficult.");
        this.prompts.Add("Think of a time when you stood up for someone else.");
        this.prompts.Add("Think of a time when you helped someone in need.");
        this.prompts.Add("Think of a time when you did something truly selfless.");

        this.followupQuestions.Add("How did you feel when it was complete?");
        this.followupQuestions.Add("What was your favorite thing about this experience?");
        this.followupQuestions.Add("Why was this experience meaningful to you?");
        this.followupQuestions.Add("Have you ever done anything like this before?");
        this.followupQuestions.Add("How did you get started?");
        this.followupQuestions.Add("What made this time different than other times when you were not as successful?");
        this.followupQuestions.Add("What could you learn from this experience that applies to other situations?");
        this.followupQuestions.Add("What did you learn about yourself through this experience?");
        this.followupQuestions.Add("How can you keep this experience in mind in the future?");
    }

    public override void RunActivity() {
        this.PrintDescription();
        this.time = int.Parse(Console.ReadLine());
        this.DelayAnimation();
        Random rand = new Random();
        int randPrompt = rand.Next(0, this.prompts.Count());
        List<int> previousQuestion = new List<int>();
        previousQuestion.Add(-1);

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {this.prompts[randPrompt]} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Now ponder each of the following questions as they related to this experience.");
        Console.Write("You may begin in: 5");
        Thread.Sleep(1000);
        Console.Write("\b \b4");
        Thread.Sleep(1000);
        Console.Write("\b \b3");
        Thread.Sleep(1000);
        Console.Write("\b \b2");
        Thread.Sleep(1000);
        Console.Write("\b \b1");
        Thread.Sleep(1000);
        Console.WriteLine();
        Console.Clear();

        while(this.time > 0) {
            Console.WriteLine();
            int randQuestion = rand.Next(0, this.followupQuestions.Count());
            int no = 0;
            int len;
            while(no == 0) {
                len = 0;
                if(previousQuestion.Count() - 1 == followupQuestions.Count()){
                    previousQuestion.Clear();
                    no = 1;
                }
                foreach(int i in previousQuestion) {
                    len++;
                    if(randQuestion == i) {
                        randQuestion = rand.Next(0, this.followupQuestions.Count());
                        break;
                    }
                    if(len == previousQuestion.Count()) {
                        no = 1;
                    }
                }
            }
            string question = this.followupQuestions[randQuestion];
            Console.Write($"> {question}");
            int wait = 15;
            Console.Write(" ");
            while(wait > 0) {
                Console.Write("/");
                Thread.Sleep(250);
                Console.Write("\b \b-");
                Thread.Sleep(250);
                Console.Write("\b \b\\");
                Thread.Sleep(250);
                Console.Write("\b \b|");
                Thread.Sleep(250);
                Console.Write("\b \b");
                this.time --;
                wait --;
            }
            previousQuestion.Add(randQuestion);
        }
        Console.Clear();
        this.CongradulateUser();
    }
    public override void PrintDescription() {
        Console.Clear();
        Console.WriteLine("Welcome to the Reflection Activity.");
        Console.WriteLine();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resiliance.");
        Console.WriteLine();
        Console.Write("How long in seconds would you like your session?: ");
    }
}