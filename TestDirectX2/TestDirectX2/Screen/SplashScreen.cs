using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectDraw;
using System.Windows.Forms;
using Microsoft.DirectX.DirectInput;

namespace TestDirectX2
{
    public class SplashScreen:DxScreen

    {
        private double _ellapsedTime = 0;
        private double _liveTime = 0;

        private DxInitImage bg;
        

        public bool IsDone
        {
            get { return _ellapsedTime >= _liveTime; }
        }



        public SplashScreen(ScreenManager scrManager, DxInitGraphics graphics, Point location, Size size, double liveTime) :
            base(scrManager,graphics, location, size)
        {
           
           
           // _surface.DrawFast(_location.X, _location.Y, bg.XImage, DrawFastFlags.Wait);
            this._liveTime = liveTime;
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            _surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
            bg = new DxInitImage("Assets/SplashScreen.png", _graphics.GraphicsDevice);
        }

        public override void Update(double deltaTime, KeyboardState keyState, MouseState mouseState)
        {
            _ellapsedTime += deltaTime;
            if (IsDone)
            {
                _scrManager._state = TestDirectX2.ScreenManager.GameState.GS_MENU;
                _scrManager.NextScreen();
            }

            HandleKeyboard(keyState);
            HandleMouse(mouseState);
            base.Update(deltaTime, keyState, mouseState);
        }

        public void HandleKeyboard(KeyboardState keyState)
        {
            if (keyState[Key.Escape])
            {
                _scrManager._state = TestDirectX2.ScreenManager.GameState.GS_MENU;
                _scrManager.NextScreen();
            }
        }

        public void HandleMouse(MouseState mouseState)
        {
            if (mouseState.GetMouseButtons()[0] !=0 )
            {
                _scrManager._state = TestDirectX2.ScreenManager.GameState.GS_MENU;
                _scrManager.NextScreen();
            }

        }
        public override void Draw(double deltaTime)
        {
            bg.DrawFast(0, 0, base.Surface, DrawFastFlags.Wait);
                
             //   .DrawFast(_location.X, _location.Y, bg.XImage, DrawFastFlags.Wait);
            base.Draw(deltaTime);
        }
    }
}
