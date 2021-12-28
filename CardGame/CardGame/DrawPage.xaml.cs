using System.Windows;
using System.Windows.Controls;
namespace CardGame
{
    public partial class DrawPage : Page
    {
        Frame main;
        public DrawPage(Frame main)
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