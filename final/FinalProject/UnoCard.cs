using System;

public class UnoCard : Card
{
    public UnoCard(string card) : base(card)
    {

    }

    public override bool PlayCard(string compareCard, string player)
    {
        string[] cardParts = compareCard.Split(" ");
        string compareColor = cardParts[0];
        string compareNumber = cardParts[1];
        if (_number == "wild")
        {
            if (player == "user")
            {
                Console.Write("What color are you changing it into? ");
                _color = Console.ReadLine();
                //somehow need to edit the card in the game class
            }
            else if (player == "opponent")
            {
                string[] colors = {"blue", "red", "yellow", "green"};
                Random random = new Random();
                _color = colors[random.Next(colors.Length)];
            }
        }
        if (_number == compareNumber || _color == compareColor)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override string Display()
    {
        return base.Display();
    }
}