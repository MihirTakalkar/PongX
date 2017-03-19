using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MihirPongX
{
    class Ball
    {
        //variables
        int x;
        int y;
        int height;
        int width;
        public int Speedx;
        public int Speedy;

        public Rectangle Hitbox;

        public bool HitLeft;
        public bool HitRight;

        public Ball(int x, int y, int width, int height, int speedx, int speedy)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.Speedx = speedx;
            this.Speedy = speedy;

            Hitbox = new Rectangle(x, y, width, height);
        }


        public void Update(Size ClientSize)
        {
            x += Speedx;
            y += Speedy;

            Hitbox.X = x;
            Hitbox.Y = y;

            HitRight = false;
            HitLeft = false;

            if (y + height > ClientSize.Height)
            {
                Speedy *= -1;
            }
            if (y < 0)

            {
                Speedy *= -1;
            }

            if (x + width > ClientSize.Width)

            {
                Speedx *= -1;
                HitRight = true;
            }
            if (x < 0)
            {
                Speedx *= -1;
                HitLeft = true;
            }
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(Brushes.Green, x, y, height, width);
            
        }


    }
}