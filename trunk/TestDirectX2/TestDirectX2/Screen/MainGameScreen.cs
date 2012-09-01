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
        
        private MapScreen _map;
        DxInitImage _mapImage;
        
        private Player _player;
        string _configPath;

        public MainGameScreen(ScreenManager scrManager,DxInitGraphics graphics, Point location, Size size, DxInitImage mapImage,string configPath, Player player) :
            base(scrManager,graphics, location, size)
        {
            _mapImage = mapImage;
            _player = player;
            _configPath = configPath;
          
            Initialize();
        }
        public override void Initialize()
        {
            base.Initialize();
            _map = new MapScreen(_scrManager, _graphics, _location, _mapImage, _player, _configPath);
           
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
           _map.Draw(deltaTime);
          
        }
    }
}
