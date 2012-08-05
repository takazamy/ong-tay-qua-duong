using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2.Core
{
    public class DxOffScreenPlainSurface
    {
        private Surface _surface;

        public Surface Surface
        {
            get { return _surface; }
            set { _surface = value; }
        }

        public DxOffScreenPlainSurface(DxInitGraphics graphics, int width, int height)
        {
            SurfaceDescription _desc = new SurfaceDescription();
            _desc.SurfaceCaps.OffScreenPlain = true;
            _desc.Width = width;
            _desc.Height = height;
            _surface = new Surface(_desc, graphics.GraphicsDevice);
        }


    }
}
