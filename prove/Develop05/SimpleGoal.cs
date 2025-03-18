using System;

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points, bool isComplete = false) : base(name, description, points, isComplete)
    {
        // nothing to see here... literally
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return _isComplete ? $"[X] {_name} - {_description}" : $"[ ] {_name} - {_description}";
    }

    public override void Save(StreamWriter writer)
    {
        writer.WriteLine($"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}");
    }

    public override void Load(string data)
    {
        base.Load(data);
    }
}