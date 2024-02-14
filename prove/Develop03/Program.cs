using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Develop03 World!");

        string choice = "hi";
        ScriptureReference sR = new ScriptureReference();
        Scripture s = new Scripture();

        while (choice != "quit")
        {
            sR.Display();
            s.Display();
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish");
            choice = Console.ReadLine();
            if (choice != "quit")
            {
                s.HideWords();
                Console.Clear();
            }
            else
            {
                break;
            }
        }
    }
}