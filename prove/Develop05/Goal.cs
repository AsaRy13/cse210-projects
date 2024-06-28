using System;

public abstract class Goal {
    protected int points;
    protected bool isComplete;
    protected string name;

    public Goal(int points, string name, bool isComplete = false) {
        this.points = points;
        this.name = name;
        this.isComplete = isComplete;
    }

    public virtual int GetPoints() {
        return this.points;
    }
    public bool GetIsComplete() {
        return this.isComplete;
    }
    public string GetIsCompleteString(){
        if(this.isComplete){
            return "Complete";
        }
        return "Incomplete";
    }
    public virtual void SetIsComplete(bool isComplete) {
        this.isComplete = isComplete;
    }
    public string GetName() {
        return this.name;
    }
}