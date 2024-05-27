using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Windows.Forms;

namespace prawo_jazdy
{
    public partial class Wynik : Form
    {
        public Wynik(int correctAnswers, int totalQuestions)
        {
            InitializeComponent();
            labelResult.Text = $"Liczba poprawnych odpowiedzi: {correctAnswers}/{totalQuestions}";
        }
    }
}
