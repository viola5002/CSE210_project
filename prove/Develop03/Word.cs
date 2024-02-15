using System;
public class Word
{
    private string _word;

    public Word(string randomWord)
    {
        _word = randomWord;
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
