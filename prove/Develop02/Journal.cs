using System;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            foreach (Entry entry in _entries)
            {
                entry.DisplayEntry();
            }
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.GetEntryText());
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                _entries.Add(new Entry(line));
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

/*
    This Searching method was done with the help of https://stackoverflow.com/questions/3099689/how-to-search-for-any-text-in-liststring
    to exceed the requirements for this program. It searches for a user-entered keyword in all entries of a Journal, and prints the 
    entries with the matching word. If none are found, it prints a message explaining that.
*/
    public void SearchEntries(string keyword)
    {
        var results = _entries.Where(e => e.GetEntryText().ToLower().Contains(keyword.ToLower())).ToList();

        if (results.Count > 0)
        {
            Console.WriteLine($"Found {results.Count} matching entries:");
            foreach (var entry in results)
            {
                entry.DisplayEntry();
            }
        }
        else
        {
            Console.WriteLine("No matching entries found.");
        }
    }

    public void Options()
    {
        Console.WriteLine("\nJournal Options:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display entries");
        Console.WriteLine("3. Save journal to file");
        Console.WriteLine("4. Load journal from file");
        Console.WriteLine("5. Search entries");
        Console.WriteLine("6. Quit");
    }
}