using System;

class Program
{
    private List<Event> _events;

    public Program()
    {
        _events = new List<Event>();
    }

    public void AddEvent(Event eventObject)
    {
        _events.Add(eventObject);
    }

    public void DisplayEvents()
    {
        if (_events.Count() == 0)
        {
            Console.WriteLine("No events available.");
        }
        else
        {
            foreach (Event eventObject in _events)
            {
                Console.WriteLine("Standard Details:");
                Console.WriteLine(eventObject.GetStandardDetails());
                Console.WriteLine("\nFull Details:");
                Console.WriteLine(eventObject.GetFullDetails());
                Console.WriteLine("\nShort Description:");
                Console.WriteLine(eventObject.GetShortDescription());
                Console.WriteLine("\n- - - - -\n");
            }
        }
    }
    static void Main(string[] args)
    {
        Program program = new Program();

        Address address1 = new Address("123 ABC St", "Somewhere", "WA", "USA");
        Address address2 = new Address("456 DEF Ave", "Elsewhere", "SA", "Australia");
        Address address3 = new Address("789 GHI Lane", "Nowhere", "XD", "Canada");

        Event lecture = new Lecture("Lecture", "An informative lecture.", "1/23/45", "1:00PM", address1, "Mr. Jim Bob", 400);
        Event reception = new Reception("Reception", "A fun reception.", "2/34/56", "2:00PM", address2, "receptionrsvp@gmail.com");
        Event outdoorGathering = new OutdoorGathering("Outdoor Gathering", "A fun gathering outdoors.", "3/45/67", "3:00 PM", address3, "Clear");

        program.AddEvent(lecture);
        program.AddEvent(reception);
        program.AddEvent(outdoorGathering);

        Console.Clear();
        program.DisplayEvents();
    }
}