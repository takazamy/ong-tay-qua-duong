using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX.DirectDraw;
using System.Drawing;

namespace TestDirectX2
{
    public class AnimationKey
    {
        public List<int> _range;
        public bool _isLoop;
    }

    public class Character
    {
        //protected DxInitSprite _image;
        #region Properties
        protected DxInitSprite _sprite = null;

        public DxInitSprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        protected AnimationPlayer _aniPlayer;
        public AnimationPlayer AniPlayer
        {
            get { return _aniPlayer; }
            set { _aniPlayer = value; }
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

        protected Rectangle _bound;

        public Rectangle Bound
        {
            get { return _bound; }
            set { _bound = value; }
        } 

        protected double _atkTime = 500;
        public Boolean _isInAtt = false;
        protected Boolean _startTimerCount = false;
        protected Boolean _onAttackKeyPress = false;
        protected Boolean _isBeAttacked = false;
        protected double _deActiveTime = 500;
        protected double _deActiveTimer = 0;
        #endregion

        public Character(float x, float y, int hp, int damage, int power , int moveSpeed, DxInitSprite sprite,int direction)
        {
            positionX = x;
            positionY = y;
            _hp = hp;
            _damage = damage;
            _power = power;
            _sprite = sprite;
            _moveSpeed = moveSpeed;
            _bound = new Rectangle((int)x,(int) y, sprite.Framewidth,sprite.Frameheight);
            _direction = direction;
            DxAnimation animation = new DxAnimation(_sprite, 100f, true);

            _aniPlayer = new AnimationPlayer();
            _aniPlayer.Play(animation);

            _direction = direction;

        }

        public Boolean CheckKeyDown(KeyboardState keyState)
        {
            Boolean _keyDown = false;
            for (int i = 0; i < 256; i++)
            {
                if (_keyState[(Key)i])
                {
                    _keyDown = true;
                }
            }
            return _keyDown;
        }

        public virtual void Move(KeyboardState keyState)
        { }

        public virtual void Attack(double deltaTime,KeyboardState keyState)
        { }

        public virtual void BeAttacked(int damages)
        {
            if (!_isBeAttacked)
            {
                _hp -= damages; 
            } 
            _isBeAttacked = true;

        }

        public virtual void Update(double deltaTime, KeyboardState keyState, MouseState mouseState) 
        {
            _keyState = keyState;
            _mouseState = mouseState;

            _bound.X =(int) this.positionX;
            _bound.Y = (int)this.positionY;

            if (_isBeAttacked)
            {
                _deActiveTimer += deltaTime;
                if (_deActiveTimer >= _deActiveTime)
                {
                    _isBeAttacked = false;
                    _deActiveTimer = 0;
                }
            }
        }

        public virtual void Draw(int x,int y,Surface surface) {
            _aniPlayer.Draw(x, y, surface);
        }
        
    }

    
}
