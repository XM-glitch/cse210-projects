using System;

class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;
    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                _isComplete = true;
                return _points + _bonusPoints;
            }
            return _points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return _isComplete ? $"[X] {_name} - {_description} (Completed { _currentCount }/{ _targetCount }, Bonus: {_bonusPoints})" : $"[ ] {_name} - {_description} (Progress: {_currentCount}/{_targetCount})";
    }

    public override void Save(StreamWriter writer)
    {
        writer.WriteLine($"ChecklistGoal|{_name}|{_description}|{_points}|{_targetCount}|{_bonusPoints}|{_currentCount}");
    }

    public override void Load(string data)
    {
        string[] parts = data.Split('|');

        _name = parts[1];
        _description = parts[2];
        _points = int.Parse(parts[3]);
        _targetCount = int.Parse(parts[4]);
        _bonusPoints = int.Parse(parts[5]);
        _currentCount = int.Parse(parts[6]);
        
        _isComplete = _currentCount >= _targetCount;
    }
}