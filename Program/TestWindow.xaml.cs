using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        List<RadioButton> rdBtn = new List<RadioButton>();
        List<QuestionsAndAnswers> answers = new List<QuestionsAndAnswers>();
        int ans = 0;
        int lastQuest = 0;
        int correctAnswer = 0;
        int allAnswer = 0;
        public TestWindow(string testName) 
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            rdBtn.Add(Answer1);
            rdBtn.Add(Answer2);
            rdBtn.Add(Answer3);
            rdBtn.Add(Answer4);

            Load_Quest(testName);

            lblquestion.Content = answers[0].question;
            Answer1.Content = answers[0].answer1;
            Answer2.Content = answers[0].answer2;
            Answer3.Content = answers[0].answer3;
            Answer4.Content = answers[0].answer4;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (ans == 0)
            {
                MessageBox.Show("Вы не выбрали ответ!");
                return;
            }
            if ($"{rdBtn[ans - 1].Content}" == answers[lastQuest].trueAnswer)
            {
                correctAnswer++;
            }

            rdBtn[ans - 1].IsChecked = false;
            lastQuest++;
            allAnswer++;
            ans = 0;

            if (lastQuest == answers.Count)
            {
                showResults(correctAnswer, allAnswer);
                return;
            }
            ChangedQuest();
        }

        private void Answer_Checked(object sender, RoutedEventArgs e)
        {
            ans = 0;
            foreach (var item in rdBtn)
            {
                if (item.IsChecked == true)
                {
                    ans++;
                    break;
                }
                ans++;
            }            
        }

        public void ChangedQuest()
        {
            lblquestion.Content = answers[lastQuest].question;
            Answer1.Content = answers[lastQuest].answer1;
            Answer2.Content = answers[lastQuest].answer2;
            Answer3.Content = answers[lastQuest].answer3;
            Answer4.Content = answers[lastQuest].answer4;
        }

        public void showResults(int correctAnswer, int allAnswer)
        {
            WindowResults form = new WindowResults();
            form.lblResults.Content = $"{correctAnswer} из {allAnswer} вопросов";
            form.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Visibility = Visibility.Collapsed;
            form.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Load_Quest(string testName)
        {
            int c = 0;
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
                            QuestionsAndAnswers question = new QuestionsAndAnswers();
                            if (xnode.Attributes.Count > 0)
                            {
                                XmlNode attr1 = childNode.Attributes.GetNamedItem("name");
                                if (attr1 != null)
                                {
                                    question.question = attr1.Value;
                                    foreach (XmlNode childChildNode in childNode.ChildNodes)
                                    {
                                        if (childChildNode.Name == "answer1")
                                        {
                                            question.answer1 = childChildNode.InnerText;
                                        }
                                        if (childChildNode.Name == "answer2")
                                        {
                                            question.answer2 = childChildNode.InnerText;
                                        }
                                        if (childChildNode.Name == "answer3")
                                        {
                                            question.answer3 = childChildNode.InnerText;
                                        }
                                        if (childChildNode.Name == "answer4")
                                        {
                                            question.answer4 = childChildNode.InnerText;
                                        }
                                        if (childChildNode.Name == "correctAnswer")
                                        {
                                            question.trueAnswer = childChildNode.InnerText;
                                        }
                                        c++;
                                        if (c == 5)
                                        {
                                            c = 0;
                                            answers.Add(question);
                                        }
                                    }

                                }

                            }

                        }
                        break;
                    }
                }

                

            }

        }

    }
}
