using System;
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

        protected Color[,] _colorMap;
        public Color[,] ColorMap {
            get { return _colorMap; } 
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

            Bitmap bmp = new Bitmap(_sourceImage);
            _colorMap = new Color[_sourceImage.Height, _sourceImage.Width];
            for (int y = 0; y < _sourceImage.Height; y++)
            {
                for (int x = 0; x < _sourceImage.Width; x++)
                {
                    _colorMap[y, x] = bmp.GetPixel(x, y);
                }
            }


            _image = new Surface(new Bitmap(_sourceImage), _desc, _graphicDevice);
            ColorKey colorKey = new ColorKey();
            //colorKey.ColorSpaceHighValue = Color.FromArgb(0, 0, 0, 0).ToArgb();
            colorKey.ColorSpaceLowValue = Color.Magenta.ToArgb();//Color.Transparent.ToArgb();
            _image.SetColorKey(ColorKeyFlags.SourceDraw, colorKey);
        }   

        public void DrawFast(int x, int y, Surface destSurface, DrawFastFlags flags) 
        {
            destSurface.DrawFast(x, y, _image, DrawFastFlags.SourceColorKey | flags);
        }
    }
}
