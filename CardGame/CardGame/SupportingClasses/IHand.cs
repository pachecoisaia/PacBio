using System.Collections.ObjectModel;
namespace CardGame.SupportClasses
{
    interface IHand
    {
        bool Busted { get; set; }
        int Total { get; set; }
        ObservableCollection<Card> RevealedCards { get; set; }
        bool IsBusted(int total);
    }
}