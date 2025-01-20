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

namespace PiT_Practice_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Проверка полей на заполненность
            if (string.IsNullOrWhiteSpace(TextBoxX.Text) || string.IsNullOrWhiteSpace(TextBoxY.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля ввода.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                double x = double.Parse(TextBoxX.Text);
                double y = double.Parse(TextBoxY.Text);
                double fx;

                if (RadioButtonSinh.IsChecked == true)
                    fx = Math.Sinh(x); // sh(x)
                else if (RadioButtonSquare.IsChecked == true)
                    fx = Math.Pow(x, 2); // x^2
                else
                    fx = Math.Exp(x); // e^x

                double a;
                if (x * y > 0)
                {
                    a = Math.Pow(fx + y, 2) - Math.Sqrt(fx * y);
                }
                else if (x * y < 0)
                {
                    a = Math.Pow(fx + y, 2) + Math.Sqrt(Math.Abs(fx * y));
                }
                else
                {
                    a = Math.Pow(fx + y, 2) + 1;
                }

                TextBoxResult.Text = a.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите числовые значения для x и y.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBoxX.Clear();
            TextBoxY.Clear();
            TextBoxResult.Clear();
            RadioButtonSinh.IsChecked = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}