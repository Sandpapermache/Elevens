using UnityEngine; 
using System.Collections.Generic;
using System.Linq;

[ExecuteInEditMode]
public class CardSorter : MonoBehaviour
{
    public bool runSort = false;
    
    // RENAMED: This must match the exact variable name (UnfilteredSortes) shown in your Unity Inspector
    public List<Sprite> UnfilteredSortes;

    void Update()
    {
        if (runSort)
        {
            runSort = false;
            SortCards(); // This method is now used by the Update loop
        }
    }

    // The method that actually sorts the cards. It is now called by the Update loop, so the warning will disappear.
    void SortCards()
    {
        var manager = GetComponent<ElevensManager>();
        if (manager == null) return;

        // Validating against the card-creation order in GameController
        string[] suits = { "club", "diamond", "heart", "spade" };
        string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        
        List<Sprite> sorted = new List<Sprite>();

        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                // This builds the name 'Aclub', '10heart', 'Qspade', etc.
                string targetName = rank + suit;
                
                // We use StringComparison.OrdinalIgnoreCase so 'Aclub' matches 'aclub'
                var match = UnfilteredSortes.FirstOrDefault(s => 
                    s.name.Equals(targetName, System.StringComparison.OrdinalIgnoreCase));
                
                if (match != null)
                {
                    sorted.Add(match);
                }
                else
                {
                    // This creates a clear error in the console if a specific card file is missing or named incorrectly.
                    Debug.LogError($"[CardSorter] Missing card: {targetName}. Please check this file's name in the Project window!");
                }
            }
        }

        manager.cardImages = sorted.ToArray();
        Debug.Log($"[CardSorter] Success! {sorted.Count} cards assigned in order.");
    }
}