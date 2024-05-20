using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace prawo_jazdy
{
    public partial class Form1 : Form
    {
        private TextBox txt_email;
        private TextBox txt_has這;

        public Form1()
        {
            InitializeComponent();
            txt_email = new TextBox();
            txt_email.Location = new Point(343, 150);
            this.Controls.Add(txt_email);

            txt_has這 = new TextBox();
            txt_has這.Location = new Point(343, 193);
            txt_has這.PasswordChar = '*';
            this.Controls.Add(txt_has這);
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-ED41F2S;Initial Catalog=Prawo_jazdy;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string email, has這;

            email = txt_email.Text;
            has這 = txt_has這.Text;

            try
            {
                string query = "SELECT * FROM urzytkownik WHERE email = '" + txt_email.Text + "' AND has這 = '" + txt_has這.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    email = txt_email.Text;
                    has這 = txt_has這.Text;

                    Menuform form2 = new Menuform();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Z造 e-mail lub has這", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_email.Clear();
                    txt_has這.Clear();

                    txt_email.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            txt_email.Clear();
            txt_has這.Clear();
            txt_email.Focus();
        }    

        private void button2_Click(object sender, EventArgs e)
        {
            rejestracja form2 = new rejestracja();
            form2.Show();
            this.Hide();
        }
    }
}