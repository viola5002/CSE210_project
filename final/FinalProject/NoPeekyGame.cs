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
                Console.WriteLine($"{i+1}. {noPeekyCard.Display()}");
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
        throw new NotImplementedException();
    }
    public override void OpponentTurn(List<string> opponentHand)
    {
        throw new NotImplementedException();
    }
}