using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;

namespace TestDirectX2
{
    public class Enemy:Character
    {
        public Enemy(float x, float y, int hp, int damage, int power, float moveSpeed, DxInitSprite sprite, int direction) :
            base(x, y, damage, power, moveSpeed, sprite, direction)
        {
            positionX = x;
            positionY = y;
            _hp = hp;
            _damage = damage;
            _power = power;
            _sprite = sprite;
            _moveSpeed = moveSpeed;
            _direction = direction;
        }


        public override void Move(Microsoft.DirectX.DirectInput.KeyboardState keyState)
        {
            base.Move(keyState);

        }
        public override void Update(double deltaTime, Microsoft.DirectX.DirectInput.KeyboardState keyState, Microsoft.DirectX.DirectInput.MouseState mouseState)
        {
            base.Update(deltaTime, keyState, mouseState);
            Move(_direction);
        }

        private void Move(int direction)
        {
            throw new NotImplementedException();
            this._direction = direction;
            if (_direction == -1)
            {
                positionX = positionX - _moveSpeed; 
            }
            if (_direction == 1)
            {
                positionX = positionX + _moveSpeed;
            }
            if (_direction == 0)
            {
                positionX = positionX;
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
