using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectDraw;
using System.Drawing;

namespace TestDirectX2.Core
{
    public class DxInitSprite:DxInitImage
    {
        private int _framewidth;

        public int Framewidth
        {
            get { return _framewidth; }
            set { _framewidth = value; }
        }

        private int _frameheight;

        public int Frameheight
        {
            get { return _frameheight; }
            set { _frameheight = value; }
        }

        private int _rows;

        public int Rows
        {
            get { return _rows; }
           
        }

        private int _columns;

        public int Columns
        {
            get { return _columns; }
            
        }

       

        public int TotalFrame
        {
            get { return _columns * _rows; }
           
        }

        public DxInitSprite(string imagePath, Device graphicDevice, int frameWidth, int frameHeight):base(imagePath, graphicDevice)
        {
            _framewidth = frameWidth;
            _frameheight = frameHeight;
            GetTotalFrame();

        }
        protected void GetTotalFrame() {
            _rows = _sourceImage.Height / _frameheight;
            _columns = _sourceImage.Width / _framewidth;
        }

        public virtual void DrawFast(int x, int y, int frameIndex, Surface destSurface, DrawFastFlags flags)
        {
            int column = (frameIndex - 1) % _columns;
            int row = (frameIndex - 1) / _columns;
            Rectangle srcRect = new Rectangle(column * _framewidth, row * _frameheight, _framewidth, _frameheight);
            destSurface.DrawFast(x, y, _image, srcRect, flags);
        }
    }
}
