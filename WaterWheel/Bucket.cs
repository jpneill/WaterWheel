using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WaterWheel
{
    class Bucket
    {
        private float x;
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        private float y;
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        private float width;
        public float Width
        {
            get { return width; }
            set { width = value; }
        }
        private float height;
        public float Height
        {
            get { return height; }
            set { height = value; }
        }
        private float water; // a proportion of bucket height
        public float Water
        {
            get { return water; }
            set { water = value; }
        }
        public Bucket()
        {

        }
        /*
        public Bucket(Graphics g, float scale)
        {
            using (Pen p = new Pen(Color.Black, scale))
            {
                g.DrawRectangle(p, x - 1, y - 1, 2, 2);
                g.FillRectangle(Brushes.Blue, x - 1, y + 1 - water, 2, water);
            }
        } */
        public void Draw(Graphics g, float scale)
        {
            using (Pen p = new Pen(Color.Black, scale))
            {
                g.DrawRectangle(p, x - width/2, y - height/2, width, height);
                g.FillRectangle(Brushes.Blue, x - width/2, y + height/2 - water*(height), width, water*height);
            }
        }
    }
}
