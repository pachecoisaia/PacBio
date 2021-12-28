using CardGame.SupportClasses;
using System.Windows;
using System.Windows.Controls;
namespace CardGame
{
    public partial class Play : Page
    {
        Frame main;
        public Play(Frame main)
        {
            InitializeComponent();
            this.main = main;
            Game = new BlackjackViewModel();
            this.DataContext = Game;

        }
        public BlackjackViewModel Game { get; }
        private void BtnHit_Click(object sender, RoutedEventArgs e)
        {
            Game.Player.Hit();
            bool won = Game.Player.DidWin();
            bool busted = Game.Player.DidLose();
            if (won)
            {
                main.Content = new WinningPage(main);
            }
            if (busted)
            {
                main.Content = new LosingPage(main);
            }
        }

        private void BtnStand_Click(object sender, RoutedEventArgs e)
        {
            Game.Player.Stand();
            main.Content = new ShowCards(main, Game);
        }
    }
}