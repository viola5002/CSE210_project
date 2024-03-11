using System;

public class EternalGoal : Goal
{
    public EternalGoal() : base()
    {
        
    }

    public override int RecordEvent()
    {
        _completed = false;
        return base.RecordEvent();
    }

}