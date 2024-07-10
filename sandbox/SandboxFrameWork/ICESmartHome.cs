using System;

public static class ICESmartHome {
    public static void SmartHome() {
        int strquit = 0;
        int numberOfRooms = 0;
        while(strquit == 0) {
            Console.Clear();
            Console.Write("How many rooms do you have in your house that have our smart devices in them?: ");
            string numberOfRoomsStr = Console.ReadLine();
            int strstay = 0;

            try{
                numberOfRooms = int.Parse(numberOfRoomsStr);
            }
            catch(System.FormatException) {
                strstay = 1;
                Console.WriteLine();
                Console.Write("Please input a number!");
                Thread.Sleep(1000);
                Console.WriteLine();
            }

            if(strstay == 0) {
                strquit = 1;
            }
        }


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
            else{
                Console.WriteLine("I didn't understand that.");
                Thread.Sleep(1000);
            }
        }
    }
}