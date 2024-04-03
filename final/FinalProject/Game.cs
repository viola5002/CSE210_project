using System;
using System.Data.SqlTypes;
using System.Xml.Serialization;

public abstract class Game
{
    private string _rules;
    private int _opponents;

    protected List<string> _deck = new List<string>() {"red 0", "red 1", "red 2", "red 3", "red 4", "red 5", "red 6", "red 7", "red 8", "red 9",
            "red 0", "red 1", "red 2", "red 3", "red 4", "red 5", "red 6", "red 7", "red 8", "red 9",
            "yellow 0", "yellow 1", "yellow 2", "yellow 3", "yellow 4", "yellow 5", "yellow 6", "yellow 7", "yellow 8", "yellow 9",
            "yellow 0", "yellow 1", "yellow 2", "yellow 3", "yellow 4", "yellow 5", "yellow 6", "yellow 7", "yellow 8", "yellow 9",
            "blue 0", "blue 1", "blue 2", "blue 3", "blue 4", "blue 5", "blue 6", "blue 7", "blue 8", "blue 9",
            "blue 0", "blue 1", "blue 2", "blue 3", "blue 4", "blue 5", "blue 6", "blue 7", "blue 8", "blue 9",
            "green 0", "green 1", "green 2", "green 3", "green 4", "green 5", "green 6", "green 7", "green 8", "green 9",
            "green 0", "green 1", "green 2", "green 3", "green 4", "green 5", "green 6", "green 7", "green 8", "green 9"};
    protected List<string> _userHand = new List<string>();
    protected List<string> _opponentHand = new List<string>();
    protected List<string> _opponentHand1 = new List<string>();
    protected List<string> _opponentHand2 = new List<string>();
    protected List<string> _discardPile = new List<string>();

    public Game(string rules)
    {
        _rules = rules;
        Console.Write("How many opponents do you want to play against? (1-3) ");
        _opponents = int.Parse(Console.ReadLine());
    }

    protected int GetOpponents()
    {
        return _opponents;
    }
    public virtual void DealCards(int _perHand)
    {
        Random random = new Random();
        for (int i = 0; i < _perHand; i++)
        {
            int index = random.Next(_deck.Count);
            _userHand.Add(_deck[index]);
            _deck.RemoveAt(index);

            int index1 = random.Next(_deck.Count);
            _opponentHand.Add(_deck[index1]);
            _deck.RemoveAt(index1);

            if (_opponents >= 2)
            {
                int index2 = random.Next(_deck.Count);
                _opponentHand1.Add(_deck[index2]);
                _deck.RemoveAt(index2);
            }
            if (_opponents == 3)
            {
                int index3 = random.Next(_deck.Count);
                _opponentHand2.Add(_deck[index3]);
                _deck.RemoveAt(index3);
            }
        }


    }
    public virtual void PlayGame()
    {
        int gameChoice = 0;
        Console.Clear();
        do {
            Console.WriteLine("1. Display Directions\n"+
                              "2. Display Cards\n"+
                              "3. PlayTurn\n"+
                              "4. Forfeit");
            Console.Write("What is your choice? ");
            gameChoice = int.Parse(Console.ReadLine());
            switch (gameChoice)
            {
                case 1:
                    Console.WriteLine(_rules);
                    break;
                case 2:
                    DisplayCards();
                    Console.WriteLine();
                    break;
                case 3:
                    PlayTurn();
                    Console.WriteLine("Opponent 1 playing...");
                    OpponentTurn(_opponentHand);
                    if (_opponents >= 2)
                    {
                        Console.WriteLine("Opponent 2 playing...");
                        OpponentTurn(_opponentHand1);
                    }
                    if (_opponents == 3)
                    {
                        Console.WriteLine("Opponent 3 playing...");
                        OpponentTurn(_opponentHand2);
                    }
                    break;
                case 4:
                    Console.WriteLine("You lose.");
                    break;
                default:
                    Console.WriteLine("Your choice is not recognized.");
                    break;
            }
        } while (gameChoice != 4);
    }
    public abstract void DisplayCards();
    public abstract void Pass(List<string> hand);
    public abstract void PlayTurn();
    public abstract void OpponentTurn(List<string> opponentHand);
    public void EndGame()
    {
        Environment.Exit(0);
    }
}