using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        int gradeLastDigit = grade % 10;
        string sign = "";
        string letter;

        // Determine Letter Grades
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        // Determine Signs (+/-)
        if(gradeLastDigit >= 7)
        {
            if (letter != "A" || letter != "F")
            {
            sign = "+";
            }
        }
        else if (gradeLastDigit < 3)
        {
            if (letter != "F")
            {
                sign = "-";
            }
        }
        // Print Letter Grade and Sign
        Console.WriteLine($"Your grade is: {letter}{sign}");
        // Print Pass/Fail Message
        if (grade >= 70)
        {
            Console.WriteLine("You passed the class, good job!");
        }
        else
        {
            Console.WriteLine("You haven't passed this time, but don't give up!");
        }
    }
}