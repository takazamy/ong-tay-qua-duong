using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX.DirectDraw;
using Microsoft.DirectX.DirectInput;
using System.Windows.Forms;

namespace TestDirectX2.Core
{
    public delegate void Action();
    public class DxButton:DxInitSprite
    {
        public enum ButtonState
        {
            BS_NORMAL = 0,
            BS_HOLD = 1,
        }

        private ButtonState _state;

        public ButtonState State
        {
            get { return _state; }
            set { _state = value; }
        }

        private Rectangle _bounding;

        public Rectangle Bounding
        {
            get { return _bounding; }
            
        }

        private byte[] _buttons;

        private Action onMouseDown = null;

        public Action OnMouseDown
        {
            
            set { onMouseDown = value; }
        }

        private Action onDrag = null;

        public Action OnDrag
        {
            
            set { onDrag = value; }
        }

        private Action onMouseUp = null;
        public Action OnMouseUp
        {
            set { onMouseUp = value; }
        }

        private int _x;
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public DxButton(int x, int y, string imgPath,Microsoft.DirectX.DirectDraw.Device graphicsDevice, int frameWidth, int frameHeight)
            :
            base(imgPath, graphicsDevice, frameWidth, frameHeight)
        {
            this._x = x;
            this._y = y;
            _state = ButtonState.BS_NORMAL;
            _bounding = new Rectangle(x, y, base._framewidth, base._frameheight);
        }

        public DxButton(int x, int y, DxInitSprite sprite)
            :
            base(sprite.ImagePath, sprite.GraphicDevice, sprite.Framewidth, sprite.Frameheight)
        {
            this._x = x;
            this._y = y;
            _state = ButtonState.BS_NORMAL;
            _bounding = new Rectangle(x, y, base._framewidth, base._frameheight);
        }

        public virtual void Update(float deltaTime, MouseState state)
        {
            _buttons = state.GetMouseButtons();
            //Left Button Click
            if (_buttons[0] != 0)
            {
                //Check if Collision
                if (_bounding.Contains(Cursor.Position))
                {
                    //MouseDown
                    if (_state == ButtonState.BS_NORMAL)
                    {
                        _state = ButtonState.BS_HOLD;
                        if (onMouseDown != null)
                        {
                            onMouseDown();
                        }
                    }
                    //Mouse move

                    else
                    {
                        if (_state == ButtonState.BS_HOLD)
                        {
                            if (onDrag != null)
                            {
                                onDrag();
                            }
                        }
                    }
                }
            }
            else
            {
                if (_state == ButtonState.BS_HOLD)
                {
                    _state = ButtonState.BS_NORMAL;
                    if (onMouseUp != null)
                    {
                        onMouseUp();
                    }
                }
            }
        }

        public void DrawFast(Surface destSurface, DrawFastFlags flags)
        {
            base.DrawFast(this._x, this._y, (int)_state + 1, destSurface, flags);
        }

    }
}
