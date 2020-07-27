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
using System.Windows.Shapes;
using System.Xml;

namespace Program
{
    /// <summary>
    /// Interaction logic for NewTestWindow.xaml
    /// </summary>
    public partial class NewTestWindow : Window
    {
        public NewTestWindow()
        {
            InitializeComponent();            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput() == false)
            {
                return;
            }
            CreateTestWindow form = new CreateTestWindow(tbxTestName.Text, tbxPass.Text);
            form.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            form.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;            
        }

        private bool CheckInput()
        {
            if (tbxTestName.Text == "Название теста" || tbxTestName.Text == "")
            {
                MessageBox.Show("Вы не ввели название теста!");
                return false;
            }
            if (tbxPass.Text == "Введите пароль" || tbxPass.Text == "")
            {
                MessageBox.Show("Вы не ввели пароль!");
                return false;
            }
            return true;
        }

        private void tbxTestName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxTestName.Text == "Название теста")
            {
                tbxTestName.Text = "";
                tbxTestName.Foreground = Brushes.Black;
            }
        }

        private void tbxTestName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxTestName.Text == "")
            {
                tbxTestName.Text = "Название теста";
                tbxTestName.Foreground = Brushes.Gray;
            }
        }

        private void tbxPass_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxPass.Text == "Введите пароль")
            {
                tbxPass.Text = "";
                tbxPass.Foreground = Brushes.Black;
            }
        }

        private void tbxPass_LostFocus(object sender, RoutedEventArgs e)
        {
            if(tbxPass.Text == "")
            {
                tbxPass.Text = "Введите пароль";
                tbxPass.Foreground = Brushes.Gray;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LoadTestWindow form = new LoadTestWindow();
            form.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            form.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }
    }
}
