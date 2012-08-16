using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX.DirectDraw;


namespace TestDirectX2
{
    public class Player:Character
    {

        public Player(float x, float y, int hp, int damage, int power, float moveSpeed, DxInitSprite sprite,int direction):
            base(x,y,hp,damage,power,moveSpeed,sprite,direction)
        {
            PositionX = x;
            PositionY = y;
            _hp = hp;
            _damage = damage;
            _power = power;
            _sprite = sprite;
            _moveSpeed = moveSpeed;
        }

        public Player() { }

        public override void Update(double deltaTime, Microsoft.DirectX.DirectInput.KeyboardState keyState, Microsoft.DirectX.DirectInput.MouseState mouseState)
        {
            base.Update(deltaTime, keyState, mouseState);
            Move(keyState);

        }
        public override void Move(Microsoft.DirectX.DirectInput.KeyboardState keyState)
        {
            base.Move(keyState);
            if (_keyState != null)
            {
                //on move left
                if (_keyState[Key.A])
                {
                    PositionX = PositionX - _moveSpeed;
                }

                //on move right

                if (_keyState[Key.D])
                {
                    PositionX = PositionX + _moveSpeed;

                }
            }
            else 
            { }

        }
        public override void Attack()
        {
            base.Attack();
        }
        public override void Draw(int x, int y, Surface surface)
        {
           base.Draw(x,y,surface);
           _animation.Draw(x, y, surface);
        }
    }
}
