using System;
using Microsoft.VisualBasic.Logging;

public class Budget {
    private List<Transaction> transactionList;
    private SaveLoad saveLoad = new SaveLoad();

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
                Console.Write("You: ");
                int inputNumber = 0;
                int quit = 0;

                if(fileList[0] != null) {
                    while(quit == 0) {
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
        //
    }
    public void NewIncome(float amount, string name) {
        transactionList.Add(new Income(DateTime.Now, amount, name));
    }
    public void NewExpense(float amount, string category, string name) {
        transactionList.Add(new Expense(DateTime.Now, category, amount, name));
    }
    public void GenerateWeeklyReport(bool chart) {
        //
    }
    public void GenerateMonthlyReport(bool chart) {
        //
    }
    public void CreateWeeklyChart(bool pie) {
        //
    }
    public void CreateMonthlyChart(bool pie) {
        //
    }
    public void SaveBudget(){
        saveLoad.SetSave(transactionList);
    }
}