using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2.Core
{
    public class AnimationPlayer
    {
        private DxAnimation _animation;

        public DxAnimation Animation
        {
            get { return _animation; }
            set { _animation = value; }
        }
        private AnimationKey _currentKey;

        public AnimationKey CurrentKey
        {
            get { return _currentKey; }
            set { _currentKey = value; }
        }

        public void Play(DxAnimation animation)
        {
            if (this._animation != animation)
            {
                this._animation = animation;
            }
        }

        public void PlayKey(AnimationKey key)
        {
            if (this._currentKey != key)
            {
                this._currentKey = key;
                this._animation.CurrentKey = this._currentKey;
                this._animation.CurrentFrame = this._currentKey._range.First();
                this._animation.IsLoop = this._currentKey._isLoop;
            }
        }


        public void Update(float deltaTime)
        {
            _animation.Update(deltaTime);
        }

        public void Draw(int x, int y, Surface dest)
        {
            _animation.Draw(x, y, dest);
        }
    }
}
