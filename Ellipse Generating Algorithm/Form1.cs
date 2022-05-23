using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ellipse_Generating_Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(xTextBox.Text);
            int y = Convert.ToInt32(yTextBox.Text);

            int rx = Convert.ToInt32(rxTextBox.Text);
            int ry = Convert.ToInt32(ryTextBox.Text);

            DrawEllipse(x, y, rx, ry);

        }

        private void DrawEllipse(int xCen, int yCen, int Rx, int Ry)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            int Rx2 = Rx * Rx;
            int Ry2 = Ry * Ry;
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;
            int px = 0;
            int p;
            int y = Ry;
            int py = twoRx2 * y;
            int x = 0;
            p = (int)Math.Round(Ry2 - (Rx2 * Ry)+(0.25*Rx2));
            while (px < py)
            {
                x++;
                px += twoRy2;
                if (p < 0)
                {
                    p += twoRy2 + px;
                }else
                {
                    y--;
                    py -= twoRx2;
                    p += Ry2 + px - py;

                }
                
                bitmap.SetPixel(xCen + x, yCen + y, Color.Red);
                bitmap.SetPixel(xCen - x, yCen + y, Color.Red);
                bitmap.SetPixel(xCen + x, yCen - y, Color.Red);
                bitmap.SetPixel(xCen - x, yCen - y, Color.Red);

            }
            while (y > 0)
            {
                y--;
                py -= twoRx2;
                if (p > 0)
                {
                    p += Rx2 - py;
                }
                else
                {
                    x++;
                    px += twoRy2;
                    p += Rx2 - py + px;
                }
                bitmap.SetPixel(xCen + x, yCen + y, Color.Red);
                bitmap.SetPixel(xCen - x, yCen + y, Color.Red);
                bitmap.SetPixel(xCen + x, yCen - y, Color.Red);
                bitmap.SetPixel(xCen - x, yCen - y, Color.Red);

            }
            Picture.Image = bitmap;
        }

        private void plotPoint(int xCen, int yCen, int x, int y)
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            bitmap.SetPixel(xCen + x, yCen + y,Color.Red);
            bitmap.SetPixel(xCen - x, yCen + y, Color.Red);
            bitmap.SetPixel(xCen + x, yCen - y, Color.Red);
            bitmap.SetPixel(xCen - x, yCen - y, Color.Red);

            Picture.Image = bitmap;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Picture.Image = null;
            xTextBox.Clear();
            yTextBox.Clear();
            rxTextBox.Clear();
            ryTextBox.Clear();
        }
    }
}
