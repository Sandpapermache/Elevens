// Elevens game
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



public class GameController
{
    private Deck _deck;
    private Table _table;
    private MoveValidator _validator;
    private GameState _state;

    public GameState State => _state;
    public Deck Deck => _deck;
    public Table Table => _table;

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


