using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.DirectX.DirectInput;
using TestDirectX2.Screen;

namespace TestDirectX2
{
    public class GameManager
    {
        

        private DxInitGraphics _graphics;
        private Control _renderTarget;

        public Control RenderTarget
        {
            get { return _renderTarget; }
            set { _renderTarget = value; }
        }

        public DxInitGraphics Graphics
        {
            get { return _graphics; }
            set { _graphics = value; }
        }

        public ScreenManager _scrManager;      

        public GameManager(Control parent,DxInitGraphics graphics )
        {
            _renderTarget = parent;
            _graphics = graphics;
            _scrManager = new ScreenManager();
            Initialized();
           
            _scrManager.PlayScreen(0);
        }

        public void Initialized()
        {
            _scrManager.Append(new SplashScreen(_scrManager, _graphics, Point.Empty,
              new Size(800, 600),
              5000));
            _scrManager.Append(new MenuScreen(_scrManager,_graphics,Point.Empty,
                 new Size(800, 600)));
            _scrManager.Append(new MainGameScreen(_scrManager, _graphics, Point.Empty,
                 new Size(800, 600), new Core.DxInitImage("Assets/map1.png",_graphics.GraphicsDevice)));
        }
        public void Update(double deltaTime, KeyboardState keyState, MouseState mouseState)
        {
            _scrManager.Update(deltaTime, keyState, mouseState);
        }

        public void Draw(DxInitGraphics graphics, double deltaTime)
        {
            _scrManager.Draw(graphics, deltaTime);
        }
    }
}
