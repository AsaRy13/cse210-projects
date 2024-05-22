using System;

class Fraction {
    private int top;
    private int bottom;

    public Fraction() {
        this.top = 1;
        this.bottom = 1;
    }
    public Fraction(int numerator) {
        this.top = numerator;
        this.bottom = 1;
    }
    public Fraction(int numerator, int denominator) {
        this.top = numerator;
        this.bottom = denominator;
    }

    public int GetTop() {
        return this.top;
    }
    public void SetTop(int top) {
        this.top = top;
    }
    public int GetBottom() {
        return this.bottom;
    }
    public void SetBottom(int bottom) {
        this.bottom = bottom;
    }

    public string GetFractionString() {
        string fractionString = $"{this.top}/{this.bottom}";
        return fractionString;
    }
    public double GetDecimalValue() {
        double decimalValue = (double)this.top/this.bottom;
        return decimalValue;
    }
}