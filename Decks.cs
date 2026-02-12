using System;

public class Deck
{
    private List<Card> Deckcards = new List<Card>();

    public Deck()
    {
        for (int i = 0; i <cards.Suits.Length; i++)
        {
            for(int j=1; j<14; j++)
            {
                Deckcards.Add(new Card(Card.Suit[i],Card.Values[j] ));
            }
        }
    }

    public void Shuffle()
{
    int n = cards.Count;
    while (n > 1)
    {
        n--;
        int k = Random.Shared.Next(n + 1);
        (cards[k], cards[n]) = (cards[n], cards[k]);
    }
}


    public Card Deal()
    {
        Card temp = Deckcards[0];
        Deckcards.Remove(0);
        return temp;
        
    }


}
