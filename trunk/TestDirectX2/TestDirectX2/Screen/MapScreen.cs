﻿using System;
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
        private string _configPath;
        private MapLoader _loader;
        //private 

        public MapScreen(ScreenManager scrManager, DxInitGraphics graphics, Point location, DxInitImage mapImage, Player player, string configPath) :
            base(scrManager, graphics, location, mapImage.SourceImage.Size)
        {
            _player = player;
            _mapImage = mapImage;
            _configPath = configPath;
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            _camera = new Camera(0,0,800,600);
            //_surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
            _characterList = new List<Character>();
            _camera.RectBounding = new Rectangle(0, 0, 800, 600);
            _loader = new MapLoader(_graphics);
            _loader.LoadMap(_configPath);
            foreach (Enemy enemy in _loader.Enemies)
            {
                _characterList.Add(enemy);
            }

            //for (int i = 0; i < _loader.Enemies.Count; i++)
            //{
            //    _characterList.Add(_loader.Enemies[i]);
            //}
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
                //Xét điều kiện cho từng Enemy khi di chuyển

               // c.Update(deltaTime, keyState, mouseState);

                float _tempX = c.PositionX;
                c.Update(deltaTime, keyState, mouseState);
                if (c.Direction == 1)
                {
                    if ((c.PositionX + c.Sprite.Framewidth) >= _player.PositionX)
                    {
                        c.Direction = 0;
                    }
                    else if (c.PositionX > (_player.PositionX + _player.Sprite.Framewidth))
                    {
                        c.Direction = -1;
                    }
                }
                else if (c.Direction == -1)
                {
                    if ((_player.PositionX + _player.Sprite.Framewidth) >= c.PositionX)
                    {
                        c.Direction = 0;
                    }
                    else if ((c.PositionX + c.Sprite.Framewidth) < _player.PositionX)
                    {
                        c.Direction = 1;
                    }
                }
                else
                {
                    if ((c.PositionX + c.Sprite.Framewidth) <= _player.PositionX)
                    {
                        c.Direction = 1;
                    }
                    else if (c.PositionX > (_player.PositionX + _player.Sprite.Framewidth))
                    {
                        c.Direction = -1;
                    }
                }
                if ((c.PositionX + c.Sprite.Framewidth >= _mapImage.SourceImage.Width) || c.PositionX < 0)
                {
                    c.PositionX = _tempX;
                    
                }
            }
            //for (int i = 0; i < _characterList.Count; i++)
            //{
            //    _characterList[i].Update(deltaTime, keyState, mouseState);
            //}
            //if ((_player.PositionX + _player.Sprite.Framewidth) < _mapImage.SourceImage.Width )
           // {

            //Xét điều kiện của Player khi di chuyển không ra khỏi màn hình
            float tempX= _player.PositionX;
             _player.Update(deltaTime, keyState, mouseState);
             if( (_player.PositionX + _player.Sprite.Framewidth >=  _mapImage.SourceImage.Width) || _player.PositionX < 0 )
             {
                 _player.PositionX = tempX;

             }
            //}
            
            //Xét điều kiện của camera khi di chuyển
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

                c.Draw((int)c.PositionX, (int)c.PositionY, base.Surface);

            }
            //for (int i = 0; i < _characterList.Count; i++)
            //{
            //    Character c = _characterList[i];
            //    c.Draw((int)c.PositionX, (int)c.PositionY, base.Surface);
            //    c = null;
            //}
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