using System;
using System.IO;
using System.Text.Json;

class Reference {
    private List<Verse> scriptures = new List<Verse>();
    private string scriptureReference;
    private string fileAddress;
    private int quit;

    public Reference(string standardWork, string book, int chapter, int startVerse, int endVerse){
        this.FindVerses(standardWork, book, chapter, startVerse, endVerse);
    }
    public Reference(string standardWork, string book, int chapter, int verse){
        this.FindVerses(standardWork, book, chapter, verse, verse);
    }

    private void FindVerses(string standardWork, string book, int chapter, int startVerse, int endVerse) {
        if (standardWork.ToLower() == "old testament"){
            this.fileAddress = "./references/old-testament-reference.json";
        }
        else if(standardWork.ToLower() == "new testament"){
            this.fileAddress = "./references/new-testament-reference.json";
        }
        else if(standardWork.ToLower() == "book of mormon"){
            this.fileAddress = "./references/book-of-mormon-reference.json";
        }
        else if(standardWork.ToLower() == "doctrine and covenants"){
            this.fileAddress = "./references/doctrine-and-covenants-reference.json";
        }
        else if(standardWork.ToLower() == "pearl of great price"){
            this.fileAddress = "./references/pearl-of-great-price-reference.json";
        }
        else {
            Console.WriteLine("I do not recognize that standard work.");
        }

        try {
            string jsonString = File.ReadAllText(this.fileAddress);
            Dictionary<string, Dictionary<string, Dictionary<string,string>>> dict = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(jsonString);
            if(startVerse != endVerse){
                string scripture = dict[book][chapter.ToString()][startVerse.ToString()];
                this.scriptureReference = $"{book} {chapter}:{startVerse}-{endVerse}";
                this.scriptures.Add(new Verse($"{this.scriptureReference} \n{startVerse} {scripture}"));
                Console.WriteLine($"{this.scriptureReference} \n{startVerse} {scripture}");

                for(int i = startVerse + 1; i <= endVerse; i++){
                    scripture = dict[book][chapter.ToString()][i.ToString()];
                    this.scriptures.Add(new Verse($"{i} {scripture}"));
                    Console.WriteLine($"{i} {scripture}");
                }
            }
            else {
                string scripture = dict[book][chapter.ToString()][startVerse.ToString()];
                this.scriptureReference = $"{book} {chapter}:{startVerse}";
                this.scriptures.Add(new Verse($"{this.scriptureReference} \n{startVerse} {scripture}"));
                Console.WriteLine($"{this.scriptureReference} \n{startVerse} {scripture}");
            }
        }
        catch (KeyNotFoundException){
            Console.WriteLine("I do not recognize that reference.");
        }
        catch (FileNotFoundException){
            Console.WriteLine("File not found.");
        }
    }
    public void PrintScripture() {
        int end = 0;
        for (int i = 0; i < scriptures.Count(); i++) {
            Console.WriteLine(scriptures[i].ModifyVerse());
            if(scriptures[i].ModifyVerse() == "All Blank") {
                end++;
            }
        }
        if (end == scriptures.Count()) {
            this.quit = 1;
        }
    }
    public string Quit() {
        if (this.quit == 1) {
            return "Quit";
        }
        return "";
    }
}