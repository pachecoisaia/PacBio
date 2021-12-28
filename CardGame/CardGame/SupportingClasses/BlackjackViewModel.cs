using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace CardGame.SupportClasses
{
    public class BlackjackViewModel : INotifyPropertyChanged
    {
        private readonly Deck deck;
        private Player player;
        private Dealer dealer;
        public BlackjackViewModel()
        {
            deck = new Deck();
            dealer = new Dealer(ref deck);
            player = new Player(ref deck);


        }
        public Player Player { get { return player; } set { player = value; OnPropertyChanged("Player"); } }
        public Dealer Dealer { get { return dealer; } set { dealer = value; OnPropertyChanged("Dealer"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}