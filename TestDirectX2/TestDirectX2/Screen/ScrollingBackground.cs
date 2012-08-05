using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using Microsoft.DirectX.DirectDraw;
using TestDirectX2.Core;
using TestDirectX2;

namespace DirectXForm
{
    public class ScrollingBackground : DxScreen
    {
        DxInitImage bg1, bg2;
        PointF point1, point2;

        private float _moveSpeed = 0;
        public float MoveSpeed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }


        public ScrollingBackground(DxInitGraphics graphics, Point location, Size size)
            :
            base(graphics, location, size)
        {
            bg1 = new DxInitImage("Assets/cave_bg.png", graphics.GraphicsDevice);
            bg2 = new DxInitImage("Assets/cave_bg.png", graphics.GraphicsDevice);

            point1 = new PointF(0, 0);
            point2 = new PointF(800, 0);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            point1 = new PointF(point1.X + _moveSpeed, point1.Y);
            point2 = new PointF(point2.X + _moveSpeed, point2.Y);

            if (point1.X + _size.Width <= 0)
            {
                point1 = new PointF(point2.X + _size.Width, point1.Y);
            }
            if (point2.X + _size.Width <= 0)
            {
                point2 = new PointF(point1.X + _size.Width, point2.Y);
            }
            base.Update(deltaTime);
        }

        public override void Draw(double deltaTime)
        {
            _surface.ColorFill(Color.White);
            if (point1.X < 0)
            {
                int srcW = _size.Width + (int)point1.X;
                int srcX = _size.Width - srcW;
                Rectangle src = new Rectangle(srcX, 0, srcW, _size.Height);
                this._surface.DrawFast(0, (int)point1.Y, bg1.XImage, src, DrawFastFlags.Wait);
            }
            else if (point1.X >= 0 && point1.X < _size.Width)
            {
                int srcW = _size.Width - (int)point1.X;
                Rectangle src = new Rectangle(0, 0, srcW, _size.Height);
                this._surface.DrawFast((int)point1.X, (int)point1.Y, bg1.XImage, src, DrawFastFlags.Wait);
            }

            if (point2.X < 0)
            {
                int srcW = _size.Width + (int)point2.X;
                int srcX = _size.Width - srcW;
                Rectangle src = new Rectangle(srcX, 0, srcW, _size.Height);
                this._surface.DrawFast(0, (int)point2.Y, bg2.XImage, src, DrawFastFlags.Wait);
            }
            else if (point2.X >= 0 && point2.X < _size.Width)
            {
                int srcW = _size.Width - (int)point2.X;
                Rectangle src = new Rectangle(0, 0, srcW, _size.Height);
                this._surface.DrawFast((int)point2.X, (int)point2.Y, bg2.XImage, src, DrawFastFlags.Wait);
            }

            base.Draw(deltaTime);
        }
    }
}
