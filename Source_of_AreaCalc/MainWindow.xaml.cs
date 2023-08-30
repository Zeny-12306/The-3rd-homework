using System.Windows;

namespace AeraCalc
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.NavigationService.Navigate(new MainPage());
        }
    }
}
