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
        Directory.CreateDirectory("Journals");
        using (StreamWriter outputFile = new StreamWriter($"Journals/{_fileName}"))
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
        string[] _lines = File.ReadAllLines($"Journals/{_fileName}");
        int i = 0;
        foreach (string l in _lines)
        {
            if (l.StartsWith("Date: "))
            {
                Entry e = new Entry();
                string[] _newLines = l.Split("Date: ");
                foreach (string m in _newLines)
                {
                _newLines = m.Split(" — Prompt: ");
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
                _entries[i]._userResponse = l;
            }
            Console.WriteLine(l);
            i++;
        }

    }

}
