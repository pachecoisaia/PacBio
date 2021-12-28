namespace CardGame.SupportClasses
{
    /// <summary> Enumerations for suits of cards </summary>
    public enum Suits
    {
        Spade,
        Club,
        Heart,
        Diamond
    }
    /// <summary> Enumerations for faces of cards </summary>
    public enum Faces{
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
    /// <summary> Enumerations for actions of blackjack players </summary>
    public enum Actions
    {
        None,
        Hit,
        Stand
    }
    /// <summary> Enumerations for results of the game </summary>
    public enum GameResults
    {
        None,
        PlayerWin,
        PlayerBust,
        DealerWin,
        DealerBust
    }
}
