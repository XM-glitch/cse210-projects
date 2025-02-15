using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that He gave His only begotten Son that whosoever believeth in Him should not perish but have everlasting life.");

        while(true)
        {
            scripture.PrintScriptureAndReference();
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            if (!scripture.IsHidden())
            {
                scripture.HideWords();
            }
            else
            {
                break;
            }
        }
    }
}