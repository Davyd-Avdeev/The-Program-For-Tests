using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for LoadTestWindow.xaml
    /// </summary>
    public partial class LoadTestWindow : Window
    {
        List<string> testNames = new List<string>();
        bool check = false;
        public LoadTestWindow()
        {
            InitializeComponent();
            Load_Tests();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTestName.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали тест");
            }
            else
            {
                TestWindow form = new TestWindow(testNames[cbxTestName.SelectedIndex]);
                form.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                form.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Collapsed;
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTestName.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали тест");
            }
            PasswordInputWindow passWindow = new PasswordInputWindow(testNames[cbxTestName.SelectedIndex]);
            passWindow.Owner = this;
            passWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            passWindow.ShowDialog();
        }

        private void btnNewTest_Click(object sender, RoutedEventArgs e)
        {
            NewTestWindow newTestWindow = new NewTestWindow();
            newTestWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            newTestWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTestName.SelectedIndex < 0)
            {
                MessageBox.Show("Вы не выбрали тест");
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"..\..\Test\Questions.xml");
                XmlElement xRoot = doc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("name");
                        if (attr.InnerText == testNames[cbxTestName.SelectedIndex])
                        {
                            xnode.ParentNode.RemoveChild(xnode);
                        }
                    }
                }
                doc.Save(@"..\..\Test\Questions.xml");
                Load_Tests();
            }
            MessageBox.Show("Тест был успешно удален");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in App.Current.Windows)
            {
                if (window is MainWindow)
                {
                    window.Visibility = Visibility.Visible;
                    this.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Load_Tests()
        {
            testNames.Clear();
            cbxTestName.Items.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Test\Questions.xml");
            XmlElement xRoot = doc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    cbxTestName.Items.Add(attr.InnerText);
                    testNames.Add(attr.InnerText);
                }
            }
        }
    }
}
