using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prawo_jazdy
{
    public partial class WynikiEgzaminuPraktycznego : Form
    {
        public WynikiEgzaminuPraktycznego()
        {
            InitializeComponent();
            this.FormClosed += WynikiEgzaminuPraktycznego_FormClosed; 
        }

        private void WynikiEgzaminuPraktycznego_Load(object sender, EventArgs e)
        {
            LoadWyniki();
        }

        private void LoadWyniki()
        {
            string connectionString = "your_connection_string_here"; // Zastąp odpowiednim connection stringiem
            string query = "SELECT TOP (1000) [Id], [Name], [LastName], [ExamDate], [StartTime], [EndTime], [Task], [Points] FROM [Prawo_jazdy].[dbo].[ExamResults]";

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-ED41F2S;Initial Catalog=Prawo_jazdy;Integrated Security=True"))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void WynikiEgzaminuPraktycznego_FormClosed(object sender, FormClosedEventArgs e)
        {
            PanelAdmina panelAdmina = new PanelAdmina();
            panelAdmina.Show();
        }
    }
}

