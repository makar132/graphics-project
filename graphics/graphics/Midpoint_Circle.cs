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
    public partial class Midpoint_Circle : Form
    {
        public Midpoint_Circle()
        {
            InitializeComponent();
        }
        public bool DRAW(int x, int y, int xinc, int yinc, Bitmap diagram)
        {
            try
            {
                diagram.SetPixel(x + xinc, y + yinc, Color.Red);
                Console.WriteLine((x+xinc-84) + " , " + (y+yinc-76));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");

                return false;
            }
            try
            {
                diagram.SetPixel(x + xinc, y - yinc, Color.Red);
                Console.WriteLine((x + xinc-84) + " , " + (y-yinc-76));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");

                return false;
            }
            try
            {
                diagram.SetPixel(x - xinc, y + yinc, Color.Red);
                Console.WriteLine((x - xinc-84) + " , " + (y + yinc-76));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                return false;
            } try
            {

                diagram.SetPixel(x - xinc, y - yinc, Color.Red);
                Console.WriteLine((x - xinc-84) + " , " + (y - yinc-76));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                return false;
            }

            if (xinc != yinc)
            {
                try
                {
                    diagram.SetPixel(x + yinc, y + xinc, Color.Red);
                    Console.WriteLine((x + yinc-84) + " , " + (y + xinc-76));
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                    return false;
                }
                try
                {
                    diagram.SetPixel(x + yinc, y - xinc, Color.Red);
                    Console.WriteLine((x + yinc-84) + " , " + (y - xinc-76));
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                    return false;
                }
                try
                {
                    diagram.SetPixel(x - yinc, y + xinc, Color.Red);
                    Console.WriteLine((x - yinc-84) + " , " + (y + xinc-76));
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                    return false;
                }
                try
                {
                    diagram.SetPixel(x - yinc, y - xinc, Color.Red);
                    Console.WriteLine((x - yinc-84) + " , " + (y - xinc-76));
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("OUT OF BOUNDS TRY SMALLER RADIUS");
                    return false;
                }
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
               p = 1 - r;
            int w = pictureBox1.Width, h = pictureBox1.Height;
            xc += w / 2;
            yc += h / 2;
          
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            while (x < y)
            {  Console.WriteLine(p + " , " +x+" , "+y);
                if (!DRAW(xc, yc, x, y, diagram))
                {
                    diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    break;
                }
                if (p >= 0)
                {
                    x++;
                    y--;
                    p += 2 * (x - y) + 1;
                }
                else
                {
                    x++;
                    p += 2 * x + 1;
                }

            }
            pictureBox1.Image = diagram;
            Console.WriteLine("new case");
        }
    }
}
