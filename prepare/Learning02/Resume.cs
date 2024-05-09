using System;

class Resume{
    private string name;
    private List<Job> jobs;

    public string Name {
        get{return name;}
        set{name = value;}
    }
    public List<Job> Jobs {
        get{return jobs;}
        set{jobs = value;}
    }

    public Resume(string name) {
        Name = name;
        Jobs = new List<Job>();
    }

    public void Display() {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine("Jobs:");

        for(int i = 0; i < Jobs.Count; i++) {
            Jobs[i].Display();
        }
    }
}