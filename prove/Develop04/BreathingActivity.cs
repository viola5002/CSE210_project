using System;
using System.ComponentModel;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
        
    }

    public void RunActivity()
    {
        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            Animation("countdown", 4);
            Console.WriteLine("\nBreate out...");
            Animation("countdown", 6);
        }
    }
}