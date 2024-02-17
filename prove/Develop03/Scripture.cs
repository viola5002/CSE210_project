using System;
public class Scripture
{
    private string[] _words;
    private string _entireScripture;
    private List<int> _indexes = new List<int>();

    public Scripture(string scripture)
    {
        _entireScripture = scripture;
        _words = _entireScripture.Split(" ");
        for (int i = 0; i < _words.Length; i++)
        {
            _indexes.Add(i);
        }
    }

    public void Display()
    {
        foreach (string word in _words)
        {
            Console.Write($"{word} ");
        }
        Console.WriteLine();
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
        int i = randomGenerator.Next(_indexes.Count);
        int index = _indexes[i];
        _indexes.RemoveAt(i);
        return index;
    }
    public void HideWords(ScriptureReference reference, Scripture scripture)
    {
        for (int i = 0; i < 4; i++)
        {
            if (IsCompletelyHidden())
            {
                Console.Clear();
                reference.Display();
                scripture.Display();
                Environment.Exit(0);
            }
            else
            {
                int index = SelectRandomWord();
                Word w = new Word(_words[index]);
                /*
                if (_indexes.Count < 4)
                {
                    w = new Word(_words[index]);
                    string _newWord = w.HideWord();
                    _words[index] = _newWord;
                    i--;
                }
                */

                w = new Word(_words[index]);
                string _newWord = w.HideWord();
                _words[index] = _newWord;
            }    
        }

    }


}