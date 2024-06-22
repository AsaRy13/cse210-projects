using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class SmartHeater : SmartDevice {
    private float temperature;
    private float roomTemperature = 70;

    public SmartHeater(string deviceName) : base(deviceName) {
        this.deviceType = "smart heater";
    }

    public override void DeviceMenu()
    {
        int quit = 0;
        while(quit == 0) {
            Console.Clear();
            Console.WriteLine("Smart Heater Menu:");
            Console.WriteLine("1. Set Temperature");
            Console.WriteLine("2. Read Temperature");
            Console.WriteLine("3. Read Room Temperature");
            Console.WriteLine("4. Leave Smart Heater Menu");

            Console.Write("Please pick an option via its number: ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            if(userInput == "1") {
                Console.Write($"What temperature would you like to change {this.deviceName} to?: ");
                this.temperature = float.Parse(Console.ReadLine());
            }
            else if (userInput == "2") {
                Console.WriteLine($"The temperature that the theromostat is set to is {this.temperature} degrees.");
                Thread.Sleep(2000);
            }
            else if (userInput == "3") {
                Console.WriteLine($"It is currently {this.roomTemperature} degrees. (This is just a placeholder until thermometers can actually be connected to this program.)");
                Thread.Sleep(2000);
            }
            else if(userInput == "4") {
                quit = 1;
            }
        }
    }
}