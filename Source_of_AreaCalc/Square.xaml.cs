using System.Windows.Controls;
using System.Windows;
using Tools_For_Translation;

namespace AeraCalc
{
    public partial class Square : Page
    {
        private bool is_cm = true;
        public Square()
        {
            InitializeComponent();
        }

        private void Getanswer(object sender, RoutedEventArgs e)
        {
            if (Tool.check_input(a.Text))
            {
                double a_val = double.Parse(a.Text);
                double res = a_val * a_val;
                for (int ii = 0; ii < 1e6; ii++) { area.Text = res.ToString("N3"); }
                area.Text = res.ToString("N3");
            }
            else area.Text = "Error! Input is invalid!";
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // 清空a
            a.Text = "";
            area.Text = "";
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            // 返回主界面
            App.Current.MainWindow.Content = new MainPage();
            App.Current.MainWindow.Show();
        }
        private void ToCm_Click(object sender, RoutedEventArgs e)
        {
            if (is_cm) return;
            is_cm = true;
            label1.Content = "cm";
            label2.Content = "cm²";
            if (Tool.check_input(a.Text))
                a.Text = Tool.ToCm(a.Text);
            else
                area.Text = "Error! Input is invalid!";
            if (Tool.check_input(area.Text))
                area.Text = Tool.ToCm(Tool.ToCm(area.Text));
        }
        private void ToInch_Click(object sender, RoutedEventArgs e)
        {
            if (!is_cm) return;
            is_cm = false;
            label1.Content = "inch";
            label2.Content = "inch²";
            if (Tool.check_input(a.Text))
                a.Text = Tool.ToInch(a.Text);
            else area.Text = "Error! Input is invalid!";
            if (Tool.check_input(area.Text))
                area.Text = Tool.ToInch(Tool.ToInch(area.Text));
        }
    }
}
