public class GameController
{
    private Deck deck;
    private Table table;
    private MoveValidator validator;
    private GameState state;

    public GameState State => state;
    public Deck Deck => deck;
    public Table Table => table;

    public GameController(Deck deck = null, Table table = null, MoveValidator validator = null)
    {
        this.deck = deck ?? new Deck();
        this.table = table ?? new Table();
        this.validator = validator ?? new MoveValidator();
        this.state = GameState.NotStarted;
    }

    public void StartGame()
    {
        deck.Shuffle();
        state = GameState.Running;
        RefillTableToNine();
    }

    public void RefillTableToNine()
    {
        while (table.Count < 9 && !deck.IsEmpty())
        {
            table.AddCard(deck.DealCard());
        }
    }

    public bool SubmitSelection(IReadOnlyList<int> indices, out string message)
    {
        var selectedCards = table.GetCardsByIndices(indices);
        
        if (validator.IsValidSelection(selectedCards))
        {
            table.RemoveCards(selectedCards);
            RefillTableToNine();
            CheckEndState();
            message = "Move is valid";
            return true;
        }

        message = "The selection was invalid";
        return false;
    }

    public void CheckEndState()
    {
        if (CheckWin())
        {
            state = GameState.Won;
        }
        else if (CheckLose())
        {
            state = GameState.Lost;
        }
    }

    public bool CheckWin()
    {
        return deck.IsEmpty() && table.IsEmpty();
    }

    public bool CheckLose()
    {
        return !validator.HasLegalMoves(table.Cards);
    }
}