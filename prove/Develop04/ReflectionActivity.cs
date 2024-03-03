using System;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>() 
        {"Think of a time when you did something difficult",
         "Think of a time when you helped somebody else",
         "Think of a time when someone else helped you",
         "Think of a time when you did something selfless"};
    private List<string> _reflections = new List<string>()
        {"Why was this experience meaningful?",
         "What was your favorite thing about this experience?",
         "What did you learn about yourself from this experience?",
         "How did you feel after this experience?",
         "How can you apply the lessons from this experience?"};

    public ReflectionActivity(string name, string description) : base(name, description)
    {

    }
    private string SelectFromList(List<string> list)
    {
        Random random = new Random();
        int i = random.Next(list.Count);
        string str = list[i];
        return str;
    }
    public void RunActivity()
    {
        int duration = GetDuration();
        string prompt = SelectFromList(_prompts);

        Console.WriteLine($"\n  ——— {prompt} ———  \n");
        Console.WriteLine("When you have something in mind, press any key to continue.");
        Console.ReadKey();
        Console.WriteLine("\nNow reflect on the following questions as related to this experience.");
        Console.Write("Begin in ");
        Animation("countdown", 3);
        

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\n \n");
            string reflection = SelectFromList(_reflections);
            _reflections.Remove(reflection);
            Console.WriteLine(reflection);
            Thread.Sleep(10000);
            if (_reflections.Count == 0)
            {
                _reflections.Add("Why was this experience meaningful?");
                _reflections.Add("What was your favorite thing about this experience?");
                _reflections.Add("What did you learn about yourself from this experience?");
                _reflections.Add("How did you feel after this experience?");
                _reflections.Add("How can you apply the lessons from this experience?");
            }
        }
    }
}