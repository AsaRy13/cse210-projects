using System;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breath = new BreathingActivity();
        ReflectionActivity reflect = new ReflectionActivity();
        ListingActivity listing = new ListingActivity();
        int quit = 0;

        while(quit == 0) {
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Breathing Activity");
            Console.WriteLine(" 2. Relflection Activity");
            Console.WriteLine(" 3. Listing Activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if(choice == "1") {
                breath.RunActivity();
            }
            else if(choice == "2") {
                reflect.RunActivity();
            }
            else if(choice == "3") {
                listing.RunActivity();
            }
            else if(choice == "4") {
                quit = 1;
            }
            Console.Clear();
        }
    }
}