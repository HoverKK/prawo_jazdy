using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prawo_jazdy
{
    public partial class Teoretyczny : Form
    {
        private int currentQuestionIndex = 0;
        private int timeLeft = 30;
        private System.Windows.Forms.Timer timer;
        private int correctAnswersCount = 0;
        private List<Question> questions = new List<Question>();

        private string connectionString = "your_connection_string_here"; // Uzupełnij odpowiednimi danymi

        public Teoretyczny()
        {
            InitializeComponent();
            LoadQuestionsFromDatabase();
            InitializeTimer();
            DisplayQuestion();
        }

        private void LoadQuestionsFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ED41F2S;Initial Catalog=Prawo_jazdy;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT p.PytanieID, p.PytanieText, o.OdpowiedzID, o.OdpowiedzText, o.Poprawne " +
                               "FROM Pytania p " +
                               "JOIN Odpowiedzi o ON p.PytanieID = o.PytanieID";

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

                    if (!questionDictionary.ContainsKey(questionId))
                    {
                        questionDictionary[questionId] = new Question
                        {
                            QuestionID = questionId,
                            QuestionText = questionText,
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

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 sekunda
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
            timeLeft = 30; // Resetowanie czasu dla każdego pytania
            labelTime.Text = $"Pozostały czas: {timeLeft} sekund";
            timer.Start();

            var currentQuestion = questions[currentQuestionIndex];
            labelQuestion.Text = $"{currentQuestionIndex + 1}. {currentQuestion.QuestionText}";
            radioButtonA.Text = currentQuestion.Answers[0].AnswerText;
            radioButtonB.Text = currentQuestion.Answers[1].AnswerText;
            radioButtonC.Text = currentQuestion.Answers[2].AnswerText;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            timer.Stop();
            CheckAnswer();
            GoToNextQuestion();
        }

        private void CheckAnswer()
        {
            char selectedAnswer = ' ';
            if (radioButtonA.Checked)
                selectedAnswer = 'a';
            else if (radioButtonB.Checked)
                selectedAnswer = 'b';
            else if (radioButtonC.Checked)
                selectedAnswer = 'c';

            var correctAnswer = questions[currentQuestionIndex].Answers.Find(a => a.IsCorrect);
            if (correctAnswer != null && correctAnswer.AnswerText.StartsWith(selectedAnswer.ToString()))
            {
                correctAnswersCount++; // Zwiększenie liczby poprawnych odpowiedzi
            }

            // Wyczyść zaznaczenie przed kolejnym pytaniem
            radioButtonA.Checked = false;
            radioButtonB.Checked = false;
            radioButtonC.Checked = false;
        }

        private void GoToNextQuestion()
        {
            if (currentQuestionIndex < questions.Count - 1)
            {
                currentQuestionIndex++;
                DisplayQuestion();
            }
            else
            {
                timer.Stop();
                var wynikForm = new Wynik(correctAnswersCount, questions.Count);
                wynikForm.Show();
                this.Close();
            }
        }

        private void Teoretyczny_Load(object sender, EventArgs e)
        {
            DisplayQuestion();
        }
    }

    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
    }

    public class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}
