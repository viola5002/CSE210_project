using System;

public class SimpleGoal : Goal
{
    public SimpleGoal() : base()
    {

    }

    public override string GetSaveFormat()
    {
        return base.GetSaveFormat() + $"||{_completed}";
    }
    public override void GetVariables(string[] list)
    {
        base.GetVariables(list);
        _completed = bool.Parse(list[4]);

    }
    public override int RecordEvent()
    {
        _completed = true;
        return base.RecordEvent();
    }
}