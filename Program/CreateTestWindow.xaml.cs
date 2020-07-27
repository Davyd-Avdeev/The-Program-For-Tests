using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
    /// Interaction logic for CreateTestWindow.xaml
    /// </summary>
    public partial class CreateTestWindow : Window
    {
        List<RadioButton> rdBtn = new List<RadioButton>();
        int ans = 0;

        string pass = "";
        string test = "";
        public CreateTestWindow(string testName, string password)
        {
            InitializeComponent();
            pass = password;
            test = testName;

            rdBtn.Add(Answer1);
            rdBtn.Add(Answer2);
            rdBtn.Add(Answer3);
            rdBtn.Add(Answer4);

            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Test\Questions.xml");
            XmlElement xRoot = doc.DocumentElement;
            XmlElement testElem = doc.CreateElement("test"); //Узел Тест
            XmlAttribute nameAttr = doc.CreateAttribute("name"); // Атрибут - название теста
            XmlText nameText = doc.CreateTextNode(test); // Текст теста
            XmlElement passElem = doc.CreateElement("password"); // Пароль от теста
            XmlText passText = doc.CreateTextNode(pass); // Тест пароля

            nameAttr.AppendChild(nameText); //Присваеваем текст к атррибуту
            passElem.AppendChild(passText); //Присваеваем текст к паролю

            testElem.Attributes.Append(nameAttr); //Присваеваем атрибут узлу
            testElem.AppendChild(passElem);  //Присваеваем пароль узлу
            xRoot.AppendChild(testElem);  //Присваеваем узел к файлу
            doc.Save(@"..\..\Test\Questions.xml");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput() == false)
            {
                return;
            }
            CreateQuestion();
        }

        private void CreateQuestion()
        {
           
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Test\Questions.xml");
            XmlElement xRoot = doc.DocumentElement;
            // создаем атрибут name для question
            XmlAttribute nameAttr2 = doc.CreateAttribute("name");
            // создаем элемент question
            XmlElement question = doc.CreateElement("question");
            // Answers
            XmlElement answer1 = doc.CreateElement("answer1");
            XmlElement answer2 = doc.CreateElement("answer2");
            XmlElement answer3 = doc.CreateElement("answer3");
            XmlElement answer4 = doc.CreateElement("answer4");
            XmlElement correctAnswer = doc.CreateElement("correctAnswer");
            // создаем текстовые значения для элементов и атрибута
            XmlText nameText2 = doc.CreateTextNode(tbxQuestion.Text);
            XmlText answer1Text = doc.CreateTextNode(tbxAnswer1.Text);
            XmlText answer2Text = doc.CreateTextNode(tbxAnswer2.Text);
            XmlText answer3Text = doc.CreateTextNode(tbxAnswer3.Text);
            XmlText answer4Text = doc.CreateTextNode(tbxAnswer4.Text);
            XmlText CorrectAnswer1Text = doc.CreateTextNode(tbxAnswer1.Text);
            XmlText CorrectAnswer2Text = doc.CreateTextNode(tbxAnswer2.Text);
            XmlText CorrectAnswer3Text = doc.CreateTextNode(tbxAnswer3.Text);
            XmlText CorrectAnswer4Text = doc.CreateTextNode(tbxAnswer4.Text);

            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr.InnerText == test)
                    {
                        nameAttr2.AppendChild(nameText2); // name - question
                        question.Attributes.Append(nameAttr2); // Attribut name - question?
                        answer1.AppendChild(answer1Text); // Text - answer
                        answer2.AppendChild(answer2Text); // Text - answer
                        answer3.AppendChild(answer3Text); // Text - answer
                        answer4.AppendChild(answer4Text); // Text - answer
                        if (ans == 1)
                        {
                            correctAnswer.AppendChild(CorrectAnswer1Text);// Text - CorrectAnswer
                        }
                        else if (ans == 2)
                        {
                            correctAnswer.AppendChild(CorrectAnswer2Text);// Text - CorrectAnswer
                        }
                        else if (ans == 3)
                        {
                            correctAnswer.AppendChild(CorrectAnswer3Text);// Text - CorrectAnswer
                        }
                        else if (ans == 4)
                        {
                            correctAnswer.AppendChild(CorrectAnswer4Text);// Text - CorrectAnswer
                        }

                        // Добавляем в узел question - Answers
                        question.AppendChild(answer1); // answer
                        question.AppendChild(answer2); // answer
                        question.AppendChild(answer3); // answer
                        question.AppendChild(answer4); // answer
                        question.AppendChild(correctAnswer);  // CorrectAnswer
                        xnode.AppendChild(question);
                    }
                }
            }
            doc.Save(@"..\..\Test\Questions.xml");

            tbxQuestion.Text = "Введите вопрос";
            tbxQuestion.Foreground = Brushes.Gray;
            tbxAnswer1.Text = "Ответ";
            tbxAnswer1.Foreground = Brushes.Gray;
            tbxAnswer2.Text = "Ответ";
            tbxAnswer2.Foreground = Brushes.Gray;
            tbxAnswer3.Text = "Ответ";
            tbxAnswer3.Foreground = Brushes.Gray;
            tbxAnswer4.Text = "Ответ";
            tbxAnswer4.Foreground = Brushes.Gray;
            rdBtn[ans - 1].IsChecked = false;
            ans = 0;
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput() == false)
            {
                return;
            }
            CreateQuestion();
            MessageBox.Show("Тест был успешно создан");
            LoadTestWindow form = new LoadTestWindow();
            form.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            form.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
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

        private bool CheckInput()
        {
            if (tbxQuestion.Text == "Введите вопрос")
            {
                MessageBox.Show("Вы не ввели вопрос");
                return false;
            }
            if (tbxAnswer1.Text == "Ответ" || tbxAnswer2.Text == "Ответ" || tbxAnswer3.Text == "Ответ" || tbxAnswer4.Text == "Ответ")
            {

                MessageBox.Show("Вы не ввели ответы");
                return false;
            }
            if (ans < 1 || ans > 4)
            {
                MessageBox.Show("Вы не выбрали правильный ответ!");
                return false;
            }
            return true;
        }

        private void tbxQuestion_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxQuestion.Text == "Введите вопрос")
            {
                tbxQuestion.Text = "";
                tbxQuestion.Foreground = Brushes.Black;
            }
            
        }

        private void tbxQuestion_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxQuestion.Text == "")
            {
                tbxQuestion.Text = "Введите вопрос";
                tbxQuestion.Foreground = Brushes.Gray;
            }
        }

        private void tbxAnswer1_GotFocus(object sender, RoutedEventArgs e)
        {            
            if (tbxAnswer1.Text == "Ответ")
            {
                tbxAnswer1.Text = "";
                tbxAnswer1.Foreground = Brushes.Black;
            }
        }
        private void tbxAnswer2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxAnswer2.Text == "Ответ")
            {
                tbxAnswer2.Text = "";
                tbxAnswer2.Foreground = Brushes.Black;
            }
        }
        private void tbxAnswer3_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxAnswer3.Text == "Ответ")
            {
                tbxAnswer3.Text = "";
                tbxAnswer3.Foreground = Brushes.Black;
            }
        }
        private void tbxAnswer4_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxAnswer4.Text == "Ответ")
            {
                tbxAnswer4.Text = "";
                tbxAnswer4.Foreground = Brushes.Black;
            }
        }

        private void tbxAnswer1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxAnswer1.Text == "")
            {
                tbxAnswer1.Text = "Ответ";
                tbxAnswer1.Foreground = Brushes.Gray;
            }
        }
        private void tbxAnswer2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxAnswer2.Text == "")
            {
                tbxAnswer2.Text = "Ответ";
                tbxAnswer2.Foreground = Brushes.Gray;
            }
        }
        private void tbxAnswer3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxAnswer3.Text == "")
            {
                tbxAnswer3.Text = "Ответ";
                tbxAnswer3.Foreground = Brushes.Gray;
            }
        }
        private void tbxAnswer4_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxAnswer4.Text == "")
            {
                tbxAnswer4.Text = "Ответ";
                tbxAnswer4.Foreground = Brushes.Gray;
            }
        }

    }
}
