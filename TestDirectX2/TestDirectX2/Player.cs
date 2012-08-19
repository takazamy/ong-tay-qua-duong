using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDirectX2.Core;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX.DirectDraw;
using TestDirectX2.Screen;


namespace TestDirectX2
{

    public class Player:Character
    {
        AnimationKey _move;
       
        public Player(float x, float y, int hp, int damage, int power, int moveSpeed, DxInitSprite sprite,int direction):
            base(x,y,hp,damage,power,moveSpeed,sprite,direction)
        {
            
            
        }


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
                    //_state = Status.C_MOVE;
                    PositionX = PositionX - MoveSpeed;
                }

                //on move right

                if (_keyState[Key.D])
                {
                    PositionX = PositionX + MoveSpeed;
                    //_state = Status.C_MOVE;
                }


            }
            //else
            //{
            //    _state = Status.C_STAY;
            //}

        }
        public override void Attack()
        {
            base.Attack();
        }
        public override void Draw(int x, int y, Surface surface)
        {
           base.Draw(x,y,surface);
           Animation.Draw(x, y, surface);
        }
    }
}
