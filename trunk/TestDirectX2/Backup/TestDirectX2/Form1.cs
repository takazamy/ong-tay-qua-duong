using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2
{
    public partial class Form1 : Form
    {
        private Device _graphicDevice = null;
        private SurfaceDescription _desc = null;
        private Surface _primarySurface = null;
        private Surface _secondarySurface = null;
        private Clipper _clipper = null;
        public Form1()
        {
            InitializeComponent();
            this.Show();
            Initialize();
            System.Threading.Thread.Sleep(5000);
        }

        public void Initialize() 
        {

            _graphicDevice = new Device();
            

            //Init Graphic Device
#if DEBUG
            _graphicDevice.SetCooperativeLevel(this, CooperativeLevelFlags.Normal);
            
#else
            _graphicDevice.SetCooperativeLevel(this, CooperativeLevelFlags.FullscreenExclusive);
            _graphicDevice.SetDisplayMode(800, 600, 32, 60, true);
                        
#endif
            CreateSurface();
#if DEBUG
            _secondarySurface.ColorFill(Color.Aquamarine);
#else
            _secondarySurface.ColorFill(Color.Blue);
#endif
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
                this.CreateSurface();
            }
        }

        public void CreateSurface() 
        {
            //Init Surfaces
            //Primary Surface
            _desc = new SurfaceDescription();
            _desc.SurfaceCaps.PrimarySurface = true;

#if !DEBUG
            _desc.SurfaceCaps.Flip = true;
            _desc.SurfaceCaps.Complex = true;
            _desc.BackBufferCount = 1;

#endif
            _primarySurface = new Surface(_desc, _graphicDevice);

            //Secondary Surface
            _desc.Clear();

#if DEBUG
            _desc.Width = _primarySurface.SurfaceDescription.Width;
            _desc.Height = _primarySurface.SurfaceDescription.Height;
            _desc.SurfaceCaps.OffScreenPlain = true;
            _secondarySurface = new Surface(_desc, _graphicDevice);
           
#else
            _desc.SurfaceCaps.BackBuffer = true;
           _secondarySurface = _primarySurface.GetAttachedSurface(_desc.SurfaceCaps);
#endif

            //Init Clipper

            _clipper = new Clipper(_graphicDevice);
            _clipper.Window = this;
            _primarySurface.Clipper = this._clipper;

           
        }
    }
}
