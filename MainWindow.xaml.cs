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
            try
            {
                // Считываем значения x и y
                double x = double.Parse(TextBoxX.Text);
                double y = double.Parse(TextBoxY.Text);
                double fx;

                // Определяем выбранную функцию f(x)
                if (RadioButtonSinh.IsChecked == true)
                    fx = Math.Sinh(x); // sh(x)
                else if (RadioButtonSquare.IsChecked == true)
                    fx = Math.Pow(x, 2); // x^2
                else
                    fx = Math.Exp(x); // e^x

                // Вычисляем значение a в зависимости от условий
                double a;
                if (x * y > 0)
                {
                    a = Math.Pow(fx + y, 2) - Math.Sqrt(fx * y);
                }
                else if (x * y < 0)
                {
                    a = Math.Pow(fx + y, 2) + Math.Sqrt(Math.Abs(fx * y)); // Модуль под корнем
                }
                else // x * y == 0
                {
                    a = Math.Pow(fx + y, 2) + 1;
                }

                // Выводим результат
                TextBoxResult.Text = a.ToString("F2");
            }
            catch (Exception ex)
            {
                // Обработка ошибок ввода
                MessageBox.Show("Ошибка ввода данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем все поля и сбрасываем выбранную функцию
            TextBoxX.Clear();
            TextBoxY.Clear();
            TextBoxResult.Clear();
            RadioButtonSinh.IsChecked = true;
        }
    }
}