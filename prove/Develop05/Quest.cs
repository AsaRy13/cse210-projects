using System;
using System.IO;

public class Quest{
    private int score = 0;
    private List<Goal> goals = new List<Goal>();
    private List<string> newEntries = new List<string>();

    public Quest() {}

    public void DisplayGoals() {
        Console.Clear();
        Console.WriteLine("You: Reads List of Your Quests.");
        Console.WriteLine("The List of Your Quests:");
        if(goals.Count() == 0){
            Console.WriteLine();
            Console.WriteLine("Your Quest List is empty!");
        }
        for(int i = 0; i < goals.Count(); i++){
            if(goals[i] is SimpleGoal simpleGoal){
                Console.WriteLine();
                if(simpleGoal.GetIsComplete()){
                    Console.WriteLine($"{i + 1}. [x]{simpleGoal.GetName()} - {simpleGoal.GetIsCompleteString()} - Points: {simpleGoal.GetPoints()}.");
                }
                else{
                    Console.WriteLine($"{i + 1}. [ ]{simpleGoal.GetName()} - {simpleGoal.GetIsCompleteString()} - Points: {simpleGoal.GetPoints()}.");
                }
            }
            else if(goals[i] is EternalGoal eternalGoal){
                Console.WriteLine();
                Console.WriteLine($"{i + 1}. [∞]{eternalGoal.GetName()} - Points: {eternalGoal.GetPoints()}");
            }
            else if(goals[i] is ChecklistGoal checklistGoal){
                Console.WriteLine();
                Console.Write($"{i + 1}. ");
                for(int j = 0; j <= checklistGoal.GetTimesNeededToComplete(); j++){
                    if(j < checklistGoal.GetTimesCompleted()){
                        Console.Write("[x]");
                    }
                    else if(j > checklistGoal.GetTimesCompleted()){
                        Console.Write("[ ]");
                    }
                }
                Console.Write($"{checklistGoal.GetName()} - {checklistGoal.GetIsCompleteString()} - {checklistGoal.GetTimesCompletedString()} times done - Points: {checklistGoal.GetPoints()} - Bonus Points when entire quest is completed: {checklistGoal.GetBonusPoints()}.");
                Console.WriteLine();
            }
        }
        Console.WriteLine();
        Console.Write("Press any key to Continue ...");
        Console.ReadKey();
    }
    public void CreateNewGoals() {
        Console.Clear();
        Console.WriteLine("The Quest Smith: \"Welcome to my Quest Forge!\"");
        Console.WriteLine("The Quest Smith: \"Now, what shall the name of your new quest be?\"");
        Console.Write("You: ");
        string name = Console.ReadLine();
        Console.WriteLine($"The Quest Smith: \"Yes, {name} is an excellent name for a quest!\"");
        Console.WriteLine("The Quest Smith: \"Now, shall this quest be (1) A Simple Goal, (2) An Eternal Goal, or (3) A Checklist Goal?\"");
        Console.Write("You: ");
        string type = Console.ReadLine();
        if(type == "1" || type.ToLower() == "simple" || type.ToLower() == "simple goal" || type.ToLower() == "a simple goal"){
            Console.WriteLine("The Quest Smith: \"A Simple Goal, excellent!\"");
            Console.WriteLine("The Quest Smith: \"Now, there is one last thing that I need to know before I can forge this quest: How many points shall this quest award you \nwith?\"");
            Console.Write("You: ");
            int quit = 0;
            int points = 0;
            int sense = 0;

            while(quit == 0){
                string pointsString = Console.ReadLine();
                int stay = 0;

                try{
                    points = int.Parse(pointsString);
                }
                catch(System.FormatException){
                    stay = 1;
                    if(sense == 0){
                        Console.WriteLine("Narrator: All of a sudden your words start to sound like gibberish. Probably some gnomes pulling a prank on you.");
                        Console.WriteLine("The Quest Smith: \"What, why are you speaking this gibberish? Please tell me the number of points (in numeric form) that this quest shall award \nyou.\"");
                        Console.Write("You: ");
                        sense = 1;
                    }
                    else if(sense == 1){
                        Console.WriteLine("The Quest Smith: \"I can't understand what you are saying. Please write the number of points that this shall award you with using numbers.\"");
                        Console.Write("You: ");
                    }
                }

                if(stay == 0){
                    if(sense == 0){
                        Console.WriteLine($"The Quest Smith: \"Excellent! {points} points for your quest it is!\"");
                    }
                    else if(sense == 1){
                        Console.WriteLine($"The Quest Smith: \"Now you're starting to make sense! {points} points for your quest it is!\"");
                    }
                    quit = 1;
                }
            }
            goals.Add(new SimpleGoal(points, name));
        }
        else if(type == "2" || type.ToLower() == "eternal" || type.ToLower() == "eternal goal" || type.ToLower() == "an eternal goal"){
            Console.WriteLine("The Quest Smith: \"An Eternal Goal, excellent!\"");
            Console.WriteLine("The Quest Smith: \"Now, there is one last thing that I need to know before I can forge this quest: How many points shall this quest award you with each time you complete it?\"");
            Console.Write("You: ");
            int quit = 0;
            int points = 0;
            int sense = 0;

            while(quit == 0){
                string pointsString = Console.ReadLine();
                int stay = 0;

                try{
                    points = int.Parse(pointsString);
                }
                catch(System.FormatException){
                    stay = 1;
                    if(sense == 0){
                        Console.WriteLine("Narrator: All of a sudden your words start to sound like gibberish. Probably some gnomes pulling a prank on you.");
                        Console.WriteLine("The Quest Smith: \"What, why are you speaking this gibberish? Please tell me the number of points (in numeric form) that this quest shall award \nyou.\"");
                        Console.Write("You: ");
                        sense = 1;
                    }
                    else if(sense == 1){
                        Console.WriteLine("The Quest Smith: \"I can't understand what you are saying. Please write the number of points that this shall award you with using numbers.\"");
                        Console.Write("You: ");
                    }
                }

                if(stay == 0){
                    if(sense == 0){
                        Console.WriteLine($"The Quest Smith: \"Excellent! {points} points for your quest it is!\"");
                    }
                    else if(sense == 1){
                        Console.WriteLine($"The Quest Smith: \"Now you're starting to make sense! {points} points for your quest it is!\"");
                    }
                    quit = 1;
                }
            }
            goals.Add(new EternalGoal(points, name));
        }
        else if(type == "3" || type.ToLower() == "checklist" || type.ToLower() == "checklist goal" || type.ToLower() == "a checklist goal"){
            Console.WriteLine("The Quest Smith: \"A Checklist Goal, excellent!\"");
            Console.WriteLine("The Quest Smith: \"Now, how many times shall \nyou perform this quest before it is completed?\"");
            Console.Write("You: ");
            int quit = 0;
            int timesNeededToComplete = 0;
            int sense = 0;

            while(quit == 0){
                string pointsString = Console.ReadLine();
                int stay = 0;

                try{
                    timesNeededToComplete = int.Parse(pointsString);
                }
                catch(System.FormatException){
                    stay = 1;
                    if(sense == 0){
                        Console.WriteLine("Narrator: All of a sudden your words start to sound like gibberish. Probably some gnomes pulling a prank on you.");
                        Console.WriteLine("The Quest Smith: \"What, why are you speaking this gibberish? Please tell me the number of times (in numeric form) that you need to perform \nthis quest.\"");
                        Console.Write("You: ");
                        sense = 1;
                    }
                    else if(sense == 1){
                        Console.WriteLine("The Quest Smith: \"I can't understand what you are saying. Please write the number of times that you need to perform this quest \nusing numbers.\"");
                        Console.Write("You: ");
                    }
                }

                if(stay == 0){
                    if(sense == 0){
                        Console.WriteLine($"The Quest Smith: \"Excellent! You will now need to preform this quest {timesNeededToComplete} before you can complete it.\"");
                    }
                    else if(sense == 1){
                        Console.WriteLine($"The Quest Smith: \"Now you're starting to make sense! You will now need to preform this quest {timesNeededToComplete} before you can complete it.\"");
                    }
                    quit = 1;
                }
            }
            Console.WriteLine("The Quest Smith: \"Now, how many points shall this quest award you with each time you complete a part of it?\"");
            Console.Write("You: ");
            int quit2 = 0;
            int points = 0;
            int sense2 = 0;

            while(quit2 == 0){
                string pointsString = Console.ReadLine();
                int stay = 0;

                try{
                    points = int.Parse(pointsString);
                }
                catch(System.FormatException){
                    stay = 1;
                    if(sense2 == 0){
                        Console.WriteLine("Narrator: All of a sudden your words start to sound like gibberish. Probably some gnomes pulling a prank on you.");
                        Console.WriteLine("The Quest Smith: \"What, why are you speaking this gibberish? Please tell me the number of points (in numeric form) that this quest shall award \nyou.\"");
                        Console.Write("You: ");
                        sense2 = 1;
                    }
                    else if(sense2 == 1){
                        Console.WriteLine("The Quest Smith: \"I can't understand what you are saying. Please write the number of points that this shall award you with using numbers.\"");
                        Console.Write("You: ");
                    }
                }

                if(stay == 0){
                    if(sense2 == 0){
                        Console.WriteLine($"The Quest Smith: \"Excellent! Now you will be awarded {points} points every time you complete a part of this quest!\"");
                    }
                    else if(sense2 == 1){
                        Console.WriteLine($"The Quest Smith: \"Now you're starting to make sense! Now you will be awarded {points} points every time you complete a part of this quest!\"");
                    }
                    quit2 = 1;
                }
            }
            Console.WriteLine("The Quest Smith: \"Now, there is one last thing that I need to ask you before I can forge this quest: How many bonus points shall this quest give you for completing the whole quest?\"");
            Console.Write("You: ");
            int quit3 = 0;
            int pointsBonus = 0;
            int sense3 = 0;

            while(quit3 == 0){
                string pointsString = Console.ReadLine();
                int stay = 0;

                try{
                    pointsBonus = int.Parse(pointsString);
                }
                catch(System.FormatException){
                    stay = 1;
                    if(sense3 == 0){
                        Console.WriteLine("Narrator: All of a sudden your words start to sound like gibberish. Probably some gnomes pulling a prank on you.");
                        Console.WriteLine("The Quest Smith: \"What, why are you speaking this gibberish? Please tell me the number of points (in numeric form) that this quest shall award \nyou.\"");
                        Console.Write("You: ");
                        sense3 = 1;
                    }
                    else if(sense3 == 1){
                        Console.WriteLine("The Quest Smith: \"I can't understand what you are saying. Please write the number of points that this shall award you with using numbers.\"");
                        Console.Write("You: ");
                    }
                }

                if(stay == 0){
                    if(sense3 == 0){
                        Console.WriteLine($"The Quest Smith: \"Excellent! Now you will be awarded {pointsBonus} points every time you complete this quest!\"");
                    }
                    else if(sense3 == 1){
                        Console.WriteLine($"The Quest Smith: \"Now you're starting to make sense! Now you will be awarded {pointsBonus} points every time you complete this quest!\"");
                    }
                    quit3 = 1;
                }
            }
            goals.Add(new ChecklistGoal(pointsBonus, name, points, timesNeededToComplete));
        }
        else{
            Console.WriteLine("The Quest Smith: \"That's not a quest type!\"");
        }
        Thread.Sleep(5000);
    }
    public string DisplayScore() {
        return $"Your Score is currently: {this.score}";
    }
    public int GetScore() {
        return this.score;
    }
    public void RecordEvent() {
        this.DisplayGoals();
        Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b");
        Console.Write("                              ");
        Console.Write("\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b\b \b");
        int quit = 0;
        int questNumber = 0;

        if(goals.Count() == 0){
            return;
        }

        while(quit == 0){
            Console.Write("Narrator: Which goal did you complete all/a part of?\n");
            Console.Write($"You: Checks off the/a checkbox right next to quest number ");
            string questNumberString = Console.ReadLine();
            Console.WriteLine();
            int stay = 0;

            try{
                questNumber = int.Parse(questNumberString);
            }
            catch(System.FormatException){
                stay = 1;
                Console.WriteLine("Narrator: That isn't a number. Let's rewind the story a little bit...");
                Console.WriteLine();
            }

            if(stay == 0 && questNumber > 0 && questNumber <= goals.Count()){
                quit = 1;
            }
            else if(questNumber <= 0 || questNumber > goals.Count()) {
                Console.WriteLine("Narrator: That number is outside of the list range. Let's rewind the story a little bit...");
                Console.WriteLine();
            }
        }

        if(goals[questNumber - 1].GetIsComplete() == false){
            goals[questNumber - 1].SetIsComplete(true);
            this.score += goals[questNumber - 1].GetPoints();
            Console.WriteLine($"Narrator: Yay, you completed/took another step on the {goals[questNumber - 1].GetName()} quest!");
            Thread.Sleep(2000);
            return;
        }
        Console.WriteLine("Narrator: That quest is already complete.");
        Thread.Sleep(2000);
    }

