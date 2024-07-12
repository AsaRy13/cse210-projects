using System;

public class ReportGenerator {
    protected List<float> amounts = new List<float>();
    protected float total;
    protected float average;
    protected string category;
    protected DateTime startDate;
    protected DateTime endDate;

    public ReportGenerator(List<Transaction> transactions) {
        //Code to separate transactions into the fields.
    }

    public void DisplayReport(DateTime startDate, DateTime endDate) {
        this.startDate = startDate;
        this.endDate = endDate;
        //Code to display report
    }
}