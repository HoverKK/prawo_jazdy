using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace prawo_jazdy
{
    public partial class rejestracja : Form
    {
        private TextBox txtImię;
        private TextBox txtNazwisko;
        private TextBox txtEmail;
        private TextBox txtHasło;

        private SqlConnection conn;

        public rejestracja()
        {
            InitializeComponent();

            conn = new SqlConnection(@"Data Source=DESKTOP-ED41F2S;Initial Catalog=Prawo_jazdy;Integrated Security=True");

            InitializeControls();
        }

        private void InitializeControls()
        {
            Label lblImię = new Label();
            lblImię.Text = "Imię:";
            lblImię.Location = new Point(this.Width / 2 - 150, this.Height / 2 - 80);
            this.Controls.Add(lblImię);

            txtImię = new TextBox();
            txtImię.Location = new Point(this.Width / 2 - 50, this.Height / 2 - 80);
            txtImię.Size = new Size(100, 20);
            this.Controls.Add(txtImię);

            Label lblNazwisko = new Label();
            lblNazwisko.Text = "Nazwisko:";
            lblNazwisko.Location = new Point(this.Width / 2 - 150, this.Height / 2 - 50);
            this.Controls.Add(lblNazwisko);

            txtNazwisko = new TextBox();
            txtNazwisko.Location = new Point(this.Width / 2 - 50, this.Height / 2 - 50);
            txtNazwisko.Size = new Size(100, 20);
            this.Controls.Add(txtNazwisko);

            Label lblEmail = new Label();
            lblEmail.Text = "E-mail:";
            lblEmail.Location = new Point(this.Width / 2 - 150, this.Height / 2 - 20);
            this.Controls.Add(lblEmail);

            txtEmail = new TextBox();
            txtEmail.Location = new Point(this.Width / 2 - 50, this.Height / 2 - 20);
            txtEmail.Size = new Size(100, 20);
            this.Controls.Add(txtEmail);

            Label lblHasło = new Label();
            lblHasło.Text = "Hasło:";
            lblHasło.Location = new Point(this.Width / 2 - 150, this.Height / 2 + 10);
            this.Controls.Add(lblHasło);

            txtHasło = new TextBox();
            txtHasło.Location = new Point(this.Width / 2 - 50, this.Height / 2 + 10);
            txtHasło.Size = new Size(100, 20);
            txtHasło.PasswordChar = '*';
            this.Controls.Add(txtHasło);

            Button buttonZarejestruj = new Button();
            buttonZarejestruj.Text = "Zarejestruj";
            buttonZarejestruj.Location = new Point(this.Width / 2 - 50, this.Height / 2 + 40);
            buttonZarejestruj.Size = new Size(100, 30);
            buttonZarejestruj.Click += new EventHandler(buttonZarejestruj_Click);
            this.Controls.Add(buttonZarejestruj);
        }

        private void buttonZarejestruj_Click(object sender, EventArgs e)
        {
            string imię = txtImię.Text;
            string nazwisko = txtNazwisko.Text;
            string email = txtEmail.Text;
            string hasło = txtHasło.Text;

            if (string.IsNullOrWhiteSpace(imię) || string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(hasło))
            {
                MessageBox.Show("Wszystkie pola są wymagane.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                string query = "INSERT INTO urzytkownik (imię, nazwisko, email, hasło) VALUES (@imię, @nazwisko, @email, @hasło)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@imię", imię);
                cmd.Parameters.AddWithValue("@nazwisko", nazwisko);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@hasło", hasło);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Rejestracja zakończona sukcesem.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 form2 = new Form1();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wystąpił problem podczas rejestracji użytkownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.Show();
            this.Hide();
        }
    }
}
