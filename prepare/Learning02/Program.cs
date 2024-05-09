using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
        Job job2 = new Job("Apple", "App Developer", 2022, 2023);
        Resume resume1 = new Resume("Steve Johnson");

        resume1.Jobs.Add(job1);
        resume1.Jobs.Add(job2);

        resume1.Display();
    }
}