using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;


namespace SimpleApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in MainRoot.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            if(str == "AC")
            {
                textLable.Text = "";
            }
            else if (str == "C")
            {
                textLable.Text = textLable.Text.Remove(textLable.Text.Length - 1);
                /*textLable.Text = textLable.Text.Substring(textLable.Text.Length - 1);*/
            }
            else if(str == "=")
            {
                string all = textLable.Text;
                double result;
                result = RPN.Calculate(all);
                all = "";
                all += result;
                textLable.Text = "";
                textLable.Text = all;
                /*string value = new DataTable().Compute(textLable.Text, null).ToString();
                textLable.Text = value;*/
            }
            else { 
            textLable.Text += str;
            }


        }
    }
}
