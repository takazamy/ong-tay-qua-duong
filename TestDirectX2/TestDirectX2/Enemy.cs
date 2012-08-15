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
        public Enemy(float x, float y, int hp, int damage, int power, float moveSpeed, DxInitSprite sprite, int direction) :
            base(x, y, hp,damage, power, moveSpeed, sprite, direction)
        {
           
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

            if (_direction == -1)
            {
                PositionX = PositionX - _moveSpeed; 
            }
            if (_direction == 1)
            {
                PositionX = PositionX + _moveSpeed;
            }
            if (_direction == 0)
            {
                PositionX = PositionX;
            }

        }
        public override void Attack()
        {
            base.Attack();
        }
        public override void Draw(int x, int y, Surface surface)
        {
            base.Draw(x,y,surface);
        }
    }
}
