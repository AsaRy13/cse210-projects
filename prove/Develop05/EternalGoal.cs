using System;

public class EternalGoal : Goal {
    public EternalGoal(int points, string name, bool isComplete = false) : base(points, name, isComplete) {}

    public override void SetIsComplete(bool isComplete)
    {
        /*Eternal Goals never are actually marked complete, so you can complete them as many times as you
        like and they still give you the points.*/
    }
}