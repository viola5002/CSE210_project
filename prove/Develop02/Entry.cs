using System;
using System.ComponentModel.DataAnnotations;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _userResponse;
    public string _entireEntry;
    public Entry()
    {

    }


    public Entry NewEntry()
    {
        Prompt prompt = new Prompt();
        Entry entry = new Entry();
        DateTime theCurrentTime = DateTime.Now;
        string date = theCurrentTime.ToShortDateString();
        _date = date;
        _prompt = prompt.RandomPrompt();
        Console.WriteLine(_prompt);
        Console.Write("> ");
        string response = Console.ReadLine();
        _userResponse = response;
        return entry;
    }
    public void Display()
    {
        
        _entireEntry = $"Date: {_date} — Prompt: {_prompt}\n- {_userResponse}\n";
        Console.WriteLine(_entireEntry);
    }

}