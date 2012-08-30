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
        AnimationKey _stay;
       
        public Player(float x, float y, int hp, int damage, int power, int moveSpeed, DxInitSprite sprite,int direction):
            base(x,y,hp,damage,power,moveSpeed,sprite,direction)
        {
            _moveR = new AnimationKey();
            _moveR._range = new List<int>();
            _moveR._range.Add(1);
            _moveR._range.Add(2);
            _moveR._range.Add(3);
            _moveR._range.Add(4);
            _moveR._range.Add(5);
            _moveR._range.Add(6);
            _moveR._isLoop = true;

            _moveL = new AnimationKey();
            _moveL._range = new List<int>();            
            _moveL._range.Add(7);
            _moveL._range.Add(8);
            _moveL._range.Add(9);
            _moveL._range.Add(10);
            _moveL._range.Add(11);
            _moveL._range.Add(12);
            _moveL._isLoop = true;

            _stay = new AnimationKey();
            _stay._range = new List<int>();
            _stay._range.Add(13);
            _stay._range.Add(14);
            _stay._isLoop = false;

            _aniPlayer.PlayKey(_stay);
           
        }


        public override void Update(double deltaTime, Microsoft.DirectX.DirectInput.KeyboardState keyState, Microsoft.DirectX.DirectInput.MouseState mouseState)
        {
            base.Update(deltaTime, keyState, mouseState);
            Move(keyState);
            Attack(keyState);
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
                _aniPlayer.PlayKey(_stay);               
            }

        }
        public override void Attack(KeyboardState keyState)
        {
            base.Attack(keyState);
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
