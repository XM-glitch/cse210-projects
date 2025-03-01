using System;

class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _responses = new();

    public ListingActivity(List<string> prompts)
    {
        _prompts = prompts;
    }

    public void RunActivity()
    {
        DisplayStartMessage();
        _duration = AskForDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplayLoadingSpinner(5);

        Console.WriteLine("List as many responses as you can to the following prompt. Press Enter after each response.");
        string prompt = GetRandomPrompt();
        DisplayRandomPrompt(prompt);
        Console.WriteLine("You may begin in:");
        DisplayCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                _responses.Add(response);
            }
        }
        DisplayNumberListed();
        Console.WriteLine("Well done!!");
        DisplayLoadingSpinner(5);
        DisplayEndMessage();
        DisplayLoadingSpinner(5);
        Console.Clear();
    }

    private string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }

    private void DisplayRandomPrompt(string prompt)
    {
        Console.WriteLine($" --- {prompt} ---");
    }

    private void DisplayNumberListed()
    {
        Console.WriteLine($"You listed {_responses.Count} items!");
    }

    public override void DisplayStartMessage()
    {
        Console.WriteLine("Welcome to the Listing Activity.");
        Console.WriteLine("\nThis activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n");
    }

    public override void DisplayEndMessage()
    {
        Console.WriteLine($"You completed another {_duration} seconds of the Listing Activity.");
    }
}