using System;

class Word
{
    private string _word;
    private bool _isVisible;

    public Word(string word)
    {
        _word = word;
        _isVisible = true;
    }

    public string GetText()
    {
        if (_isVisible)
        {
            return _word;
        }
        else
        {
            return new string('_', _word.Length);
        }
    }

    public void Hide()
    {
        _isVisible = false;
    }

    public void Show()
    {
        _isVisible = true;
    }

    public bool IsVisible()
    {
        return _isVisible;
    }
}