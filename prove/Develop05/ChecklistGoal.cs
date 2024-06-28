using System;

public class ChecklistGoal : Goal {
    private int timesCompleted;
    private int timesNeededToComplete;
    private int progressPoints;

    public ChecklistGoal(int points, string name, int progressPoints, int timesNeededToComplete, bool isComplete = false, int timesCompleted = 0) : base(points, name, isComplete) {
        this.progressPoints = progressPoints;
        this.timesNeededToComplete = timesNeededToComplete;
        this.timesCompleted = timesCompleted;
    }

    public override int GetPoints()
    {
        if(this.timesCompleted == this.timesNeededToComplete){
            return base.GetPoints() + this.progressPoints;
        }
        return this.progressPoints;
    }
    public override void SetIsComplete(bool isComplete)
    {
        if(isComplete){
            this.timesCompleted++;
        }
        if(this.timesCompleted >= this.timesNeededToComplete && isComplete){
            base.SetIsComplete(isComplete);
        }
        if(isComplete == false){
            base.SetIsComplete(isComplete);
        }
    }

    public string GetTimesCompletedString() {
        return $"{this.timesCompleted}/{this.timesNeededToComplete}";
    }
    public int GetTimesCompleted() {
        return timesCompleted;
    }
    public int GetTimesNeededToComplete() {
        return timesNeededToComplete;
    }
    public int GetBonusPoints(){
        return this.points;
    }
}