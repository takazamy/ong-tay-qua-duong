﻿using System;
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
        AnimationKey _stayL;
        AnimationKey _stayR;
        
        public Enemy(float x, float y, int hp, int damage, int power, int moveSpeed, DxInitSprite sprite, int direction) :
            base(x, y, hp,damage, power, moveSpeed, sprite, direction)
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

            _stayL = new AnimationKey();
            _stayL._range = new List<int>();
            _stayL._range.Add(13);
            _stayR = new AnimationKey();
            _stayR._range = new List<int>();
            _stayR._range.Add(14);
            _stayR._isLoop = false;
            if (this.Direction == 1)
            {
                _aniPlayer.PlayKey(_stayL);
            }
            else
                _aniPlayer.PlayKey(_stayR);
        }

        public override void Update(double deltaTime, Microsoft.DirectX.DirectInput.KeyboardState keyState, Microsoft.DirectX.DirectInput.MouseState mouseState)
        {
            base.Update(deltaTime, keyState, mouseState);
            _aniPlayer.Update((float)deltaTime);
            Move(keyState);

        }

        public override void Move(KeyboardState keyState)
        {
            //throw new NotImplementedException();
            //this._direction = direction;
            
            if (Direction == -1 && !isStop)
            {
                PositionX = PositionX - MoveSpeed;

                _aniPlayer.PlayKey(_moveL);
            }
            if (Direction == 1 && !isStop)
            {
                PositionX = PositionX + MoveSpeed;
                _aniPlayer.PlayKey(_moveR);
            }
            if (isStop)
            {
                PositionX = PositionX;
                if (Direction == 1)                
                    _aniPlayer.PlayKey(_stayL);
                if (Direction == -1)
                    _aniPlayer.PlayKey(_stayR);
            }
        }
        public override void Attack(double deltaTime, KeyboardState keyState)
        {
            base.Attack(deltaTime,keyState);
        }

        public override void BeAttacked(int damages)
        {
            base.BeAttacked(damages);
            
            if(this.Direction == 1)
                this.positionX -= 20;
            else
                this.positionX += 20;
        }

        public override void Draw(int x, int y, Surface surface)
        {
            base.Draw(x,y,surface);
            _aniPlayer.Draw(x, y, surface);
        }
    }
}
