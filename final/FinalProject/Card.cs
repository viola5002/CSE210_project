using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

public abstract class Card
{
    private string _card;
    protected string _color;
    protected string _number;

    public Card(string card)
    {
        _card = card;
        ParseCard();
    }
    public string GetCard()
    {
        return _card;
    }
    public abstract bool PlayCard(string compareCard);
    public virtual void Display()
    {
        Console.WriteLine(_card);
    }
    private void ParseCard()
    {
        string[] parts = _card.Split(" ");
        _color = parts[0];
        _number = parts[1];
    }
}