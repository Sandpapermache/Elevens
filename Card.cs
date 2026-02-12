using System;
using System.Collections.Generic;
public class Card
{
    private string Suit;
    private int Values;

    

    public static string[] Suits = {"Clubs", "Diamonds", "Hearts", "Spades"};

    public Card (string suit, int value)
    {
        this.Suit = suit;
        this.Values = value;
    }

    public int getValue(){
        return Values;
    }

    public override string ToString(){
        return $"{Suit} of {Values}";
    }
}


