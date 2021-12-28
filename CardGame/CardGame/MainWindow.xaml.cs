using System.Windows;
namespace CardGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new MainMenu(Main);
        }
    }
}