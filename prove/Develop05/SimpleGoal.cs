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
    public override int RecordEvent()
    {
        _completed = true;
        return base.RecordEvent();
    }
}