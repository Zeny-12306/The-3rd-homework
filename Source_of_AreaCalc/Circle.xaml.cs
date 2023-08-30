using System.Windows.Controls;
using System.Windows;
using System;
using Tools_For_Translation;

namespace AeraCalc
{
    public partial class Circle : Page
    {
        private const double PI = 3.1415926535;
        //private const double cmtoinch = 0.393701;
        private bool is_cm = true;
        public Circle()
        {
            InitializeComponent();
        }
        //private bool check_input(string input)
        //{
        //    if (input.Length == 0) return false;
        //    foreach (char ch in input)
        //        if ((ch < '0' || ch > '9') && ch != '.') { return false; }
        //    return true;
        //}
        //private string ToInch(string data)
        //{
        //    return (double.Parse(data) * cmtoinch).ToString("N3");
        //}
        //private string ToCm(string data)
        //{
        //    return (double.Parse(data) / cmtoinch).ToString("N3");
        //}

        private void Getanswer(object sender, RoutedEventArgs e)
        {
            
            
            if (Tool.check_input(radius.Text))
            {
                double r = double.Parse(radius.Text);
                double res = PI * r * r;
                area.Text = res.ToString("N3");
            }
            else area.Text ="Error! Input is invalid!";
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // 清空radius
            radius.Text = "";
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
            if (Tool.check_input(radius.Text))
                radius.Text = Tool.ToCm(radius.Text);
            else
                area.Text = "Error! Input is invalid!";
            if (Tool.check_input(area.Text))
                area.Text = Tool.ToCm(Tool.ToCm(area.Text));

            //if (is_inch && area.Text != "面积")
            //{
            //    double r = double.Parse(radius.Text) / cmtoinch;
            //    double res = PI * r * r;
            //    radius.Text = r.ToString();
            //    area.Text = res.ToString();
            //    label1.Content = "cm";
            //    label2.Content = "cm²";
            //    is_inch = false;
            //    is_cm = true;
            //}
            //else if (area.Text == "面积")
            //{
            //    label1.Content = "cm";
            //    label2.Content = "cm²";
            //}
        }
        private void ToInch_Click(object sender, RoutedEventArgs e)
        {
            if (!is_cm) return;
            is_cm = false;
            label1.Content = "inch";
            label2.Content = "inch²";
            if (Tool.check_input(radius.Text))
                radius.Text = Tool.ToInch(radius.Text);
            else area.Text = "Error! Input is invalid!";
            if(Tool.check_input(area.Text))
                area.Text = Tool.ToInch(Tool.ToInch(area.Text));
            //if (is_cm && area.Text != "面积")
            //{
            //    double r = double.Parse(radius.Text) * cmtoinch;
            //    double res = PI * r * r;
            //    radius.Text = r.ToString();
            //    area.Text = res.ToString();
            //    label1.Content = "inch";
            //    label2.Content = "inch²";
            //    is_inch = true;
            //    is_cm = false;
            //}
            //else if (area.Text == "面积")
            //{
            //    label1.Content = "inch";
            //    label2.Content = "inch²";
            //}
        }
    }
}
