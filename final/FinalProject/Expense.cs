using System;

public class Expense : Transaction {
    private string category;
    public Expense(DateTime date, string category, float amount, string name) : base(date, name) {
        this.amount = -amount;
        this.category = category;
    }

    public string GetCategory() {
        return this.category;
    }
}