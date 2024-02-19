using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning04 World!");
        Assignment a = new Assignment("Hannah Buckley", "Inheritance");
        Console.WriteLine(a.GetSummary());

        MathAssignment ma = new MathAssignment("Calvin", "Multiplication", "6.4", "1-12");
        Console.WriteLine(ma.GetSummary());
        Console.WriteLine(ma.GetHomeworkList());
        
        WritingAssignment wa = new WritingAssignment("Holly Watson", "Literature", "Summary of book'");
        Console.WriteLine(wa.GetSummary());
        Console.WriteLine(wa.GetWritingInfo());
    }
}