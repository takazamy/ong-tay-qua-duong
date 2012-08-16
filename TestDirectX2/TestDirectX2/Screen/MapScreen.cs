using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using System.Drawing;
using Microsoft.DirectX.DirectInput;

namespace TestDirectX2.Screen
{
    public class MapScreen:DxScreen
    {
        private List<Character> _characterList;
        private Camera _camera;
        private DxInitImage _mapImage;

        public MapScreen(ScreenManager scrManager, DxInitGraphics graphics, Point location, DxInitImage mapImage) :
            base(scrManager, graphics, location, mapImage.SourceImage.Size)
        {
            _mapImage = mapImage;
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            _camera = new Camera(0,0,800,600);
            _surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
            _characterList = new List<Character>();
            _camera.RectBounding = new Rectangle(0, 0, 800, 600);
            //_playBtn = new DxButton(100, 100, new DxInitSprite("Assets/button-sprite.png", _graphics.GraphicsDevice, 150, 50));
            //bg = new DxInitImage("Assets/vietnam_war.jpg", _graphics.GraphicsDevice);

            //_playBtn.OnMouseDown = delegate()
            //{
            //    //Console.WriteLine("Mouse down");
            //    _scrManager._state = TestDirectX2.ScreenManager.GameState.GS_MAIN_GAME;
            //    _scrManager.NextScreen();
            //};

            //_playBtn.OnMouseUp = delegate()
            //{
            //    Console.WriteLine("Mouse up");
            //};
        }
        public override void Update(double deltaTime, KeyboardState keyState, MouseState mouseState)
        {
            // _ellapsedTime += deltaTime;
            //HandleKeyboard(keyState);
            foreach (Character c in _characterList)
            {
                c.Update(deltaTime, keyState, mouseState);
            }

            base.Update(deltaTime, keyState, mouseState);
            //_playBtn.Update(deltaTime, mouseState);

        }

        public override void Draw(double deltaTime)
        {
            foreach (Character c in _characterList)
            {
               
                    c.Draw((int)c.PositionX,(int)c.PositionY,base.Surface);
                
            }
            _graphics.SecondarySurface.DrawFast(0, 0, base.Surface, _camera.RectBounding, Microsoft.DirectX.DirectDraw.DrawFastFlags.Wait);

           // bg.DrawFast(0, 0, base.Surface, DrawFastFlags.Wait);
            //_playBtn.DrawFast(base.Surface, DrawFastFlags.Wait);
            //   .DrawFast(_location.X, _location.Y, bg.XImage, DrawFastFlags.Wait);

            //base.Draw(deltaTime);
        }
    }
}
