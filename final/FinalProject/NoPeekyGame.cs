using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

public class NoPeekyGame : Game
{
    private int _userScore;
    private int _opponentScore;
    private int _opponentScore1;
    private int _opponentScore2;
    private int _turnCycles;
    public NoPeekyGame(string rules) : base(rules)
    {
        DealCards(4);
        Random random = new Random();
        int index = random.Next(_deck.Count);
        _discardPile.Add(_deck[index]);
        _deck.RemoveAt(index);

        Console.WriteLine("Your cards are: ");
        for (int i = 0; i < _userHand.Count; i++)
        {
            NoPeekyCard noPeekyCard = new NoPeekyCard(_userHand[i]);
            if (i == 0 || i == 3)
            {
                Console.WriteLine($"{i+1}. {noPeekyCard.GetCard()}");
            }
            else
            {
                Console.WriteLine($"{i+1}. Hidden");
            }
        }
        Console.WriteLine();
    }

    public override void DisplayCards()
    {
        int i = 1;
        foreach (string card in _userHand)
        {
            Console.WriteLine($"{i}. Hidden");
            i++;
        }
    }
    public override void PlayTurn()
    {
        string topCard = _discardPile[_discardPile.Count-1];
        Console.WriteLine($"The discard card is {topCard}");
        Console.Write("Do you want to take it? (y/n) ");
        if (Console.ReadLine().Contains('y'))
        {
            _userHand.Add(topCard);
            _discardPile.RemoveAt(_discardPile.Count-1);
        }
        else
        {
            Pass(_userHand);
        }
        string card = _userHand[_userHand.Count-1];
        Console.WriteLine($"You drew a {card}");
        Console.Write("Which card do you want to replace it with? (Enter 0 to discard it.) ");
        int index = int.Parse(Console.ReadLine());
        if (index == 0)
        {
            _discardPile.Add(card);
            _userHand.RemoveAt(_userHand.Count-1);
        }
        else
        {
            NoPeekyCard replaceCard = new NoPeekyCard(_userHand[index-1]);
            Console.WriteLine($"You are replacing {replaceCard.GetCard()} with {card}");
            replaceCard.PlayCard(card, "user");
            _discardPile.Add(_userHand[index-1]);
            _userHand[index-1] = replaceCard.GetCard();
            _userHand.RemoveAt(_userHand.Count-1);
        }
        Console.Write("Do you want to call \"No Peeky\"? ");
        if (Console.ReadLine().Contains("y"))
        {
            EndGame();
        }
        _turnCycles++;    
    }
    public override void OpponentTurn(List<string> opponentHand)
    {
        string topCard = _discardPile[_discardPile.Count-1];
        NoPeekyCard newTopCard = new NoPeekyCard(topCard);
        if (newTopCard.GetNumber() < 4)
        {
            opponentHand.Add(topCard);
            _discardPile.RemoveAt(_discardPile.Count-1);
            Console.WriteLine($"Drawing {topCard} from the discard pile...");    
        }
        else
        {
            Pass(opponentHand);
        }
        int i = 0;
        string newCard = opponentHand[opponentHand.Count-1];   
        foreach (string card in opponentHand)
        {
            NoPeekyCard replaceCard = new NoPeekyCard(card);
            if (replaceCard.GetNumber() >= 5 && replaceCard.GetCard() != newCard)
            {
                replaceCard = new NoPeekyCard(card);
                if (replaceCard.PlayCard(newCard, "opponent"))
                {
                    _discardPile.Add(opponentHand[i]);
                    Console.WriteLine($"Discarding {opponentHand[i]}...");
                    opponentHand[i] = replaceCard.GetCard();
                    opponentHand.RemoveAt(opponentHand.Count-1);
                    break; 
                }
                else
                {
                    i++;           
                }
            }
            else
            {
                i++;
            }
        }
        if (i == 5)
        {
            _discardPile.Add(newCard);
            Console.WriteLine($"Discarding {newCard}");
            opponentHand.RemoveAt(opponentHand.Count-1);
        }
        if (GetScore(opponentHand) <= 15 && _turnCycles > 3)
        {
            Console.WriteLine("\"No Peeky!\"");
            EndGame();
        }
    }
    public override void EndGame()
    {
        int opponents = GetOpponents();
        _userScore = GetScore(_userHand);
        _opponentScore = GetScore(_opponentHand);
        _opponentScore1 = GetScore(_opponentHand1);
        _opponentScore2 = GetScore(_opponentHand2);
        if (_userScore <= _opponentScore && _userScore <= _opponentScore1 && _userScore <= _opponentScore2)
        {
            Console.WriteLine("You won!");
        }
        else
        {
            Console.WriteLine("You lost.");
        }
        base.EndGame();
    }
    private int GetScore(List<string> hand)
    {
        int total = 0;
        if (hand.Count() == 0)
        {
            total = 1000;
        }
        foreach (string card in hand)
        {
            string[] cardParts = card.Split(" ");
            int number = int.Parse(cardParts[1]);
            total += number;
        }
        return total;
    }
}