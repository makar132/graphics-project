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
    public partial class Line_Clipping : Form
    {
        public Line_Clipping()
        {
            InitializeComponent();
        }

        private void Line_Clipping_Load(object sender, EventArgs e)
        {

        }
        public void DRAW(int x1, int y1, int x2, int y2, Bitmap diagram)
        {
            int w = pictureBox1.Width, h = pictureBox1.Height;
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
            diagram.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Red);
            for (int i = 0; i < steps; i++)
            {
                x += xinc;
                y += yinc;
                diagram.SetPixel((int)Math.Round(x), (int)Math.Round(y), Color.Red);
            }
        }
        public double x1, y1, x2, y2, xmin, ymin, xmax, ymax;
        const int LEFT = 1;
        const int RIGHT = 2;
        const int BOTTOM = 4;
        const int TOP = 8;
        public int compute_code(double x, double y)
        {
            int code = 0;
            if (x < xmin) code |= LEFT;
            else if (x > xmax) code |= RIGHT;
            if (y < ymin) code |= BOTTOM;
            else if (y > ymax) code |= TOP;
            return code;
        }
        public bool clipp()
        {
            int code1 = compute_code(x1, y1), code2 = compute_code(x2, y2);
            bool clipped = false;
            while (true)
            {Console.WriteLine(x1+" "+y1+" "+code1);
            Console.WriteLine(x2 + " " + y2 + " " + code2);
          //  Console.WriteLine(xmin + " " + ymin + " " + xmax + " " + ymax);
                if ((code1 & code2) != 0)
                {
                    break;
                }
                if ((code1 | code2) == 0)
                {
                    clipped = true;
                    break;
                }
                int code = 0;
                if (code1 != 0) code = code1;
                else code = code2;
                double clippx = 0, clippy = 0;
                if ((code & TOP) != 0)
                {
                    clippx = (((ymax - y1) * (x2 - x1)) / (y2 - y1)) + x1;
                    clippy = ymax;
                }
                else if ((code & BOTTOM) != 0)
                {
                    clippx = (((ymin - y1) * (x2 - x1)) / (y2 - y1)) + x1;
                    clippy = ymin;
                }
                else if ((code & LEFT) != 0)
                {
                    clippy = (((xmin - x1) * (y2 - y1)) / (x2 - x1)) + y1;
                    clippx = xmin;
                }
                else if ((code & RIGHT) != 0)
                {
                    clippy = (((xmax - x1) * (y2 - y1)) / (x2 - x1)) + y1;
                    clippx = xmax;
                }

                if (code == code1)
                {
                    x1 = clippx;
                    y1 = clippy;
                    code1 = compute_code(x1, y1);
                }
                else if (code == code2)
                {
                    x2 = clippx;
                    y2 = clippy;
                    code2 = compute_code(x2, y2);
                }
            }
            return clipped;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text),
               y1 = int.Parse(textBox2.Text),
               x2 = int.Parse(textBox3.Text),
               y2 = int.Parse(textBox4.Text);
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            DRAW(x1, y1, x2, y2, diagram);
            pictureBox1.Image = diagram;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x1 = int.Parse(textBox1.Text);
            y1 = int.Parse(textBox2.Text);
            x2 = int.Parse(textBox3.Text);
            y2 = int.Parse(textBox4.Text);
            xmin = int.Parse(textBox6.Text);
            ymin = int.Parse(textBox5.Text);
            xmax = int.Parse(textBox8.Text);
            ymax = int.Parse(textBox7.Text);
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            if (clipp())
            {
                Console.WriteLine(x1 + " " + y1 + " " + x2 + " " + y2);
                DRAW((int)x1, (int)y1, (int)x2, (int)y2, diagram);}

            pictureBox1.Image = diagram;
        }
    }
}
