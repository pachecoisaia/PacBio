using CardGame.SupportClasses;
using System.Windows;
using System.Windows.Controls;
namespace CardGame
{
    public partial class ShowCards : Page
    {
        Frame main;
        BlackjackViewModel Game;
        public ShowCards(Frame main, BlackjackViewModel Game)
        {
            InitializeComponent();
            this.main = main;
            this.Game = Game;
            this.DataContext = Game;
            Game.Dealer.ShowHiddenCards();

        }
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {

            int action = Game.Dealer.DecideAction();

            if (action == 1)
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
            
            else if (action == 0){
                main.Content = new ShowHands(main, Game);
            }
        }
    }
}
