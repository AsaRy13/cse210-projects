using System;
using System.IO;

class Journal {
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>();
    private List<string> newEntryList = new List<string>();
    private Random rnd = new Random();

    public void AddToList() {
        prompts.Add("How was your day today?:");
        prompts.Add("What was your favorite thing that happened today?:");
        prompts.Add("What about today made you happy?");
    }
    public void NewEntry() {
        Console.WriteLine("Entry:");
        string prompt = prompts[rnd.Next(prompts.Count())];

        Console.WriteLine(prompt);
        string newText = Console.ReadLine();

        Console.Write("Please enter the date: ");
        string newDate = Console.ReadLine();

        newEntryList.Add(prompt);
        newEntryList.Add(newText);
        newEntryList.Add(newDate);

        Console.Write("Where would you like to export this entry to? (Leave blank if you don't want to save): ");
        string export = Console.ReadLine();

        if(export != "") {
            Export(export, prompt, newText, newDate);
        }
    }
    public void DisplayEntries() {
        Console.WriteLine();
        for(int i = 0; i < entries.Count(); i++) {
            Console.WriteLine(entries[i].GetEntry());
        }
    }
    public void Import(string importLocation) {
        //Code to read a file.
        entries.Clear();
        using (StreamReader read = new StreamReader(importLocation)) {
            string line;
            while((line = read.ReadLine()) != null) {
                newEntryList = line.Split("|").ToList();
                entries.Add(new Entry());
                entries[entries.Count() - 1].StoreResponse(newEntryList);
            }
        }
    }
    private void Export(string exportLocation, string prompt, string text, string date) {
        //Code to add to a file.
        using (StreamWriter writer = new StreamWriter(exportLocation, true)) {
            writer.WriteLine($"{prompt}|{text}|{date}");
        }
    }
}