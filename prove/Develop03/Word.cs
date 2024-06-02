using System;

class Word {
    private string word;
    private bool isBlank = false;
    private int wordLen;

    public Word(string word) {
        this.word = word;
        this.wordLen = word.Length;
    }

    public override string ToString() {
        if(isBlank == true){
            string blankWord = "";
            for (int i = 1; i <= this.wordLen; i++){
                blankWord += "_";
            }
            return blankWord;
        }

        return this.word;
    }
    public void Blank() {
        this.isBlank = !this.isBlank;
    }
    public bool CheckBlank() {
        return this.isBlank;
    }
}