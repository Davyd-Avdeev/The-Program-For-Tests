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
    /// Interaction logic for EditTestWindow.xaml
    /// </summary>
    public partial class EditTestWindow : Window
    {
        List<RadioButton> rdBtn = new List<RadioButton>();
        List<QuestionsAndAnswers> answers = new List<QuestionsAndAnswers>();
        int ans = 0;
        int questIndex = 0;
        string testName = "";
        bool newQuest = false;
        public EditTestWindow(string TestName)
        {
            InitializeComponent();

            btnNext.Content = ">>";
            btnPrev.Content = "<<";

            rdBtn.Add(Answer1);
            rdBtn.Add(Answer2);
            rdBtn.Add(Answer3);
            rdBtn.Add(Answer4);
            testName = TestName;

            Load_Quest();

            tbxQuestion.Text = answers[0].question;
            tbxAnswer1.Text = answers[0].answer1;
            tbxAnswer2.Text = answers[0].answer2;
            tbxAnswer3.Text = answers[0].answer3;
            tbxAnswer4.Text = answers[0].answer4;
            RdBtn_Checked();

            btnPrev.IsEnabled = false;

            if (answers.Count == 1)
            {
                btnNext.IsEnabled = false;
                btnPrev.IsEnabled = false;
            }
        }

        public void ChangeQuest()
        {
            tbxQuestion.Text = answers[questIndex].question;
            tbxAnswer1.Text = answers[questIndex].answer1;
            tbxAnswer2.Text = answers[questIndex].answer2;
            tbxAnswer3.Text = answers[questIndex].answer3;
            tbxAnswer4.Text = answers[questIndex].answer4;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput() == false)
            {
                return;
            }

            if (questIndex - 1 == 0)
            {
                btnPrev.IsEnabled = false;
                btnNext.IsEnabled = true;
            }
            if (questIndex - 1 != 0 && questIndex + 2 != answers.Count)
            {
                btnPrev.IsEnabled = true;
                btnNext.IsEnabled = true;
            }

            if (newQuest == true)
            {
                SaveNewQuest();
                newQuest = false;
            }
            else
            {
                Save_Question();
            }
            questIndex--;
            ChangeQuest();
            RdBtn_Checked();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput() == false)
            {
                return;
            }

            if (questIndex + 2 == answers.Count)
            {
                btnNext.IsEnabled = false;
                btnPrev.IsEnabled = true;
            }
            if (questIndex - 1 != 0 && questIndex + 2 != answers.Count)
            {
                btnNext.IsEnabled = true;
                btnPrev.IsEnabled = true;
            }

            Save_Question();
            questIndex++;
            ChangeQuest();
            RdBtn_Checked();
        }

        private void btnNewQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput() == false)
            {
                return;
            }
            if (newQuest == true)
            {
                SaveNewQuest();
            }
            else
            {
                Save_Question();
            }            
            questIndex = answers.Count;
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

            rdBtn[ans].IsChecked = false;
            ans = 0;
            newQuest = true;
            btnNext.IsEnabled = false;
            btnPrev.IsEnabled = true;
        }
        private void btnSaveTest_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput() == false)
            {
                return;
            }

            if (newQuest == true)
            {
                SaveNewQuest();
            }
            else
            {
                Save_Question();
            }
            foreach (Window window in App.Current.Windows)
            {
                if (window is LoadTestWindow)
                {
                    window.Visibility = Visibility.Visible;
                    this.Visibility = Visibility.Collapsed;
                }
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (answers.Count == 1)
            {
                var window = new AcceptWindow(testName);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();
                return;
            }

            Save_Question();
            
            if (btnPrev.IsEnabled == true)
            {                
                questIndex--;                
            }
            else
            {
                questIndex++;
            }

            
            ChangeQuest();
            RdBtn_Checked();

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
                            if (xnode.Attributes.Count > 0)
                            {
                                XmlNode attr1 = childNode.Attributes.GetNamedItem("name"); // Вопрос
                                if (attr1 != null)
                                {
                                    if (btnPrev.IsEnabled == true)
                                    {
                                        if (attr1.InnerText == answers[questIndex + 1].question)
                                        {
                                            questIndex++;
                                            answers.RemoveAt(questIndex);
                                            xnode.RemoveChild(childNode);
                                            questIndex--;
                                        }
                                    }
                                    else
                                    {
                                        if (attr1.InnerText == answers[questIndex - 1].question)
                                        {
                                            questIndex--;
                                            answers.RemoveAt(questIndex);
                                            xnode.RemoveChild(childNode);
                                            questIndex++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            doc.Save(@"..\..\Test\Questions.xml");

            if (answers.Count != 1)
            {
                if (questIndex == 0)
                {
                    btnPrev.IsEnabled = false;
                    btnNext.IsEnabled = true;
                }
                else
                {
                    btnPrev.IsEnabled = true;
                }
                if (questIndex + 1 == answers.Count)
                {
                    btnNext.IsEnabled = false;
                    btnPrev.IsEnabled = true;
                }
                else
                {
                    btnNext.IsEnabled = true;
                }
            }
            else
            {
                btnPrev.IsEnabled = false;
                btnNext.IsEnabled = false;
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
            ans = 0;
            foreach (var item in rdBtn)
            {
                if (item.IsChecked == true)
                {
                    break;
                }
                ans++;
            }
            if (ans < 0 || ans > 3)
            {
                MessageBox.Show("Вы не выбрали правильный ответ!");
                return false;
            }
            return true;
        }

        private void Save_Question()
        {
            int count = 0;
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
                            if (xnode.Attributes.Count > 0)
                            {
                                XmlNode attr1 = childNode.Attributes.GetNamedItem("name"); // Вопрос
                                if (attr1 != null)
                                {
                                    if (attr1.InnerText == answers[questIndex].question)
                                    {
                                        attr1.InnerText = tbxQuestion.Text;
                                        answers[questIndex].question = attr1.InnerText;
                                        foreach (XmlNode childChildNode in childNode.ChildNodes) // Ответы на него
                                        {
                                            if (childChildNode.Name == "answer1")
                                            {
                                                childChildNode.InnerText = tbxAnswer1.Text;
                                                answers[questIndex].answer1 = childChildNode.InnerText;
                                            }
                                            if (childChildNode.Name == "answer2")
                                            {
                                                childChildNode.InnerText = tbxAnswer2.Text;
                                                answers[questIndex].answer2 = childChildNode.InnerText;
                                            }
                                            if (childChildNode.Name == "answer3")
                                            {
                                                childChildNode.InnerText = tbxAnswer3.Text;
                                                answers[questIndex].answer3 = childChildNode.InnerText;
                                            }
                                            if (childChildNode.Name == "answer4")
                                            {
                                                childChildNode.InnerText = tbxAnswer4.Text;
                                                answers[questIndex].answer4 = childChildNode.InnerText;
                                            }
                                            if (childChildNode.Name == "correctAnswer")
                                            {
                                                childChildNode.InnerText = answers[questIndex].trueAnswer;
                                                answers[questIndex].trueAnswer = childChildNode.InnerText;
                                            }

                                            count++;

                                            if (count == 5)
                                            {
                                                count = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
            doc.Save(@"..\..\Test\Questions.xml");
        }

        private void SaveNewQuest()
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
                    if (attr.InnerText == testName)
                    {
                        QuestionsAndAnswers quest = new QuestionsAndAnswers();
                        quest.question = tbxQuestion.Text;
                        nameAttr2.AppendChild(nameText2); // name - question
                        question.Attributes.Append(nameAttr2); // Attribut name - "question?"
                        answer1.AppendChild(answer1Text); // Text - answer
                        quest.answer1 = tbxAnswer1.Text;
                        answer2.AppendChild(answer2Text); // Text - answer
                        quest.answer2 = tbxAnswer2.Text;
                        answer3.AppendChild(answer3Text); // Text - answer
                        quest.answer3 = tbxAnswer3.Text;
                        answer4.AppendChild(answer4Text); // Text - answer
                        quest.answer4 = tbxAnswer4.Text;
                        if (ans == 0)
                        {
                            correctAnswer.AppendChild(CorrectAnswer1Text);// Text - CorrectAnswer
                            quest.trueAnswer = tbxAnswer1.Text;
                        }
                        if (ans == 1)
                        {
                            correctAnswer.AppendChild(CorrectAnswer2Text);// Text - CorrectAnswer
                            quest.trueAnswer = tbxAnswer2.Text;
                        }
                        if (ans == 2)
                        {
                            correctAnswer.AppendChild(CorrectAnswer3Text);// Text - CorrectAnswer
                            quest.trueAnswer = tbxAnswer3.Text;
                        }
                        if (ans == 3)
                        {
                            correctAnswer.AppendChild(CorrectAnswer4Text);// Text - CorrectAnswer
                            quest.trueAnswer = tbxAnswer4.Text;
                        }
                        answers.Add(quest);
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
            newQuest = false;
        }

        private void Load_Quest()
        {
            int c = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Test\Questions.xml");
            XmlElement xRoot = doc.DocumentElement;
            foreach (XmlNode xnode in xRoot) //Все Тесты
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr.InnerText == testName) // Если это наш тест
                    {
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            QuestionsAndAnswers question = new QuestionsAndAnswers();
                            if (xnode.Attributes.Count > 0)
                            {
                                XmlNode attr1 = childNode.Attributes.GetNamedItem("name"); // Вопрос
                                if (attr1 != null)
                                {
                                    question.question = attr1.Value;
                                    foreach (XmlNode childChildNode in childNode.ChildNodes) // Ответы на него
                                    {
                                        if (childChildNode.Name == "answer1")
                                        {
                                            question.answer1 = childChildNode.InnerText;
                                        }
                                        else if (childChildNode.Name == "answer2")
                                        {
                                            question.answer2 = childChildNode.InnerText;
                                        }
                                        else if (childChildNode.Name == "answer3")
                                        {
                                            question.answer3 = childChildNode.InnerText;
                                        }
                                        else if (childChildNode.Name == "answer4")
                                        {
                                            question.answer4 = childChildNode.InnerText;
                                        }
                                        else if (childChildNode.Name == "correctAnswer")
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
                    }
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void RdBtn_Checked()
        {
            if (answers[questIndex].trueAnswer == tbxAnswer1.Text)
            {
                rdBtn[0].IsChecked = true;
            }
            else if (answers[questIndex].trueAnswer == tbxAnswer2.Text)
            {
                rdBtn[1].IsChecked = true;
            }
            else if (answers[questIndex].trueAnswer == tbxAnswer3.Text)
            {
                rdBtn[2].IsChecked = true;
            }
            else if (answers[questIndex].trueAnswer == tbxAnswer4.Text)
            {
                rdBtn[3].IsChecked = true;
            }
        }
        private void Answer_Checked(object sender, RoutedEventArgs e)
        {
            ans = 0;
            foreach (var item in rdBtn)
            {
                if (item.IsChecked == true)
                {
                    break;
                }
                ans++;
            }
            if (newQuest == true)
            {
                return;
            }

            if (ans == 0)
            {
                answers[questIndex].trueAnswer = tbxAnswer1.Text;
            }
            if (ans == 1)
            {
                answers[questIndex].trueAnswer = tbxAnswer2.Text;
            }
            if (ans == 2)
            {
                answers[questIndex].trueAnswer = tbxAnswer3.Text;
            }
            if (ans == 3)
            {
                answers[questIndex].trueAnswer = tbxAnswer4.Text;
            }

        }

        private void Button_check() 
        {
            if (answers.Count == 1)
            {
                btnNext.IsEnabled = false;
                btnPrev.IsEnabled = false;
            }
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
