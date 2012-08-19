using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;

using Microsoft.DirectX.DirectDraw;

using Microsoft.DirectX.DirectInput;


namespace TestDirectX2
{
     
    public class Enemy:Character
    {


        AnimationKey _moveR;
        AnimationKey _moveL;
        AnimationKey _stay;
        public Enemy(float x, float y, int hp, int damage, int power, int moveSpeed, DxInitSprite sprite, int direction) :
            base(x, y, hp,damage, power, moveSpeed, sprite, direction)
        {
            _moveR._range = new List<int>();
            _moveR._range.Add(1);
            _moveR._range.Add(2);
            _moveR._range.Add(3);
            _moveR._range.Add(4);
            _moveR._range.Add(5);
            _moveR._range.Add(6);
            _moveR._current = _moveR._range[0];

            _moveL._range = new List<int>();
            _moveL._range.Add(7);
            _moveL._range.Add(8);
            _moveL._range.Add(9);
            _moveL._range.Add(10);
            _moveL._range.Add(11);
            _moveL._range.Add(12);
            _moveL._current = _moveL._range[0];

            _stay._range = new List<int>();
            _stay._range.Add(13);
            _stay._range.Add(14);
            _stay._current = _stay._range[(_direction - 1) >= 0 ? 0 : 1];
            _animation.CurrentFrame = _stay._current;
        }

        public override void Update(double deltaTime, Microsoft.DirectX.DirectInput.KeyboardState keyState, Microsoft.DirectX.DirectInput.MouseState mouseState)
        {
            base.Update(deltaTime, keyState, mouseState);
            Move(keyState);
        }

        public override void Move(KeyboardState keyState)
        {
            //throw new NotImplementedException();
            //this._direction = direction;
            
            if (Direction == -1)
            {
                PositionX = PositionX - MoveSpeed;

                if (_moveL._current < 12)
                {
                    _moveL._current++;
                } if (_moveL._current == 12)
                {
                    _moveL._current = _moveL._range[0];
                }
                _animation.CurrentFrame = _moveL._current;
                _stay._current = _stay._range[(_direction - 1) >= 0 ? 0 : 1];
            }
            if (Direction == 1)
            {
                PositionX = PositionX + MoveSpeed;
                if (_moveR._current < _moveR._range.Count)
                {
                    _moveR._current++;
                }
                if (_moveR._current == _moveR._range.Count)
                {
                    _moveR._current = _moveR._range[0];
                }
                _animation.CurrentFrame = _moveR._current;
                _stay._current = _stay._range[(_direction - 1) >= 0 ? 0 : 1];
            }
            if (Direction == 0)
            {
                PositionX = PositionX;
                _animation.CurrentFrame = _stay._current;
            } 
        }
        public override void Attack()
        {
            base.Attack();
        }
        public override void Draw(int x, int y, Surface surface)
        {
            base.Draw(x,y,surface);
            Animation.Draw(x, y, surface);
        }
    }
}
