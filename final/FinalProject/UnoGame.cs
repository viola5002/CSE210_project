using System;
using System.Collections.ObjectModel;

public class UnoGame : Game
{

    public UnoGame(string rules) : base(rules)
    {
        string[] extraCards = {"color wild", "color wild", "color wild", "color wild",};
        _deck.AddRange(extraCards);
        DealCards(7);
        Random random = new Random();
        int index = random.Next(_deck.Count);
        _discardPile.Add(_deck[index]);
        _deck.RemoveAt(index);
    }

    public override void Pass(List<string> hand)
    {
        Console.WriteLine("Drawing card...");
        Random random = new Random();
        int index = random.Next(_deck.Count);
        hand.Add(_deck[index]);
        _deck.RemoveAt(index);
    }
    public override void PlayTurn()
    {
        string topCard = _discardPile[_discardPile.Count-1];
        Console.WriteLine($"The top card is {topCard}");
        Console.Write("Pick your card that you want to play: ");
        UnoCard card = new UnoCard(_userHand[int.Parse(Console.ReadLine())-1]);
        if(card.PlayCard(topCard, "user"))
        {
            _discardPile.Add(card.GetCard());
            _userHand.Remove(card.GetCard());
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
        int numbofCards = opponentHand.Count();
        string topCard = _discardPile[_discardPile.Count-1];
        foreach (string card in opponentHand)
        {
            UnoCard uc = new UnoCard(card);
            if(uc.PlayCard(topCard, "opponent"))
            {
                _discardPile.Add(uc.GetCard());
                opponentHand.Remove(uc.GetCard());
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
    public override int EndGame()
    {
        Environment.Exit(0);
        return base.EndGame();
    }
}
