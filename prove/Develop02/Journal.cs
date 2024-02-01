using System;

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

}
