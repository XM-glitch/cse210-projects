using System;

abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points, bool isComplete = false)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual int RecordEvent()
    {
        return _points;
    }
    public virtual string GetStatus()
    {
        return _isComplete ? "[X] " + _name : "[ ] " + _name;
    }
     public virtual void Save(StreamWriter writer)
    {
        writer.WriteLine($"{GetType().Name}|{_name}|{_description}|{_points}|{_isComplete}");
    }
    public virtual void Load(string data)
    {
        string[] parts = data.Split('|');
        
        _name = parts[1];
        _description = parts[2];
        _points = int.Parse(parts[3]);
        _isComplete = bool.Parse(parts[4]);
    }
}