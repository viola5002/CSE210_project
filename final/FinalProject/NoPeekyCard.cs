using System;

public class NoPeekyCard : Card
{
    public NoPeekyCard(string card) : base(card)
    {

    }

    public int GetNumber()
    {
        return int.Parse(_number);
    }
    public override bool PlayCard(string compareCard, string player)
    {
        string[] cardParts = compareCard.Split(" ");
        string comareColor = cardParts[0];
        string compareNumber = cardParts[1];
        if (player == "user")
        {
            _card = compareCard;
            return true;
        }
        else
        {
            if (int.Parse(compareNumber) <= 4)
            {
                _card = compareCard;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}