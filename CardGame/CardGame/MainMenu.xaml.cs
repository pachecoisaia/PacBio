using System.Windows;
using System.Windows.Controls;
namespace CardGame
{
    public partial class MainMenu : Page
    {
        Frame main;
        public MainMenu(Frame main)
        {
            InitializeComponent();
            this.main = main;
        }
        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new Play(main);
        }
        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}