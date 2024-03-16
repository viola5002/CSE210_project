using System;

public class Goal
{
    private string _name;
    private string _description;
    private int _pointsWorth;
    protected bool _completed = false;

    public Goal()
    {

    }

    public virtual void SetVariables()
    {
        Console.Write("What is the goal? ");
        _name = Console.ReadLine();
        Console.Write("Type a short description: ");
        _description = Console.ReadLine();
        Console.Write("How many points is this goal worth? ");
        _pointsWorth = int.Parse(Console.ReadLine());
    }
    public virtual void GetVariables(string[] list)
    {
        _name = list[1];
        _description = list[2];
        _pointsWorth = int.Parse(list[3]);
    }
    public virtual string DisplayString()
    {
        if (_completed)
        {
            return $"[x] {_name} ({_description})";
        }
        else
        {
            return $"[ ] {_name} ({_description})";
        }
    }
    public virtual string GetSaveFormat()
    {
        return $"{this.GetType()}||{_name}||{_description}||{_pointsWorth}";
    }
    public virtual int RecordEvent()
    {
        return _pointsWorth;
    }
}