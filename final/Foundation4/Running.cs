using System;

public class Running : Exercise
{
    private double _distance;

    public Running(string date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return GetDistance() / _duration * 60;
    }

    public override double GetPace()
    {
        return _duration / GetDistance();   
    }

    public override string GetActivity()
    {
        return "Running";
    }
}