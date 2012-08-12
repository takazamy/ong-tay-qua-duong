using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TestDirectX2
{
    public class Player:Character
    {
        public override void Update(double deltaTime, Microsoft.DirectX.DirectInput.KeyboardState keyState, Microsoft.DirectX.DirectInput.MouseState mouseState)
        {
            base.Update(deltaTime, keyState, mouseState);
        }
        public override void Move(Microsoft.DirectX.DirectInput.KeyboardState keyState)
        {
            base.Move(keyState);
        }
    }
}
