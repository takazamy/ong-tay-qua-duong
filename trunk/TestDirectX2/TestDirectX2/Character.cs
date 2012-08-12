using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectInput;

namespace TestDirectX2
{
    public class Character
    {
        //protected DxInitSprite _image;
        protected DxInitSprite _sprite = null;
        protected int _hp = 100;
        protected int _damage = 10;
        protected int _power = 100;
        protected float positionX = 0;
        protected float positionY = 0;
        protected KeyboardState _keyState = null;
        protected MouseState _mouseState = null;
        protected float _moveSpeed = 1;
        private float x;
        private float y;
        private int damage;
        private int power;
        private float moveSpeed;
        private DxInitSprite sprite;

        public Character(float x, float y, int hp, int damage, int power , float moveSpeed, DxInitSprite sprite)
        {
            positionX = x;
            positionY = y;
            _hp = hp;
            _damage = damage;
            _power = power;
            _sprite = sprite;
            _moveSpeed = moveSpeed;
        }

        public Character() { }

        public Character(float x, float y, int damage, int power, float moveSpeed, DxInitSprite sprite)
        {
            // TODO: Complete member initialization
            this.x = x;
            this.y = y;
            this.damage = damage;
            this.power = power;
            this.moveSpeed = moveSpeed;
            this.sprite = sprite;
        }

        public virtual void Move(KeyboardState keyState)
        { }

        public virtual void Attack()
        { }

        public virtual void Update(double deltaTime, KeyboardState keyState, MouseState mouseState) 
        {
            _keyState = keyState;
            _mouseState = mouseState;
            
        }

        public virtual void Draw(double deltaTime) {
        
        }
        
    }

   
    
}
