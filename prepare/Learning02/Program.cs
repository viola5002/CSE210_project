using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning02 World!");

        /*

        Class: Job
        Attributes: 
        * _company : string
        * _jobTitle : string
        * _startYear : int
        * _endYear : int
        Behaviors:
        * Display() : void
        
        Class: Resume
        Attributes:
        * _name : string
        * _jobs : List<Job>
        Behaviors:
        * Display() : void

        */




        Job job1 = new Job();
        job1._jobTitle = "Electrician";
        job1._company = "Some Company";
        job1._startYear = 2002;
        job1._endYear = 2010;
        
        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._company = "Another Company";
        job2._startYear = 2010;
        job2._endYear = 2014;

        //job1.Display();
        //job2.Display();

        Resume resume1 = new Resume();
        resume1._name = "Veronica Smith";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1.Display();
    }
}