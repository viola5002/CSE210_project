using System;

public class NoPeekyCard : Card
{
    public NoPeekyCard(string card) : base(card)
    {

    }

    public override bool PlayCard(string compareCard, string player)
    {
        _card = compareCard;
        return true;
    }
}