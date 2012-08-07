﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectInput;

namespace TestDirectX2
{
    public class ScreenManager
    {
        public enum GameState
        {
            GS_SPLASH_SCREEN = 0,
            GS_MENU = 1,
            GS_MAIN_GAME = 2,
            GS_EXIT = 3,
        }

        public GameState _state = GameState.GS_SPLASH_SCREEN;

        List<DxScreen> _children;

        internal List<DxScreen> Children
        {
            get { return _children; }
            
        }

        private DxScreen _currentScreen = null;

        internal DxScreen CurrentScreen
        {
            get { return _currentScreen; }
            set { _currentScreen = value; }
        }

        private int _currentIndex = -1;

        public ScreenManager()
        {
            _children = new List<DxScreen>();
        }

        public void Append(DxScreen screen)
        {
            _children.Add(screen);
        }

        public void PlayScreen(int index)
        {
            _currentScreen = _children[index];
            _currentIndex = index;
        }

        public void NextScreen()
        {
            _currentScreen = _children[++_currentIndex];
        }

        public void PrevScreen()
        {
            _currentScreen = _children[--_currentIndex];
        }

        public void Update(double deltaTime, KeyboardState keyState, MouseState mouseState)
        {
            _currentScreen.Update(deltaTime, keyState,mouseState);
        }

        public void Draw(DxInitGraphics graphics, double deltaTime)
        {
            _currentScreen.Draw(deltaTime);
        }
    }
}
