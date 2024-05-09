using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

public class Job {
    private string company;
    private string jobTitle;
    private int startYear;
    private int endYear;

    public string Company {
        get{return company;}
        set{company = value;}
    }

    public string JobTitle {
        get{return jobTitle;}
        set{jobTitle = value;}
    }
    public int StartYear {
        get{return startYear;}
        set{startYear = value;}
    }
    public int EndYear {
        get{return endYear;}
        set{endYear = value;}
    }

    public Job(string company, string jobTitle, int startYear, int endYear) {
        Company = company;
        JobTitle = jobTitle;
        StartYear = startYear;
        EndYear = endYear;
    }

    public void Display() {
        Console.WriteLine($"{JobTitle} ({Company}) {StartYear}-{EndYear}");
    }
}