using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics
{
    public partial class app : Form
    {
        public app()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form f = new DDA_LINE();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form f = new Bresenham_LINE();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f = new BRESENHAM_CIRCLE();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f = new Midpoint_Circle();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Midpoint_Elipse();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Transformation();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Line_Clipping();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }
    }
}
