using System;
using System.Globalization;
using System.Xml.Schema;

public class NoPeekyGame : Game
{
    private int _userScore;
    private int _opponentScore;
    private int _opponent1Score;
    private int _opponent2Score;
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
        Console.Write("Do you want to call \"No Peeky?\" ");
        if (Console.ReadLine().Contains("y"))
        {
            EndGame();
        }    
    }
    public override void OpponentTurn(List<string> opponentHand)
    {
        throw new NotImplementedException();
    }
    public override void EndGame()
    {
        _userScore = GetScore(_userHand);
        _opponentScore = GetScore(_opponentHand);
        _opponent1Score = GetScore(_opponentHand1);
        _opponent2Score = GetScore(_opponentHand2);
        if (_userScore >= _opponentScore && _userScore >= _opponent1Score && _userScore >= _opponent2Score)
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
        foreach (string card in hand)
        {
            string[] cardParts = card.Split(" ");
            int number = int.Parse(cardParts[1]);
            total += number;
        }
        return total;
    }
}