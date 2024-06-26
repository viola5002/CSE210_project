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
            Console.WriteLine($"{i}. {goFishCard.GetCard()}");
            i++;
        }
        Console.WriteLine($"You have {_userMatches.Count/2} matches.");
    }
    public override void PlayTurn()
    {
        Console.Write("Which opponent are you asking? (Enter 0 for yourself, 1 for opponent 1, etc.) ");
        int opponent = int.Parse(Console.ReadLine());
        Console.Write("What card are you asking for? (Enter the number of the first appearance of the card) ");
        int index = int.Parse(Console.ReadLine())-1;
        GoFishCard goFishCard = new GoFishCard(_userHand[index]);
        int numbOfCards = _userHand.Count;
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
            }
        }
        if (opponent == 1)
        {
            foreach (string card in _opponentHand)
            {
                if (goFishCard.PlayCard(card, "user"))
                {
                    MoveCards(_userHand, _userMatches, _opponentHand, goFishCard.GetCard(), card);
                    Console.WriteLine("Match found!");
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
                    MoveCards(_userHand, _userMatches, _opponentHand1, goFishCard.GetCard(), card);
                    Console.WriteLine("Match found!");
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
                    MoveCards(_userHand, _userMatches, _opponentHand2, goFishCard.GetCard(), card);
                    Console.WriteLine("Match found!");
                    break;
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
        int maxRandomNumb= GetOpponents()+1;
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
        int numbOfCards = opponentHand.Count;
        Random random = new Random();
        int askPlayer = random.Next(maxRandomNumb);
        int index = random.Next(opponentHand.Count);
        string card = opponentHand[index];
        GoFishCard goFishCard = new GoFishCard(card);
        Console.WriteLine($"Asking for {goFishCard.GetCard()}...");
        switch (askPlayer)
        {
            case 0:
                foreach (string compareCard in _userHand)
                {
                    if(goFishCard.PlayCard(compareCard, "opponentToUser"))
                    {
                        Console.Write($"Your opponent is asking you for {goFishCard.GetCard()} and you have it! "+
                            "Press Enter to give it to them. ");
                        Console.ReadLine();
                        MoveCards(opponentHand, opponentMatches, _userHand, goFishCard.GetCard(), compareCard);
                        break;  
                    }
                }
                if (numbOfCards == opponentHand.Count)
                {
                    Console.WriteLine($"Your opponent is asking you for {goFishCard.GetCard()} "+
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
    public override void EndGame()
    {
        Console.WriteLine($"You have {_userMatches.Count/2} matches.");
        Console.WriteLine($"Opponent 1 has {_opponentMatches.Count/2} matches.");
        if (GetOpponents() >= 2)
        {
            Console.WriteLine($"Opponent 2 has {_opponentMatches2.Count/2} matches.");
        }
        if (GetOpponents() == 3)
        {
            Console.WriteLine($"Opponent 3 has {_opponentMatches2.Count/2} matches.");
        }
        base.EndGame();
    }
}