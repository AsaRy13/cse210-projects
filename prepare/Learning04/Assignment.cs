using System;

public class Assignment {
    protected string studentName;
    private string topic;

    public Assignment(string studentName, string topic) {
        this.studentName = studentName;
        this.topic = topic;
    }

    public string GetSummary() {
        return $"{this.studentName} - {this.topic}";
    }
}