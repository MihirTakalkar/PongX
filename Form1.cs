using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MihirPongX
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics gfx;

        int Ballx = 50;
        int Bally = 50;
        int Ballh = 60;
        int Ballw = 60;
        int speedx = 2;
        int speedy = 2;
        int paddle1x = 0;
        int paddle2x = 0;
        int paddle1y = 128;
        int paddle2y = 128;
        int paddle1w = 10;
        int paddle2w = 10;
        int paddle1h = 100;
        int paddle2h = 100;



        public Form1()
        {
            //Bitmap
            InitializeComponent();
            bitmap = new Bitmap(drawBox.Width, drawBox.Height);
            gfx = Graphics.FromImage(bitmap);
            drawBox.Image = bitmap;
            paddle2x = ClientSize.Width - 10;

            this.Hide();
            Form2 intro = new Form2();
            intro.ShowDialog();
            this.Show();
            timer1.Enabled = true;

        }


        //Location Label
        private void positionLabel_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void drawBox_MouseMove(object sender, MouseEventArgs e)
        {
            positionLabel.Text = e.Location.ToString();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            gfx.Clear(Color.Transparent);
            Ballx += speedx;
            Bally += speedy;

            if (Bally + Ballh > ClientSize.Height)
            {
                speedy *= -1;
            }
            if (Bally < 0)

            {
                speedy *= -1;
            }

            if (Ballx + Ballw > ClientSize.Width)

            {
                speedx *= -1;
            }
            if (Ballx < 0)
            {
                speedx *= -1;
            }
            gfx.FillEllipse(Brushes.Green, Ballx, Bally, Ballh, Ballw);
            //Paddle 1

            gfx.FillRectangle(Brushes.Orange, paddle1x, paddle1y, paddle1w, paddle1h);


            //Paddle 2
            gfx.FillRectangle(Brushes.Orange, paddle2x, paddle2y, paddle2w, paddle2h);
            drawBox.Image = bitmap;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && paddle1y + paddle1h <= ClientSize.Height)
            {
                paddle1y += 4;
            }
            if (e.KeyCode == Keys.W && paddle1y >= 0)
            {
                paddle1y -= 4;
            }
            if (e.KeyCode == Keys.Down && paddle2y + paddle2h <= ClientSize.Height)
            {
                paddle2y += 4;
            }
            if (e.KeyCode == Keys.Up && paddle2y >= 0)
            {
                paddle2y -= 4;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }

}



