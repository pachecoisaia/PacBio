using System.Windows;
using System.Windows.Controls;
namespace CardGame
{
    public partial class LosingPage : Page
    {
        Frame main;
        public LosingPage(Frame main)
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