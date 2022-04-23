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

namespace Exam_23_04_22
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void showHideButton_Click(object sender, RoutedEventArgs e)
        {

            passwordTextBox.Text = passwordPasswordBox.Password;
            passwordTextBox.Visibility = Visibility.Visible;
            passwordPasswordBox.Visibility = Visibility.Hidden;

            Button buttonShowPass = sender as Button;
            buttonShowPass.Click -= new RoutedEventHandler(showHideButton_Click);
            buttonShowPass.Click += new RoutedEventHandler(showHideButton_Click_1);
        }
        private void showHideButton_Click_1(object sender, RoutedEventArgs e)
        {
            passwordPasswordBox.Password = passwordTextBox.Text;
            passwordPasswordBox.Visibility = Visibility.Visible;
            passwordTextBox.Visibility = Visibility.Hidden;

            Button buttonShowPass = sender as Button;
            buttonShowPass.Click -= new RoutedEventHandler(showHideButton_Click_1);
            buttonShowPass.Click += new RoutedEventHandler(showHideButton_Click);
        }

        private void authorizationButton_Click(object sender, RoutedEventArgs e)
        {
            classess.CheckLogPassClass oneCheckLogPassClass = new classess.CheckLogPassClass();
            oneCheckLogPassClass.CheckLogPass(this);
        }
    }
}
