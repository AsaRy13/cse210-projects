using System;
using System.Threading.Tasks;

public class SmartTV : SmartDevice {
    private int volume = 20;
    private int channel = 8;

    public SmartTV(string deviceName) : base(deviceName) {
        this.deviceType = "smart tv";
    }

    public override void DeviceMenu()
    {
        int quit = 0;
        while(quit == 0) {
            Console.Clear();
            Console.WriteLine("Smart TV Menu:");
            Console.WriteLine("1. Turn Volume Up");
            Console.WriteLine("2. Turn Volume Down");
            Console.WriteLine("3. Channel +");
            Console.WriteLine("4. Channel -");
            Console.WriteLine("5. Leave Smart TV Menu");

            Console.Write("Please pick an option via its number: ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            if(userInput == "1") {
                this.volume++;
                Console.WriteLine($"Volume: {this.volume}");
                Thread.Sleep(2000);
            }
            else if(userInput == "2") {
                this.volume--;
                Console.WriteLine($"Volume: {this.volume}");
                Thread.Sleep(2000);
            }
            else if(userInput == "3") {
                this.channel++;
                Console.WriteLine($"Channel: {this.channel}");
                Thread.Sleep(2000);
            }
            else if(userInput == "4") {
                this.channel--;
                Console.WriteLine($"Channel: {this.channel}");
                Thread.Sleep(2000);
            }
            else if(userInput == "5") {
                quit = 1;
            }
        }
    }
}