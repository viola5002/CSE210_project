using System;

public class UnoCard : Card
{
    public UnoCard(string card) : base(card)
    {

    }

    public override bool PlayCard(string compareCard)
    {
        string[] cardParts = compareCard.Split(" ");
        string compareColor = cardParts[0];
        string compareNumber = cardParts[1];
        if (_number == compareNumber || _color == compareColor)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void Display()
    {
        base.Display();
    }
}