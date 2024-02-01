using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Develop02 World!");
        

        int menuChoice = 0;
        Journal journal = new Journal();
        while (menuChoice != 5)
        {
            Console.WriteLine("Journal App");
            Console.WriteLine("Options:");
            Console.WriteLine("1. New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");
            menuChoice = int.Parse(Console.ReadLine());
             
            switch (menuChoice)
            {
                case 1:
                    Prompt prompt = new Prompt();
                    Entry entry = new Entry();
                    DateTime theCurrentTime = DateTime.Now;
                    string date = theCurrentTime.ToShortDateString();
                    entry._date = date;
                    entry._prompt = prompt.RandomPrompt();
                    Console.WriteLine(entry._prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    entry._userResponse = response;
                    journal._entries.Add(entry);
                    break;
                case 2:
                    journal.Display();
                    break;
                case 3:
                    Console.WriteLine("Hi");
                    break;
                case 4:
                    Console.WriteLine("Hi");
                    break;
                case 5:
                    Console.WriteLine("Goodbye...");
                    break;
                default:
                    Console.WriteLine("That's not a choice!");
                    break;

            }

        }

    }
}