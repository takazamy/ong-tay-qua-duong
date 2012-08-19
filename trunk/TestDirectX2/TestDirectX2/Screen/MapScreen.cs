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
    public class MapScreen:DxScreen
    {
        private List<Character> _characterList;
        private Camera _camera;
        private DxInitImage _mapImage;
        private Player _player;

        public MapScreen(ScreenManager scrManager, DxInitGraphics graphics, Point location, DxInitImage mapImage, Player player) :
            base(scrManager, graphics, location, mapImage.SourceImage.Size)
        {
            _player = player;
            _mapImage = mapImage;
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            _camera = new Camera(0,0,800,600);
            //_surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
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
            //if ((_player.PositionX + _player.Sprite.Framewidth) < _mapImage.SourceImage.Width )
           // {
            float tempX= _player.PositionX;
             _player.Update(deltaTime, keyState, mouseState);
             if( (_player.PositionX + _player.Sprite.Framewidth >=  _mapImage.SourceImage.Width) || _player.PositionX < 0 )
             {
                 _player.PositionX = tempX;
             }
            //}
            
            if (_player.PositionX + _camera.RectBounding.Width / 2 <=  _mapImage.SourceImage.Width)
            {
                _camera.Update((float)deltaTime, (int)_player.PositionX, true);
            }
            
            base.Update(deltaTime, keyState, mouseState);
            //_playBtn.Update(deltaTime, mouseState);

        }

        public override void Draw(double deltaTime)
        {
            _mapImage.DrawFast(0, 0, base.Surface, DrawFastFlags.Wait);
            foreach (Character c in _characterList)
            {

                    c.Draw((int)c.PositionX,(int)c.PositionY,base.Surface);

            }
            //if( ((_player.PositionX + _player.Sprite.Framewidth) < _mapImage.SourceImage.Width) || _player.PositionX >= 0)
            //{
                _player.Draw((int)_player.PositionX, (int)_player.PositionY, base.Surface);
            //}
            
            _graphics.SecondarySurface.DrawFast(0, 0, base.Surface, _camera.RectBounding, DrawFastFlags.Wait);

           // bg.DrawFast(0, 0, base.Surface, DrawFastFlags.Wait);
            //_playBtn.DrawFast(base.Surface, DrawFastFlags.Wait);
            //   .DrawFast(_location.X, _location.Y, bg.XImage, DrawFastFlags.Wait);

            //base.Draw(deltaTime);
        }
    }
}
