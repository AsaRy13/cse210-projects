using System;
using System.ComponentModel;

class Entry {
    private string date;
    private string prompt;
    private string text;

    public string GetEntry() {
        string entry = $"{date}\n{prompt}\n{text}\n";
        return entry;
    }
    public void StoreResponse(List<string> newEntry) {
        date = newEntry[0];
        prompt = newEntry[1];
        text = newEntry[2];
    }
}