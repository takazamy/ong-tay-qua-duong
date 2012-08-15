using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2
{
    public class Character
    {
        //protected DxInitSprite _image;
        protected DxInitSprite _sprite = null;
        private DxAnimation _animation;
        protected int _hp = 100;
        protected int _damage = 10;
        protected int _power = 100;

        private float positionX = 0;

        public float PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
        private float positionY = 0;

        public float PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }
        protected KeyboardState _keyState;
        protected MouseState _mouseState;

     

        protected float _moveSpeed = 1;

        private bool _visible = false;
        protected int _direction = 1;
        private float x;
        private float y;
        private int damage;
        private int power;
        private float moveSpeed;
        private DxInitSprite sprite;
        protected int _direction;
        private int direction;



     

        public Character(float x, float y, int hp, int damage, int power , float moveSpeed, DxInitSprite sprite,int direction)
        {
            positionX = x;
            positionY = y;
            _hp = hp;
            _damage = damage;
            _power = power;
            _sprite = sprite;
            _moveSpeed = moveSpeed;

            _direction = direction;
            _animation = new DxAnimation(_sprite, 40f, false);

            _direction = direction;

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

        public Character(float x, float y, int damage, int power, float moveSpeed, DxInitSprite sprite, int direction)
        {
            // TODO: Complete member initialization
            this.x = x;
            this.y = y;
            this.damage = damage;
            this.power = power;
            this.moveSpeed = moveSpeed;
            this.sprite = sprite;
            this.direction = direction;
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

        public virtual void Draw(int x,int y,Surface surface) {
            _animation.Draw(x, y, surface);
        }
        
    }

    
}
