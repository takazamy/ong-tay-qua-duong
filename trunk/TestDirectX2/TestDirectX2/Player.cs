using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectInput;


namespace TestDirectX2
{
    public class Player:Character
    {
        

        public Player(float x, float y, int hp, int damage, int power, float moveSpeed, DxInitSprite sprite,int direction):
            base(x,y,hp,damage,power,moveSpeed,sprite,direction)
        {
            positionX = x;
            positionY = y;
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
                //on escape -> exit
                if (_keyState[Key.A])
                {
                    positionX = positionX - _moveSpeed;
                    
                }
                if (_keyState[Key.D])
                {
                    positionX = positionX + _moveSpeed;

                }
            }
           

        }
        public override void Attack()
        {
            base.Attack();
        }
        public override void Draw(double deltaTime)
        {
            base.Draw(deltaTime);
        }
    }
}
