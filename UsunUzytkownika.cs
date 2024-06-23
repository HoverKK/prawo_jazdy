using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace prawo_jazdy
{
    public partial class UsunUzytkownika : Form
    {
        private SqlConnection conn;

        public UsunUzytkownika()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-ED41F2S;Initial Catalog=Prawo_jazdy;Integrated Security=True");
            this.FormClosed += UsunUzytkownika_FormClosed; 
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text;

            if (string.IsNullOrWhiteSpace(userId))
            {
                MessageBox.Show("Proszę podać ID użytkownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                
                string query = "DELETE FROM urzytkownik WHERE id = @userId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Użytkownik został usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Nie znaleziono użytkownika o podanym ID.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void UsunUzytkownika_FormClosed(object sender, FormClosedEventArgs e)
        {
            PanelAdmina panelAdmina = new PanelAdmina();
            panelAdmina.Show();
        }
    }
}
