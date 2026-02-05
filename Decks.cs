using System;

public class Deck
{
    private List<Card> cards = new List<Card>();

    public Deck()
    {
        for (int i = 0; i <cards.Suits.Length; i++)
        {
            for(int j=0; j<cards.Values.Length; j++)
            {
                cards.Add(new Card(Card.Suits[i],Card.Values[j] ));
            }
        }
    }
}
