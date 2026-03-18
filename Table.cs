using System.Collections.Generic;
using System.Linq;

public class Table
{
    private List<Card> visibleCards = new List<Card>();
    private readonly int MaxCards = 9;

    public IReadOnlyList<Card> Cards => visibleCards.AsReadOnly();

    public int Count() => visibleCards.Count;

    public bool IsEmpty() => visibleCards.Count == 0;

    public void AddCard(Card c)
    {
        if (visibleCards.Count < MaxCards)
        {
            visibleCards.Add(c);
        }
    }

    public Card GetCardAt(int index) => visibleCards[index];

    public List<Card> GetCardsByIndices(IEnumerable<int> indices)
    {
        return indices.Select(i => visibleCards[i]).ToList();
    }

    public void RemoveCards(IEnumerable<Card> cardsToRemove)
    {
        foreach (var card in cardsToRemove)
        {
            visibleCards.Remove(card);
        }
    }
}