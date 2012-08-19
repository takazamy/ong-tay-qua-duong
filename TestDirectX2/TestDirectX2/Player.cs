using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX.DirectDraw;
using TestDirectX2.Screen;


namespace TestDirectX2
{

    public class Player:Character
    {
        AnimationKey _move;
       
        public Player(float x, float y, int hp, int damage, int power, int moveSpeed, DxInitSprite sprite,int direction):
            base(x,y,hp,damage,power,moveSpeed,sprite,direction)
        {

            _move._range = new List<int>();
            _move._range.Add(1);
            _move._range.Add(2);
            _move._range.Add(3);
            _move._range.Add(4);
            _move._current = _move._range[0];
        }


        public override void Update(double deltaTime, Microsoft.DirectX.DirectInput.KeyboardState keyState, Microsoft.DirectX.DirectInput.MouseState mouseState)
        {
            base.Update(deltaTime, keyState, mouseState);
            Move(keyState);
            //_animation.Update((float)deltaTime);
        }
        public override void Move(Microsoft.DirectX.DirectInput.KeyboardState keyState)
        {
            //base.Move(keyState);
            Boolean _keyDown = false;
            for (int i = 0; i < 256; i++)
            {
                if (_keyState[(Key)i])
                {
                    _keyDown = true;
                }
            }
            if (_keyDown)
            {

                //on move left
                if (_keyState[Key.A])
                {
                    //_state = Status.C_MOVE;
                    PositionX = PositionX - MoveSpeed;
                    if (_move._current >0)
                    {
                        _move._current--;
                    } if (_move._current == 0)
                    {
                        _move._current = _move._range[_move._range.Count - 1];
                    }
                    _animation.CurrentFrame = _move._current;
                }
                

                //on move right

                if (_keyState[Key.D])
                {
                    PositionX = PositionX + MoveSpeed;
                    if (_move._current < _move._range.Count)
                    {
                        _move._current++;
                    }
                    if (_move._current == _move._range.Count)
                    {
                        _move._current = _move._range[0];
                    }
                    _animation.CurrentFrame = _move._current;
                    //_state = Status.C_MOVE;
                }


            }
            else
            {
                _move._current = _move._range[0];
                _animation.CurrentFrame = _move._current;
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
