using System;

public class Deck
{
    private List<Card> Deckcards = new List<Card>();

    public Deck()
    {
        for (int i = 0; i < Card.Suits.Length; i++)
        {
            for(int j = 1; j < 14; j++)
            {
                Deckcards.Add(new Card(Card.Suits[i],j ));
            }
        }
    }

    public bool IsEmpty() => Deckcards.Count == 0;

    public void Shuffle()  { //Shuffle algorithm
    int n = Deckcards.Count;
    while (n > 1)
    {
        n--;
        int k = Random.Shared.Next(n + 1);
        (Deckcards[k], Deckcards[n]) = (Deckcards[n], Deckcards[k]);
    }
}


    public Card Deal()
    {
        Card temp = Deckcards[0];
        Deckcards.RemoveAt(0);
        return temp;
        
    }


}
