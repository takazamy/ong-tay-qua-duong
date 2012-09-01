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
        AnimationKey _moveR;
        AnimationKey _moveL;
        AnimationKey _attL;
        AnimationKey _attR;
        AnimationKey _stayL;
        AnimationKey _stayR;

        public double _timer = 0;
       

        public Player(float x, float y, int hp, int damage, int power, int moveSpeed, DxInitSprite sprite,int direction):
            base(x,y,hp,damage,power,moveSpeed,sprite,direction)
        {
            _timer = _atkTime;
            _moveR = new AnimationKey();
            _moveR._range = new List<int>();
            _moveR._range.Add(1);
            _moveR._range.Add(2);
            _moveR._range.Add(3);
            _moveR._range.Add(4);
            _moveR._range.Add(5);
            //_moveR._range.Add(6);
            _moveR._isLoop = true;

            _moveL = new AnimationKey();
            _moveL._range = new List<int>();            
            _moveL._range.Add(6);
            _moveL._range.Add(7);
            _moveL._range.Add(8);
            _moveL._range.Add(9);
            _moveL._range.Add(10);
           // _moveL._range.Add(12);
            _moveL._isLoop = true;

            _attR = new AnimationKey();
            _attR._range = new List<int>();
            _attR._range.Add(11);
            _attR._range.Add(12);
            _attR._range.Add(13);
            _attR._range.Add(14);
            _attR._isLoop = false;

            _attL = new AnimationKey();
            _attL._range = new List<int>();
            _attL._range.Add(16);
            _attL._range.Add(17);
            _attL._range.Add(18);
            _attL._range.Add(19);
            _attL._isLoop = false;

            _stayR = new AnimationKey();
            _stayR._range = new List<int>();
            _stayR._range.Add(21);
            _stayR._range.Add(22);
            _stayR._isLoop = true;
            _aniPlayer.PlayKey(_stayR);

            _stayL = new AnimationKey();
            _stayL._range = new List<int>();
            _stayL._range.Add(26);
            _stayL._range.Add(27);
            _stayL._isLoop = true;

           
        }


        public override void Update(double deltaTime, Microsoft.DirectX.DirectInput.KeyboardState keyState, Microsoft.DirectX.DirectInput.MouseState mouseState)
        {
            if (_startTimerCount)
            {
                _timer += deltaTime;
                if (_timer > _atkTime)
                {
                    _timer = 0;
                    _startTimerCount = false;
                    _isInAtt = false;
                }
            }
            
            base.Update(deltaTime, keyState, mouseState);
            Attack(deltaTime, keyState);
            
            Move(keyState);
            
            _aniPlayer.Update((float)deltaTime);
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
                    _direction = -1;
                    PositionX = PositionX - MoveSpeed;
                    _aniPlayer.PlayKey(_moveL);
                }
                

                //on move right

                if (_keyState[Key.D])
                {
                    _direction = 1;
                    PositionX = PositionX + MoveSpeed;
                    _aniPlayer.PlayKey(_moveR);
                    //_state = Status.C_MOVE;
                }


            }
            else
            {
                if (!_isInAtt)
                {
                    if (_direction == 1)
                    {
                        _aniPlayer.PlayKey(_stayR);
                    }
                    else
                    {
                        _aniPlayer.PlayKey(_stayL);
                    }
                    
                }
               
            }

        }
        public override void Attack(double deltaTime, KeyboardState keyState)
        {
            base.Attack(deltaTime,keyState);
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
                if (_keyState[Key.J])
                {
                    if (!_isInAtt )
                    {
                        _isInAtt = true;
                        _startTimerCount = true;
                        if (_direction == 1)
                        {
                            _aniPlayer.PlayKey(_attR);
                            
                        }
                        else
                        {
                            _aniPlayer.PlayKey(_attL);
                           
                        } 
                    }
                    
                }
            }

        }
        public override void Draw(int x, int y, Surface surface)
        {
           base.Draw(x,y,surface);
           _aniPlayer.Draw(x, y, surface);
        }
    }
}
