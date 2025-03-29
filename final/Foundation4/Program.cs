using System;

class Program
{
    private List<Exercise> _exercises;

    public Program()
    {
        _exercises = new List<Exercise>();
    }

    public void AddExercise(Exercise exercise)
    {
        _exercises.Add(exercise);
    }

    public void DisplayExercises()
    {
        if (_exercises.Count == 0)
        {
            Console.WriteLine("No exercises available");
        }
        else
        {
            foreach (Exercise exercise in _exercises)
            {
                Console.WriteLine(exercise.GetSummary());
            }
        }
    }
    static void Main(string[] args)
    {
        Program program = new Program();

        Running running = new Running("03 Mar 2025", 18, 5);
        Cycling cycling = new Cycling("06 Mar 2025", 45, 28.95);
        Swimming swimming = new Swimming("09 Mar 2025", 20, 10);

        program.AddExercise(running);
        program.AddExercise(cycling);
        program.AddExercise(swimming);

        Console.Clear();
        program.DisplayExercises();
    }
}