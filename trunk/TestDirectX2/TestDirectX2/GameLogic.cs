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
        public enum GameState
        {
            RUN = 0,
            EXIT = 1
        }

        private Control _renderTarget;
        private DxInitGraphics _graphics;
        private DxInitKeyboard _keyboard;

        private double _ellapsedMilisec = 0;
        private static int FPS = 60;
        private int _game_fps = 0;
        private int _fps_counter = 0;
        private double _fps_ellapsedMillisec = 0;

        /****** MY GAME'S COMPONENTS*******/
        DxInitSprite _sprite;
        DxAnimation _animation;

        GameState _state = GameState.RUN;

        public GameLogic(Control RenderTarget)
        {
            _renderTarget = RenderTarget;
            _graphics = new DxInitGraphics(_renderTarget);
            _keyboard = new DxInitKeyboard(_renderTarget);
            DxTimer.Init();
            RenderTarget.GotFocus += new EventHandler(target_GotFocus);

        }

        void target_GotFocus(object sender, EventArgs e)
        {
            _graphics.CreateSurfaces();
            _sprite.CreateSurface();
        }

        public void GameLoop()
        {
            DxTimer.Start();
            while (_renderTarget.Created && _state == GameState.RUN)
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
            _sprite = new DxInitSprite("Assets/walk.png", _graphics.GraphicsDevice, 104, 150);
            _animation = new DxAnimation(_sprite, 30, true);
        }

        public void Update(double deltaTime)
        {
            KeyboardState state = _keyboard.State;
            if (state[Key.Escape])
            {
                _state = GameState.EXIT;
            }

            _animation.Update((float)deltaTime);
         //   x++;
        }

        int x = 0;
        public void Draw(double deltaTime)
        {
            _graphics.Clear(Color.CornflowerBlue);


          //  _sprite.DrawFast(x, 50, 1, _graphics.SecondarySurface, DrawFastFlags.Wait);

            _animation.Draw(50, 200, _graphics.SecondarySurface);

            _graphics.SecondarySurface.DrawText(0, 0, "FPS: " + _game_fps, false);

            _graphics.Render();
        }
    }
}
