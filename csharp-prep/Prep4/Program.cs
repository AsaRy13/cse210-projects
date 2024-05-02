using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int inputtedNumber = 0;
        float numberSum = 0;
        float numberAverage = 0;
        int largestNumber = 0;
        int smallestPositiveNumber = 0;

        do {
            Console.Write("Enter number: ");
            inputtedNumber = int.Parse(Console.ReadLine());
            numbers.Add(inputtedNumber);
            if (inputtedNumber != 0) {
                numberSum += inputtedNumber;
                numberAverage = numberSum / numbers.Count();
                if (inputtedNumber > largestNumber) {
                    largestNumber = inputtedNumber;
                }
                if (smallestPositiveNumber == 0) {
                    smallestPositiveNumber = largestNumber;
                }
                else if (inputtedNumber < smallestPositiveNumber && inputtedNumber > 0) {
                    smallestPositiveNumber = inputtedNumber;
                }
            }
            else {
                numbers.Remove(0);
            }
        } while (inputtedNumber != 0);

        Console.WriteLine($"The sum is: {numberSum}");
        Console.WriteLine($"The average is: {numberAverage}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");
    }
}