using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using System.Drawing;
using Microsoft.DirectX.DirectInput;

namespace TestDirectX2.Screen
{
    public class MainGameScreen : DxScreen
    {
        //private ScrollingBackground scrBackground;
        //private _map;
        private MapScreen _map;
        DxInitImage _mapImage;

        public MainGameScreen(ScreenManager scrManager,DxInitGraphics graphics, Point location, Size size, DxInitImage mapImage) :
            base(scrManager,graphics, location, size)
        {
            _mapImage = mapImage;
            Initialize();
        }
        public override void Initialize()
        {
            base.Initialize();
            _map = new MapScreen(_scrManager, _graphics, _location, _mapImage);
            //_map = new DxInitImage("Assets/map1.png", _graphics.GraphicsDevice);
            _surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
        }

        public override void Update(double deltaTime, KeyboardState keyState, MouseState mouseState)
        {
            // _ellapsedTime += deltaTime;
            //HandleKeyboard(keyState);

            base.Update(deltaTime, keyState, mouseState);
           // _playBtn.Update(deltaTime, mouseState);

        }

        public override void Draw(double deltaTime)
        {
          //  bg.DrawFast(0, 0, base.Surface, DrawFastFlags.Wait);
           // _playBtn.DrawFast(base.Surface, DrawFastFlags.Wait);
            //   .DrawFast(_location.X, _location.Y, bg.XImage, DrawFastFlags.Wait);
            base.Draw(deltaTime);
        }
    }
}
