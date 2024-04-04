using System;

public class NoPeekyGame : Game
{
    public NoPeekyGame(string rules) : base(rules)
    {
        DealCards(4);
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
        Pass(_userHand);
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
    }
    public override void OpponentTurn(List<string> opponentHand)
    {
        throw new NotImplementedException();
    }
}