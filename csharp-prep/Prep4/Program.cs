using System;
using System.Numerics;
using System.Runtime;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        int inputNumber;
        int sum = 0;
        int amount = 0;
        int largest = 0;
        int smallestPositive = Int32.MaxValue;


        do
        {
            Console.Write("Enter number: ");
            inputNumber = int.Parse(Console.ReadLine());
            if (inputNumber != 0)
            {
                numbers.Add(inputNumber);
            }
        } while (inputNumber != 0);

        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }

            if (number < smallestPositive && number > 0)
            {
                smallestPositive = number;
            }

            amount++;
            sum += number;
        }
        double average = (double) sum / amount;
        Console.WriteLine(average);
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

    }
}