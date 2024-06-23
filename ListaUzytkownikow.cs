using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prawo_jazdy
{
    public partial class ListaUzytkownikow : Form
    {
        private SqlConnection conn;

        public ListaUzytkownikow()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-ED41F2S;Initial Catalog=Prawo_jazdy;Integrated Security=True");
            this.FormClosed += ListaUzytkownikow_FormClosed; // Obsługa zamknięcia formularza
        }

        private void ListaUzytkownikow_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                conn.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT id, imię, nazwisko, email FROM urzytkownik", conn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void ListaUzytkownikow_FormClosed(object sender, FormClosedEventArgs e)
        {
            PanelAdmina panelAdmina = new PanelAdmina();
            panelAdmina.Show();
        }
    }
}
