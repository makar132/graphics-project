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
    public partial class MID_POINT_LINE : Form
    {
        public MID_POINT_LINE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text),
             y1 = int.Parse(textBox2.Text),
             x2 = int.Parse(textBox3.Text),
             y2 = int.Parse(textBox4.Text),
             dx = x2 - x1,
             dy = y2 - y1,
             d,
             x=x1,
             y=y1;
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            if(dx >= dy)
            {
                d = dy - (dx / 2);
                diagram.SetPixel(x, y, Color.Black);
                while(x<x2)
                {
                    x++;

                }

            }
            else
            {

            }
        }
    }
}
