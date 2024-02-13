using System;
public class Scripture
{
    private string[] _words;
    private string _entireScripture;

    public Scripture()
    {
        _entireScripture = "And this is life eternal, that they might know thee the only true God, and Jesus Christ, whom thou hast sent.";
    }

    public void Display()
    {
        Console.WriteLine(_entireScripture);
    }
    private void ReadScripture()
    {
        _words = _entireScripture.Split(" ");
    }
    private bool IsCompletelyHidden()
    {
        
        bool result = true;
        foreach (string w in _words)
        {
            if (w.StartsWith('_'))
            {
                result = true;
            }
            else
            {
                result = false;
                break;
            }
        }
        return result;
        
    }
    public string SelectRandomWord()
    {
        Random randomGenerator = new Random();
        int i = randomGenerator.Next(_words.Length);
        string word = _words[i];
        return word;
    }
}