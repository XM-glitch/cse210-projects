using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {

    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetStatus()
    {
        return $"[∞] {_name} - {_description} (Earns {_points} points for each time it is done)";
    }

    public override void Save(StreamWriter writer)
    {
        writer.WriteLine($"EternalGoal|{_name}|{_description}|{_points}|{false}");
    }

    public override void Load(string data)
    {
        base.Load(data);
    }
}