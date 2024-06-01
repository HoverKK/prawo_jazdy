using System;
using System.Collections.Generic;
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
    public partial class WybórA : Form
    {
        public WybórA()
        {
            InitializeComponent();
        }

        private void WybórA_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeoretycznyA1 form = new TeoretycznyA1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Praktyczny form = new Praktyczny();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menuform form1 = new Menuform();
            form1.Show();
            this.Hide();
        }
    }
}
