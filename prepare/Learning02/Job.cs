using System;
//What's the importance of including this line of code?
//I didn't until I saw the example, and it worked okay.

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public Job()    //the example code in the lesson reading material included this "constructor?"
                    //but the sample solution didn't
    {
    }

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}