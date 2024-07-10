using System;

using System;
using System.Threading.Tasks;

static class Test
{
    private static bool isTrue = false;

    public static async void RunTimeTest() {
        await TimeTest();
    }
    private static async Task TimeTest()
    {
        // Start monitoring the Boolean variable
        Task monitorTask = MonitorBooleanAsync();

        // Simulate changing the Boolean value
        await Task.Delay(2000); // Wait for 2 seconds
        isTrue = true;
        Console.WriteLine("Boolean set to true.");

        await Task.Delay(5000); // Wait for 5 seconds
        isTrue = false;
        Console.WriteLine("Boolean set to false.");

        await monitorTask; // Ensure the monitor task completes
    }

    private static async Task MonitorBooleanAsync()
    {
        DateTime? startTime = null;

        while (true)
        {
            if (isTrue)
            {
                if (startTime == null)
                {
                    startTime = DateTime.Now;
                }
                else
                {
                    TimeSpan duration = DateTime.Now - startTime.Value;
                    Console.WriteLine($"Boolean has been true for {duration.TotalSeconds} seconds.");
                }
            }
            else
            {
                startTime = null;
            }

            await Task.Delay(1000); // Check every second
        }
    }
}