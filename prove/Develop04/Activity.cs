using System;

class Activity
{
    protected int _duration;

    public int AskForDuration()
    {
        Console.Write("How long, in seconds, would you like for you session? ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int seconds))
        {
            if (seconds > 0)
            {
                return seconds;
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                return AskForDuration();
            }
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return AskForDuration();
        }
    }

    public void DisplayLoadingSpinner(int seconds)
    {
        char[] spinner = {'|', '\\', '-', '/'};
        int counter = 0;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[counter % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            counter++;
        }
        Console.Write("\b \n");
    }

    public void DisplayCountdown(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}");
            Thread.Sleep(1000);
        }
        Console.Write("\b \n");
    }

    public virtual void DisplayStartMessage()
    {
        Console.WriteLine("Starting activity...");
        DisplayLoadingSpinner(3);
    }

    public virtual void DisplayEndMessage()
    {
        Console.WriteLine($"Good job, you completed {_duration} seconds of activity!");
    }
}