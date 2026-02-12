// Elevens game
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



public class GameController
{
    private bool gameState;
    private Deck totalDeck;
    private Table currentcards;
    

    public GameController()
    {
        gameState = true;
        totalDeck.Deck();
        for(int i = 0; i < 9; i++)
        {
            currentcards.AddCards(totalDeck.Deal());
        }

        
    }






}


