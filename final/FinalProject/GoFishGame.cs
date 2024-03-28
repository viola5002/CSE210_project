using System;

public class GoFishGame : Game
{
    public GoFishGame(string rules) : base(rules)
    {
        DealCards(5);
    }

    public override void Pass(List<string> hand)
    {
        throw new NotImplementedException();
    }
    public override void PlayTurn()
    {
        throw new NotImplementedException();
    }
    public override void OpponentTurn(List<string> oppenentHand)
    {
        throw new NotImplementedException();
    }
    public override int EndGame()
    {
        throw new NotImplementedException();
    }
}