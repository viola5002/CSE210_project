using System;
using System.Runtime.InteropServices;

public class GoFishGame : Game
{
    private List<string> _userMatches = new List<string>();
    private List<string> _opponentMatches = new List<string>();
    private List<string> _opponentMatches1 = new List<string>();
    private List<string> _opponentMatches2 = new List<string>();

    public GoFishGame(string rules) : base(rules)
    {
        DealCards(5);
    }

    public override void DisplayCards()
    {
        int i = 1;
        foreach (string card in _userHand)
        {
            GoFishCard goFishCard = new GoFishCard(card);
            Console.WriteLine($"{i}. {goFishCard.Display()}");
            i++;
        }
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
        Console.Write("Which opponent are you asking? (Enter a number) ");
        int opponent = int.Parse(Console.ReadLine());
        Console.Write("What card are you asking for? (Enter a number)");
        GoFishCard goFishCard = new GoFishCard(_userHand[int.Parse(Console.ReadLine())-1]);
        int numbOfHands = _userHand.Count;
        if (opponent == 1)
        {
            foreach (string card in _opponentHand)
            {
                if (goFishCard.PlayCard(card, "user"))
                {
                    _userMatches.Add(card);
                    _userMatches.Add(goFishCard.GetCard());
                    _opponentHand.Remove(card);
                    _userHand.Remove(goFishCard.GetCard());
                    break;
                }
            }
        }
        else if (opponent == 2)
        {
            foreach (string card in _opponentHand1)
            {
                if (goFishCard.PlayCard(card, "user"))
                {
                    _userMatches.Add(card);
                    _userMatches.Add(goFishCard.GetCard());
                    _opponentHand.Remove(card);
                    _userHand.Remove(goFishCard.GetCard());
                    break;
                }
            }            
        }
        else if (opponent == 3)
        {
            foreach (string card in _opponentHand2)
            {
                if (goFishCard.PlayCard(card, "user"))
                {
                    _userMatches.Add(card);
                    _userMatches.Add(goFishCard.GetCard());
                    _opponentHand.Remove(card);
                    _userHand.Remove(goFishCard.GetCard());
                    if (_userMatches.Count == 10)
                    {
                        Console.WriteLine("You win!");
                        EndGame();
                    }
                    break;
                }
            }
        }
        if (numbOfHands == _userHand.Count)
        {
            Console.WriteLine("Your opponent does not have the card. Go Fish!");
            Pass(_userHand);
        }
    }
    public override void OpponentTurn(List<string> opponentHand)
    {
        int numbOfCards = 0;
        Random random = new Random();
        int askCard = random.Next(4);
        string card = opponentHand[random.Next(opponentHand.Count)];
        GoFishCard goFishCard = new GoFishCard(card);
        switch (askCard)
        {
            case 0:
                foreach (string compareCard in _userHand)
                {
                    if(goFishCard.PlayCard(card, "opponentToUser"))
                    {
                        Console.Write($"Your opponent is asking for {goFishCard.GetCard()} and you have it!"+
                            "Press Enter to give it to them. ");
                        Console.ReadKey();
                        opponentHand.Add(compareCard);
                        break;  
                    }
                    else
                    {
                        numbOfCards++;
                    }
                }
                if (numbOfCards == _userHand.Count)
                {
                    Console.WriteLine($"Your opponent is asking for {goFishCard.GetCard()}"+
                        "and you don't have it.");
                    Pass(opponentHand);
                }
                break;
            case 1:
                if(goFishCard.PlayCard(card, "opponent1"))
                {
                    Console.WriteLine("Match found!");
                }
                else
                {
                    Pass(opponentHand);
                }
                break;
            case 2:
                if(goFishCard.PlayCard(card, "opponent2"))
                {
                    Console.WriteLine("Match found!");
                }
                else
                {
                    Pass(opponentHand);
                }
                break;
            case 3:
                if(goFishCard.PlayCard(card, "opponent3"))
                {
                    Console.WriteLine("Match found!");
                }
                else
                {
                    Pass(opponentHand);
                }
                break;
        }
        if (opponentHand.Count == 10)
        {
            Console.WriteLine("You lose.");
            EndGame();
        }
    }
}