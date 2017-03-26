using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MihirPongX
{
    public class Paddle
    {
        public int x;
        public int y;
        public int height;
        public int width;
        public int speed;

        public Rectangle Hitbox
        {
            get { return new Rectangle(x, y, width, height); }
        }

        public Paddle(int x, int y, int height, int width, int speed)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.speed = speed;
        }

        public void Update(bool up, bool down, Form currentForm)
        {
            if (up && y >= 0)
            {
                y -= speed;
            }
            if (down && y + height <= currentForm.ClientSize.Height)
            {
                y += speed;
            }

        }






        public void Draw(Graphics gfx)
        {
            gfx.FillRectangle(Brushes.Orange, x, y, width, height);
        }

    }
}
