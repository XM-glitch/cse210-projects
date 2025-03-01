using System;

class BreathingActivity : Activity
{
    public void RunActivity()
    {
        DisplayStartMessage();
        _duration = AskForDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplayLoadingSpinner(5);

        for (int i = 0; i < _duration; i+=6)
        {
            BreatheIn(3);
            BreatheOut(3);
        }

        Console.WriteLine("Well done!!");
        DisplayLoadingSpinner(5);

        DisplayEndMessage();
        DisplayLoadingSpinner(5);
        Console.Clear();
    }

    public void BreatheIn(int seconds)
    {
        Console.WriteLine("Breathe in... ");
        DisplayCountdown(seconds);
    }

    public void BreatheOut(int seconds)
    {
        Console.WriteLine("Now breathe out... ");
        DisplayCountdown(seconds);
    }

    public override void DisplayStartMessage()
    {
        Console.WriteLine("Welcome to the Breathing Activity.\n");
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.\n");

    }

    public override void DisplayEndMessage()
    {
        Console.WriteLine($"You completed another {_duration} seconds of the Breathing Activity.");
    }
}