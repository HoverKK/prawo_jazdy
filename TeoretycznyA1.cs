using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace prawo_jazdy
{
    public partial class TeoretycznyA1 : Form
    {
        private int currentQuestionIndex = 0;
        private int timeLeft = 30;
        private System.Windows.Forms.Timer timer;
        private int correctAnswersCount = 0;
        private int totalPoints = 0;
        private int maxPoints = 0;
        private List<Question> questions = new List<Question>();
        private List<Question> selectedQuestions = new List<Question>();

        private string connectionString = "your_connection_string_here";

        public TeoretycznyA1()
        {
            InitializeComponent();
            LoadQuestionsFromDatabase();
            SelectRandomQuestions();
            InitializeTimer();
            DisplayQuestion();
        }

        private void LoadQuestionsFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ED41F2S;Initial Catalog=Prawo_jazdy;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT p.PytanieID, p.PytanieText, o.OdpowiedzID, o.OdpowiedzText, o.Poprawne, o.Punkty " +
                               "FROM Pytania_A1 p " +
                               "JOIN Odpowiedzi_A o ON p.PytanieID = o.PytanieID";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                Dictionary<int, Question> questionDictionary = new Dictionary<int, Question>();

                while (reader.Read())
                {
                    int questionId = reader.GetInt32(0);
                    string questionText = reader.GetString(1);
                    int answerId = reader.GetInt32(2);
                    string answerText = reader.GetString(3);
                    bool isCorrect = reader.GetBoolean(4);
                    int points = reader.GetInt32(5);

                    if (!questionDictionary.ContainsKey(questionId))
                    {
                        questionDictionary[questionId] = new Question
                        {
                            QuestionID = questionId,
                            QuestionText = questionText,
                            Points = points,
                            Answers = new List<Answer>()
                        };
                    }

                    questionDictionary[questionId].Answers.Add(new Answer
                    {
                        AnswerID = answerId,
                        AnswerText = answerText,
                        IsCorrect = isCorrect
                    });
                }

                questions.AddRange(questionDictionary.Values);
                reader.Close();
            }
        }

        private void SelectRandomQuestions()
        {
            Random random = new Random();
            var shuffledQuestions = questions.OrderBy(q => random.Next()).ToList();
            int sumPoints = 0;
            foreach (var question in shuffledQuestions)
            {
                if (sumPoints + question.Points <= 74)
                {
                    selectedQuestions.Add(question);
                    sumPoints += question.Points;
                }
                if (sumPoints == 74) break;
            }
            maxPoints = sumPoints;
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                labelTime.Text = $"Pozostały czas: {timeLeft} sekund";
            }
            else
            {
                timer.Stop();
                CheckAnswer();
                GoToNextQuestion();
            }
        }

        private void DisplayQuestion()
        {
            timeLeft = 30;
            labelTime.Text = $"Pozostały czas: {timeLeft} sekund";
            timer.Start();

            if (selectedQuestions.Count > 0 && currentQuestionIndex < selectedQuestions.Count)
            {
                var currentQuestion = selectedQuestions[currentQuestionIndex];
                labelQuestion.Text = $"{currentQuestionIndex + 1}. {currentQuestion.QuestionText}";
                radioButtonA.Text = currentQuestion.Answers[0].AnswerText;
                radioButtonB.Text = currentQuestion.Answers[1].AnswerText;
                radioButtonC.Text = currentQuestion.Answers[2].AnswerText;
            }
            else
            {
                MessageBox.Show("Brak pytań do wyświetlenia!");
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            timer.Stop();
            CheckAnswer();
            GoToNextQuestion();
        }

        private void CheckAnswer()
        {
            if (selectedQuestions.Count > 0 && currentQuestionIndex < selectedQuestions.Count)
            {
                var currentQuestion = selectedQuestions[currentQuestionIndex];
                var checkedRadioButton = this.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                string selectedAnswerText = checkedRadioButton != null ? checkedRadioButton.Text : "Brak odpowiedzi";

                currentQuestion.UserSelectedAnswer = selectedAnswerText; // Zapisz wybraną odpowiedź użytkownika

                var userAnswer = currentQuestion.Answers.FirstOrDefault(a => a.AnswerText == selectedAnswerText);
                if (userAnswer != null && userAnswer.IsCorrect)
                {
                    correctAnswersCount++;
                    totalPoints += currentQuestion.Points;
                }

                radioButtonA.Checked = false;
                radioButtonB.Checked = false;
                radioButtonC.Checked = false;
            }
        }

        private void GoToNextQuestion()
        {
            if (selectedQuestions.Count > 0 && currentQuestionIndex < selectedQuestions.Count - 1)
            {
                currentQuestionIndex++;
                DisplayQuestion();
            }
            else
            {
                timer.Stop();
                ShowResult();
            }
        }

        private void ShowResult()
        {
            var resultForm = new ResultForm(correctAnswersCount, selectedQuestions.Count, totalPoints, maxPoints, selectedQuestions);
            resultForm.Show();
            this.Close();
        }

        private void TeoretycznyA1_Load(object sender, EventArgs e)
        {
            DisplayQuestion();
        }
    }

    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public int Points { get; set; }
        public List<Answer> Answers { get; set; }
        public string UserSelectedAnswer { get; set; } // Dodajemy właściwość przechowującą odpowiedź użytkownika
    }

    public class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class ResultForm : Form
    {
        public ResultForm(int correctAnswersCount, int totalQuestions, int totalPoints, int maxPoints, List<Question> questions)
        {
            this.Text = "Wynik";
            this.Size = new Size(1600, 1100);

            Label resultLabel = new Label();
            resultLabel.Text = $"Uzyskane punkty: {totalPoints} / {maxPoints}";
            resultLabel.Location = new Point(10, 10);
            resultLabel.AutoSize = true;
            this.Controls.Add(resultLabel);

            Label correctAnswersLabel = new Label();
            correctAnswersLabel.Text = $"Poprawne odpowiedzi: {correctAnswersCount} / {totalQuestions}";
            correctAnswersLabel.Location = new Point(10, 40);
            correctAnswersLabel.AutoSize = true;
            this.Controls.Add(correctAnswersLabel);

            Label passLabel = new Label();
            passLabel.Location = new Point(10, 70);
            passLabel.AutoSize = true;
            if (totalPoints >= 68) // Prog zdawalności
            {
                passLabel.Text = "Zdałeś!";
                passLabel.ForeColor = Color.Green;
            }
            else
            {
                passLabel.Text = "Nie zdałeś!";
                passLabel.ForeColor = Color.Red;
            }
            this.Controls.Add(passLabel);

            ListView listView = new ListView();
            listView.View = View.Details;
            listView.Columns.Add("Pytanie", 600);
            listView.Columns.Add("Twoja odpowiedź", 450);
            listView.Columns.Add("Poprawna odpowiedź", 450);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.Location = new Point(10, 100);
            listView.Size = new Size(1600, 800);

            foreach (var question in questions)
            {
                var userAnswer = question.Answers.FirstOrDefault(a => a.AnswerText == question.UserSelectedAnswer);
                var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);

                ListViewItem item = new ListViewItem(question.QuestionText);
                item.SubItems.Add(userAnswer != null ? userAnswer.AnswerText : "Brak odpowiedzi");
                item.SubItems.Add(correctAnswer.AnswerText);
                listView.Items.Add(item);
            }

            this.Controls.Add(listView);

            Button closeButton = new Button();
            closeButton.Text = "Zamknij";
            closeButton.Location = new Point(700, 920);
            closeButton.Size = new Size(100, 40);
            closeButton.Click += (s, e) => this.Close();
            this.Controls.Add(closeButton);
        }
    }

}
