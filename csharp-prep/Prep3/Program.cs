using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        int number;
        int guess;
        int count = 0;
        string run;
        do
        {
            Console.Write("What's the magic number? ");
            number = int.Parse(Console.ReadLine());
            do
            {

                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                count++;

                if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
            } while (guess != number);
            Console.WriteLine($"You guessed it in {count} guesses!");

            Console.Write("Do you want to play again? (yes/no): ");
            run = Console.ReadLine();
        } while (run == "yes");
    }
}