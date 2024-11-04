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

namespace Figury
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SquareRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RectangleBTextBox.IsEnabled = false;
            RectangleShape.Height = 100;
        }

        private void RectangleRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RectangleBTextBox.IsEnabled = true;
            RectangleShape.Height = 150;
        }

        private void RectangleCircuitButton_Click(object sender, RoutedEventArgs e)
        {
            double a = Parse(RectangleATextBox.Text);
            if (a == -1)
                return;

            if ((bool)SquareRadioButton.IsChecked)
                RectangleCircuitTextBox.Text = (a * 4).ToString();
            else
            {
                double b = Parse(RectangleBTextBox.Text);
                if (b == -1)
                    return;

                RectangleCircuitTextBox.Text = (a * 2 + b * 2).ToString();
            }
        }

        private void RectangleAreaButton_Click(object sender, RoutedEventArgs e)
        {
            double a = Parse(RectangleATextBox.Text);
            if (a == -1)
                return;

            if ((bool)SquareRadioButton.IsChecked)
                RectangleAreaTextBox.Text = (a * a).ToString();
            else
            {
                double b = Parse(RectangleBTextBox.Text);
                if (b == -1)
                    return;

                RectangleAreaTextBox.Text = (b * a).ToString();
            }
        }

        private void TriangleCircuitButton_Click(object sender, RoutedEventArgs e)
        {
            double a = Parse(TriangleATextBox.Text);
            if (a == -1)
                return;

            TriangleCircuitTextBox.Text = (a * 3).ToString();
        }

        private void TriangleAreaButton_Click(object sender, RoutedEventArgs e)
        {
            double a = Parse(TriangleATextBox.Text);
            if (a == -1)
                return;

            TriangleAreaTextBox.Text = Math.Round(a * a * Math.Sqrt(3) / 4, 3).ToString();
        }

        private void CircleCircuitButton_Click(object sender, RoutedEventArgs e)
        {
            double r = Parse(CircleRTextBox.Text);
            if (r == -1)
                return;

            CircleCircuitTextBox.Text = Math.Round(2 * Math.PI * r, 3).ToString();
        }

        private void CircleAreaButton_Click(object sender, RoutedEventArgs e)
        {
            double r = Parse(CircleRTextBox.Text);
            if (r == -1)
                return;

            CircleAreaTextBox.Text = Math.Round(Math.PI * (r * r), 3).ToString();
        }

        private double Parse(string text)
        {
            if(text == "")
            {
                MessageBox.Show("Nie podano boku");
                return -1;
            }

            double result;

            if(double.TryParse(text, out result))
            {
                if(result <= 0)
                {
                    MessageBox.Show("Bok musi być liczbą dodatnią");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("Bok nie jest liczbą");
                return -1;
            }

            return result;
        }
    }
}
