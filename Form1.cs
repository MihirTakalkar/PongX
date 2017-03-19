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

        //int paddle1x = 0;
        int paddle2x = 0;
        //int paddle1y = 128;
        //int paddle2y = 128;
        //int paddle1w = 10;
        //int paddle2w = 10;
        //int paddle1h = 100;
        //int paddle2h = 100;
        int score1 = 0;
        int score2 = 0;

        bool w = false;
        bool s = false;
        bool up;

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
            left = new Paddle(0, 128, 100, 10, 6);
            right = new Paddle(paddle2x, 128, 100, 10, 6);



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
            if (ball.Hitbox.IntersectsWith(left.hitbox))
            {
                ball.Speedx = Math.Abs(ball.Speedx);
            }
            if (ball.Hitbox.IntersectsWith(right.hitbox))
            {
                ball.Speedx = -Math.Abs(ball.Speedx);
            }


            ball.Update(ClientSize);
            left.Update(w, s, this);
            right.Update(false, false, this);

            if (ball.HitRight)
            {
                score1++;
            }

            if (ball.HitLeft)
            {
                score2++;
            }

            if (score1 == 10 || score2 == 10)
            {

                timer1.Enabled = false;

                if (score1 == 10)
                {
                    MessageBox.Show("Left Side Wins!");
                }
                else
                {
                    MessageBox.Show("Right Side Wins!");
                }



                ball = new Ball(50, 50, 60, 60, 4, 4);
                left = new Paddle(0, 128, 100, 10, 6);
                right = new Paddle(paddle2x, 128, 100, 10, 6);
                score1 = 0;
                score2 = 0;

                timer1.Enabled = true;

            }


            //draw
            left.Draw(gfx);
            right.Draw(gfx);
            ball.Draw(gfx);
            gfx.DrawString($"Score: {score1}", label1.Font, Brushes.Orange, label1.Location);
            gfx.DrawString($"Score: {score2}", label2.Font, Brushes.Orange, label2.Location);
            gfx.DrawString("PongX", label3.Font, Brushes.Lime, label3.Location);
            drawBox.Image = bitmap;



        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keyPressed = e;

            if (keyPressed.KeyCode == Keys.W)
            {
                w = true;
            }
            if (keyPressed.KeyCode == Keys.S)
            {
                s = true;
            }


            if (keyPressed.KeyCode == Keys.Z)
            {
                score1++;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keyPressed = e;

            if (keyPressed.KeyCode == Keys.W)
            {
                w = false;
            }
            if (keyPressed.KeyCode == Keys.S)
            {
                s = false;
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

       
    }

}



