﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using System.Drawing;

namespace TestDirectX2.Screen
{
    public class LevelScreen:DxScreen
    {
        MainGameScreen mainScreen;
        DxInitImage initImage;
        Point pX;
        Point pY;
        List<DxScreen> lstScreen;
        List<DxButton> lstButton;
        
        
        public LevelScreen(ScreenManager scrManager, DxInitGraphics graphics, Point location, Size size) :
            base(scrManager,graphics, location, size)
        {
            Initialize();
        }
        
        public override void Initialize()
        {
           lstScreen = new List<DxScreen>();
           lstButton = new List<DxButton>();
           _surface.ColorFill(Color.FromArgb(0, 255, 0, 255));
            DxButton playBtn = new DxButton(10, 10, "Assets/button-sprite.png", _graphics.GraphicsDevice, 50, 50);
            lstButton.Add(playBtn);

            playBtn.OnMouseDown = delegate()
            {
                initImage = new DxInitImage("Assets/map1.png", _graphics.GraphicsDevice);
                mainScreen = new MainGameScreen(_scrManager, _graphics, _location, _size, initImage);
                lstScreen.Add(mainScreen);
                _scrManager.Append(mainScreen);
                _scrManager._state = TestDirectX2.ScreenManager.GameState.GS_MAIN_GAME;
                _scrManager.NextScreen();
            };
            
            
        }

        public override void Update(double deltaTime, Microsoft.DirectX.DirectInput.KeyboardState keyState, Microsoft.DirectX.DirectInput.MouseState mouseState)
        {
            base.Update(deltaTime, keyState, mouseState);
            for (int i = 0; i < lstButton.Count; i++)
            {
                lstButton[i].Update(deltaTime, mouseState);
            }
            
        }
        public override void Draw(double deltaTime)
        {
            
            for (int i = 0; i < lstButton.Count; i++)
            {
                lstButton[i].DrawFast(base.Surface,Microsoft.DirectX.DirectDraw.DrawFastFlags.Wait);
            }
            base.Draw(deltaTime);
        }

    }
}
