using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Regex onlyNumbers = new Regex(@"^-?(\d+(,\d+)?)$");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WrongInput()
        {
            // Очищает поля, если возникает какая-либо ошибка
            textBall.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string t1 = text1.Text.Trim(), t2 = text2.Text.Trim(), t3 = text3.Text.Trim(), t4 = text4.Text.Trim();

            #region ошибки ввода
            if (text1.Text == "" && text2.Text == "" && text3.Text == "" && text4.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибочка", MessageBoxButton.OK, MessageBoxImage.Error);
                WrongInput();
            }
            else if (!onlyNumbers.IsMatch(text1.Text) && !onlyNumbers.IsMatch(text2.Text) && !onlyNumbers.IsMatch(text3.Text) && !onlyNumbers.IsMatch(text4.Text))
            {
                MessageBox.Show("Вы ввели недопустимые символы в полях", "Ошибочка");
                WrongInput();
            }
            else
            {
                int text1t = Convert.ToInt32(t1), text2t = Convert.ToInt32(t2), text3t = Convert.ToInt32(t3), text4t = Convert.ToInt32(t4);

                if (text1t > 10 || text1t < 0)
                {
                    MessageBox.Show("Вы ввели недопустимые значения в 1 задании", "Ошибочка", MessageBoxButton.OK, MessageBoxImage.Error);
                    WrongInput();
                }
                else if (text2t > 50 || text2t < 0)
                {
                    MessageBox.Show("Вы ввели недопустимые значения в 2 задании", "Ошибочка", MessageBoxButton.OK, MessageBoxImage.Error);
                    WrongInput();
                }
                else if (text3t > 30 || text3t < 0)
                {
                    MessageBox.Show("Вы ввели недопустимые значения в 3 задании", "Ошибочка", MessageBoxButton.OK, MessageBoxImage.Error);
                    WrongInput();
                }
                else if (text4t > 10 || text4t < 0)
                {
                    MessageBox.Show("Вы ввели недопустимые значения в 4 задании", "Ошибочка", MessageBoxButton.OK, MessageBoxImage.Error);
                    WrongInput();
                }
                else
                {
                    
                    int ball = 0;
                    ball = text1t + text2t + text3t + text4t;
                    if (ball >= 0 && ball <= 19)
                    {
                        textBall.Text = "<<2>> - неудовлетворительно";
                    }
                    if (ball >= 20 && ball <= 39)
                    {
                        textBall.Text = "<<3>> - удовлетворительно";
                    }
                    if (ball >= 40 && ball <= 69)
                    {
                        textBall.Text = "<<4>> - хорошо";
                    }
                    if (ball >= 70 && ball <= 100)
                    {
                        textBall.Text = "<<5>> - отлично";
                    }
                }

            #endregion


           

            }


        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            var exitConfirmation = MessageBox.Show("Вы действительно хотите выйти?  :(", "Пока-пока", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (exitConfirmation == MessageBoxResult.No) e.Cancel = true; // Отменяем закрытие окна
        }

    }



}


