using System;

public class User
{
    private List<Goal> _goals = new List<Goal>();
    private string _fileName;
    private int _score;

    public User()
    {
        int choice = 0;
        do{
            Console.WriteLine($"\nYou have {_score} points\n");
            Console.WriteLine("Menu Options:\n"+
                                "1. Create new Goal\n"+
                                "2. List Goals\n"+
                                "3. Save Goals\n"+
                                "4. Load Goals\n"+
                                "5. Recored Completion\n"+
                                "6. Quit");
            Console.Write("What is your choice? ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordCompletion();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("That is not a recognized choice.");
                    break;
            }
        } while (choice != 6);
    }

    private void CreateGoal()
    {
        Console.WriteLine("\n1. Simple Goal\n"+
                          "2. Eternal Goal\n"+
                          "3. Checklist Goal\n");
        Console.Write("Which type of goal are you starting: ");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                SimpleGoal s = new SimpleGoal();
                s.SetVariables();
                _goals.Add(s);
                break;
            case 2:
                EternalGoal e = new EternalGoal();
                e.SetVariables();
                _goals.Add(e);
                break;
            case 3:
                ChecklistGoal c = new ChecklistGoal();
                c.SetVariables();
                _goals.Add(c);
                break;
        }
    }
    private void ListGoals()
    {
        int i = 1;
        Console.WriteLine();
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.DisplayString()}");
            i++;
        }
    }    
    private void SaveGoals()
    {
        Console.Write("\nWhat is the file name to save under? ");
        _fileName = Console.ReadLine();
        if (File.Exists(_fileName))
        {
            Console.Write("That file already exists. Do you want to override it? (y/n)");
        }
        string str = Console.ReadLine();
        if (str == "y")
        {
            using (StreamWriter newFile = new StreamWriter(_fileName))
            {
                foreach (Goal goal in _goals)
                {
                    newFile.WriteLine(goal.GetSaveFormat());
                }
            }
        }
    }
    private void LoadGoals()
    {
        Console.Write("What is the filename to load? ");
        _fileName = Console.ReadLine();
        if (File.Exists(_fileName) == false)
        {
            Console.WriteLine("That file does not exist.");
        }
        else
        {
            string[] lines = File.ReadAllLines(_fileName);
            foreach (string line in lines)
            {
                string[] newLines = line.Split("||");
                if (newLines[0] == "SimpleGoal")
                {
                    SimpleGoal s = new SimpleGoal();
                    s.GetVariables(newLines);
                    _goals.Add(s);
                }
                else if (newLines[0] == "EternalGoal")
                {
                    EternalGoal e = new EternalGoal();
                    e.GetVariables(newLines);
                    _goals.Add(e);
                }
                else if (newLines[0] == "ChecklistGoal")
                {
                    ChecklistGoal c = new ChecklistGoal();
                    c.GetVariables(newLines);
                    _goals.Add(c);
                }
            }
        }
        ListGoals();
    }
    private void RecordCompletion()
    {
        Console.WriteLine("The goals are:");
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());
        Goal goal = _goals[choice-1];
        int goalScore = goal.RecordEvent();
        _score += goalScore;
    }
}