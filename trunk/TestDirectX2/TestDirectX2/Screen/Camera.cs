using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestDirectX2.Screen
{
    public class Camera
    {
        private Rectangle _rectBounding;
        public Rectangle RectBounding
        {
            get { return _rectBounding; }
            set { _rectBounding = value; }
        }

        private Point _position;
        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public void Update(float gameTime, int player_speed)
        {
            _position.Y += player_speed;
        }
    }
}
