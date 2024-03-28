using System;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello FinalProject World!");
        int choice = 0;
        do {
                Console.WriteLine("1. Uno\n"+
                                  "2. Go Fish\n"+
                                  "3. No Peeky\n"+
                                  "4. Quit");
                Console.Write("What game do you want to play? ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UnoGame uno = new UnoGame("haha");
                        uno.PlayGame();
                        break;
                    case 2:
                        GoFishGame goFish = new GoFishGame("haha");
                        goFish.PlayGame();
                        break;
                    case 3:
                        NoPeekyGame noPeeky = new NoPeekyGame("haha");
                        noPeeky.PlayGame();
                        break;
                    case 4:
                        Console.WriteLine("Play again soon!");
                        break;
                    default:
                        Console.WriteLine("That coice is not recognized");
                        break;
                }
        }while (choice != 4);
    }
}