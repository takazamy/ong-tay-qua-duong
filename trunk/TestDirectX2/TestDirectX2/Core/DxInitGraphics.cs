using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectDraw;
using Microsoft.DirectX;
using System.Drawing;

namespace TestDirectX2
{
    class DxInitGraphics
    {

        private Device _graphicsDevice = null;
        public Device GraphicsDevice
        {
            get { return _graphicsDevice; }
        }

        private Surface _primarySurface = null;
        public Surface PrimarySurface
        {
            get { return _primarySurface; }
        }

        private Surface _secondarySurface = null;
        public Surface SecondarySurface
        {
            get { return _secondarySurface; }
        }

        private Clipper _clipper;
        public Clipper Clipper
        {
            get { return _clipper; }
        }

        private Control _parent;
        public Control Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }


        public DxInitGraphics(Control parent)
        {
            //save reference to target control
            this._parent = parent;
            //Create DirectDraw Device
            _graphicsDevice = new Device();
#if DEBUG
            // In debug mode, use share mode
            _graphicsDevice.SetCooperativeLevel(this._parent, CooperativeLevelFlags.Normal);
#else
            //in release mode, use exclusive
            _graphicsDevice.SetCooperativeLevel(this._parent, CooperativeLevelFlags.FullscreenExclusive);
            _graphicsDevice.SetDisplayMode(800,600,32,60,true);
#endif
            //Create surface

            this.CreateSurfaces();
        }

        /// <summary>
        /// This Function create Surface
        /// </summary>
        public void CreateSurfaces()
        {
            SurfaceDescription _desc = new SurfaceDescription();
            //Create primary surface
            _desc.SurfaceCaps.PrimarySurface = true;
#if !DEBUG
            _desc.SurfaceCaps.Flip = true;
            _desc.SurfaceCaps.Complex = true;
            _desc.BackBufferCount = 1;
#endif
            //create the surface
            _primarySurface = new Surface(_desc, _graphicsDevice);

            _desc.Clear();
#if DEBUG
            //in debug mode, we copy the primary surfaces
            //dimensions and create an offscreen plain 
            _desc.Width = _primarySurface.SurfaceDescription.Width;
            _desc.Height = _primarySurface.SurfaceDescription.Height;
            _desc.SurfaceCaps.OffScreenPlain = true;

            _secondarySurface = new Surface(_desc, _graphicsDevice);
#else
            _desc.SurfaceCaps.BackBuffer = true;
            _secondarySurface = _primarySurface.GetAttachedSurface(_desc.SurfaceCaps);
#endif
            _clipper = new Clipper(_graphicsDevice);
            _clipper.Window = this._parent;
            _primarySurface.Clipper = _clipper;
        }

        /// <summary>
        /// This function use to clear the second surface.
        /// </summary>
        /// <param name="clearColor"></param>
        public void Clear(Color clearColor)
        {
            _secondarySurface.ColorFill(clearColor);
        }

        /// <summary>
        /// This function use to flip the surfaces in FullScreenExclusive mode
        /// </summary>
        public void Render()
        {

            if (!this._parent.Created)
            {
                return;
            }
            if (this._primarySurface == null || this._secondarySurface == null)
            {
                return;
            }
            try
            {
#if DEBUG
                _primarySurface.Draw(_secondarySurface, DrawFlags.Wait);
#else
                _primarySurface.Flip(_secondarySurface, FlipFlags.Wait);
#endif
            }
            catch (SurfaceLostException)
            {
                this.CreateSurfaces();
            }
        }
    }
}
