using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using System.Drawing;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2
{
    public class MenuScreen:DxScreen
    {
        private DxInitImage bg;

        public MenuScreen(ScreenManager scrManager,DxInitGraphics graphics, Point location, Size size) :
            base(scrManager,graphics, location, size) 
        {
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            _surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
            bg = new DxInitImage("Assets/vietnam_war.jpg", _graphics.GraphicsDevice);
        }

        public override void Update(double deltaTime, KeyboardState keyState, MouseState mouseState)
        {
           // _ellapsedTime += deltaTime;
           //HandleKeyboard(keyState);

            base.Update(deltaTime, keyState, mouseState);
        }

        public override void Draw(double deltaTime)
        {
            bg.DrawFast(0, 0, base.Surface, DrawFastFlags.Wait);

            //   .DrawFast(_location.X, _location.Y, bg.XImage, DrawFastFlags.Wait);
            base.Draw(deltaTime);
        }
    }
}
