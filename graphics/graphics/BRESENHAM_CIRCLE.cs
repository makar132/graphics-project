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
    public partial class BRESENHAM_CIRCLE : Form
    {

        public BRESENHAM_CIRCLE()
        {
            InitializeComponent();
        }

        private void BRESENHAM_CIRCLE_Load(object sender, EventArgs e)
        {

        }

        public bool DRAW(int x, int y, int xinc, int yinc, Bitmap diagram)
        {

            try
            {
                diagram.SetPixel(x + xinc, y + yinc, Color.Red);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");

                return false;
            }
            try
            {
                diagram.SetPixel(x + xinc, y - yinc, Color.Red);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");

                return false;
            }
            try
            {
                diagram.SetPixel(x - xinc, y + yinc, Color.Red);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                return false;
            } try
            {

                diagram.SetPixel(x - xinc, y - yinc, Color.Red);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                return false;
            }

            try
            {
                diagram.SetPixel(x + yinc, y + xinc, Color.Red);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                return false;
            }
            try
            {
                diagram.SetPixel(x + yinc, y - xinc, Color.Red);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                return false;
            }
            try
            {
                diagram.SetPixel(x - yinc, y + xinc, Color.Red);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                return false;
            }
            try
            {
                diagram.SetPixel(x - yinc, y - xinc, Color.Red);

            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int xc = int.Parse(textBox1.Text),
               yc = int.Parse(textBox2.Text),
               x = 0,
               r = int.Parse(textBox3.Text),
               y = r,
               p = 3 - 2 * r;
            int w = pictureBox1.Width, h = pictureBox1.Height;
            xc += w / 2;
            yc += h / 2;
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            if (DRAW(xc, yc, x, y, diagram))
                while (x <= y)
                {
                    if (p >= 0)
                    {
                        x++;
                        y--;
                        p += 4 * (x - y) + 10;
                    }
                    else
                    {
                        x++;
                        p += 4 * x + 6;
                    }
                    if (!DRAW(xc, yc, x, y, diagram))
                    {
                        diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        break;
                    }


                }
            pictureBox1.Image = diagram;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
