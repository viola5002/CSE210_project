using System;

public class GoFishCard : Card
{
    GoFishCard(string card) : base(card)
    {

    }

    public override bool PlayCard(string compareCard)
    {
        string[] cardParts = compareCard.Split(" ");
        string compareColor = cardParts[0];
        string compareNumber = cardParts[1];
        return false;
    }
    public override void Display()
    {
        base.Display();
    }
}