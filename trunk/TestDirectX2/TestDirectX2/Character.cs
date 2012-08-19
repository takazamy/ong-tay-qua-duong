using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX.DirectDraw;

namespace TestDirectX2
{
    public struct AnimationKey
    {
        public int _length;
       // int[] range = new int[x];
       public int[] _range;
        //public AnimationKey(int[] _range, int length)
        //{
        //    _length = length;
        //    _range = new int[_length];
        //}
    }
    public class Character
    {
        //protected DxInitSprite _image;
        protected DxInitSprite _sprite = null;

        public DxInitSprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }
        protected DxAnimation _animation;

        public DxAnimation Animation
        {
            get { return _animation; }
            set { _animation = value; }
        }
        protected int _hp = 100;

        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        protected int _damage = 10;

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        protected int _power = 100;

        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }
        protected float positionX = 0;

        public float PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
        protected float positionY = 0;

        public float PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }
        protected KeyboardState _keyState;
        protected MouseState _mouseState;
        protected int _moveSpeed = 1;

        public int MoveSpeed
        {
            get { return _moveSpeed; }
            set { _moveSpeed = value; }
        }
        public enum Status
        {
            C_STAY = 0,
            C_MOVE =1,
            C_ATTACK=2,
            C_DIE = 3
        }
        protected int _direction = 1;

        public int Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        protected Status _state = Status.C_STAY;

        public Status State
        {
            get { return _state; }
            set { _state = value; }
        }

        public Character(float x, float y, int hp, int damage, int power , int moveSpeed, DxInitSprite sprite,int direction)
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
