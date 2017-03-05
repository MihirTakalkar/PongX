using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MihirPongX
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics gfx;


        Ball ball;

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

            ball = new Ball(50, 50, 60, 60, 4, 4);

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


            ball.Update(ClientSize);

            //Paddle 1
            gfx.FillRectangle(Brushes.Orange, paddle1x, paddle1y, paddle1w, paddle1h);




            //Paddle 2
            gfx.FillRectangle(Brushes.Orange, paddle2x, paddle2y, paddle2w, paddle2h);

            ball.Draw(gfx);

            drawBox.Image = bitmap;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && paddle1y + paddle1h <= ClientSize.Height)
            {
                paddle1y += 6;
            }
            if (e.KeyCode == Keys.W && paddle1y >= 0)
            {
                paddle1y -= 6;
            }
            if (e.KeyCode == Keys.Down && paddle2y + paddle2h <= ClientSize.Height)
            {
                paddle2y += 6;
            }
            if (e.KeyCode == Keys.Up && paddle2y >= 0)
            {
                paddle2y -= 6;
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }

}



