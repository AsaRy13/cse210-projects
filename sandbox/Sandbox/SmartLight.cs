using System;
using System.Threading.Tasks;

public class SmartLight : SmartDevice {
    private string color = "white";

    public SmartLight(string deviceName) : base(deviceName) {
        this.deviceType = "smart light";
    }

    public override void DeviceMenu()
    {
        int quit = 0;
        while(quit == 0) {
            Console.Clear();
            Console.WriteLine("Smart Light Menu:");
            Console.WriteLine("1. Change Light Color");
            Console.WriteLine("2. Display Light Color");
            Console.WriteLine("3. Leave Smart Light Menu");

            Console.Write("Please pick an option via its number: ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            if(userInput == "1") {
                Console.Write($"What color would you like to change {this.deviceName} to?: ");
                this.color = Console.ReadLine();
            }
            else if(userInput == "2") {
                Console.WriteLine(this.color);
                Thread.Sleep(2000);
            }
            else if(userInput == "3") {
                quit = 1;
            }
        }
    }
}