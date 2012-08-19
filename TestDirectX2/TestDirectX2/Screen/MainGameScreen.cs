using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using System.Drawing;
using Microsoft.DirectX.DirectInput;

namespace TestDirectX2.Screen
{
    public class MainGameScreen : DxScreen
    {
        //private ScrollingBackground scrBackground;
        //private _map;
        private MapScreen _map;
        DxInitImage _mapImage;
        //private List<Character> _characterList;
        //private Camera _camera;
        //private MapLoader _loader;
        private Player _player;
        string _configPath;

        public MainGameScreen(ScreenManager scrManager,DxInitGraphics graphics, Point location, Size size, DxInitImage mapImage,string configPath, Player player) :
            base(scrManager,graphics, location, size)
        {
            _mapImage = mapImage;
            _player = player;
            _configPath = configPath;
           // _loader = new MapLoader();
           // _loader.LoadMap(configPath);
            Initialize();
        }
        public override void Initialize()
        {
            base.Initialize();
            _map = new MapScreen(_scrManager, _graphics, _location, _mapImage, _player, _configPath);
           
            //_camera = new Camera(0, 0, 800, 600);
            ////_surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
            //_characterList = new List<Character>();
            //_camera.RectBounding = new Rectangle(0, 0, 800, 600);
            //_map = new DxInitImage("Assets/map1.png", _graphics.GraphicsDevice);
            _surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
        }

        public override void Update(double deltaTime, KeyboardState keyState, MouseState mouseState)
        {
            // _ellapsedTime += deltaTime;
            //HandleKeyboard(keyState);
            _map.Update(deltaTime, keyState, mouseState);
            base.Update(deltaTime, keyState, mouseState);
           // _playBtn.Update(deltaTime, mouseState);

        }

        public override void Draw(double deltaTime)
        {
          //  bg.DrawFast(0, 0, base.Surface, DrawFastFlags.Wait);
           // _playBtn.DrawFast(base.Surface, DrawFastFlags.Wait);
            //   .DrawFast(_location.X, _location.Y, bg.XImage, DrawFastFlags.Wait);
            //_map.Draw(deltaTime);
            //foreach (Character c in _characterList)
            //{
            //    c.Draw((int)c.PositionX, (int)c.PositionY, base.Surface);
            //}
            //_graphics.SecondarySurface.DrawFast(0, 0, base.Surface, _camera.RectBounding, Microsoft.DirectX.DirectDraw.DrawFastFlags.Wait);

            _map.Draw(deltaTime);
           // base.Draw(deltaTime);
        }
    }
}
