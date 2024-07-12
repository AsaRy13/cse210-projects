using System;
using System.IO;

public class SaveLoad {
    private List<Transaction> saveList;
    private List<string> fileNameList = new List<string>();
    private string fileLocation;
    private List<string> entriesList = new List<string>();

    public SaveLoad() {}

    public List<Transaction> GetSave() {
        return saveList;
    }
    public void LoadSave(string loadName) {
        this.saveList = new List<Transaction>();
        this.entriesList.Clear();

        string fileLocation = $"./saves/{loadName}";
        using (StreamReader read = new StreamReader(fileLocation)) {
            string line;
            while((line = read.ReadLine()) != null) {
                entriesList = line.Split("<|>").ToList();
                float amount = float.Parse(entriesList[0]);
                DateTime date = DateTime.Parse(entriesList[1]);
                string name = entriesList[2];
                if(amount >= 0){
                    this.saveList.Add(new Income(date, amount, name));
                }
                else if(amount < 0) {
                    string category = entriesList[3];
                    this.saveList.Add(new Expense(date, category, -amount, name));
                }
            }
        }
    }
    public void SetSave(List<Transaction> saveList) {
        Console.Clear();
        if(this.fileLocation == null) {
            this.saveList = saveList;

            Console.WriteLine("Bank Teller: \"Alright, what would you like to name this budget?\"");
            Console.Write("You: ");
            string userInput = Console.ReadLine();
            this.fileLocation = $"./saves/{userInput}.txt";

            using (StreamWriter writer = new StreamWriter(this.fileLocation)){
                for(int i = 0; i < saveList.Count(); i++) {
                    if(saveList[i] is Expense expense) {
                        writer.WriteLine($"{saveList[i].GetAmount()}<|>{saveList[i].GetDate()}<|>{saveList[i].GetName()}<|>{expense.GetCategory()}");
                    }
                    else{
                        writer.WriteLine($"{saveList[i].GetAmount()}<|>{saveList[i].GetDate()}<|>{saveList[i].GetName()}");
                    }
                }
            }
            Console.WriteLine("Bank Teller: \"Done.\"");
            Thread.Sleep(1000);
        }
        else {
            this.saveList = saveList;

            Console.WriteLine("Bank Teller: \"Alright!\"");
            using (StreamWriter writer = new StreamWriter(this.fileLocation)){
                for(int i = 0; i < saveList.Count(); i++) {
                    if(saveList[i] is Expense expense) {
                        writer.WriteLine($"{saveList[i].GetAmount()}<|>{saveList[i].GetDate()}<|>{saveList[i].GetName()}<|>{expense.GetCategory()}");
                    }
                    else{
                        writer.WriteLine($"{saveList[i].GetAmount()}<|>{saveList[i].GetDate()}<|>{saveList[i].GetName()}");
                    }
                }
            }
            Console.WriteLine("Bank Teller: \"Done.\"");
            Thread.Sleep(1000);
        }
    }
    public List<string> ListSaves() {
        this.fileNameList.Clear();
        //Based on code from Stack Overflow
        DirectoryInfo d = new DirectoryInfo("./saves");
        FileInfo[] Files = d.GetFiles("*.txt");
        int index = 1;
        foreach(FileInfo file in Files){
            Console.WriteLine($"{index}. {file.Name}");
            this.fileNameList.Add(file.Name);
            index++;
        }
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        return fileNameList;
    }
}