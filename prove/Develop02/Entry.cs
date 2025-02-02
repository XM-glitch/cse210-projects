using System;

public class Entry
{
    private string _text;
    private string _date;

    public Entry(string text)
    {
        _text = text;
        _date = GetDate();
    }

    private string GetDate()
    {
        return DateTime.Now.ToString("yyyy-MM-dd");
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"[{_date}] --- {_text}");
    }

    public string GetEntryText()
    {
        return $"[{_date}]\n {_text}";
    }
}