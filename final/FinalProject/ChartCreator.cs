using System;

public class ChartCreator : ReportGenerator {
    public ChartCreator() {}

    public void CreateChart(DateTime startDate, DateTime endDate) {
        this.startDate = startDate;
        this.endDate = endDate;
        int dayAmount = 0;
        amounts.Clear();
        for(int i = 0; i < transactions.Count(); i++) {
            if(transactions[i].GetDate().Day >= startDate.Day && transactions[i].GetDate().Month >= startDate.Month && transactions[i].GetDate().Year >= startDate.Year && transactions[i].GetDate().Day <= endDate.Day && transactions[i].GetDate().Month <= endDate.Month && transactions[i].GetDate().Year <= endDate.Year){
                if(i > 0){
                    if(transactions[i].GetDate().Day == transactions[i - 1].GetDate().Day){
                        dayAmount += transactions[i].GetAmountInt();
                    }
                    else{
                        dayAmount += transactions[i].GetAmountInt();
                        amounts.Add(dayAmount);
                        dayAmount = 0;
                    }
                }
                else{
                    if(transactions[i].GetDate().Day == transactions[i + 1].GetDate().Day){
                        dayAmount += transactions[i].GetAmountInt();
                    }
                    else{
                        dayAmount += transactions[i].GetAmountInt();
                        amounts.Add(dayAmount);
                        dayAmount = 0;
                    }
                }
            }
        }
        Application.Run(new ChartCreatorForm(this.amounts, false, categories));
    }
    public void CreatePieChart(DateTime startDate, DateTime endDate) {
        this.startDate = startDate;
        this.endDate = endDate;
        int dayAmount = 0;
        amounts.Clear();
        for(int i = 0; i < transactions.Count(); i++) {
            if(transactions[i].GetDate().Day >= startDate.Day && transactions[i].GetDate().Month >= startDate.Month && transactions[i].GetDate().Year >= startDate.Year && transactions[i].GetDate().Day <= endDate.Day && transactions[i].GetDate().Month <= endDate.Month && transactions[i].GetDate().Year <= endDate.Year){
                if(i > 0){
                    if(transactions[i].GetDate().Day == transactions[i - 1].GetDate().Day){
                        dayAmount += transactions[i].GetAmountInt();
                    }
                    else{
                        dayAmount += transactions[i].GetAmountInt();
                        amounts.Add(dayAmount);
                        dayAmount = 0;
                    }
                }
                else{
                    if(transactions[i].GetDate().Day == transactions[i + 1].GetDate().Day){
                        dayAmount += transactions[i].GetAmountInt();
                    }
                    else{
                        dayAmount += transactions[i].GetAmountInt();
                        amounts.Add(dayAmount);
                        dayAmount = 0;
                    }
                }
                if(transactions[i] is Expense expense){
                    categories.Add(expense.GetCategory());
                }
                else{
                    categories.Add("Income");
                }
            }
        }
        Application.Run(new ChartCreatorForm(this.amounts, true, categories));
    }
}