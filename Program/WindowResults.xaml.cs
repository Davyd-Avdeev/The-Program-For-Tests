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

namespace Program
{
    /// <summary>
    /// Interaction logic for WindowResults.xaml
    /// </summary>
    public partial class WindowResults : Window
    {
        public WindowResults()
        {
            InitializeComponent();
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
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
    }
}
