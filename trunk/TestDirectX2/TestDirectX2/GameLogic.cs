using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectInput;
using System.Drawing;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2
{
    class GameLogic
    {
        //public enum GameState
        //{
        //    GS_SPLASH_SCREEN = 0,
        //    GS_MENU = 1,
        //    GS_MAIN_GAME = 2,
        //    GS_EXIT = 3,
        //}

        private Control _renderTarget;
        private DxInitGraphics _graphics;
        private DxInitKeyboard _keyboard;
        private DxInitMouse _mouse;

        private double _ellapsedMilisec = 0;
        private static int FPS = 60;
        private int _game_fps = 0;
        private int _fps_counter = 0;
        private double _fps_ellapsedMillisec = 0;

        /****** MY GAME'S COMPONENTS*******/

        GameManager _gameManager = null;
        

        //GameState _state = GameState.GS_SPLASH_SCREEN;
        //ScrollingBackground _scrollingBG;

        public GameLogic(Control RenderTarget)
        {
            _renderTarget = RenderTarget;
            _graphics = new DxInitGraphics(_renderTarget);
            _keyboard = new DxInitKeyboard(_renderTarget);
            _mouse = new DxInitMouse(_renderTarget);
            DxTimer.Init();
            RenderTarget.GotFocus += new EventHandler(target_GotFocus);

        }

        void target_GotFocus(object sender, EventArgs e)
        {
            _graphics.CreateSurfaces();
           // _sprite.CreateSurface();
        }

        public void GameLoop()
        {
            DxTimer.Start();
            while (_renderTarget.Created && _gameManager._scrManager._state != TestDirectX2.ScreenManager.GameState.GS_EXIT)
            {
                _ellapsedMilisec += DxTimer.GetElapsedMilliseconds();
                if (_fps_ellapsedMillisec >= 1000.0f)
                {
                    _fps_ellapsedMillisec = 0;
                    _game_fps = _fps_counter;
                    _fps_counter = 0;
                }

                if (_ellapsedMilisec >= (1000.0f / (float)FPS))
                {
                    _fps_ellapsedMillisec += _ellapsedMilisec;
                    Update(_ellapsedMilisec);

                    Draw(_ellapsedMilisec);

                    _fps_counter++;
                    _ellapsedMilisec = 0;
                    DxTimer.Reset();

                }
                Application.DoEvents();
            }
        }

        public void Initialize()
        {
            //_sprite = new DxInitSprite("Assets/walk.png", _graphics.GraphicsDevice, 104, 150);
            //_animation = new DxAnimation(_sprite, 30, true);

           // _screenManager = new ScreenManager();
            _gameManager = new GameManager(_renderTarget, _graphics);
            //_screenManager.Append(new SplashScreen(_graphics, Point.Empty,
               // new Size(800, 600),
               // 5000));

         //   _screenManager.PlayScreen(0);

           // _tiledMap = DxTiledMap.Load("Assets/map01.xml", _graphics);

           // List<DxInitImage> imgs = new List<DxInitImage>();
            //imgs.Add(new DxInitImage("Assets/cave_bg.png", _graphics.GraphicsDevice));
           // imgs.Add(new DxInitImage("Assets/cave_bg.png", _graphics.GraphicsDevice));
            //_scrollingBG = new ScrollingBackground(_graphics, this._renderTarget.Location, this._renderTarget.ClientSize);
            //_scrollingBG.MoveSpeed = -.2f;
        }

        public void Update(double deltaTime)
        {
            KeyboardState keyState = _keyboard.State;
            MouseState mouseState = _mouse.State;
           // HandleKeyboard(keyState);

           // _scrollingBG.Update(deltaTime);
            _gameManager.Update(deltaTime,keyState,mouseState);
            //_screenManager.Update(deltaTime);
         //   x++;
        }

       
        
        public void Draw(double deltaTime)
        {
            _graphics.Clear(Color.CornflowerBlue);


          //  _sprite.DrawFast(x, 50, 1, _graphics.SecondarySurface, DrawFastFlags.Wait);

            //_scrollingBG.Draw(deltaTime);
            _gameManager.Draw(_graphics, deltaTime);
            //_graphics.SecondarySurface.DrawFast(0, 0, _scrollingBG.Surface, DrawFastFlags.Wait);

            _graphics.SecondarySurface.DrawText(0, 0, "FPS: " + _game_fps, false);

            _graphics.Render();
        }
    }
}