    public void SaveGoals() {
        Console.Clear();
        Console.WriteLine("You: Casts \"Checkpoint.\"");
        if(goals.Count() == 0){
            Console.WriteLine("Narrator: You don't have any quests to save.");
            Thread.Sleep(2000);
            return;
        }
        Console.WriteLine("Narrator: Alright, what would you like to name your save file? (without extentions)");
        Console.Write("You: ");
        string file = $".\\{Console.ReadLine()}.txt";

        using (StreamWriter writer = new StreamWriter(file)){
            for(int i = 0; i < goals.Count(); i++){
                if(goals[i] is ChecklistGoal checklistGoal){
                    writer.WriteLine($"{goals[i].GetType()}<|>{goals[i].GetPoints()}<|>{goals[i].GetName()}<|>{goals[i].GetIsComplete()}<|>{checklistGoal.GetBonusPoints()}<|>{checklistGoal.GetTimesCompleted()}<|>{checklistGoal.GetTimesNeededToComplete()}");
                }
                else{
                    writer.WriteLine($"{goals[i].GetType()}<|>{goals[i].GetPoints()}<|>{goals[i].GetName()}<|>{goals[i].GetIsComplete()}");
                }
            }
            writer.WriteLine($"Score<|>{this.score}");
        }
        Console.WriteLine("Narrator: Done.");
        Thread.Sleep(1000);
    }
    public void LoadGoals() {
        Console.Clear();
        Console.WriteLine("You: Casts \"Portal to Checkpoint\"");
        Console.WriteLine("Narrator: Alright, what is the name of the save file that you would like to load? (without extentions)");
        Console.Write("You: ");
        string file = $".\\{Console.ReadLine()}.txt";
        int caught = 0;

        try{
            using (StreamReader read = new StreamReader(file)){
                string line;
                newEntries.Clear();
                goals.Clear();
                while((line = read.ReadLine()) != null){
                    newEntries = line.Split("<|>").ToList();
                    if(newEntries[0] == "SimpleGoal"){
                        goals.Add(new SimpleGoal(int.Parse(newEntries[1]), newEntries[2], bool.Parse(newEntries[3])));
                    }
                    else if(newEntries[0] == "EternalGoal") {
                        goals.Add(new EternalGoal(int.Parse(newEntries[1]), newEntries[2]));
                    }
                    else if(newEntries[0] == "ChecklistGoal"){
                        goals.Add(new ChecklistGoal(int.Parse(newEntries[4]), newEntries[2], int.Parse(newEntries[1]), int.Parse(newEntries[6]), bool.Parse(newEntries[3]), int.Parse(newEntries[5])));
                    }
                    else if(newEntries[0] == "Score"){
                        this.score = int.Parse(newEntries[1]);
                    }
                }
            }
        }
        catch(System.IO.FileNotFoundException){
            Console.WriteLine("Narrator: That File doesn't exist.");
            caught = 1;
        }

        if(caught == 0){
            Console.WriteLine("Narrator: Done.");
        }
        Thread.Sleep(1000);
    }
}