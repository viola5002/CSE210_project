using System;

public class User
{
    private List<Goal> _goals = new List<Goal>();
    private string _fileName;
    private int _score;
    private string _level;
    private int _milestone;
    private List<string> _levels = new List<string>() {"Muggle||99", "Squib||249", "Wizard Wannabe||499",
        "Wizard-in-Training||999", "Wizard of the Realm||1499", "Master Wizard||2499"};

    public User()
    {
    }

    public int GetScore()
    {
        return _score;
    }
    public void CreateGoal()
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
    public void ListGoals()
    {
        int i = 1;
        Console.WriteLine();
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.DisplayString()}");
            i++;
        }
    }    
    public void SaveGoals()
    {
        Console.Write("\nWhat is the file name to save under? ");
        _fileName = Console.ReadLine();
        if (File.Exists(_fileName))
        {
            Console.Write("That file already exists. Do you want to override it? (y/n)");
        
            string str = Console.ReadLine();
            if (str == "y")
            {
                using (StreamWriter newFile = new StreamWriter(_fileName))
                {
                    newFile.WriteLine($"{_score}||{GetLevel()}");
                    foreach (Goal goal in _goals)
                    {
                        newFile.WriteLine(goal.GetSaveFormat());
                    }
                }
            }
        }
        else
        {
            using (StreamWriter newFile = new StreamWriter(_fileName))
            {
                newFile.WriteLine($"{_score}||{GetLevel()}");
                foreach (Goal goal in _goals)
                {
                    newFile.WriteLine(goal.GetSaveFormat());
                }
            }
        }
    }
    public void LoadGoals()
    {
        Console.WriteLine("This will delete the unsaved goals.");
        Console.Write("What is the filename to load? ");
        _fileName = Console.ReadLine();
        if (File.Exists(_fileName) == false)
        {
            Console.WriteLine("That file does not exist.");
        }
        else
        {
            _goals.Clear();
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
                else
                {
                    _score = int.Parse(newLines[0]);
                }
            }
        }
    }
    public string RecordCompletion()
    {
        Console.WriteLine("The goals are:");
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());
        Goal goal = _goals[choice-1];
        int goalScore = goal.RecordEvent();
        _score += goalScore;
        return GetLevel();
    }
    public string GetLevel()
    {
        _milestone = 0;
        string[] newLevels;
        foreach (string level in _levels)
        {
            newLevels = level.Split("||");
            if (_score >= int.Parse(newLevels[1]))
            {
                _level = newLevels[0];
                _milestone++;
            }
            else
            {
                _level = newLevels[0];
                break;
            }
        }
        return _level;
    }
    public void LevelProgress()
    {
        string[] maxLevel = _levels[_levels.Count-1].Split("||");
        int untilMax = int.Parse(maxLevel[1]) - _score + 1;
        Console.WriteLine($"You have {untilMax} points until you are a {maxLevel[0]}");
        string[] nextLevel = _levels[_milestone].Split("||");
        int untilNext = int.Parse(nextLevel[1]) - _score + 1;
        Console.WriteLine($"You have {untilNext} points until next level");
    }
}