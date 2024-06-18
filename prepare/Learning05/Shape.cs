using System;

public class Shape {
    private string color;

    public Shape(string color) {
        this.color = color.ToLower();
    }

    public string GetColor() {
        return this.color;
    }
    public void SetColor(string color) {
        this.color = color.ToLower();
    }

    public virtual double GetArea() {
        return 1d;
    }
}