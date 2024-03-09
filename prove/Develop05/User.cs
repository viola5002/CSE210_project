using System;

public class User
{
    private List<Goal> _goals = new List<Goal>();
    private string _fileName;
    private int _score = 0;

    public User(int choice)
    {
        do{
            Console.WriteLine($"\nYou have {_score} points\n");
            Console.WriteLine("Menu Options:\n"+
                                "1. Create new Goal\n"+
                                "2. Quit");
            Console.Write("What is your choice? ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("That is not a recognized choice.");
                    break;
            }
        } while (choice != 2);
    }

    public void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal\n"+
                          "2. Eternal Goal\n"+
                          "3. Checklist Goal\n");
        Console.Write("Which type of goal are you starting: ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                SimpleGoal s = new SimpleGoal();
                _goals.Add(s);
                break;
            case 2:
                EternalGoal e = new EternalGoal();
                _goals.Add(e);
                break;
            case 3:
                ChecklistGoal c = new ChecklistGoal();
                _goals.Add(c);
                break;
        }
    }
}