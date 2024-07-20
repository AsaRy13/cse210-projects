using System;

public class ReportGenerator {
    protected List<Transaction> transactions;
    protected List<int> amounts = new List<int>();
    protected List<string> categories = new List<string>();
    protected float total;
    protected float average;
    protected DateTime startDate;
    protected DateTime endDate;

    public ReportGenerator() {}

    public void DisplayReport(DateTime startDate, DateTime endDate) {
        this.startDate = startDate;
        this.endDate = endDate;
        //Code to display report
        Console.WriteLine("Name".PadRight(34) + "Amount".PadRight(31) + "Date");
        float total = 0;
        int averageDen = 0;
        int j = 0;
        for(int i = 0; i < transactions.Count(); i++) {
            if(transactions[i].GetDate().Day >= startDate.Day && transactions[i].GetDate().Month >= startDate.Month && transactions[i].GetDate().Year >= startDate.Year && transactions[i].GetDate().Day <= endDate.Day && transactions[i].GetDate().Month <= endDate.Month && transactions[i].GetDate().Year <= endDate.Year){
                Console.WriteLine($"{j + 1}.) {transactions[i].GetName().PadRight(30)}${transactions[i].GetAmount().ToString().PadRight(30)}{transactions[i].GetDate()}");
                total += transactions[i].GetAmount();
                averageDen++;
                j++;
            }
        }
        this.total = total;
        this.average = Convert.ToInt32(Math.Round(total/averageDen, 2));
        Console.WriteLine(">>>>Total".PadRight(34) + $"${this.total}");
        Console.WriteLine(">>>>Average".PadRight(34) + $"${this.average}");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
    public void SetReport(List<Transaction> transactions) {
        this.transactions = transactions;
    }
}