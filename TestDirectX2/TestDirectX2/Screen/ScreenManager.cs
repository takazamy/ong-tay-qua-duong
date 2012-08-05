using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;

namespace TestDirectX2
{
    public class ScreenManager
    {
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

        public void Update(double deltaTime)
        {
            _currentScreen.Update(deltaTime);
        }

        public void Draw(DxInitGraphics graphics, double deltaTime)
        {
            _currentScreen.Draw(deltaTime);
        }
    }
}
