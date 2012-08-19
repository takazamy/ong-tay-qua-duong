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
        public static Player _player;
        public static Camera _camera;
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
            
            _player = new Player(20,300,100,100,100,10,new Core.DxInitSprite("Assets/walk.png",_graphics.GraphicsDevice,80,150),1);
            _scrManager.Append(new SplashScreen(_scrManager, _graphics, Point.Empty,
              new Size(800, 600),
              5000));
            _scrManager.Append(new MenuScreen(_scrManager,_graphics,Point.Empty,
                 new Size(800, 600)));
            
            _scrManager.Append(new LevelScreen(_scrManager, _graphics, Point.Empty, new Size(800, 600),_player)); 
            _scrManager.Append(new InstructionScreen(_scrManager,_graphics,Point.Empty,new Size(800,600) ) );
            _scrManager.Append(new CreditScreen(_scrManager, _graphics, Point.Empty, new Size(800, 600)));
            string s = "Assets/level01.xml";
            _scrManager.Append(new MainGameScreen(_scrManager, _graphics, Point.Empty, new Size(800, 600), new Core.DxInitImage("Assets/map1.png", _graphics.GraphicsDevice),s,_player));
            _scrManager.Append(new EndGameScreen(_scrManager, _graphics, Point.Empty, new Size(800, 600)));

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
