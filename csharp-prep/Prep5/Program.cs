using System;

class Program
{
    static void Main(string[] args)
    {
       // Console.WriteLine("Hello Prep5 World!");

       static void DisplayWelcome()
       {
            Console.WriteLine("Welcome to the Program!");
       }
       static string PromptUserName()
       {
            Console.Write("What is your name? ");
            string userName = Console.ReadLine();
            return userName;
       }
       static int PromptUserNumber()
       {
            Console.Write("What is your favorite number? ");
            int userNumber = int.Parse(Console.ReadLine());
            return userNumber;
       }
       static int SquareNumber(int number)
       {
            number = number*number;
            return number;
       }
       static void DisplayResult(string name, int squaredNumber)
       {
;
            Console.WriteLine($"{name}, the square of the number is {squaredNumber}.");
       }
        
        
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int userSquaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, userSquaredNumber);

    }
}
