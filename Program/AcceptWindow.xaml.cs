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
    /// Interaction logic for AcceptWindow.xaml
    /// </summary>
    public partial class AcceptWindow : Window
    {
        string testName = "";
        public AcceptWindow(string test)
        {
            InitializeComponent();
            testName = test;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
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
                        xnode.ParentNode.RemoveChild(xnode);
                    }
                }
            }
            doc.Save(@"..\..\Test\Questions.xml");

            foreach (Window window in App.Current.Windows)
            {
                if (window is LoadTestWindow)
                {
                    window.Visibility = Visibility.Visible;
                    this.Close();
                }
            }
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
