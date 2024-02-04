using System;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public string _fileName;


    public Journal()
    {
    }

    public void Display()
    {
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }
    public void Save()
    {
         Console.Write("What is the filename? ");
        _fileName = Console.ReadLine();       
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            foreach (Entry e in _entries)
            {
                outputFile.WriteLine($"Date: {e._date} — Prompt: {e._prompt}\n{e._userResponse}\n");
            }
        }
    }
    public void Load()
    {
        _entries.Clear();
        Console.Write("What is the filename? ");
        _fileName = Console.ReadLine();
        string[] _lines = File.ReadAllLines(_fileName);
        int i = 0;
        //List<string> responseParts = new List<string>();
        foreach (string l in _lines)
        {
            if (l.StartsWith("Date: "))
            {
                Entry e = new Entry();
                string[] _newLines = l.Split("Date: ");
                foreach (string m in _newLines)
                {
                _newLines = m.Split(" — Prompt: ");
                //_entries[i]._date = _newLines[0];
                //_entries[i]._prompt = _newLines[1];
                }
                e._date = _newLines[0];
                e._prompt = _newLines[1];
                _entries.Add(e);
                i--;
            }
            else if (l.Length == 0)
            {
                i--;
            }
            else
            {
                //string[] _newLines = l.Split("\n",StringSplitOptions.RemoveEmptyEntries);
                //responseParts.Add(l);
                _entries[i]._userResponse = l;
            }
            //string combinedResponse = String.Join(' ', responseParts);
            Console.WriteLine(l);
            i++;
        }

        //return journal;
    }

}
