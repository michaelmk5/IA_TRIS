using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tris_graf
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int p = 1;
            new TRIS(p).Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int p = 3;
            new TRIS(p).Show();
            this.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int p = 5;
            new TRIS(p).Show();
            this.Visible = false;
        }
    }
}
