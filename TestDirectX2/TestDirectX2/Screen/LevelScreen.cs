using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using System.Drawing;
using TestDirectX2.Screen;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2.Screen
{
    public class LevelScreen:DxScreen
    {
        private DxInitImage bg;
        MainGameScreen mainScreen;
        DxInitImage initImage;        
        List<DxScreen> lstScreen;
        List<DxButton> lstButton;
        private Player _player;
        
        public LevelScreen(ScreenManager scrManager, DxInitGraphics graphics, Point location, Size size, Player player) :
            base(scrManager,graphics, location, size)
        {
            _player = player;
            Initialize();
        }
        
        public override void Initialize()
        {
           bg = new DxInitImage("Assets/levelScreen.jpg", _graphics.GraphicsDevice);
           lstScreen = new List<DxScreen>();
           lstButton = new List<DxButton>();
           //_surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
           DxButton playBtn = new DxButton(50, 50, "Assets/levelmap1.png", _graphics.GraphicsDevice, 200, 200);
            lstButton.Add(playBtn);

            playBtn.OnMouseUp = delegate()
            {
                SoundManager.Instance.Stop(SoundManager.SoundType.LevelScreenMusic);
                initImage = new DxInitImage("Assets/map1.jpg", _graphics.GraphicsDevice);
                string configPath = "Assets/level01.xml";
                mainScreen = new MainGameScreen(_scrManager, _graphics, _location, _size, initImage, configPath, _player);
               // _scrManager.Children[TestDirectX2.ScreenManager.GameState.GS_MAIN_GAME] = mainScreen;
                _scrManager[(int)TestDirectX2.ScreenManager.GameState.GS_MAIN_GAME] = mainScreen;
               // lstScreen.Add(mainScreen);
               // _scrManager.Append(mainScreen);
                _scrManager._state = TestDirectX2.ScreenManager.GameState.GS_MAIN_GAME;
                _scrManager.PlayScreen((int)TestDirectX2.ScreenManager.GameState.GS_MAIN_GAME);
            };
            
            
        }

        public override void Update(double deltaTime, Microsoft.DirectX.DirectInput.KeyboardState keyState, Microsoft.DirectX.DirectInput.MouseState mouseState)
        {
            if (SoundManager.Instance.isLoop)
            {
                if (SoundManager.Instance.CheckDuration(SoundManager.SoundType.LevelScreenMusic))
                {
                    SoundManager.Instance.Replay(SoundManager.SoundType.LevelScreenMusic);
                }
            }
            base.Update(deltaTime, keyState, mouseState);
            for (int i = 0; i < lstButton.Count; i++)
            {
                lstButton[i].Update(deltaTime, mouseState);
            }
            
        }
        public override void Draw(double deltaTime)
        {
            SoundManager.Instance.Play(SoundManager.SoundType.LevelScreenMusic);
            SoundManager.Instance.isLoop = true;
            bg.DrawFast(0, 0, base.Surface, DrawFastFlags.Wait);
            for (int i = 0; i < lstButton.Count; i++)
            {
                lstButton[i].DrawFast(base.Surface,DrawFastFlags.Wait);
            }
            base.Draw(deltaTime);
        }


    }
}
