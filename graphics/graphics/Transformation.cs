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
    public partial class Transformation : Form
    {
        public Transformation()
        {
            InitializeComponent();
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
        private void button1_Click(object sender, EventArgs e)//draw square
        {
            int x1 = int.Parse(textBox1.Text),
                y1 = int.Parse(textBox2.Text),
                x2 = int.Parse(textBox3.Text),
                y2 = int.Parse(textBox4.Text);
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            DRAW(x1, y1, x2, y1, diagram);
            DRAW(x2, y1, x2, y2, diagram);
            DRAW(x2, y2, x1, y2, diagram);
            DRAW(x1, y2, x1, y1, diagram);
            pictureBox1.Image = diagram;
        }

        private void button2_Click(object sender, EventArgs e)//scale
        {
            int x1 = int.Parse(textBox1.Text),
                y1 = int.Parse(textBox2.Text),
                x2 = int.Parse(textBox3.Text),
                y2 = int.Parse(textBox4.Text),
                sx = int.Parse(textBox5.Text),
                sy = int.Parse(textBox6.Text);
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            DRAW(x1, y1, x2 * sx, y1, diagram);
            DRAW(x2 * sx, y1, x2 * sx, y2 * sy, diagram);
            DRAW(x2 * sx, y2 * sy, x1, y2 * sy, diagram);
            DRAW(x1, y2 * sy, x1, y1, diagram);
            pictureBox1.Image = diagram;
        }

        private void button3_Click(object sender, EventArgs e)//translate
        {
            int x1 = int.Parse(textBox1.Text),
                y1 = int.Parse(textBox2.Text),
                x2 = int.Parse(textBox3.Text),
                y2 = int.Parse(textBox4.Text),
                tx = int.Parse(textBox7.Text),
                ty = int.Parse(textBox8.Text);
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            x1 += tx;
            x2 += tx;
            y1 += ty;
            y2 += ty;
            DRAW(x1, y1, x2, y1, diagram);
            DRAW(x2, y1, x2, y2, diagram);
            DRAW(x2, y2, x1, y2, diagram);
            DRAW(x1, y2, x1, y1, diagram);
            pictureBox1.Image = diagram;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }



        private void button5_Click(object sender, EventArgs e)//reflect on xaxis
        {
            int x1 = int.Parse(textBox1.Text),
                y1 = int.Parse(textBox2.Text),
                x2 = int.Parse(textBox3.Text),
                y2 = int.Parse(textBox4.Text),
                dx = x2 - x1,
                dy = y2 - y1;
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            diagram.SetPixel(50, 50, Color.Black);
            DRAW(x1, -y1, x2, -y1, diagram);
            DRAW(x2, -y1, x2, -y2, diagram);
            DRAW(x2, -y2, x1, -y2, diagram);
            DRAW(x1, -y2, x1, -y1, diagram);
            pictureBox1.Image = diagram;
        }

        private void button6_Click(object sender, EventArgs e)//reflect on yaxis
        {
            int x1 = int.Parse(textBox1.Text),
                y1 = int.Parse(textBox2.Text),
                x2 = int.Parse(textBox3.Text),
                y2 = int.Parse(textBox4.Text),
                dx = x2 - x1,
                dy = y2 - y1;
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            diagram.SetPixel(50, 50, Color.Black);
            DRAW(-x1, y1, -x2, y1, diagram);
            DRAW(-x2, y1, -x2, y2, diagram);
            DRAW(-x2, y2, -x1, y2, diagram);
            DRAW(-x1, y2, -x1, y1, diagram);
            pictureBox1.Image = diagram;
        }
    }
}
