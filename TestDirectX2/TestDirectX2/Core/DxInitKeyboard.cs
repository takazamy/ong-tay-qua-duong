using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;
using System.Windows.Forms;


namespace TestDirectX2.Core
{
    class DxInitKeyboard
    {
        Device _keyboardDevice = null;
        Control _parent;

        public DxInitKeyboard(Control parent)
        {
            this._parent = parent;

            _keyboardDevice = new Device(SystemGuid.Keyboard);

            _keyboardDevice.SetCooperativeLevel(this._parent,
                CooperativeLevelFlags.Foreground |
                CooperativeLevelFlags.NonExclusive |
                CooperativeLevelFlags.NoWindowsKey);

            _keyboardDevice.SetDataFormat(DeviceDataFormat.Keyboard);
        }

        private KeyboardState _state;

        public KeyboardState State
        {
            get 
            {
                do
                {
                    try
                    {
                        _state = _keyboardDevice.GetCurrentKeyboardState();
                        break;
                    }
                    catch (InputException)
                    {
                        try
                        {
                            Application.DoEvents();
                            _keyboardDevice.Acquire();
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
