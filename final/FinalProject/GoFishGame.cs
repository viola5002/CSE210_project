using System;
using System.Reflection.Metadata;
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
        Console.Write("Which opponent are you asking? (Enter 0 for yourself, 1 for opponent 1, etc.) ");
        int opponent = int.Parse(Console.ReadLine());
        Console.Write("What card are you asking for? (Enter a number) ");
        int index = int.Parse(Console.ReadLine())-1;
        GoFishCard goFishCard = new GoFishCard(_userHand[index]);
        int numbOfCards = 0;
        if (opponent == 0)
        {
            foreach (string card in _userHand)
            {
                if (goFishCard.PlayCard(card, "user") && index != _userHand.FindLastIndex(a => a.Contains(card)))
                {
                    MoveCards(_userHand, _userMatches, _userHand, goFishCard.GetCard(), card);
                    Console.WriteLine("Match found!");
                    break;
                }
                else
                {
                    numbOfCards++;
                }
            }
        }
        if (opponent == 1)
        {
            foreach (string card in _opponentHand)
            {
                if (goFishCard.PlayCard(card, "user"))
                {
                    MoveCards(_userHand, _userMatches, _opponentHand, goFishCard.GetCard(), card);
                    break;
                }
                else
                {
                    numbOfCards++;
                }
            }
        }
        else if (opponent == 2)
        {
            foreach (string card in _opponentHand1)
            {
                if (goFishCard.PlayCard(card, "user"))
                {
                    MoveCards(_userHand, _userMatches, _opponentHand1, goFishCard.GetCard(), card);
                    break;
                }
                else
                {
                    numbOfCards++;
                }
            }            
        }
        else if (opponent == 3)
        {
            foreach (string card in _opponentHand2)
            {
                if (goFishCard.PlayCard(card, "user"))
                {
                    MoveCards(_userHand, _userMatches, _opponentHand2, goFishCard.GetCard(), card);
                    break;
                }
                else
                {
                    numbOfCards++;
                }
            }
        }
        
        if (numbOfCards == _userHand.Count)
        {
            Console.WriteLine("Your opponent does not have the card. Go Fish!");
            Pass(_userHand);
        }
        if (_userMatches.Count == 10)
        {
            Console.WriteLine("You win!");
            EndGame();
        }
    }
    public override void OpponentTurn(List<string> opponentHand)
    {
        List<string> opponentMatches = new List<string>();
        int maxRandomNumb= GetOpponents();
        if (opponentHand == _opponentHand) 
        {
            opponentMatches = _opponentMatches;
        }
        else if (opponentHand == _opponentHand1)
        {
            opponentMatches = _opponentMatches1;
        }
        else if (opponentHand == _opponentHand2)
        {
            opponentMatches = _opponentMatches2;
        }
        int numbOfCards = 0;
        Random random = new Random();
        int askCard = random.Next(maxRandomNumb);
        int index = random.Next(opponentHand.Count);
        string card = opponentHand[index];
        GoFishCard goFishCard = new GoFishCard(card);
        switch (askCard)
        {
            case 0:
                foreach (string compareCard in _userHand)
                {
                    if(goFishCard.PlayCard(compareCard, "opponentToUser"))
                    {
                        Console.Write($"Your opponent is asking for {goFishCard.GetCard()} and you have it!"+
                            "Press Enter to give it to them. ");
                        Console.ReadKey();
                        MoveCards(opponentHand, opponentMatches, _userHand, goFishCard.GetCard(), compareCard);
                        break;  
                    }
                    else
                    {
                        numbOfCards++;
                    }
                }
                if (numbOfCards == _userHand.Count)
                {
                    Console.WriteLine($"Your opponent is asking for {goFishCard.GetCard()} "+
                        "and you don't have it.");
                }
                break;
            case 1:
                foreach (string compareCard in _opponentHand)
                {
                    if (goFishCard.PlayCard(compareCard, "opponent") && index != opponentHand.FindLastIndex(a => a.Contains(compareCard)))
                    {
                        Console.WriteLine("Match found!");   
                        MoveCards(opponentHand, opponentMatches, _opponentHand, goFishCard.GetCard(), compareCard);
                        break;                         
                    }
                    else
                    {
                        numbOfCards++;
                    }
                }
                break;
            case 2:
                foreach (string compareCard in _opponentHand1)
                {
                    if (goFishCard.PlayCard(compareCard, "opponent") && index != opponentHand.FindLastIndex(a => a.Contains(compareCard)))
                    {
                        Console.WriteLine("Match found!");   
                        MoveCards(opponentHand, opponentMatches, _opponentHand1, goFishCard.GetCard(), compareCard);
                        break;                         
                    }
                    else
                    {
                        numbOfCards++;
                    }
                }
                break;
            case 3:
                foreach (string compareCard in _opponentHand2)
                {
                    if (goFishCard.PlayCard(compareCard, "opponent") && index != opponentHand.FindLastIndex(a => a.Contains(compareCard)))
                    {
                        Console.WriteLine("Match found!");   
                        MoveCards(opponentHand, opponentMatches, _opponentHand2, goFishCard.GetCard(), compareCard);                         
                        break;
                    }
                    else
                    {
                        numbOfCards++;
                    }
                }
                break;
        }
        if (numbOfCards == opponentHand.Count)
        {
            Pass(opponentHand);
        }
        if (opponentMatches.Count == 10)
        {
            Console.WriteLine("You lose.");
            EndGame();
        }
    }
    public void MoveCards(List<string> recieveHand, List<string> recieveMatches, List<string> giveHand, string alreadyHaveCard, string giveCard)
    {
        recieveMatches.Add(alreadyHaveCard);
        recieveMatches.Add(giveCard);
        giveHand.Remove(alreadyHaveCard);
        recieveHand.Remove(giveCard);
    }
}