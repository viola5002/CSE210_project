using System;

public class ChecklistGoal : Goal
{
    private int _totalTimes;
    private int _bonus;
    private int _timesCompleted;
    public ChecklistGoal() : base()
    {

    }

    public override void SetVariables()
    {
        base.SetVariables();
        Console.Write("How many times do you want to do this? ");
        _totalTimes = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus amoount of points to be awarded upon completion? ");
        _bonus = int.Parse(Console.ReadLine());
    }
    public override void GetVariables(string[] list)
    {
        base.GetVariables(list);
        _bonus = int.Parse(list[4]);
        _totalTimes = int.Parse(list[5]);
        _timesCompleted = int.Parse(list[6]);
    }
    public override string DisplayString()
    {
        return base.DisplayString() + $" — Currently Completed: {_timesCompleted}/{_totalTimes}";
    }
    public override string GetSaveFormat()
    {
        return base.GetSaveFormat() + $"||{_bonus}||{_totalTimes}||{_timesCompleted}";
    }
    public override int RecordEvent()
    {
        _timesCompleted++;
        if (_timesCompleted == _totalTimes)
        {
            _completed = true;
        }
        else
        {
            _completed = false;
        }
        return base.RecordEvent();
    }
}