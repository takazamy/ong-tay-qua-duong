using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TestDirectX2.Core;

namespace TestDirectX2.Screen
{
    public class EndGameScreen:DxScreen
    {
        public EndGameScreen(ScreenManager scrManager,DxInitGraphics graphics, Point location, Size size):
            base(scrManager,graphics, location, size) { }
    }
}
