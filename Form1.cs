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
        Paddle paddle;

        Ball ball;

        Paddle left;

        Paddle right;

        KeyEventArgs keyPressed;

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
            left = new Paddle(0, 128, 100, 10, 6, Keys.W, Keys.S);
            right = new Paddle(paddle2x, 128, 100, 10, 6, Keys.Up, Keys.Down);

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

            //update
            ball.Update(ClientSize);
            

            //draw
            left.Draw(gfx);
            right.Draw(gfx);
            ball.Draw(gfx);

            drawBox.Image = bitmap;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keyPressed = e;
            left.Update(keyPressed, this);
            right.Update(keyPressed, this);
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }

}



