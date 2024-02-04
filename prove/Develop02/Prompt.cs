using System;

public class Prompt
{
    
    public List<string> _prompts = new List<string>();    

    public Prompt()
    {
    }

    public void EditList()
    {
        _prompts.Add("If you could do the day over, what you do differently?");
        _prompts.Add("The things that I'm grateful for today are...");
        _prompts.Add("What was the most interesting part of my day?");
        _prompts.Add("How has the Lord blessed me today?");
        _prompts.Add("What were your plans for the day? How well did you follow them? What was different?");
    }
    public string RandomPrompt()
    {
        EditList();
        Random randomGenerator = new Random();
        int _promptNumber = randomGenerator.Next(6);
        string _prompt = _prompts[_promptNumber];
        return _prompt;
    }
}