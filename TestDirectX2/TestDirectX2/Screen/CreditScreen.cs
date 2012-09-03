using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using System.Drawing;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2.Screen
{
    public class CreditScreen:DxScreen
    {

        private DxInitImage bg;
        public CreditScreen(ScreenManager scrManager,DxInitGraphics graphics, Point location, Size size):
            base(scrManager,graphics, location, size)
        {
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            bg = new DxInitImage("Assets/CreditSreen.png", _graphics.GraphicsDevice);
        }

        public override void Update(double deltaTime, KeyboardState keyState, MouseState mouseState)
        {
            base.Update(deltaTime, keyState, mouseState);
        }

        public override void Draw(double deltaTime)
        {
            base.Draw(deltaTime);
            bg.DrawFast(0, 0, base.Surface, DrawFastFlags.Wait);
        }

    }
}
