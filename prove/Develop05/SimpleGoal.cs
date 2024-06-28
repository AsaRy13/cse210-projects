using System;

public class SimpleGoal : Goal {
    //This class is not empty, it has a constructor.
    public SimpleGoal(int points, string name, bool isComplete = false) : base(points, name, isComplete) {}
}