using CardGame.SupportClasses;
using System.Windows;
using System.Windows.Controls;

namespace CardGame
{
    /// <summary>
    /// Interaction logic for ShowHands.xaml
    /// </summary>
    public partial class ShowHands : Page
    {
        Frame main;
        BlackjackViewModel Game;
        public ShowHands(Frame main, BlackjackViewModel Game)
        {
            InitializeComponent();
            this.main = main;
            this.Game = Game;
            this.DataContext = Game;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            bool dealerWin = Game.Dealer.DidWin();
            bool dealerLost = Game.Dealer.DidLose();
            bool playerWin = Game.Player.DidWin();
            bool playerLost = Game.Player.DidLose();
            if (dealerWin & playerWin)
            {
                Game.Dealer.CalculateScore();
                Game.Player.CalculateScore();
                main.Content = new DrawPage(main);
            }
            else if (dealerWin | playerLost)
            {
                Game.Dealer.CalculateScore();
                Game.Player.CalculateScore();
                main.Content = new LosingPage(main);
            }
            else if (dealerLost | playerWin)
            {
                Game.Dealer.CalculateScore();
                Game.Player.CalculateScore();
                main.Content = new WinningPage(main);
            }
            else
            {
                int dealerScore = Game.Dealer.CalculateScore();
                int playerScore = Game.Player.CalculateScore();
                if (dealerScore == playerScore)
                {
                    main.Content = new DrawPage(main);
                }
                else if (dealerScore > playerScore)
                {
                    main.Content = new LosingPage(main);
                }
                else
                {
                    main.Content = new WinningPage(main);
                }
            }
        }
    }
}
