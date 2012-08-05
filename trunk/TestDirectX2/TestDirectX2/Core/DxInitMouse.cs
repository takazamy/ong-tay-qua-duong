using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;
using System.Windows.Forms;

namespace TestDirectX2.Core
{
   public  class DxInitMouse
    { Device _mice = null;
        Control _parent;

        public DxInitMouse(Control parent)
        {
            this._parent = parent;

            _mice = new Device(SystemGuid.Mouse);

            _mice.SetCooperativeLevel(this._parent,
                CooperativeLevelFlags.Foreground |
                CooperativeLevelFlags.NonExclusive |
                CooperativeLevelFlags.NoWindowsKey);

            _mice.SetDataFormat(DeviceDataFormat.Mouse);
        }

        private MouseState _state;
        public MouseState State
        {
            get
            {
                do
                {
                    try
                    {
                        _state = _mice.CurrentMouseState;

                        break;
                    }
                    catch (InputException)
                    {
                        try
                        {
                            Application.DoEvents();
                            _mice.Acquire();
                        }
                        catch (InputLostException)
                        {
                            continue;
                        }
                        catch (OtherApplicationHasPriorityException)
                        {
                            continue;
                        }
                    }
                } while (true);

                return _state;
            }
        }

    }
}
