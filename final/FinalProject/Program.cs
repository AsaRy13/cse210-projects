using System;

class Program
{
    static void Main(string[] args)
    {
        TOMOLogo logo = new TOMOLogo();
        logo.DisplayArt();

        Budget budget = new Budget();

        int quit = 0;

        while(quit == 0) {
            Console.Clear();
            Console.WriteLine("You: Reads Budget Scroll");
            Console.WriteLine("Budget Scroll:");
            Console.WriteLine("1. List Transactions");
            Console.WriteLine("2. Insert New Income");
            Console.WriteLine("3. Insert New Expense");
            Console.WriteLine("4. Generate Weekly Report");
            Console.WriteLine("5. Generate Monthly Report");
            Console.WriteLine("6. Save Changes to This Budget");
            Console.WriteLine("7. Load New Budget");
            Console.WriteLine("8. Quit");
            Console.WriteLine();
            Console.WriteLine("Narrator: Which option would you like to pick? (Please input the number next to the option that you would like to pick.)");
            Console.Write("You: ");
            string userInput = Console.ReadLine();

            if(userInput == "1"){
                budget.ListTransactions();
            }
            else if(userInput == "2"){
                Console.Clear();
                Console.WriteLine("INCOME:");
                Console.WriteLine("Narrator: Please input the amount");
                Console.Write("You: $");
                string userInput2 = Console.ReadLine();
                Console.WriteLine();

                try{
                    float inputNumber = float.Parse(userInput2);

                    Console.WriteLine("Narrator: What is the name of this income?");
                    Console.Write("You: ");
                    string userInput3 = Console.ReadLine();
                    budget.NewIncome(inputNumber, userInput3);
                }
                catch(System.FormatException){
                    Console.WriteLine();
                    Console.WriteLine("Narrator: That's not a number");
                    Thread.Sleep(1000);
                }
            }
            else if(userInput == "3"){
                Console.Clear();
                Console.WriteLine("EXPENSE:");
                Console.WriteLine("Narrator: Please input the amount");
                Console.Write("You: $");
                string userInput2 = Console.ReadLine();
                Console.WriteLine();

                try{
                    float inputNumber = float.Parse(userInput2);

                    Console.WriteLine("Narrator: What is the catagory of this expense?");
                    Console.Write("You: ");
                    string userInput3 = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Narrator: Finally, what is the name of this expense?");
                    Console.Write("You: ");
                    string userInput4 = Console.ReadLine();
                    budget.NewExpense(inputNumber, userInput3, userInput4);
                }
                catch(System.FormatException){
                    Console.WriteLine();
                    Console.WriteLine("Narrator: That's not a number");
                    Thread.Sleep(1000);
                }
            }
            else if(userInput == "4"){
                Console.Clear();
                Console.WriteLine("Narrator: Would you also like a trends chart displayed as well? (y/n)");
                Console.Write("You: ");
                string userInput2 = Console.ReadLine();

                if(userInput2.ToLower() == "y"){
                    budget.GenerateWeeklyReport(true);
                }
                else if(userInput2.ToLower() == "n"){
                    budget.GenerateWeeklyReport(false);
                }
                else{
                    Console.WriteLine("Narrator: I didn't understand that.");
                    Thread.Sleep(1000);
                }
            }
            else if(userInput == "5"){
                Console.Clear();
                Console.WriteLine("Narrator: Would you also like a trends chart displayed as well? (y/n)");
                Console.Write("You: ");
                string userInput2 = Console.ReadLine();

                if(userInput2.ToLower() == "y"){
                    budget.GenerateMonthlyReport(true);
                }
                else if(userInput2.ToLower() == "n"){
                    budget.GenerateMonthlyReport(false);
                }
                else{
                    Console.WriteLine("Narrator: I didn't understand that.");
                    Thread.Sleep(1000);
                }
            }
            else if(userInput == "6"){
                budget.SaveBudget();
            }
            else if(userInput == "7"){
                Console.Clear();
                Console.WriteLine("Narrator: Would you like to save this budget first? (y/n)");
                Console.Write("You: ");
                string userInput2 = Console.ReadLine();

                if(userInput2.ToLower() == "y"){
                    budget.SaveBudget();
                    budget = new Budget();
                }
                else if(userInput2.ToLower() == "n"){
                    budget = new Budget();
                }
                else{
                    Console.WriteLine("Narrator: I didn't understand that.");
                }
            }
            else if(userInput == "8"){
                Console.Clear();
                Console.WriteLine("Narrator: Would you like to save this budget first? (y/n)");
                Console.Write("You: ");
                string userInput2 = Console.ReadLine();

                if(userInput2.ToLower() == "y"){
                    budget.SaveBudget();
                    Console.Clear();
                    quit = 1;
                }
                else if(userInput2.ToLower() == "n"){
                    Console.Clear();
                    quit = 1;
                }
                else{
                    Console.WriteLine();
                    Console.WriteLine("Narrator: I didn't understand that.");
                }
            }
        }
    }
}