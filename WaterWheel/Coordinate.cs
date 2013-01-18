using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterWheel
{
    class Coordinate
    {
        private float _x;
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        private float _y;
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Coordinate()
        {

        }
        public Coordinate(float x, float y)
        {
            _x = x;
            _y = y;
        }
    }
}
