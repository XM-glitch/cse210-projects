using System;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string words)
    {
        _reference = reference;
        _words = words.Split(' ').Select(w => new Word(w)).ToList();
        _random = new Random();
    }

    public void PrintScriptureAndReference()
    {
        Console.Clear();
        Console.WriteLine(_reference.GetReference());
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetText())));
    }

    public void HideWords()
    {
        // for stretch challenge, only selects words to hide from non-hidden words
        var visibleWords = _words.Where(w => w.IsVisible()).ToList();
        if (visibleWords.Count > 0)
        {
            int wordsToHide = Math.Min(3, visibleWords.Count);

            for (int i = 0; i < wordsToHide; i++)
            {
                int index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }
    }

    public bool IsHidden()
    {
        return _words.All(w => !w.IsVisible());
    }
}