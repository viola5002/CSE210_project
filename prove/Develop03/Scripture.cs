using System;
public class Scripture
{
    private string[] _words;
    private string _entireScripture;

    public Scripture()
    {
        _entireScripture = "And this is life eternal, that they might know thee the only true God, and Jesus Christ, whom thou hast sent. extra";
        _words = _entireScripture.Split(" ");
    }

    public void Display()
    {
        foreach (string word in _words)
        {
            Console.Write($"{word} ");
        }
        Console.WriteLine();
    }
    private void ReadScripture()
    {
        _words = _entireScripture.Split(" ");
    }
    private bool IsCompletelyHidden()
    {
        
        bool result = false;
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
    private int SelectRandomWord()
    {
        Random randomGenerator = new Random();
        int i = randomGenerator.Next(_words.Length);
        int index = i;
        return i;
    }
    public void HideWords()
    {
        for (int i = 0; i < 3; i++)
        {
            if (IsCompletelyHidden())
            {
                Environment.Exit(0);
            }
            else
            {
                int index = SelectRandomWord();
                Word w = new Word(_words[index]);
                if (w.IsHidden() && i > 0)
                {
                    i--;
                }
                else
                {
                    w = new Word(_words[index]);
                    string _newWord = w.HideWord();
                    _words[index] = _newWord;
                }
            }    

            //string _newWord = w.HideWord();
            //_words[index] = _newWord;

        }
    }


}