using System;
using System.Collections.Generic;
public class Card
{
    private int Values;

    private string Suit;

    public static string[] Suits = {"Clubs", "Diamonds", "Hearts", "Spades"};

    public Card (string suit, int value)
    {
        this.suit = suit;
        this.value = value;
    }

    public int getValue(){
        return value;
    }

    public override string ToString(){
        return $"{suit} of {value}";
    }
}


