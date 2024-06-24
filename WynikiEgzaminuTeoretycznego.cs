using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prawo_jazdy
{
    public partial class WynikiEgzaminuTeoretycznego : Form
    {
        public WynikiEgzaminuTeoretycznego()
        {
            InitializeComponent();
            this.FormClosed += WynikiEgzaminuTeoretycznego_FormClosed; 
        }

        private void WynikiEgzaminuTeoretycznego_Load(object sender, EventArgs e)
        {
            LoadWyniki();
        }

        private void LoadWyniki()
        {
            string connectionString = "your_connection_string_here"; 
            string query = "SELECT TOP (1000) [WynikID], [TotalPoints], [MaxPoints], [CorrectAnswersCount], [TotalQuestions], [Timestamp], [Kategoria] FROM [Prawo_jazdy].[dbo].[Wyniki]";

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ED41F2S;Initial Catalog=Prawo_jazdy;Integrated Security=True"))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void WynikiEgzaminuTeoretycznego_FormClosed(object sender, FormClosedEventArgs e)
        {
            PanelAdmina panelAdmina = new PanelAdmina();
            panelAdmina.Show();
        }
    }
}