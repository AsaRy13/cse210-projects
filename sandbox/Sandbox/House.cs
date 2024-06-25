using System;

public class House {
    private List<Room> rooms = new List<Room>();
    
    public House(int numberOfRooms) {
        for(int i = 0; i < numberOfRooms; i++) {
            Console.Clear();
            Console.WriteLine($"Questions for room number {i + 1}:");
            Console.Write("What is the name of this room?: ");
            string roomName = Console.ReadLine();
            Console.WriteLine();
            int strquit = 0;
            int smartLights = 0;
            Console.Write("How many smart lights do you have in this room?: ");
            while(strquit == 0) {
                string smartLightsStr = Console.ReadLine();
                int strstay = 0;
                
                try{
                    smartLights = int.Parse(smartLightsStr);
                }
                catch(System.FormatException) {
                    strstay = 1;
                    Console.Write("Please input a number for this question!: ");
                }

                if(strstay == 0){
                    Console.WriteLine();
                    strquit = 1;
                }
            }
            int quit = 0;
            bool smartHeaterBool = false;
            while(quit == 0) {
                Console.Write("Does this room have a smart heater? (y/n): ");
                string smartHeater = Console.ReadLine();
                if(smartHeater.ToLower() == "y") {
                    smartHeaterBool = true;
                    Console.WriteLine();
                    quit = 1;
                }
                else if (smartHeater.ToLower() == "n") {
                    smartHeaterBool = false;
                    Console.WriteLine();
                    quit = 1;
                }
                else {
                    Console.WriteLine("I didn't understand that.");
                    Console.WriteLine();
                }
            }
            strquit = 0;
            Console.Write("How many smart TVs do you have in this room?: ");
            int smartTVs = 0;
            while(strquit == 0){
                string smartTVsString = Console.ReadLine();
                int strstay = 0;

                try{
                    smartTVs = int.Parse(smartTVsString);
                }
                catch(System.FormatException) {
                    strstay = 1;
                    Console.Write("Please input a number for this question!: ");
                }

                if(strstay == 0) {
                    Console.WriteLine();
                    strquit = 1;
                }
            }

            this.rooms.Add(new Room(roomName, smartLights, smartHeaterBool, smartTVs));
        }
    }

    public void PickRoom() {
        Console.Clear();
        Console.WriteLine("Room List:");
        for(int i = 0; i < rooms.Count(); i++) {
            Console.WriteLine($"{i + 1}. {this.rooms[i].GetRoomName()}");
        }

        Console.Write("Pick a room via its number in the list: ");
        int quit = 0;
        int roomNum = 0;
        while(quit == 0){
            string roomNumStr = Console.ReadLine();
            int stay = 0;

            try{
                roomNum = int.Parse(roomNumStr);
            }
            catch(System.FormatException){
                stay = 1;
                Console.Write("I said number!: ");
            }

            if(stay == 0) {
                Console.WriteLine();
                quit = 1;
            }
        }

        if(roomNum > 0 && roomNum <= rooms.Count()) {
            rooms[roomNum - 1].Action();
        }
    }
}