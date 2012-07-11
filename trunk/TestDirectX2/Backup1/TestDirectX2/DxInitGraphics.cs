using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectDraw;
using Microsoft.DirectX;

namespace TestDirectX2
{
    class DxInitGraphics
    {
        protected Control _target = null;
        protected Device _graphicsDevice = null;
        protected Surface _primarySurface = null;
        protected Surface _secondarySurface = null;
        protected Clipper _clipper = null;

        public Device DDDevice
        {
            get 
            {
                return _graphicsDevice;
            }
        }

        public Surface RenderSurface
        {
            get 
            {
                return _secondarySurface;
            }
        }

        public DxInitGraphics(Control RenderControl) 
        {
            //save reference to target control
            this._target = RenderControl;
        }
    }
}
