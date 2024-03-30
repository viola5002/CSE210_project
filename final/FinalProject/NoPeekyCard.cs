using System;

public class NoPeekyCard : Card
{
    NoPeekyCard(string card) : base(card)
    {

    }

    public override bool PlayCard(string compareCard, string player)
    {        
        string[] cardParts = compareCard.Split(" ");
        string compareColor = cardParts[0];
        string compareNumber = cardParts[1];
        return false;
    }
    public override string Display()
    {
        return base.Display();
    }
}