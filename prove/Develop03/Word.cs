using System;
public class Word
{
    private string _word;
    private int _lengthOfWord;

    public Word(string randomWord)
    {
        _word = randomWord;
        _lengthOfWord = _word.Length;
    }

    private bool IsHidden()
    {
        bool result;
        if (_word.StartsWith('_'))
        {
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }
    public string HideWord()
    {
        string _newWord = "hi";
        if (IsHidden())
        {
            foreach (char c in _word)
            {
                _newWord = _word.Replace(c, '_');
            }
            return _newWord;
        }
        else
        {
            return _word;
        }
    }
}
