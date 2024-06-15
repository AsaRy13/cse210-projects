using System;

public class BreathingActivity : Activity {
    private List<string> breathAnimation = new List<string>();
    public BreathingActivity() {
        this.activityName = "Breathing Activity";

        breathAnimation.Add("Breath in");
        breathAnimation.Add("|Breath in|");
        breathAnimation.Add("||Breath in||");
        breathAnimation.Add("|||Breath in|||");
        breathAnimation.Add("||||Breath in||||");
        breathAnimation.Add("||||||Breath out||||||");
        breathAnimation.Add("|||||Breath out|||||");
        breathAnimation.Add("||||Breath out||||");
        breathAnimation.Add("|||Breath out|||");
        breathAnimation.Add("||Breath out||");
        breathAnimation.Add("|Breath out|");
        breathAnimation.Add("Breath out");
    }

    public override void RunActivity() {
        this.PrintDescription();
        this.time = int.Parse(Console.ReadLine());
        this.DelayAnimation();
        this.BreathAnimation(this.time);
        Console.Clear();
        this.CongradulateUser();
    }
    public override void PrintDescription() {
        Console.Clear();
        Console.WriteLine("Welcome to the Breathing Activity.");
        Console.WriteLine();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.WriteLine();
        Console.Write("How long in seconds would you like your session?: ");
    }

    public string Backspace(int breathIndex, int bOut = 0) {
        string backspace = "";
        for(int i = 0; i <= breathAnimation[breathIndex].Length; i++) {
            backspace += "\b \b";
        }
        if(bOut == 1) {
            backspace += "  ";
        }
        if(bOut == 2) {
            backspace += " ";
        }
        return backspace;
    }

    public void BreathAnimation(float time) {
        if(time > 0) {
            Console.Write(breathAnimation[0].PadLeft(50));
            Thread.Sleep(1000);
            time --;
            Console.Write(this.Backspace(0, 0));
            Console.Write(breathAnimation[1]);
            Thread.Sleep(1000);
            time --;
            Console.Write(this.Backspace(1, 0));
            Console.Write(breathAnimation[2]);
            Thread.Sleep(1000);
            time --;
            Console.Write(this.Backspace(2, 0));
            Console.Write(breathAnimation[8]);
            Thread.Sleep(1000);
            time --;
            Console.Write(this.Backspace(8, 1));
            Console.Write(breathAnimation[9]);
            Thread.Sleep(1000);
            time --;
            Console.Write(this.Backspace(9, 1));
            Console.Write(breathAnimation[10]);
            Thread.Sleep(1000);
            time --;
            Console.Write(this.Backspace(10, 1));
            Console.Write(breathAnimation[11]);
            Thread.Sleep(1000);
            time --;
            Console.Write(this.Backspace(11, 2));
            while(time > 0) {
                for(int i = 0; i < breathAnimation.Count(); i++) {
                    Console.Write(breathAnimation[i]);
                    Thread.Sleep(1000);
                    if(i < 4) {
                        Console.Write(this.Backspace(i, 0));
                    }
                    else if(i == 4) {
                        Console.Write(this.Backspace(i, 0));
                        Console.Write("\b \b");
                    }
                    else if(i == 5) {
                        Console.Write(this.Backspace(i, 2));
                        Console.Write(" ");
                    }
                    else if(i > 5 && i < 11) {
                        Console.Write(this.Backspace(i, 1));
                    }
                    else if(i == 11) {
                        Console.Write(this.Backspace(i, 2));
                    }
                    time --;
                }
            }
        }
    }
}