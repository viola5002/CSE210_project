using System;

public class SensoryCountingActivity : Activity
{
    private List<string> _colors = new List<string>() {"brown", "black", "white", "pink", "red", 
        "orange", "yellow", "green", "blue", "purple"};

    public SensoryCountingActivity(string name, string description) : base(name, description)
    {

    }

    private string SelectFromList()
    {
        Random random = new Random();
        int i = random.Next(_colors.Count);
        string str = _colors[i];
        _colors.Remove(str);
        if (_colors.Count == 0)
        {
            _colors.Add("brown");
            _colors.Add("black");
            _colors.Add("white");
            _colors.Add("pink");
            _colors.Add("red");
            _colors.Add("orange");
            _colors.Add("yellow");
            _colors.Add("green");
            _colors.Add("blue");
            _colors.Add("purple");
        }
        return str;
    }
    public void RunActiviity()
    {
        int i = 1;
        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string color = SelectFromList();
            if (i == 1)
            {
                Console.WriteLine($"Look around and count {i} {color} thing");
            }
            else
            {
                Console.WriteLine($"Look around and count {i} {color} things");
            }
            Thread.Sleep(7000);
            i++;
        }
    }
}