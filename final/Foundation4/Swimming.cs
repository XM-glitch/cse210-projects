using System;

public class Swimming : Exercise
{
    private int _laps;

    public Swimming(string date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 0.050;
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
        return "Swimming";
    }
}