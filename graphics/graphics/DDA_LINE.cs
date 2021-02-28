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
    public partial class DDA_LINE : Form
    {
        public DDA_LINE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text),
             y1 = int.Parse(textBox2.Text),
             x2 = int.Parse(textBox3.Text),
             y2 = int.Parse(textBox4.Text);
            int w = pictureBox1.Width, h = pictureBox1.Height;
            if (Math.Max(x1, x2) > 80 || Math.Min(x1, x2) < -80 || Math.Max(y1, y2) > 75 || Math.Min(y1, y2) < -75)
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER COORDINATES");

            }
            else
            {
                y1 *= -1;
                y2 *= -1;
                x1 += w / 2;
                y1 += h / 2;
                x2 += w / 2;
                y2 += h / 2;

                int dx = x2 - x1,
                 dy = y2 - y1;
                float x = x1, y = y1;
                int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
                float xinc = dx / (float)steps,
                      yinc = dy / (float)steps;
                Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                diagram.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Red);
                for (int i = 0; i < steps; i++)
                {
                    x += xinc;
                    y += yinc;
                    if (i == steps - 1)
                        diagram.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Red);
                    else
                        diagram.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Black);
                }
                pictureBox1.Image = diagram;
            }

        }
    }
}
