using System;

class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedQuestions = new List<string>();

    public ReflectingActivity(List<string> prompts, List<string> questions)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public void RunActivity()
    {
        DisplayStartMessage();
        _duration = AskForDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        DisplayLoadingSpinner(5);

        Console.WriteLine("Consider the following prompt:\n");

        string prompt = GetRandomPrompt();
        DisplayRandomPrompt(prompt);

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.\nYou may begin in:");
        DisplayCountdown(5);

        Console.Clear();

        ShuffleQuestions();
      
        for (int i = 0; i < _duration / 10; i++)
        {
            if (_usedQuestions.Count == _questions.Count)
            {
                _usedQuestions.Clear();
                ShuffleQuestions();
            }

            string question = GetNextQuestion();
            DisplayRandomQuestion(question);
            DisplayLoadingSpinner(10);
        }

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

    private string GetNextQuestion()
    {
        string nextQuestion = _questions.Find(q => !_usedQuestions.Contains(q));
        _usedQuestions.Add(nextQuestion);
        return nextQuestion;
    }

    private void ShuffleQuestions()
    {
        Random random = new Random();
        int n = _questions.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            string value = _questions[k];
            _questions[k] = _questions[n];
            _questions[n] = value;
        }
    }

    private void DisplayRandomQuestion(string question)
    {
        Console.WriteLine($"> {question}");
    }

    public override void DisplayStartMessage()
    {
        Console.WriteLine("Welcome to the Reflecting Activity");
        Console.WriteLine("\nThis activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n");
    }

    public override void DisplayEndMessage()
    {
        Console.WriteLine($"You completed another {_duration} seconds of the Reflecting Activity.");
    }
}