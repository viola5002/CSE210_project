using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _pointsWorth;

    public Goal()
    {
        Console.Write("What is the goal? ");
        _name = Console.ReadLine();
        Console.Write("Type a short description: ");
        _description = Console.ReadLine();
        Console.Write("How many points is this goal worth? ");
        _pointsWorth = int.Parse(Console.ReadLine());
    }
}