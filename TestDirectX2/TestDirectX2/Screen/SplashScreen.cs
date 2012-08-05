using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2
{
    public class SplashScreen:DxScreen

    {
        private double _ellapsedTime = 0;
        private double _liveTime = 0;

        public bool IsDone
        {
            get { return _ellapsedTime >= _liveTime; }
        }

        public SplashScreen(DxInitGraphics graphics, Point location, Size size, double liveTime):
            base(graphics, location, size)
        {
            this._liveTime = liveTime;
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            _surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
        }

        public override void Update(double deltaTime)
        {
            _ellapsedTime += deltaTime;
            base.Update(deltaTime);
        }

        public override void Draw(double deltaTime)
        {
            _graphics.SecondarySurface.DrawFast(_location.X, _location.Y, _surface, DrawFastFlags.Wait);
            base.Draw(deltaTime);
        }
    }
}
