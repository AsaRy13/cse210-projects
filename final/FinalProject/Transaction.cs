using System;

public abstract class Transaction {
    protected float amount;
    protected DateTime date;
    protected string name;

    public Transaction(DateTime date, string name) {
        this.date = date;
        this.name = name;
    }

    public float GetAmount() {
        return this.amount;
    }
    public DateTime GetDate() {
        return this.date;
    }
    public string GetName() {
        return this.name;
    }
}