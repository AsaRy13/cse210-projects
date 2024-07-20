using System;
using Microsoft.VisualBasic.Logging;

public class Budget {
    private List<Transaction> transactionList;
    private SaveLoad saveLoad = new SaveLoad();
    private ReportGenerator reportGenerator = new ReportGenerator();
    private ChartCreator chartCreator = new ChartCreator();

    public Budget() {
        int quit2 = 0;

        while(quit2 == 0){
            Console.Clear();
            Console.WriteLine("Bank Teller: \"Hello! Would you like me to (1)fetch a budget or (2)make you a new one?\"");
            Console.Write("You: ");
            string userInput = Console.ReadLine();

            if(userInput == "1") {
                List<string> fileList = this.ListSaves();
                //Load budget
                Console.WriteLine("Bank Teller: \"Alright! Which of these budgets would you like me to fetch? (Please input the number right next to the name.)\"");
                int inputNumber = 0;
                int quit = 0;

                if(fileList[0] != null) {
                    while(quit == 0) {
                        Console.Write("You: ");
                        string secondUserInput = Console.ReadLine();
                        int stay = 0;
                        try{
                            inputNumber = int.Parse(secondUserInput);
                        }
                        catch(System.FormatException){
                            stay = 1;
                            Console.WriteLine("Bank Teller: \"That's not a number!\"");
                        }

                        if(stay == 0 && inputNumber > 0 && inputNumber <= fileList.Count()){
                            quit = 1;
                        }
                        else if(inputNumber <= 0 && stay == 0){
                            Console.WriteLine("Bank Teller: \"The number needs to be 1 or bigger.\"");
                        }
                        else if(inputNumber > fileList.Count()){
                            Console.WriteLine("Bank Teller: \"You haven't created that many budgets yet.\"");
                        }
                    }
                    saveLoad.LoadSave(fileList[inputNumber - 1]);
                    transactionList = saveLoad.GetSave();
                    Console.WriteLine("Bank Teller: \"Alright, here is your budget.\"");
                    Thread.Sleep(1000);
                    quit2 = 1;
                }
            }
            else if(userInput == "2"){
                //New budget
                transactionList = new List<Transaction>();
                Console.WriteLine("Bank Teller: \"Alright, here is your new budget.\"");
                Thread.Sleep(1000);
                quit2 = 1;
            }
            else{
                Console.WriteLine("Bank Teller: \"That's not an option!\"");
            }
        }
    }

    private List<string> ListSaves() {
        List<string> fileList = saveLoad.ListSaves();
        return fileList;
    }
    public void ListTransactions() {
        Console.Clear();
        Console.WriteLine("You: Casts \"List Transactions\" and reads Budget Scroll.");
        Console.WriteLine("Name".PadRight(34) + "Amount".PadRight(31) + "Date");
        float total = 0;
        for(int i = 0; i < transactionList.Count(); i++) {
            Console.WriteLine($"{i + 1}.) {transactionList[i].GetName().PadRight(30)}${transactionList[i].GetAmount().ToString().PadRight(30)}{transactionList[i].GetDate()}");
            total += transactionList[i].GetAmount();
        }
        Console.WriteLine(">>>>Total".PadRight(34) + $"${total}");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
    public void NewIncome(float amount, string name) {
        transactionList.Add(new Income(DateTime.Now, amount, name));
    }
    public void NewExpense(float amount, string category, string name) {
        transactionList.Add(new Expense(DateTime.Now, category, amount, name));
    }
    public void GenerateWeeklyReport(bool chart) {
        reportGenerator.SetReport(this.transactionList);
        Console.Clear();
        if(chart){
            Console.WriteLine("Narrator: Also, Would you like your chart to be a pie chart? (y/n)");
            Console.Write("You: ");
            string userInput = Console.ReadLine();

            if(userInput.ToLower() == "y"){
                this.CreateWeeklyChart(true);
            }
            else if(userInput.ToLower() == "n"){
                this.CreateWeeklyChart(false);
            }
            else{
                Console.WriteLine("Narrator: I didn't understand that!");
                Thread.Sleep(2000);
            }
        }
        Console.WriteLine("Narrator: This report displays transactions from the past seven days.");
        reportGenerator.DisplayReport(DateTime.Now.AddDays(-6), DateTime.Now);
    }
    public void GenerateMonthlyReport(bool chart) {
        reportGenerator.SetReport(this.transactionList);
        Console.Clear();
        if(chart){
            Console.WriteLine("Narrator: Also, Would you like your chart to be a pie chart? (y/n)");
            Console.Write("You: ");
            string userInput = Console.ReadLine();

            if(userInput.ToLower() == "y"){
                this.CreateMonthlyChart(true);
            }
            else if(userInput.ToLower() == "n"){
                this.CreateMonthlyChart(false);
            }
            else{
                Console.WriteLine("Narrator: I didn't understand that!");
                Thread.Sleep(2000);
            }
        }
        Console.WriteLine("Narrator: This report shows transactions from this calendar month.");
        reportGenerator.DisplayReport(DateTime.Now.AddDays(1 - DateTime.Now.Day), DateTime.Now);
    }
    public void CreateWeeklyChart(bool pie) {
        chartCreator.SetReport(this.transactionList);
        if(!pie){
            chartCreator.CreateChart(DateTime.Now.AddDays(-6), DateTime.Now);
        }
        else{
            chartCreator.CreatePieChart(DateTime.Now.AddDays(-6), DateTime.Now);
        }
    }
    public void CreateMonthlyChart(bool pie) {
        reportGenerator.SetReport(this.transactionList);
        chartCreator.SetReport(this.transactionList);
        if(!pie){
            chartCreator.CreateChart(DateTime.Now.AddDays(1 - DateTime.Now.Day), DateTime.Now);
        }
        else{
            chartCreator.CreatePieChart(DateTime.Now.AddDays(1 - DateTime.Now.Day), DateTime.Now);
        }
    }
    public void SaveBudget(){
        saveLoad.SetSave(transactionList);
    }
}