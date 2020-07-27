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
    /// Interaction logic for PasswordInputWindow.xaml
    /// </summary>
    public partial class PasswordInputWindow : Window
    {
        string pass = "";
        string nameTest = "";
        public PasswordInputWindow(string testName)
        {
            InitializeComponent();
            nameTest = testName;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Test\Questions.xml");
            XmlElement xRoot = doc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr.InnerText == testName)
                    {
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            if (childNode.Name == "password")
                            {
                                pass = childNode.InnerText;
                                break;
                            } 
                        }                    
                    }
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (tbxPass.Text == pass)
            {
                EditTestWindow form = new EditTestWindow(nameTest);
                form.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                form.Show();
                this.Owner.Visibility = Visibility.Collapsed;
                this.Close();                
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный пароль");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in App.Current.Windows)
            {
                if (window is LoadTestWindow)
                {
                    window.Visibility = Visibility.Visible;
                    this.Visibility = Visibility.Collapsed;
                }
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
            if (tbxPass.Text == "")
            {
                tbxPass.Text = "Введите пароль";
                tbxPass.Foreground = Brushes.Gray;
            }
        }
    }
}
