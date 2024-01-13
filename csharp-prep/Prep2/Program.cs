using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep2 World!");
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        char letter;
        char sign;
        if (grade >= 90)
        {
            letter = 'A';
        }
        else if (grade >= 80)
        {
            letter = 'B';
        }
        else if (grade >= 70)
        {
            letter = 'C';
        }
        else if (grade >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        int gradeRemainder = grade % 10;
        if (gradeRemainder >= 7 && letter != 'A' && letter != 'F')
        {
            sign = '+';
        }
        else if (gradeRemainder <= 3 && letter != 'F')
        {
            sign = '-';
        }
        else
        {
            sign = ' ';
        }


        Console.WriteLine($"Your letter grade is {letter}{sign}");


        if (grade >= 70)
        {
            Console.WriteLine("You passed the class!");
        }
        else
        {
            Console.WriteLine("You did not pass the class. " +
                "Keep working hard and next time you'll get it,");
        }
    }
}