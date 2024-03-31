using System;

public class GoFishCard : Card
{
    public GoFishCard(string card) : base(card)
    {

    }

    public override bool PlayCard(string compareCard, string player)
    {
        string[] cardParts = compareCard.Split(" ");
        string compareColor = cardParts[0];
        string compareNumber = cardParts[1];
        if (_color == compareColor && _number == compareNumber)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}