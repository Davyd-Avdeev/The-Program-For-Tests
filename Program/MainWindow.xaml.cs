using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<QuestionsAndAnswers> answers = new List<QuestionsAndAnswers>();
        bool check = false;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {            
            if (check == true)
            {
                foreach (Window window in App.Current.Windows)
                {
                    if (window is LoadTestWindow)
                    {                        
                        window.Visibility = Visibility.Visible;                      
                    }
                }
            }            
            else
            {
                LoadTestWindow form = new LoadTestWindow();
                form.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                form.Visibility = Visibility.Visible;
                check = true;

            }
            this.Visibility = Visibility.Collapsed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnImpor(object sender, RoutedEventArgs e)
        {

        }
    }
}
