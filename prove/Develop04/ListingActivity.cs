using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
        {"Who are people you appreciate",
         "What are some things about you that you like?",
         "Who are poeple that you've helped this week?",
         "Who are some of your heroes?",
         "what has been the best part of each day this week?"};
    private int _numbOfUserList;

    public ListingActivity(string name, string description) : base(name, description)
    {
        
    }

    private string SelectFromList()
    {
        Random random = new Random();
        int i = random.Next(_prompts.Count);
        string str = _prompts[i];
        _prompts.Remove(str);
        if (_prompts.Count == 0)
        {
            _prompts.Add("Who are people you appreciate");
            _prompts.Add("What are some things about you that you like?");
            _prompts.Add("Who are poeple that you've helped this week?");
            _prompts.Add("Who are some of your heroes?");
            _prompts.Add("what has been the best part of each day this week?");
        }
        return str;
    }
    public void RunActiviity()
    {
        int duration = GetDuration();
        Console.WriteLine("List as many responses as possible to this prompt:");
        Console.WriteLine($"——— {SelectFromList()} ———");
        Console.Write("You may begin in ");
        Animation("countdown", 3);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _numbOfUserList++;
        }
        Console.WriteLine($"You listed {_numbOfUserList} items!");
    }
}