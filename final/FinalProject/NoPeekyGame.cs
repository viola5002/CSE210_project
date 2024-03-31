using System;

public class NoPeekyGame : Game
{
    public NoPeekyGame(string rules) : base(rules)
    {
        DealCards(8);
    }

    public override void DisplayCards()
    {
        throw new NotImplementedException();
    }
    public override void Pass(List<string> hand)
    {
        throw new NotImplementedException();
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