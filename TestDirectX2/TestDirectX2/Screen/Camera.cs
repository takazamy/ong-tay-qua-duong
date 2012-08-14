using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TestDirectX2.Core;

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

        public Camera(Rectangle rectBounding) 
        {
            
            _rectBounding = rectBounding;
            _position = _rectBounding.Location;
        }

        public Camera(Point _point, Size _size) 
        {
            _rectBounding = new Rectangle(_point, _size);
            _position = _point;
           
        }

        public Camera(int x, int y, int width, int height)
        {
            _rectBounding = new Rectangle(x, y, width, height);
            _position = new Point(x, y);
        }

        public void Update(float gameTime, int player_speed)
        {
            _position.X += player_speed;
        }

      
        
    }
}
