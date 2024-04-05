using System;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello FinalProject World!");
        int choice = 0;
        string rules;
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
                        rules = "You must play a card that matches the color, number, or symbol of the top discard card. "+
                            "If you don't have one, you will draw a card. Wild cards may be changed to "+
                            "any of the four colors. A draw2 card will make the next player draw two cards. They will "+
                            "still have their turn. There are no skips or reverses. The game ends when someone runs "+
                            "out of cards and wins.";
                        UnoGame uno = new UnoGame(rules);
                        uno.PlayGame();
                        break;
                    case 2:
                        rules = "You must ask an opponent (or yourself) for a card. If they have the same card, "+
                            "they will give it to you to put in your matches. If they don't have it, you will "+
                            "draw a card. When either you or your opponent has 5 matches, the game is over "+
                            "and whomever has 5 matches wins.";
                        GoFishGame goFish = new GoFishGame(rules);
                        goFish.PlayGame();
                        break;
                    case 3:
                        rules = "You have four hidden cards. You are allowed to know the outside cards "+
                            "once at the beggining if the game. At each turn, you may either take the top discard card "+
                            "or draw from the draw pile. You may then replace any of your cards with the card you drew or "+
                            "discard it. When you think you have the lowest numbers, you declare \"No Peeky\" to end the game. "+
                            "Whomever has the lowest score wins.";
                        NoPeekyGame noPeeky = new NoPeekyGame(rules);
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