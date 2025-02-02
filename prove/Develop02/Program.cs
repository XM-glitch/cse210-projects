using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            journal.Options();
            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Your entry: ");
                string userEntry = Console.ReadLine();
                journal.AddEntry(new Entry($"{prompt} --- {userEntry}"));
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nJournal Entries");
                journal.DisplayEntries();
            }
            else if (choice == "3")
            {
                Console.Write("\nEnter filename to save: ");
                string saveFile = Console.ReadLine();
                journal.SaveToFile(saveFile);

            }
            else if (choice == "4")
            {
                Console.Write("\nEnter filename to load: ");
                string loadFile = Console.ReadLine();
                journal.LoadFromFile(loadFile);
            }
            else if (choice == "5")
            {
                Console.Write("\nEnter keyword to search: ");
                string keyword = Console.ReadLine();
                journal.SearchEntries(keyword);
            }
            else if (choice == "6")
            {
                running = false;
                Console.WriteLine("\nGoodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option selected. Please try again.");
            }
        }
    }
}