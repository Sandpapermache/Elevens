using System.Collections.Generic;
using System.Linq;

public class MoveValidator
{
    public bool IsValidSelection(IReadOnlyList<Card> selected)
    {
        if (selected.Count == 2)
            return IsValidPair(selected[0], selected[1]);
        
        if (selected.Count == 3)
            return IsValidTriple(selected);
            
        return false;
    }

    public bool HasLegalMoves(IReadOnlyList<Card> tableCards)
    {
        for (int i = 0; i < tableCards.Count; i++)
        {
            for (int j = i + 1; j < tableCards.Count; j++)
            {
                if (IsValidPair(tableCards[i], tableCards[j])) return true;
            }
        }

        var values = tableCards.Select(c => c.getValue()).ToList();
        return values.Contains(11) && values.Contains(12) && values.Contains(13);
    }

    private bool IsValidPair(Card a, Card b)
    {
        return (a.getValue() + b.getValue() == 11);
    }

    private bool IsValidTriple(IReadOnlyList<Card> three)
    {
        if (three.Count != 3) return false;
        var values = three.Select(c => c.getValue()).ToList();
        return values.Contains(11) && values.Contains(12) && values.Contains(13);
    }
}