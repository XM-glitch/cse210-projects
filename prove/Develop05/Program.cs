using System;
class Program
{
    private int _totalPoints;
    private List<Goal> _goals;
    private int _currentLevel;  // for the stretch activity
    private int _xpThreshold;   // for the stretch activity



    public Program()
    {
        _totalPoints = 0;
        _goals = new List<Goal>();
        _currentLevel = 1;      // for the stretch activity
        _xpThreshold = 100;     // for the stretch activity
    }


    public void UpdateXPBar()                                                                           // for the stretch activity
    {                                                                                                   // for the stretch activity
        int xpProgress = _totalPoints % _xpThreshold;                                                   // for the stretch activity
        int barLength = 20;                                                                             // for the stretch activity
        int filledLength = (int)((float)xpProgress / _xpThreshold * barLength);                         // for the stretch activity
        
        string xpBar = new string('▒', filledLength) + new string('-', barLength - filledLength);       // for the stretch activity
        
        Console.WriteLine($"[{xpBar}] XP: {xpProgress}/{_xpThreshold}");                                // for the stretch activity
        
        if (xpProgress == 0 && _totalPoints > 0)                                                        // for the stretch activity
        {                                                                                               // for the stretch activity
            _currentLevel++;                                                                            // for the stretch activity
            _xpThreshold += 10;                                                                         // for the stretch activity
            Console.WriteLine($"Congratulations! You've leveled up!");                                  // for the stretch activity
        }                                                                                               // for the stretch activity
    }                                                                                                   // for the stretch activity

    public void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine($"\nTotal Points: {_totalPoints}");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Goal Event");
            Console.WriteLine("3. Show Total Points");
            Console.WriteLine("4. Display Goals");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddGoal();  break;
                case "2": RecordGoalEvent(); break;
                case "3": ShowTotalPoints(); break;
                case "4": DisplayGoals(); break;
                case "5": SaveGoals(); break;
                case "6": LoadGoals(); break;
                case "7": return;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    public void AddGoal()
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name:  ");
        string name = Console.ReadLine();

        Console.Write("Enter your goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for completion: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter target completion count: ");
                int targetCount = int.Parse(Console.ReadLine());

                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());

                newGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                break;
            default:
                Console.WriteLine("Bad selection, please try again.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal added");
    }

    public void RecordGoalEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available");
            return;
        }

        Console.WriteLine("\nSelect a goal to record: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }

        Console.Write("Enter a goal number: ");
        int index = int.Parse(Console.ReadLine());
        index--;

        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _totalPoints += pointsEarned;
            UpdateXPBar();  // for stretch activity
            Console.WriteLine($"Goal recorded, you earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("Not a valid choice");
        }
    }

    public void ShowTotalPoints()
    {
        Console.WriteLine($"\nTotal Points: {_totalPoints}");
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to display");
            return;
        }

        Console.WriteLine("\nYour Goals: ");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter file name to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_totalPoints);

            foreach (Goal goal in _goals)
            {
                goal.Save(writer);
            }
        }

        Console.WriteLine($"Goals saved to {filename}");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            _totalPoints = int.Parse(reader.ReadLine());

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                Goal goal = null;

                switch (parts[0])
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal("", "", 0);
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal("", "", 0);
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal("", "", 0, 0, 0);
                        break;
                }

                if (goal != null)
                {
                    goal.Load(line);
                    _goals.Add(goal);
                }
            }
        }

        Console.WriteLine("Goals loaded.");
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        program.DisplayMenu();
    }
}