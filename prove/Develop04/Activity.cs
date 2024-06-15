using System;

public abstract class Activity {
    protected List<string> prompts = new List<string>();
    protected int time;
    protected string activityName;
    private List<string> delayAnimationList = new List<string>();

    public Activity() {
        delayAnimationList.Add("-_________");
        delayAnimationList.Add("_-________");
        delayAnimationList.Add("__-_______");
        delayAnimationList.Add("___-______");
        delayAnimationList.Add("____-_____");
        delayAnimationList.Add("_____-____");
        delayAnimationList.Add("______-___");
        delayAnimationList.Add("_______-__");
        delayAnimationList.Add("________-_");
        delayAnimationList.Add("_________-");
    }

    public void DelayAnimation() {
        Console.Clear();
        Console.WriteLine("Get Ready...");
        for(int j = 0; j <= 1; j++) {
            for(int i = 0; i < delayAnimationList.Count(); i++) {
                Console.Write(delayAnimationList[i]);
                Thread.Sleep(500);
                Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b");
            }
        }
        Console.WriteLine();
    }
    public virtual void CongradulateUser() {
        Console.WriteLine($"Congradulations on completing the {activityName}!");
        Thread.Sleep(5000);
    }
    public abstract void PrintDescription();
    public abstract void RunActivity();
}