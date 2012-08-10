using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;

namespace TestDirectX2
{
    public class Character
    {
        protected DxInitSprite _image;
        protected int _hp;
        protected int _damage;
        protected int _power;

        public Character(int hp)
        { hp = _hp; }
        public Character(int damage)
        { damage = _damage; }
        public Character(int power)
        { power = _power; }
        public Character(DxInitSprite image)
        { image = _image; }

        public virtual void Move()
        { }
        public virtual void Attack()
        { }
    }
   
    
}
