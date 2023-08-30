using System.Windows.Controls;
using System.Windows;

namespace AeraCalc
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GoToSquare_Click(object sender, RoutedEventArgs e)
        {
            // 创建新的主页面实例并切换到它
            App.Current.MainWindow.Content = new Square();
            App.Current.MainWindow.Show();
        }
        private void GoToRect_Click(object sender, RoutedEventArgs e)
        {
            // 创建新的主页面实例并切换到它
            App.Current.MainWindow.Content = new Rect();
            App.Current.MainWindow.Show();
        }
        private void GoToCircle_Click(object sender, RoutedEventArgs e)
        {
            // 创建新的主页面实例并切换到它
            App.Current.MainWindow.Content = new Circle();
            App.Current.MainWindow.Show();
        }
        private void GoToTrig_Click(object sender, RoutedEventArgs e)
        {
            // 创建新的主页面实例并切换到它
            App.Current.MainWindow.Content = new Trig();
            App.Current.MainWindow.Show();
        }
    }
}
