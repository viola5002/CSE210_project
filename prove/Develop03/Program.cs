using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Develop03 World!");

        Console.Clear();
        string choice = "hi";
        ScriptureChoice sC = new ScriptureChoice();
        ScriptureReference sR = sC.ChooseReference();
        Scripture s = sC.GetScripture();
        Console.Clear();

        while (choice != "quit")
        {
            sR.Display();
            s.Display();
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish");
            choice = Console.ReadLine();
            if (choice != "quit")
            {
                s.HideWords(sR, s);
                Console.Clear();
            }
            else
            {
                break;
            }
        }
    }
}