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

    public bool IsHidden()
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
        if (IsHidden())
        {
            return _word;
        }
        else
        {
            foreach (char c in _word)
            {
                if (c!=',' && c!=';' && c!='.' && c!=':' && c!='!' && c!='?')
                {
                    _word = _word.Replace(c, '_');
                }
            }
            return _word;
        }
    }
}
