using System.Windows;
using System.Windows.Controls;
namespace CardGame
{
    public partial class WinningPage : Page
    {
        Frame main;
        public WinningPage(Frame main)
        {
            InitializeComponent();
            this.main = main;
        }
        private void BtnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new MainMenu(main);
        }
    }
}