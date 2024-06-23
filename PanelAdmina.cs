using System;
using System.Windows.Forms;

namespace prawo_jazdy
{
    public partial class PanelAdmina : Form
    {
        public PanelAdmina()
        {
            InitializeComponent();
        }

        private void PanelAdmina_Load(object sender, EventArgs e)
        {
           
        }

        private void btnTestTeoretyczny_Click(object sender, EventArgs e)
        {
            WynikiEgzaminuTeoretycznego form = new WynikiEgzaminuTeoretycznego();
            form.Show();
            this.Hide();
        }

        private void btnTestPraktyczny_Click(object sender, EventArgs e)
        {
            WynikiEgzaminuPraktycznego form = new WynikiEgzaminuPraktycznego();
            form.Show();
            this.Hide();
        }

        private void btnDodajUzytkownika_Click(object sender, EventArgs e)
        {
            DodajUzytkownika Form = new DodajUzytkownika();
            Form.ShowDialog();
            this.Hide();
        }

        private void btnUsunUzytkownika_Click(object sender, EventArgs e)
        {
            UsunUzytkownika Form = new UsunUzytkownika();
            Form.ShowDialog();
            this.Hide();
        }

        private void btnZmodyfikujUzytkownika_Click(object sender, EventArgs e)
        {
            ModyfikacjaUzytkownika form = new ModyfikacjaUzytkownika();
            form.Show();
            this.Hide();
        }

        private void btnListaUzytkownikow_Click(object sender, EventArgs e)
        {
            ListaUzytkownikow form = new ListaUzytkownikow();
            form.ShowDialog();
            this.Hide();
        }
    }
}
