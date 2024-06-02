using System;

class Verse {
    private string verse;
    private List<Word> words = new List<Word>();
    private List<string> newWords = new List<string>();
    private Random rnd = new Random();

    public Verse(string verse) {
        this.verse = verse;
        this.newWords = this.verse.Split(" ").ToList();
        for(int i = 0; i < this.newWords.Count(); i++) {
            this.words.Add(new Word(newWords[i]));
        }
    }
    public string ModifyVerse() {
        string returnVerse = "";
        int end = 0;
        for(int i = 0; i < words.Count(); i++) {
            int rand = rnd.Next(0, 50);
            bool checkBlank = words[i].CheckBlank();
            if(checkBlank == false) {
                if(rand <= 2) {
                    words[i].Blank();
                }
                returnVerse += words[i].ToString() + " ";
            }
            else{
                returnVerse += words[i].ToString() + " ";
                end++;
            }
        }
        if(end == words.Count()){
            return "All Blank";
        }
        return returnVerse;
    }
    public string PrintVerse() {
        return this.verse;
    }
}