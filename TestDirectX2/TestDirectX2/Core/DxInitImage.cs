﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectDraw;
using System.Drawing;

namespace TestDirectX2.Core
{
    public class DxInitImage
    {
        protected Surface _image;

        public Surface XImage
        {
            get { return _image; }
            set { _image = value; }
        }

        protected String _imagePath;

        public String ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }

        protected Image _sourceImage;

        public Image SourceImage
        {
            get { return _sourceImage; }
            set { _sourceImage = value; }
        }

        protected Device _graphicDevice;

        public Device GraphicDevice
        {
            get { return _graphicDevice; }
            set { _graphicDevice = value; }
        }

        public DxInitImage(String imagePath, Device graphicDevice)
        {
            _imagePath = imagePath;
            _graphicDevice = graphicDevice;

            CreateSurface();
        }

        public void CreateSurface() 
        {
            _sourceImage = Image.FromFile(_imagePath);

            SurfaceDescription _desc = new SurfaceDescription();
            _desc.SurfaceCaps.OffScreenPlain = true;
            _desc.Width = _sourceImage.Width;
            _desc.Height = _sourceImage.Height;

            _image = new Surface(new Bitmap(_sourceImage), _desc, _graphicDevice);
        }

        public void DrawFast(int x, int y, Surface destSurface, DrawFastFlags flags) 
        {
            destSurface.DrawFast(x, y, _image, flags);
        }
    }
}
