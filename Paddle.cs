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
        Keys upKey;
        Keys downKey;

        public Paddle(int x, int y, int height, int width, int speed, Keys upKey, Keys downKey)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.speed = speed;
            this.upKey = upKey;
            this.downKey = downKey;
        }

        public void Update(KeyEventArgs e, Form currentForm)
        {
            if (e.KeyCode == upKey && y >= 0)
            {
                y -= speed;
            }
            if (e.KeyCode == downKey && y + height <= currentForm.ClientSize.Height)
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
