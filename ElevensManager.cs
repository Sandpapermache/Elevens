using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class ElevensManager : MonoBehaviour 
{
    [Header("UI References")]
    public Sprite[] cardImages; 
    public Button[] gridButtons; 
    public TextMeshProUGUI statusText;

    [Header("Game Logic")]
    private GameController controller;
    private List<int> selectedSlots = new List<int>();

    void Start() {
        controller = new GameController();
        controller.StartGame(); 
        SetupButtons();
        UpdateView();
    }

    void SetupButtons() {
        for (int i = 0; i < gridButtons.Length; i++) {
            int slotIndex = i; 
            gridButtons[i].onClick.RemoveAllListeners();
            gridButtons[i].onClick.AddListener(() => OnCardClicked(slotIndex));
        }
    }

    public void OnCardClicked(int slotIndex) {
        if (selectedSlots.Contains(slotIndex)) {
            selectedSlots.Remove(slotIndex);
            gridButtons[slotIndex].image.color = Color.white;
            return;
        }

        if (selectedSlots.Count >= 3) {
            ResetVisualSelection();
        }

        selectedSlots.Add(slotIndex);
        gridButtons[slotIndex].image.color = Color.yellow; 

        // Attempt move if we have enough cards for a pair or triple
        if (selectedSlots.Count == 2 || selectedSlots.Count == 3) {
            CheckForMatch();
        }
    }

    void CheckForMatch() {
        string message;
        if (controller.SubmitSelection(selectedSlots, out message)) {
            selectedSlots.Clear();
            UpdateView();
        } 
        
        if (statusText != null) statusText.text = message;

        // Reset if 3 cards were picked and failed, or if it's a valid move
        if (selectedSlots.Count >= 3 || !selectedSlots.Any()) {
            ResetVisualSelection();
        }
    }

    void UpdateView() {
        var tableCards = controller.Table.Cards; 
        for (int i = 0; i < gridButtons.Length; i++) {
            if (i < tableCards.Count) {
                gridButtons[i].gameObject.SetActive(true);
                gridButtons[i].image.sprite = GetSpriteForCard(tableCards[i]);
                gridButtons[i].image.color = Color.white;
            } else {
                gridButtons[i].gameObject.SetActive(false); 
            }
        }

        if (controller.State == GameState.Won) statusText.text = "You Win!";
        else if (controller.State == GameState.Lost) statusText.text = "No more moves!";
    }

    Sprite GetSpriteForCard(Card card) {
        int suitIndex = 0;
        string cardString = card.ToString(); 
        
        if (cardString.Contains("Clubs")) suitIndex = 0;
        else if (cardString.Contains("Diamonds")) suitIndex = 1;
        else if (cardString.Contains("Hearts")) suitIndex = 2;
        else if (cardString.Contains("Spades")) suitIndex = 3;

        int rankIndex = card.getValue() - 1; 
        int finalIndex = (suitIndex * 13) + rankIndex;

        return (finalIndex >= 0 && finalIndex < cardImages.Length) ? cardImages[finalIndex] : null;
    }

    void ResetVisualSelection() {
        foreach (int slot in selectedSlots) {
            gridButtons[slot].image.color = Color.white;
        }
        selectedSlots.Clear();
    }
}