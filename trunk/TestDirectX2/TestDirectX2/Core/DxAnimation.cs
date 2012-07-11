using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2.Core
{
    class DxAnimation
    {
        private DxInitSprite _sprite;

        public DxInitSprite Sprite
        {
            get { return _sprite; }
           
        }

        private float _frameTime;
        private float _ellapseMillisec = 0;

        private bool _isLoop;

        public bool IsLoop
        {
            get { return _isLoop; }
            set { _isLoop = value; }
        }

        private int _currentFrame = 1;

        public int CurrentFrame
        {
            get { return _currentFrame; }
            set { _currentFrame = value; }
        }

        public DxAnimation(DxInitSprite sprite, float frameTime, bool isLoop)
        {
            _sprite = sprite;
            _frameTime = frameTime;
            _isLoop = isLoop;
        }

        public void Update(float deltaTime)
        {
            _ellapseMillisec += deltaTime;
            if (_ellapseMillisec > _frameTime) 
            {
                _ellapseMillisec = 0;
                _currentFrame++;
                if (_currentFrame > _sprite.TotalFrame)
                {
                    _currentFrame = 1;
                }
            }
        }

        public void Draw(int x, int y, Surface destSurface)
        {
            _sprite.DrawFast(x, y, _currentFrame, destSurface, DrawFastFlags.Wait);
        }
    }
}
