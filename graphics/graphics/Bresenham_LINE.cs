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
    public partial class Bresenham_LINE : Form
    {
        public Bresenham_LINE()
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

            x1 += w / 2;
            y1 += h / 2;
            x2 += w / 2;
            y2 += h / 2;

            int dx = Math.Abs(x2 - x1), dy = Math.Abs (y2 - y1);
            int x = x1, y = y1;
            int p = 0;
            Console.WriteLine(dx + " " + dy + " " + x1 + " " + y1 + " " + x2 + " " + y2);
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            diagram.SetPixel(x, y, Color.Black);
            if (dx != 0)
            {
                p = dy + dy - dx;
                
                for (int i = 1; i < dx; i++)
                {
                    if (p < 0)
                    {
                        x++;
                        p += (dy + dy);
                    }
                    else
                    {
                        x++;
                        y--;
                        p += (dy + dy) - (dx + dx);
                    }
                    diagram.SetPixel(x, y, Color.Black);

                }
            }
            else
            {
                p = dx + dx - dy;
                for (int i = 1; i < dy; i++)
                {
                    if (p < 0)
                    {
                        y--;
                        p += (dx + dx);
                    }
                    else
                    {
                        x++;
                        y--;
                        p += (dx + dx) - (dy + dy);
                    }
                    diagram.SetPixel(x, y, Color.Black);

                }
            }
            pictureBox1.Image = diagram;
        }
    }
}
