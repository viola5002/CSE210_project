using System;
using System.Collections;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

//This class is for the extra points.
public class ScriptureChoice
{
    private List<string> _references = new List<string>();
    private List<string> _scriptures = new List<string>();
    private int _choice;

    public ScriptureChoice()
    {

    }

    private void ParseFile()
    {
        //you can't edit the file, or it will affect the program
        string[] _lines = File.ReadAllLines("scriptures.txt");
        for (int i = 1; i < (_lines.Length+1); i++)
        {
            if (i % 3 == 1)
            {
                _references.Add(_lines[i-1]);
            }
            else if (i % 3 == 2)
            {
                _scriptures.Add(_lines[i-1]);
            }
        }
    }
    public ScriptureReference ChooseReference()
    {
        ParseFile();
        Console.WriteLine("Choose a scripture to memorize:");
        int i = 1;
        foreach(string reference in _references)
        {
            Console.WriteLine($"{i}. {reference}");
            i++;
        }

        Console.Write("Select a scripture (1-3)");
        _choice = int.Parse(Console.ReadLine());
        switch (_choice)
        {
            case 1:
                ScriptureReference sR = new ScriptureReference("John", 17, 3);
                return sR;
            case 2:
                ScriptureReference sR1 = new ScriptureReference("1 Nephi", 3, 7);
                return sR1;
            case 3:
                ScriptureReference sR2 = new ScriptureReference("Proverbs", 3, 5, 6);
                return sR2;
            default:
                ScriptureReference sR3 = new ScriptureReference("John", 17, 3);
                return sR3;
        }
    }
    public Scripture GetScripture()
    {
        ParseFile();
        switch (_choice)
        {
            case 1:
                Scripture s = new Scripture(_scriptures[0]);
                return s;
            case 2:
                Scripture s1 = new Scripture(_scriptures[1]);
                return s1;
            case 3:
                Scripture s2 = new Scripture(_scriptures[2]);
                return s2;
            default:
                Scripture s3 = new Scripture(_scriptures[0]);
                return s3;
        }
    }
}