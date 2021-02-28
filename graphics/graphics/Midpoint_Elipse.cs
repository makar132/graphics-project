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
    public partial class Midpoint_Elipse : Form
    {
        public Midpoint_Elipse()
        {
            InitializeComponent();
        }
        public void DRAW(int x, int y, int xinc, int yinc, Bitmap diagram)
        {
            diagram.SetPixel(x + xinc, y + yinc, Color.Red);
            Console.WriteLine((x + xinc - 84) + " , " + (y + yinc - 76));
            diagram.SetPixel(x + xinc, y - yinc, Color.Red);
            Console.WriteLine((x + xinc - 84) + " , " + (y - yinc - 76));
            diagram.SetPixel(x - xinc, y + yinc, Color.Red);
            Console.WriteLine((x - xinc - 84) + " , " + (y + yinc - 76));
            diagram.SetPixel(x - xinc, y - yinc, Color.Red);
            Console.WriteLine((x - xinc - 84) + " , " + (y - yinc - 76));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int xc = int.Parse(textBox1.Text),
             yc = int.Parse(textBox2.Text),
             rx = int.Parse(textBox3.Text),
             ry = int.Parse(textBox4.Text),
             x,
             y,
             p,
             dx,
             dy;
           
            Bitmap diagram = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            x = 0;
            y = ry;
            p = (int)((ry * ry) - (ry * rx * rx) + (rx * rx * 0.25));
            dx = 2 * ry * ry * x;
            dy = 2 * rx * rx * y;
            int w = pictureBox1.Width, h = pictureBox1.Height;
            xc += w / 2;
            yc += h / 2;
            while (dx < dy)
            {Console.WriteLine(p + " , " +dx+" , "+dy+" , "+x+" , "+y);
                DRAW(xc, yc, x, y, diagram);
                
                if (p >= 0)
                {
                    x++;
                    y--;
                    dx += (2 * ry * ry);
                    dy -= (2 * rx * rx);
                    p += (dx - dy + (ry * ry));
                }
                else
                {
                    x++;
                    dx += (2 * ry * ry);
                    p += (dx + (ry * ry));

                }
            }
            Console.WriteLine("second: ");
            p = (int)(((ry * ry) * (x + 0.5) * (x + 0.5)) + ((rx * rx) * (y - 1) * (y - 1)) - (rx * rx * ry * ry));

            while (y >= 0)
            {
                Console.WriteLine(p + " , " + dx + " , " + dy + " , " + x + " , " + y);
                DRAW(xc, yc, x, y, diagram);
                if (p >= 0)
                {

                    y--;
                    dy -= (2 * rx * rx);
                    p += (-dy + (rx * rx));
                }
                else
                {
                    x++;
                    y--;
                    dx += (2 * ry * ry);
                    dy -= (2 * rx * rx);
                    p += (dx - dy + (rx * rx));


                }
            }

            pictureBox1.Image = diagram;
        }
    }
}
