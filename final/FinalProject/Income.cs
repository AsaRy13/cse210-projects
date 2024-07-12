using System;

public class Income : Transaction {
    public Income(DateTime date, float amount, string name) : base(date, name) {
        this.amount = amount;
    }
}