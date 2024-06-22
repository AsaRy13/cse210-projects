using System;
using System.Security;
using System.Threading.Tasks;

public abstract class SmartDevice {
    protected string deviceName;
    protected string deviceType;
    protected bool isOn = false;
    protected TimeSpan onDuration;
    protected int stopOnTimeThread = 0;

    public SmartDevice(string deviceName) {
        this.deviceName = deviceName;
    }

    public abstract void DeviceMenu();
    public virtual void TurnOnDevice() {
        isOn = true;
        async void RunOnTime() {
            await OnTime();
            stopOnTimeThread = 1;
            stopOnTimeThread = 0;
        }
        RunOnTime();
    }
    public virtual void TurnOffDevice() {
        isOn = false;
    }
    public string GetDeviceName() {
        return this.deviceName;
    }
    public string GetDeviceType() {
        return this.deviceType;
    }
    public bool GetDevicePowerStatus() {
        return isOn;
    }
    public TimeSpan OnDuration() {
        return onDuration;
    }
    public async Task OnTime() {
        //Code based off of code from ChatGPT:
        DateTime? startTime = null;

        //ChatGPT had this as while(true). I changed it because I didn't want a thread to keep running this
        //all the time.
        while(this.stopOnTimeThread == 0) {
            if(this.isOn) {
                if(startTime == null) {
                    startTime = DateTime.Now;
                }
                else {
                    this.onDuration = DateTime.Now - startTime.Value;
                    /*ChatGPT had code here that wrote to the console how long the bool has been true.
                    As you can see at the end of this while loop, this loop loops every second, so the
                    message would be displayed every second.*/
                }
            }
            else{
                startTime = null;
            }

            await Task.Delay(1000);
        }
    }
}