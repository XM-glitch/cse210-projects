using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

public class Event
{
    protected string _title;
    protected string _description;
    protected string _date;
    protected string _time;
    protected Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"{_title} - {_description}\nDate: {_date}, {_time}\nLocation: {_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return $"{GetStandardDetails()}, Type of Event: {GetEventType()}";
    }

    public virtual string GetShortDescription()
    {
        return $"{GetEventType()} - {_title}, Date: {_date}";
    }

    public virtual string GetEventType()
    {
        return "Basic Event";
    }
}