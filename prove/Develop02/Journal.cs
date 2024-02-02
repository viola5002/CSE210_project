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
                outputFile.WriteLine($"Date: {e._date} — Prompt: {e._prompt}\n- {e._userResponse}\n");
            }
        }
    }
    public void Load()
    {
        StreamReader file = new StreamReader(_fileName);
        
        //return journal;
    }

}
