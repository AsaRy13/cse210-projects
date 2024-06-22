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
            Console.Write("How many smart lights do you have in this room?: ");
            int smartLights = int.Parse(Console.ReadLine());
            Console.WriteLine();
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
            Console.Write("How many smart TVs do you have in this room?: ");
            int smartTVs = int.Parse(Console.ReadLine());

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
        int roomNum = int.Parse(Console.ReadLine());
        rooms[roomNum - 1].Action();
    }
}