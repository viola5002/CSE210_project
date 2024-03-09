using System;

public class ChecklistGoal : Goal
{
    private int _checklistTimes;
    private int _bonus;
    public ChecklistGoal() : base()
    {
        Console.Write("How many times do you want to do this? ");
        _checklistTimes = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus amoount of points to be awarded upon completion? ");
        _bonus = int.Parse(Console.ReadLine());
    }
}