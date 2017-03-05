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
        int speedx;
        int speedy;


        public Ball(int x, int y, int width, int height, int speedx, int speedy)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.speedx = speedx;
            this.speedy = speedy; 
        }
        

        public void Update(Size ClientSize)
        {
            x += speedx;
            y += speedy;

            if (y + height > ClientSize.Height)
            {
                speedy *= -1;
            }
            if (y < 0)

            {
                speedy *= -1;
            }

            if (x + width > ClientSize.Width)

            {
                speedx *= -1;
            }
            if (x < 0)
            {
                speedx *= -1;
            }
        }

        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(Brushes.Green, x, y, height, width);
        }


    }
}