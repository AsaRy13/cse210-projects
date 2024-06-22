using System;

public static class ICESmartHome {
    public static void SmartHome() {
        Console.Clear();
        Console.Write("How many rooms do you have in your house that have our smart devices in them?: ");
        int numberOfRooms = int.Parse(Console.ReadLine());
        House house = new House(numberOfRooms);

        int quit = 0;
        while(quit == 0) {
            Console.Clear();
            Console.WriteLine("ICESmartHome Menu:");
            Console.WriteLine("1. Select a Room");
            Console.WriteLine("2. Quit");
            Console.Write("Please pick an option: ");
            string selection = Console.ReadLine();
            Console.WriteLine();

            if(selection == "1") {
                house.PickRoom();
            }
            else if(selection == "2") {
                Console.Write("Are you sure? You will have to restart all over if you do (y/n): ");
                string selectionQ = Console.ReadLine();
                if(selectionQ.ToLower() == "y") {
                    quit = 1;
                }
            }
        }
    }
}