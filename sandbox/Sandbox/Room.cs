using System;

public class Room {
    private List<SmartDevice> smartDevices = new List<SmartDevice>();
    private string roomName;

    public Room(string roomName, int numSmartLight, bool hasSmartHeater, int numSmartTV) {
        this.roomName = roomName;
        for(int j = 0; j < numSmartLight; j++) {
            smartDevices.Add(new SmartLight($"Smart Light #{j + 1}"));
        }
        for(int j = 0; j < numSmartTV; j++) {
            smartDevices.Add(new SmartTV($"Smart TV #{j + 1}"));
        }
        if(hasSmartHeater == true) {
            smartDevices.Add(new SmartHeater("Smart Heater"));
        }
    }
    
    public string GetRoomName() {
        return roomName;
    }
    public void Action() {
        int quit = 0;
        while(quit == 0) {
            Console.Clear();
            Console.WriteLine("Device Actions in this Room:");
            Console.WriteLine("1. Toggle a Device");
            Console.WriteLine("2. Turn on all Lights");
            Console.WriteLine("3. Turn off all Lights");
            Console.WriteLine("4. Turn on all Devices");
            Console.WriteLine("5. Turn off all Devices");
            Console.WriteLine("6. List Devices that are on");
            Console.WriteLine("7. Show Device that has been on the longest");
            Console.WriteLine("8. List all Devices and their Status");
            Console.WriteLine("9. Access Device Menu");
            Console.WriteLine("10. Go Back to Smart Home Menu");
            
            Console.Write("Pick an option via its number: ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            if(userInput == "1") {
                this.ToggleDevice();
            }
            else if(userInput == "2") {
                this.TurnOnLights();
            }
            else if(userInput == "3") {
                this.TurnOffLights();
            }
            else if(userInput == "4") {
                this.TurnOnAll();
            }
            else if(userInput == "5") {
                this.TurnOffAll();
            }
            else if(userInput == "6") {
                this.DeviceOnReport();
            }
            else if(userInput == "7") {
                this.DeviceOnLongestReport();
            }
            else if(userInput == "8") {
                this.DeviceStatusReport();
            }
            else if(userInput == "9") {
                this.AccessDeviceMenu();
            }
            else if(userInput == "10") {
                quit = 1;
            }
        }
    }
    public void TurnOnLights() {
        for(int i = 0; i < smartDevices.Count(); i++) {
            if(smartDevices[i].GetDeviceType() == "smart light") {
                smartDevices[i].TurnOnDevice();
            }
        }
    }
    public void TurnOffLights() {
        for(int i = 0; i < smartDevices.Count(); i++) {
            if(smartDevices[i].GetDeviceType() == "smart light") {
                smartDevices[i].TurnOffDevice();
            }
        }
    }
    public void TurnOnAll() {
        for(int i = 0; i < smartDevices.Count(); i++) {
            smartDevices[i].TurnOnDevice();
        }
    }
    public void TurnOffAll() {
        for(int i = 0; i < smartDevices.Count(); i++) {
            smartDevices[i].TurnOffDevice();
        }
    }
    public void DeviceOnReport() {
        Console.Clear();
        Console.WriteLine("Devices that are on:");
        for(int i = 0; i < smartDevices.Count(); i++) {
            if(smartDevices[i].GetDevicePowerStatus()) {
                Console.WriteLine($"{smartDevices[i].GetDeviceName()}");
            }
        }
        Console.Write("End of list. Press enter to continue ...");
        Console.ReadLine();
        Console.WriteLine();
    }
    public void DeviceOnLongestReport() {
        Console.Clear();
        Console.WriteLine("Item that has been on the longest: ");
        Console.WriteLine();
        TimeSpan onDuration = TimeSpan.FromTicks(0);
        string onLongestDeviceName = "";
        for(int i = 0; i < smartDevices.Count(); i++) {
            if(smartDevices[i].GetDevicePowerStatus() && onDuration <= smartDevices[i].OnDuration()) {
                onLongestDeviceName = $"{smartDevices[i].GetDeviceName()}";
                onDuration = smartDevices[i].OnDuration();
            }
        }
        Console.WriteLine($"{onLongestDeviceName} has been on for {onDuration}.");
        Console.WriteLine();
        Console.Write("Press enter to continue ...");
        Console.ReadLine();
        Console.WriteLine();
    }
    public void DeviceStatusReport() {
        Console.Clear();
        Console.WriteLine("Devices:");
        string powerStatus = "";
        for(int i = 0; i < smartDevices.Count(); i++) {
            if (smartDevices[i].GetDevicePowerStatus() == true) {
                powerStatus = "on";
            }
            else if (smartDevices[i].GetDevicePowerStatus() == false) {
                powerStatus = "off";
            }
            Console.WriteLine($"{smartDevices[i].GetDeviceName()}  {powerStatus}  {smartDevices[i].OnDuration()}");
        }
        Console.Write("End of list. Press enter to continue ...");
        Console.ReadLine();
        Console.WriteLine();
    }
    public void ToggleDevice() {
        Console.Clear();
        Console.WriteLine("Devices:");
        string powerStatus = "";
        for(int i = 0; i < smartDevices.Count(); i++) {
            if (smartDevices[i].GetDevicePowerStatus() == true) {
                powerStatus = "on";
            }
            else if (smartDevices[i].GetDevicePowerStatus() == false) {
                powerStatus = "off";
            }
            Console.WriteLine($"{i + 1}. {smartDevices[i].GetDeviceName()}  {powerStatus}");
        }
        Console.Write("Select a device from the list via its number: ");
        int userInput = int.Parse(Console.ReadLine());
        Console.WriteLine();
        
        bool devicePowerStatus = smartDevices[userInput - 1].GetDevicePowerStatus();
        if(devicePowerStatus == true) {
            smartDevices[userInput - 1].TurnOffDevice();
        }
        else if(devicePowerStatus == false) {
            smartDevices[userInput - 1].TurnOnDevice();
        }
    }
    public void AccessDeviceMenu() {
        Console.Clear();
        Console.WriteLine("Devices:");
        for(int i = 0; i < smartDevices.Count(); i++) {
            if(smartDevices[i].GetDevicePowerStatus()) {
                Console.WriteLine($"{i + 1}. {smartDevices[i].GetDeviceName()}");
            }
            else if(smartDevices[i].GetDevicePowerStatus() == false) {
                Console.WriteLine($"{i + 1}. {smartDevices[i].GetDeviceName()} (Turn on to access menu)");
            }
        }
        Console.Write("Select a device from the list via its number: ");
        int userInput = int.Parse(Console.ReadLine());
        Console.WriteLine();
        
        if(smartDevices[userInput - 1].GetDevicePowerStatus()) {
            smartDevices[userInput - 1].DeviceMenu();
        }
        else if(smartDevices[userInput - 1].GetDevicePowerStatus() == false) {
            Console.WriteLine("That device must be on.");
            Thread.Sleep(2000);
        }
    }
}