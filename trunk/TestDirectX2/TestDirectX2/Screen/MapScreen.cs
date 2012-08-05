using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using System.Drawing;

namespace TestDirectX2.Screen
{
    public class MapScreen:DxScreen
    {
        public MapScreen(DxInitGraphics graphics, Point location, Size size, double liveTime):
            base(graphics, location, size) { }
    }
}
