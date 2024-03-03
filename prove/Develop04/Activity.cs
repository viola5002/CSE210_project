using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private string _startingMessage;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _startingMessage = $"Welcome to the {_name}.\n\nThis activity will help you {_description}";
    }

    private void SetDuration()
    {
        Console.Write("How many seconds would you like to do the activity? ");
        string duration = Console.ReadLine();
        _duration = int.Parse(duration);
    }
    protected int GetDuration()
    {
        return _duration;
    }
    public void BeginActivity()
    {
        Console.Clear();
        Console.WriteLine($"{_startingMessage}\n");
        SetDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        Animation("spinner", 5);

    }
    public void EndActivity()
    {
        string endingMessage = $"You have completed another {GetDuration()} seconds of {_name}.";
        Console.WriteLine("Well done!");
        Animation("spinner", 3);
        Console.WriteLine($"\n{endingMessage}");
        Animation("spinner", 5);

    }
    protected void Animation(string type, int length)
    {
        if (type == "spinner")
        {
            List<string> animations = new List<string>() {"|", "/", "—", "\\"};
            int i = 0;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(length);
            while (DateTime.Now < endTime)
            {
                Console.Write(animations[i]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                if (i == (animations.Count - 1))
                {
                    i = -1;
                }
                i++;
            }
        }

        else if (type == "countdown")
        {
            for (int i = length; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}