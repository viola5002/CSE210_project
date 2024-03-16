using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Develop05 World!");
        User u = new User();
        int choice = 0;
        do{
            string level = u.GetLevel();
            Console.WriteLine($"\nYou have {u.GetScore()} points");
            Console.WriteLine($"You are a {level}\n");
            Console.WriteLine("Menu Options:\n"+
                                "1. Create new Goal\n"+
                                "2. List Goals\n"+
                                "3. Save Goals\n"+
                                "4. Load Goals\n"+
                                "5. Record Completion\n"+
                                "6. Level Progress\n"+
                                "7. Quit");
            Console.Write("What is your choice? ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    u.CreateGoal();
                    break;
                case 2:
                    u.ListGoals();
                    break;
                case 3:
                    u.SaveGoals();
                    break;
                case 4:
                    u.LoadGoals();
                    break;
                case 5:
                    level = u.RecordCompletion();
                    break;
                case 6:
                    u.LevelProgress();
                    break;
                case 7:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("That is not a recognized choice.");
                    break;
            }
        } while (choice != 7);
    }
}