using System;
using System.Collections.ObjectModel;
using System.Reflection;

public class UnoGame : Game
{

    public UnoGame(string rules) : base(rules)
    {
        string[] extraCards = {"color wild", "color wild", "color wild", "color wild", 
            "blue draw2", "blue draw2", "yellow draw2", "yellow draw2", "red draw2", "red draw2", "green draw2", "green draw2"};
        _deck.AddRange(extraCards);
        DealCards(7);
        Random random = new Random();
        int index = random.Next(_deck.Count);
        _discardPile.Add(_deck[index]);
        _deck.RemoveAt(index);
    }

    public override void DisplayCards()
    {
        int i = 1;
        foreach (string card in _userHand)
        {
            UnoCard unoCard = new UnoCard(card);
            Console.WriteLine($"{i}. {unoCard.Display()}");
            i++;
        }
    }
    public override void PlayTurn()
    {
        string topCard = _discardPile[_discardPile.Count-1];
        UnoCard newTopCard = new UnoCard(topCard);
        Console.WriteLine($"The top card is {newTopCard.Display()}");
        Console.Write("Pick your card that you want to play (Enter a number): ");
        int index = int.Parse(Console.ReadLine())-1;
        UnoCard card = new UnoCard(_userHand[index]);
        if(card.PlayCard(topCard, "user"))
        {
            _discardPile.Add(card.GetCard());
            _userHand.RemoveAt(index);
            Console.WriteLine($"Playing {card.Display()}...");
            if (card.GetCard().Contains("draw2"))
            {
                Pass(_opponentHand);
                Pass(_opponentHand);
            }
        }
        else
        {
            Console.Write("That card can't be played right now. Do you want to draw a card? (y/n)");
            string choice = Console.ReadLine();
            if (choice == "n")
            {
                PlayTurn();
            }
            else
            {
                Pass(_userHand);
            }
        }
        if (_userHand.Count == 0)
        {
            Console.WriteLine("You Won!");
            EndGame();
        }
    }
    public override void OpponentTurn(List<string> opponentHand)
    {
        List<string> nextPlayer = new List<string>();
        if (opponentHand == _opponentHand)
        {
            nextPlayer = _opponentHand1;
        }
        else if (opponentHand == _opponentHand1)
        {
            nextPlayer = _opponentHand2;
        }
        else if (opponentHand == _opponentHand2)
        {
            nextPlayer = _userHand;
        }
        int numbofCards = opponentHand.Count();
        string topCard = _discardPile[_discardPile.Count-1];
        foreach (string card in opponentHand)
        {
            UnoCard uc = new UnoCard(card);
            if(uc.PlayCard(topCard, "opponent"))
            {
                _discardPile.Add(uc.GetCard());
                opponentHand.Remove(card);
                Console.WriteLine($"Playing {uc.Display()}...");
                if (uc.GetCard().Contains("draw2"))
                {
                    Pass(nextPlayer);
                    Pass(nextPlayer);
                }
                break;
            }
            if (opponentHand.Count == 0)
            {
                Console.WriteLine("You lost.");
                EndGame();
            }
        }
        if (numbofCards == opponentHand.Count())
        {
            Pass(opponentHand);
        }
    }

}
