using System;

public abstract class Exercise
{
    protected string _date;
    protected int _duration;

    public Exercise(string date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetActivity()
    {
        return "Basic Exercise";
    }

    public string GetSummary()
    {
        return $"{_date} {GetActivity()} ({_duration} min): Distance {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}