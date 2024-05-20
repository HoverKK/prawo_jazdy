using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace prawo_jazdy
{
    public partial class Menuform : Form
    {
        public Menuform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Wybór form = new Wybór();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wybrałeś kategorie B");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wybrałeś kategorie C");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wybrałeś kategorie C+E");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wybrałeś kategorie D");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}