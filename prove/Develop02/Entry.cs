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

    public void Display()
    {

        Console.WriteLine($"Date: {_date} — Prompt: {_prompt}\n{_userResponse}\n");
    }

}