using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using System.Drawing;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2
{
    public class MenuScreen:DxScreen
    {
        private DxInitImage bg;
        private DxInitImage credit;
        private DxInitImage howtoplay;
        private DxButton _playBtn = null;
        private DxButton _exitBtn = null;
        private DxButton _creditBtn = null;
        private DxButton _howtoplayBtn = null;
        private int _onCredit = -1;
        private int _onHTP = -1;
        public MenuScreen(ScreenManager scrManager,DxInitGraphics graphics, Point location, Size size) :
            base(scrManager,graphics, location, size) 
        {
            Initialize();
            
        }

        public override void Initialize()
        {
            base.Initialize();
            //_surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
            _playBtn = new DxButton(600, 300, new DxInitSprite("Assets/NewGame.png", _graphics.GraphicsDevice, 150, 50));
            _creditBtn = new DxButton(600, 350, new DxInitSprite("Assets/cRedit.png", _graphics.GraphicsDevice, 150, 50));
            _exitBtn = new DxButton(600, 450, new DxInitSprite("Assets/EXIT.png", _graphics.GraphicsDevice, 150, 50));
            _howtoplayBtn = new DxButton(600, 400, new DxInitSprite("Assets/HowToPlay.png", _graphics.GraphicsDevice, 150, 50));
            bg = new DxInitImage("Assets/MenuScreen.png", _graphics.GraphicsDevice);
            credit = new DxInitImage("Assets/CreditSreen.png", _graphics.GraphicsDevice);
            howtoplay = new DxInitImage("Assets/howtoplayScreen.png", _graphics.GraphicsDevice);

            _playBtn.OnMouseDown = delegate()
            {
                //Console.WriteLine("Mouse down");
               
            };

            _playBtn.OnMouseUp = delegate()
            {
                SoundManager.Instance.Stop(SoundManager.SoundType.MenuScreenMusic);
                _scrManager._state = ScreenManager.GameState.GS_LEVEL;
                _scrManager.PlayScreen((int)ScreenManager.GameState.GS_LEVEL);
              //  Console.WriteLine("Mouse up");
            };

            _exitBtn.OnMouseUp = delegate()
            {
                _scrManager._state = ScreenManager.GameState.GS_EXIT;
               // _scrManager.NextScreen();
            };

            _creditBtn.OnMouseUp = delegate()
            {
                //_scrManager._state = ScreenManager.GameState.GS_CREDIT;
                //_scrManager.PlayScreen((int)ScreenManager.GameState.GS_CREDIT);
                _onCredit *= -1;
                _onHTP = -1;
            };

            _howtoplayBtn.OnMouseUp = delegate()
            {
                //_scrManager._state = ScreenManager.GameState.GS_CREDIT;
                //_scrManager.PlayScreen((int)ScreenManager.GameState.GS_CREDIT);
                _onHTP *= -1;
                _onCredit = -1;
            };
        }

        public override void Update(double deltaTime, KeyboardState keyState, MouseState mouseState)
        {
           // _ellapsedTime += deltaTime;
           //HandleKeyboard(keyState);
            if (SoundManager.Instance.isLoop)
            {
                if (SoundManager.Instance.CheckDuration(SoundManager.SoundType.MenuScreenMusic))
                {
                    SoundManager.Instance.Replay(SoundManager.SoundType.MenuScreenMusic);
                }
            }
            base.Update(deltaTime, keyState, mouseState);
            _playBtn.Update(deltaTime, mouseState);
            _exitBtn.Update(deltaTime, mouseState);
            _creditBtn.Update(deltaTime, mouseState);
            _howtoplayBtn.Update(deltaTime, mouseState);
        }   
                    
        public override void Draw(double deltaTime)
        {
            SoundManager.Instance.Play(SoundManager.SoundType.MenuScreenMusic);
            SoundManager.Instance.isLoop = true;
            bg.DrawFast(0, 0, base.Surface, DrawFastFlags.Wait);
            _playBtn.DrawFast(base.Surface, DrawFastFlags.Wait);
            _exitBtn.DrawFast(base.Surface, DrawFastFlags.Wait);
            _creditBtn.DrawFast(base.Surface, DrawFastFlags.Wait);
            _howtoplayBtn.DrawFast(base.Surface, DrawFastFlags.Wait);
            if (_onCredit > 0)
            {
                credit.DrawFast(200, 300, base.Surface, DrawFastFlags.Wait);
            }
            if (_onHTP > 0)
            {
                howtoplay.DrawFast(200, 300, base.Surface, DrawFastFlags.Wait);
            }
            //   .DrawFast(_location.X, _location.Y, bg.XImage, DrawFastFlags.Wait);
            base.Draw(deltaTime);
        }
    }
}
